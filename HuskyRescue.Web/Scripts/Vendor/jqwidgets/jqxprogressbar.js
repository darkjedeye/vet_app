/*
jQWidgets v3.0.3 (2013-Oct-01)
Copyright (c) 2011-2013 jQWidgets.
License: http://jqwidgets.com/license/
*/

(function (a) {
	a.jqx.jqxWidget("jqxProgressBar", "", {});
	a.extend(a.jqx._jqxProgressBar.prototype, {
		defineInstance: function () {
			this.value = 0;
			this.oldValue = null;
			this.max = 100;
			this.min = 0;
			this.orientation = "horizontal";
			this.layout = "normal";
			this.width = null;
			this.height = null;
			this.showText = false;
			this.animationDuration = 300;
			this.disabled = false;
			this.rtl = false;
			this.renderText = null;
			this.aria = {
				"aria-valuenow": {
					name: "value",
					type: "number"
				},
				"aria-disabled": {
					name: "disabled",
					type: "boolean"
				}
			};
			this.events = ["valuechanged", "invalidvalue", "complete"]
		},
		createInstance: function (c) {
			var b = this;
			this.host.addClass(this.toThemeProperty("jqx-progressbar"));
			this.host.addClass(this.toThemeProperty("jqx-widget"));
			this.host.addClass(this.toThemeProperty("jqx-widget-content"));
			this.host.addClass(this.toThemeProperty("jqx-rc-all"));
			a.jqx.aria(this);
			if (this.width != null && this.width.toString().indexOf("px") != -1) {
				this.host.width(this.width)
			} else {
				if (this.width != undefined && !isNaN(this.width)) {
					this.host.width(this.width)
				} else {
					this.host.width(this.width)
				}
			} if (this.height != null && this.height.toString().indexOf("px") != -1) {
				this.host.height(this.height)
			} else {
				if (this.height != undefined && !isNaN(this.height)) {
					this.host.height(this.height)
				} else {
					this.host.height(this.height)
				}
			}
			this.valueDiv = a("<div></div>").appendTo(this.element);
			if (this.orientation == "horizontal") {
				this.valueDiv.width(0);
				this.valueDiv.addClass(this.toThemeProperty("jqx-progressbar-value"))
			} else {
				this.valueDiv.height(0);
				this.valueDiv.addClass(this.toThemeProperty("jqx-progressbar-value-vertical"))
			}
			this.valueDiv.addClass(this.toThemeProperty("jqx-fill-state-pressed"));
			this.feedbackElementHost = a("<div style='width: 100%; height: 100%; position: relative;'></div>").appendTo(this.host);
			this.feedbackElement = a("<span class='text'></span>").appendTo(this.feedbackElementHost);
			this.feedbackElement.addClass(this.toThemeProperty("jqx-progressbar-text"));
			this.oldValue = this._value();
			this.refresh();
			a.jqx.utilities.resize(this.host, function () {
				b.refresh()
			})
		},
		destroy: function () {
			this.host.removeClass();
			this.valueDiv.removeClass();
			this.valueDiv.remove();
			this.feedbackElement.remove()
		},
		_raiseevent: function (g, d, f) {
			if (this.isInitialized != undefined && this.isInitialized == true) {
				var c = this.events[g];
				var e = new jQuery.Event(c);
				e.previousValue = d;
				e.currentValue = f;
				e.owner = this;
				var b = this.host.trigger(e);
				return b
			}
		},
		actualValue: function (b) {
			if (b === undefined) {
				return this._value()
			}
			a.jqx.aria(this, "aria-valuenow", b);
			a.jqx.setvalueraiseevent(this, "value", b);
			return this._value()
		},
		val: function (b) {
			if (arguments.length == 0 || typeof (b) == "object") {
				return this.actualValue()
			}
			return this.actualValue(b)
		},
		propertyChangedHandler: function (c, d, b, f) {
			if (!this.isInitialized) {
				return
			}
			var e = this;
			if (d == "min" && c.value < f) {
				c.value = f
			} else {
				if (d == "max" && c.value > f) {
					c.value = f
				}
			} if (d === "value" && e.value != undefined) {
				e.value = f;
				e.oldValue = b;
				a.jqx.aria(c, "aria-valuenow", f);
				if (f < e.min || f > e.max) {
					e._raiseevent(1, b, f)
				}
				e.refresh()
			}
			if (d == "theme") {
				a.jqx.utilities.setTheme(b, f, c.host)
			}
			if (d == "renderText" || d == "orientation" || d == "layout" || d == "showText" || d == "min" || d == "max") {
				e.refresh()
			} else {
				if (d == "width" && e.width != undefined) {
					if (e.width != undefined && !isNaN(e.width)) {
						e.host.width(e.width);
						e.refresh()
					}
				} else {
					if (d == "height" && e.height != undefined) {
						if (e.height != undefined && !isNaN(e.height)) {
							e.host.height(e.height);
							e.refresh()
						}
					}
				}
			} if (d == "disabled") {
				e.refresh()
			}
		},
		_value: function () {
			var c = this.value;
			if (typeof c !== "number") {
				var b = parseInt(c);
				if (isNaN(b)) {
					c = 0
				} else {
					c = b
				}
			}
			return Math.min(this.max, Math.max(this.min, c))
		},
		_percentage: function () {
			return 100 * this._value() / this.max
		},
		_textwidth: function (d) {
			var c = a("<span>" + d + "</span>");
			a(this.host).append(c);
			var b = c.width();
			c.remove();
			return b
		},
		_textheight: function (d) {
			var c = a("<span>" + d + "</span>");
			a(this.host).append(c);
			var b = c.height();
			c.remove();
			return b
		},
		_initialRender: true,
		refresh: function () {
			var l = this.actualValue();
			var p = this._percentage();
			if (this.disabled) {
				this.host.addClass(this.toThemeProperty("jqx-progressbar-disabled"));
				this.host.addClass(this.toThemeProperty("jqx-fill-state-disabled"));
				return
			} else {
				this.host.removeClass(this.toThemeProperty("jqx-progressbar-disabled"));
				this.host.removeClass(this.toThemeProperty("jqx-fill-state-disabled"));
				a(this.element.children[0]).show()
			} if (isNaN(l)) {
				return
			}
			if (isNaN(p)) {
				return
			}
			if (this.oldValue !== l) {
				this._raiseevent(0, this.oldValue, l);
				this.oldValue = l
			}
			var b = this.oldValue;
			var n = this.host.outerHeight();
			var c = this.host.outerWidth();
			if (this.width != null) {
				c = parseInt(this.width)
			}
			if (this.height != null) {
				n = parseInt(this.height)
			}
			var f = parseInt(this.host.outerWidth()) / 2;
			var i = parseInt(this.host.outerHeight()) / 2;
			if (isNaN(p)) {
				p = 0
			}
			var j = this;
			try {
				var m = this.element.children[0];
				a(m)[0].style.position = "relative";
				if (this.orientation == "horizontal") {
					a(m).toggle(l >= this.min);
					var c = this.host.outerWidth() * p / 100;
					var e = 0;
					if (this.layout == "reverse" || this.rtl) {
						if (this._initialRender) {
							a(m)[0].style.left = this.host.width() + "px";
							a(m)[0].style.width = 0
						}
						e = this.host.outerWidth() - c
					}
					a(m).animate({
						width: c,
						left: e + "px"
					}, this.animationDuration, function () {
						if (j._value() === j.max) {
							j._raiseevent(2, b, j.max)
						}
					});
					this.feedbackElementHost.css("margin-top", -this.host.height())
				} else {
					a(m).toggle(l >= this.min);
					var n = this.host.height() * p / 100;
					var d = 0;
					if (this.layout == "reverse") {
						if (this._initialRender) {
							a(m)[0].style.top = this.host.height() + "px";
							a(m)[0].style.height = 0
						}
						d = this.host.height() - n
					}
					this.feedbackElementHost.animate({
						"margin-top": -(p.toFixed(0) * j.host.height()) / 100
					}, this.animationDuration, function () { });
					a(m).animate({
						height: n,
						top: d + "px"
					}, this.animationDuration, function () {
						var q = j._percentage();
						if (isNaN(q)) {
							q = 0
						}
						if (q.toFixed(0) == j.min) {
							a(m).hide();
							if (j._value() === j.max) {
								j._raiseevent(2, b, j.max)
							}
						}
					})
				}
			} catch (h) { }
			this._initialRender = false;
			this.feedbackElement.html(p.toFixed(0) + "%").toggle(this.showText == true);
			if (this.renderText) {
				this.feedbackElement.html(this.renderText(p.toFixed(0) + "%"))
			}
			this.feedbackElement.css("position", "absolute");
			this.feedbackElement.css("top", "50%");
			this.feedbackElement.css("left", "0");
			var k = this.feedbackElement.height();
			var g = this.feedbackElement.width();
			var o = Math.floor(f - (parseInt(g) / 2));
			this.feedbackElement.css({
				left: (o),
				"margin-top": -parseInt(k) / 2 + "px"
			})
		}
	})
})(jQuery);