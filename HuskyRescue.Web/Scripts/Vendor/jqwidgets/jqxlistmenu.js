/*
jQWidgets v3.0.3 (2013-Oct-01)
Copyright (c) 2011-2013 jQWidgets.
License: http://jqwidgets.com/license/
*/

(function (c) {
	c.jqx.jqxWidget("jqxListMenu", "", {});
	var a = 0,
		b = 0;
	c.extend(c.jqx._jqxListMenu.prototype, {
		defineInstance: function () {
			this.filterCallback = function (f, e) {
				var d = c.jqx.string.containsIgnoreCase(c.trim(f), e);
				return d
			};
			this.placeHolder = "Filter list items...";
			this.showFilter = false;
			this.showHeader = true;
			this.showBackButton = true;
			this.showNavigationArrows = true;
			this.alwaysShowNavigationArrows = false;
			this.backLabel = "Back";
			this.width = "100%";
			this.height = "auto";
			this.animationType = "slide";
			this.animationDuration = 0;
			this.headerAnimationDuration = 0;
			this.autoSeparators = false;
			this.readOnly = false;
			this.roundedCorners = true;
			this.disabled = false;
			this.enableScrolling = true;
			this.touchMode = false;
			this._childrenMap = {};
			this._parentMap = {};
			this._lock = false;
			this._backButton = null;
			this._currentPage = null;
			this._header = null;
			this._oldHost;
			this.rtl = false;
			this.aria = {
				"aria-disabled": {
					name: "disabled",
					type: "boolean"
				}
			}
		},
		destroy: function () {
			this.host.remove()
		},
		createInstance: function () {
			c.jqx.aria(this);
			this.host.attr("data-role", "listmenu");
			this.host.attr("role", "tree")
		},
		refresh: function (d) {
			this._render();
			this._removeClasses();
			this._addClasses();
			this._currentPage = this._currentPage || this.host.children(".jqx-listmenu").first();
			this._changeHeader(this._currentPage);
			this._removeEventHandlers();
			this._addEventHandlers()
		},
		_render: function () {
			this._renderHost();
			this._renderAutoSeparators();
			this._renderSublists();
			this._renderFilterBar();
			this._renderHeader();
			this.host.css({
				width: this.width,
				height: this.height
			});
			if (this.disabled) {
				this.disable()
			}
			if (this.enableScrolling && this.host.jqxPanel && this.panel) {
				this.panel.jqxPanel("_arrange")
			}
		},
		_renderHost: function () {
			if (!this.host.is("div")) {
				this._oldHost = this.host;
				this.host.wrap("<div/>");
				this.host = this.host.parent();
				this.element = this.host[0];
				if (this.host.jqxPanel && this.enableScrolling) {
					this.host.wrap("<div/>");
					this.panel = this.host.parent();
					this.panel[0].id = "panel" + this.element.id;
					this.panel.jqxPanel({
						theme: this.theme,
						autoUpdate: true,
						width: this.width,
						height: this.height,
						touchMode: this.touchMode
					});
					this.host.css({
						width: "100%"
					});
					this.host.css({
						height: "auto"
					});
					this.host.css("border", "none")
				}
			} else {
				this.element.style.overflow = "hidden"
			} if (!this.enableScrolling) {
				this.element.style.overflow = "hidden"
			}
			if (c.jqx.browser.msie && c.jqx.browser.version < 8) {
				this.element.style.position = "relative"
			}
			if (this.enableScrolling && this.panel) {
				this.panel.jqxPanel("_arrange")
			}
		},
		_renderAutoSeparators: function (g) {
			var f = this.host.find(".jqx-listmenu-auto-separator"),
				d = this.host.find('[data-role="listmenu"]'),
				g, e;
			f.remove();
			for (e = 0; e < d.length; e += 1) {
				g = c(d[e]);
				if (g.data("auto-separators") || this.autoSeparators) {
					this._renderListAutoSeparators(g)
				}
			}
		},
		_renderSublists: function () {
			var e = [(this.host.find(".jqx-listmenu").first()[0] || this.host.find("ul,ol").first()[0])],
				g, d, k, f, j;
			this._refreshList(e[0]);
			while (e.length) {
				k = e.pop();
				g = this._getChildrenByTagName(k, "li", "LI");
				f = g.length;
				for (var h = 0; h < f; h += 1) {
					d = g[h];
					c(d).attr("role", "treeitem");
					j = this._getChildList(d);
					this._refreshLi(d, h, f);
					if (j) {
						e.push(j);
						this._refreshList(j, d, true)
					}
				}
			}
		},
		_refreshList: function (f, e, d) {
			f = c(f);
			if (f.data("role") === "listmenu") {
				if (!f.is(".jqx-listmenu")) {
					this._renderList(f);
					this._handleListId(f);
					this._addListClasses(f)
				}
				if (e) {
					this._expandHierarchy(f[0], e)
				}
				if (d) {
					this._handleSublist(f[0])
				}
			}
		},
		_renderList: function (d) {
			d = c(d);
			if (!d.is(".jqx-listmenu")) {
				d.detach();
				d.appendTo(this.host)
			}
		},
		_handleListId: function (d) {
			if (!d[0].id) {
				d[0].id = "jqx-listmenu-" + b;
				b += 1
			}
		},
		_renderListAutoSeparators: function (h) {
			var e = h.children("li"),
				k, d;
			var j = {};
			for (var g = 0; g < e.length; g += 1) {
				d = c(e[g]);
				if (!d.data("role")) {
					if (c.trim(d.text())[0] !== k) {
						k = c.trim(d.text())[0];
						var f = c('<li data-role="separator" class="' + this.toThemeProperty("jqx-listmenu-auto-separator") + '">' + k + "</li>");
						f.insertBefore(d);
						f[0].items = new Array();
						j = f[0]
					}
					if (j.items) {
						j.items[j.items.length] = d[0]
					}
				}
			}
		},
		_addListClasses: function (d) {
			d.addClass("jqx-listmenu")
		},
		_expandHierarchy: function (g, f) {
			if (f && g) {
				var e = f.id,
					d = g.id;
				this._childrenMap[e] = d;
				this._parentMap[d] = e
			}
		},
		_handleSublist: function (d) {
			if (!this._currentPage || d !== this._currentPage[0]) {
				d.style.display = "none"
			} else {
				d.style.display = "block"
			}
		},
		_getChildrenByTagName: function (f, e, g) {
			var d = [],
				h = {};
			h[e] = h[g] = true;
			f = f.firstChild;
			while (f) {
				if (h[f.nodeName]) {
					d.push(f)
				}
				f = f.nextSibling
			}
			return d
		},
		_renderFilterBar: function () {
			if (!this._filterBar) {
				this._filterBar = c("<div/>");
				this._filterInput = c('<input type="text" />');
				this._filterBar.append(this._filterInput);
				this.host.prepend(this._filterBar)
			}
			var d = false;
			if (c.jqx.browser.msie && c.jqx.browser.version < 8) {
				d = true
			}
			if (!d) {
				this._filterInput.attr("placeholder", this.placeHolder)
			}
			if (!this.showFilter) {
				this._filterBar.css("display", "none")
			} else {
				this._filterBar.css("display", "block")
			}
		},
		_renderHeader: function () {
			if (!this._header) {
				this._header = c("<div/>");
				this.host.prepend(this._header);
				this._renderHeaderLabel()
			}
			this._renderBackButton();
			if (!this.showHeader) {
				this._header.css("display", "none")
			} else {
				this._header.css("display", "block")
			}
		},
		_renderHeaderLabel: function () {
			this._headerLabel = c("<span/>");
			this._headerLabel.addClass(this.toThemeProperty("jqx-listmenu-header-label"));
			this._header.append(this._headerLabel)
		},
		_renderBackButton: function () {
			if (!this._backButton) {
				this._backButton = c('<div><div style="float: left;"></div><span style="float: left;">' + this.backLabel + '</span><div style="clear:both;"></div></div>');
				this._header.prepend(this._backButton);
				this._backButton.jqxButton({
					theme: this.theme
				});
				this._backButton.find("div:first").addClass(this.toThemeProperty("jqx-listmenu-backbutton-arrow"));
				if (!this.showBackButton) {
					this._backButton.css("display", "none")
				} else {
					this._backButton.css("display", "inline-block")
				} if (this.rtl) {
					var d = c.jqx.browser.msie && c.jqx.browser.version < 8;
					if (!d) {
						this._backButton.css("position", "relative");
						this._backButton.css("margin-left", "100%");
						this._backButton.css("left", -this._backButton.outerWidth() - 15)
					} else {
						this._backButton.css("position", "relative");
						this._backButton.css("left", "100%");
						this._backButton.css("margin-left", -this._backButton.outerWidth() - 45 + "px")
					}
				}
			}
			if (!this.showBackButton) {
				this._backButton.css("display", "none")
			} else {
				this._backButton.css("display", "inline-block")
			}
		},
		_removeEventHandlers: function () {
			var d = this.isTouchDevice() && !this.touchMode;
			var e = c.jqx.mobile.getTouchEventName("touchstart");
			this.removeHandler(this._backButton, !d ? "click" : e);
			this.removeHandler(this._filterInput, "keyup");
			this.removeHandler(this._filterInput, "change")
		},
		_addEventHandlers: function () {
			var d = this;
			var e = this.isTouchDevice() && !this.touchMode;
			var f = c.jqx.mobile.getTouchEventName("touchstart");
			this.addHandler(this._backButton, !e ? "click" : f, function () {
				d.back()
			});
			this.addHandler(this._filterInput, "keyup change", function () {
				d._filter(c(this).val())
			})
		},
		_getChildList: function (d) {
			if (!d) {
				return
			}
			var h = this._childrenMap[d.id],
				g;
			if (d.className.indexOf("jqx-listmenu-item") >= 0 && h) {
				return document.getElementById(h)
			}
			var f = this._getChildrenByTagName(d, "ul", "UL")[0],
				e = this._getChildrenByTagName(d, "ol", "OL")[0];
			g = f || e;
			return g
		},
		_refreshLi: function (d, g, f) {
			if (d.parentNode && d.parentNode.getAttribute("data-role") === "listmenu") {
				if (d.id == "") {
					var e = 2
				}
				this._handleLiId(d);
				this._renderLi(d);
				this._removeLiEventHandlers(d);
				this._addLiEventHandlers(d);
				this._addLiClasses(d, g, f)
			}
		},
		_handleLiId: function (d) {
			if (!d.id) {
				d.id = "jqx-listmenu-item-" + a;
				a += 1
			}
		},
		_renderLi: function (d) {
			if ((/(separator|header)/).test(c(d).data("role")) || c(d).children(".jqx-listmenu-arrow-right").length > 0) {
				return
			}
			c(d).wrapInner('<span class="' + this.toThemeProperty("jqx-listmenu-item-label") + '"></span>');
			if (this.showNavigationArrows || this.alwaysShowNavigationArrows) {
				var f = c("<span/>");
				var g = c(d).find("ul");
				var e = c(d).find("ol");
				if (this.alwaysShowNavigationArrows || (((g.length > 0) && (/(listmenu)/).test(g.data("role"))) || ((e.length > 0) && (/(listmenu)/).test(e.data("role"))))) {
					f.addClass(this.toThemeProperty("jqx-listmenu-arrow-right"));
					if (!this.rtl) {
						f.addClass(this.toThemeProperty("jqx-icon-arrow-right"));
						f.appendTo(d)
					} else {
						f.addClass(this.toThemeProperty("jqx-icon-arrow-left"));
						f.addClass(this.toThemeProperty("jqx-listmenu-arrow-rtl"));
						f.prependTo(d)
					}
				}
			}
		},
		_removeLiEventHandlers: function (d) {
			var g = this.isTouchDevice();
			var j = c.jqx.mobile.getTouchEventName("touchstart");
			var i = c.jqx.mobile.getTouchEventName("touchend");
			var e = c.jqx.mobile.getTouchEventName("touchmove");
			var f = (!g ? "mousedown" : j) + ".listmenu";
			var h = (!g ? "mouseup" : i) + ".listmenu";
			this.removeHandler(c(d), f);
			this.removeHandler(c(document), h + "." + d.id)
		},
		isTouchDevice: function () {
			var d = c.jqx.mobile.isTouchDevice();
			if (this.touchMode == true) {
				d = true
			}
			return d
		},
		_addLiEventHandlers: function (m) {
			m = c(m);
			var o = this,
				f = this.toThemeProperty("jqx-listmenu-arrow-right-pressed"),
				k = m.children(".jqx-listmenu-arrow-right");
			var d = o.isTouchDevice() && !this.touchMode;
			var j = c.jqx.mobile.getTouchEventName("touchstart");
			var l = c.jqx.mobile.getTouchEventName("touchstart");
			var g = c.jqx.mobile.getTouchEventName("touchmove");
			var h = (!d ? "mousedown" : j) + ".listmenu";
			var e = (!d ? "mouseup" : l) + ".listmenu";
			var n = null;
			var i = "";
			if (!(/(separator|readonly)/).test(m.data("role")) && !this.readOnly) {
				this.addHandler(m, "dragstart", function () {
					return false
				});
				this.addHandler(m, h, function (p) {
					if (!o.disabled) {
						n = p.target;
						i = c.jqx.position(p);
						if (m.find('div[data-role="content"]').length == 0) {
							m.addClass(o.toThemeProperty("jqx-fill-state-pressed"));
							k.addClass(f)
						}
					}
				});
				this.addHandler(m, e, function (p) {
					if (!o.disabled) {
						if (n == p.target || !d) {
							if (d) {
								if (c.jqx.position(p).top === i.top) {
									o.next(m)
								}
							} else {
								if (c.jqx.position(p).top === i.top) {
									o.next(m)
								}
							}
						}
					}
				});
				this.addHandler(c(document), e + "." + m[0].id, function () {
					if (!o.disabled) {
						m.removeClass(o.toThemeProperty("jqx-fill-state-pressed"));
						k.removeClass(f)
					}
				})
			}
		},
		_addLiClasses: function (d, f, e) {
			d = c(d);
			if (d.data("role") === "separator") {
				this._handleSeparatorStyle(d)
			} else {
				if (d.data("role") === "header") {
					this._handleHeaderStyle(d)
				} else {
					if (this.readOnly || d.data("role") === "readonly") {
						d.addClass(this.toThemeProperty("jqx-listmenu-item-readonly"))
					} else {
						d.removeClass(this.toThemeProperty("jqx-listmenu-item-readonly"))
					}
					this._handleItemStyle(d)
				}
			} if (f === 0 && !this.showHeader && !this.showFilter) {
				d.addClass(this.toThemeProperty("jqx-rc-t"))
			}
			if (f === e - 1) {
				d.addClass(this.toThemeProperty("jqx-rc-b"))
			}
		},
		_handleSeparatorStyle: function (d) {
			d.addClass(this.toThemeProperty("jqx-listmenu-separator"));
			d.addClass(this.toThemeProperty("jqx-fill-state-pressed"));
			d[0].style.listStyle = "none"
		},
		_handleHeaderStyle: function (d) {
			d.css("display", "none")
		},
		_handleItemStyle: function (d) {
			d.addClass(this.toThemeProperty("jqx-listmenu-item"));
			if (this.rtl) {
				d.addClass(this.toThemeProperty("jqx-rtl"))
			}
			d.addClass(this.toThemeProperty("jqx-fill-state-normal"))
		},
		back: function () {
			var e = this._currentPage,
				d;
			if (e) {
				d = this._parentMap[e[0].id]
			}
			this._back = true;
			if (c("#" + d).length > 0) {
				c.jqx.aria(c("#" + d), "aria-expanded", false)
			}
			this._changePage(e, c("#" + d).parent(), this.animationDuration, true);
			this._back = false
		},
		next: function (d) {
			var h = d.attr("id"),
				f = this._childrenMap[h],
				g = c("#" + f),
				e = c("#" + h).parent();
			c.jqx.aria(d, "aria-expanded", true);
			this._changePage(e, g, this.animationDuration)
		},
		changePage: function (d) {
			if (typeof d === "string") {
				d = c(d)
			}
			if (!d[0] || (d.attr("data-role") !== "listmenu") || d.parents().index(this.host) < 0) {
				throw new Error("Invalid newPage. The chosen newPage is not listmenu or it's not part of the selected jqxListMenu hierarchy.")
			}
			if (this._currentPage[0] == d[0]) {
				return
			}
			this._changePage(this._currentPage, d, this.animationDuration)
		},
		_changePage: function (h, f, g, e) {
			if (!this._lock) {
				var d = "_" + this.animationType + "Change" + (e ? "Back" : "");
				if (f[0]) {
					if (this.showFilter) {
						if (f.find('div[data-role="content"]').length > 0) {
							c.each(f.find("li"), function () {
								if (c(this).data("role") === "separator") {
									c(this).hide()
								}
							});
							this._filterBar.css("display", "none")
						} else {
							this._filterBar.css("display", "block")
						}
					}
					this._lock = true;
					this[d](h, f, this.animationDuration, function () {
						this._lock = false;
						this._changeHeader(f);
						this._currentPage = f
					})
				}
			}
		},
		_changeHeader: function (e) {
			var f = c(e).find('li[data-role="header"]').first();
			if (f[0]) {
				var d = this;
				this._headerLabel.fadeOut(this.headerAnimationDuration / 2, function () {
					d._headerLabel.html(f.html());
					d._headerLabel.fadeIn(d.headerAnimationDuration / 2)
				})
			}
		},
		_slideChange: function (h, e, g, i) {
			var d = this;
			if (this.enableScrolling && this.panel != null) {
				this.panel.jqxPanel("scrollTo", 0, 0)
			}
			var f = this.rtl;
			this._initSlide(h, e);
			if (!f) {
				h.animate({
					"margin-left": -h.width() - parseInt(h.css("margin-right"), 10) || 0
				}, g, "easeInOutSine");
				e.animate({
					"margin-left": 0
				}, g, "easeInOutSine", function () {
					d._slideEnd(h, e);
					i.call(d, c(this))
				})
			} else {
				h.animate({
					"margin-left": h.width() + parseInt(h.css("margin-right"), 10) || 0
				}, g, "easeInOutSine");
				e.animate({
					"margin-left": 0
				}, g, "easeInOutSine", function () {
					d._slideEnd(h, e);
					i.call(d, c(this))
				})
			}
		},
		_initSlide: function (f, d) {
			var e = this.rtl;
			f.width(f.width());
			d.css({
				marginTop: -(f.outerHeight(true)),
				marginLeft: !e ? f.width() + (parseInt(f.css("margin-right"), 10) || 0) : -f.width() - (parseInt(f.css("margin-right"), 10) || 0),
				display: "block",
				height: "auto",
				width: f.width()
			})
		},
		_slideEnd: function (e, d) {
			this.host.css("height", "auto");
			e.css({
				display: "none",
				width: "auto",
				height: "auto",
				marginTop: 0,
				marginLeft: 0
			});
			d.css({
				marginTop: 0,
				marginLeft: 0,
				height: "auto",
				width: "auto",
				display: "block"
			})
		},
		_slideChangeBack: function (g, e, f, h) {
			var d = this;
			this._initSlideBack(g, e);
			g.animate({
				"margin-left": !this.rtl ? g.width() + parseInt(g.css("margin-right"), 10) || 0 : -g.width() - parseInt(g.css("margin-right"), 10) || 0
			}, f);
			e.animate({
				"margin-left": 0
			}, f, function () {
				d._slideEnd(g, e);
				h.call(d, c(this))
			})
		},
		_initSlideBack: function (e, d) {
			e.css({
				marginTop: -(d.outerHeight(true)),
				width: e.width()
			});
			d.css({
				width: e.width(),
				marginLeft: !this.rtl ? -e.width() - parseInt(e.css("margin-right"), 10) || 0 : e.width() + parseInt(e.css("margin-right"), 10) || 0,
				display: "block",
				height: "auto"
			})
		},
		_fadeChangeBack: function (f, d, e, g) {
			this._fadeChange(f, d, e, g)
		},
		_fadeChange: function (g, e, f, h) {
			var d = this;
			g.fadeOut(f / 2, function () {
				e.fadeIn(f / 2, function () {
					h.call(d, c(this))
				})
			})
		},
		_removeClasses: function () {
			this._filterBar.removeClass(this.toThemeProperty("jqx-listmenu-filter"));
			this._filterBar.removeClass(this.toThemeProperty("jqx-widget-header"));
			this._filterInput.removeClass(this.toThemeProperty("jqx-listmenu-filter-input"));
			this._filterInput.removeClass(this.toThemeProperty("jqx-input"));
			this._header.removeClass(this.toThemeProperty("jqx-listmenu-header"));
			this._header.removeClass(this.toThemeProperty("jqx-widget-header"));
			this._header.removeClass(this.toThemeProperty("jqx-rc-t"));
			if (this.roundedCorners) {
				this.host.removeClass(this.toThemeProperty("jqx-rc-all"))
			}
			this.host.removeClass(this.toThemeProperty("jqx-widget"));
			this.host.removeClass(this.toThemeProperty("jqx-listmenu-widget"));
			this.host.removeClass(this.toThemeProperty("jqx-fill-state-normal"));
			this.host.removeClass(this.toThemeProperty("jqx-reset"));
			if (this.host.find('div[data-role="content"]').length > 0) {
				this.host.find('div[data-role="content"]').removeClass(this.toThemeProperty("jqx-widget-content"))
			}
		},
		_addClasses: function () {
			if (this.roundedCorners) {
				this.host.addClass(this.toThemeProperty("jqx-rc-all"))
			} else {
				this.host.removeClass(this.toThemeProperty("jqx-rc-all"))
			}
			this.host.addClass("jqx-widget");
			this.host.addClass("jqx-listmenu-widget");
			this.host.addClass("jqx-fill-state-normal");
			this.host.addClass("jqx-reset");
			this._filterBar.addClass(this.toThemeProperty("jqx-listmenu-filter"));
			this._filterBar.addClass(this.toThemeProperty("jqx-widget-header"));
			this._filterInput.addClass(this.toThemeProperty("jqx-listmenu-filter-input"));
			this._filterInput.addClass(this.toThemeProperty("jqx-input"));
			this._header.addClass(this.toThemeProperty("jqx-listmenu-header"));
			this._header.addClass(this.toThemeProperty("jqx-widget-header"));
			this._header.addClass(this.toThemeProperty("jqx-rc-t"));
			if (this.host.find('div[data-role="content"]').length > 0) {
				this.host.find('div[data-role="content"]').addClass(this.toThemeProperty("jqx-widget-content"))
			}
		},
		_raiseEvent: function () { },
		_filter: function (h) {
			var f = this.host.find(".jqx-listmenu-item");
			for (var e = 0; e < f.length; e += 1) {
				var g = c.trim(c(f[e]).text());
				if (!this.filterCallback(g, h)) {
					f[e].style.display = "none"
				} else {
					f[e].style.display = "block"
				}
			}
			var f = this.host.find(".jqx-listmenu-separator");
			for (var e = 0; e < f.length; e += 1) {
				var d = false;
				c.each(f[e].items, function () {
					if (c(this).css("display") != "none") {
						d = true;
						return false
					}
				});
				if (!d) {
					f[e].style.display = "none"
				} else {
					f[e].style.display = "block"
				}
			}
		},
		disable: function () {
			this.host.addClass(this.toThemeProperty("jqx-fill-state-disabled"));
			this.disabled = true
		},
		enable: function () {
			this.host.removeClass(this.toThemeProperty("jqx-fill-state-disabled"));
			this.disabled = false
		},
		propertyChangedHandler: function (d, e, g, f) {
			if (e == "disabled") {
				if (f) {
					d.disable()
				} else {
					d.enable()
				}
			}
			if (e === "backLabel") {
				d._backButton.html(f);
				return
			} else {
				if (e === "placeHolder") {
					d._filterInput.attr("placeholder", f)
				} else {
					if ((/(showFilter|showHeader|showBackButton|width|height|autoSeparators|readOnly)/).test(e)) {
						d._render();
						return
					}
				}
			}
		}
	})
}(jQuery));