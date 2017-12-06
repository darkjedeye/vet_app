/*
jQWidgets v3.0.3 (2013-Oct-01)
Copyright (c) 2011-2013 jQWidgets.
License: http://jqwidgets.com/license/
*/

(function (a) {
	a.jqx.jqxWidget("jqxScrollBar", "", {});
	a.extend(a.jqx._jqxScrollBar.prototype, {
		defineInstance: function () {
			this.height = null;
			this.width = null;
			this.vertical = false;
			this.min = 0;
			this.max = 1000;
			this.value = this.min;
			this.step = 10;
			this.largestep = 50;
			this.thumbMinSize = 10;
			this.thumbSize = 0;
			this.thumbStep = "auto";
			this.roundedCorners = "all";
			this.showButtons = true;
			this.disabled = false;
			this.touchMode = "auto";
			this.touchModeStyle = "auto";
			this.thumbTouchSize = 0;
			this._triggervaluechanged = true;
			this.rtl = false;
			this.areaDownCapture = false;
			this.areaUpCapture = false;
			this._initialLayout = false
		},
		createInstance: function (b) {
			this.render()
		},
		render: function () {
			this._mouseup = new Date();
			var b = this;
			var c = "<div id='jqxScrollOuterWrap' style='width:100%; height: 100%; align:left; border: 0px; valign:top; position: relative;'><div id='jqxScrollWrap' style='width:100%; height: 100%; left: 0px; top: 0px; align:left; valign:top; position: absolute;'><div id='jqxScrollBtnUp' style='align:left; valign:top; left: 0px; top: 0px; position: absolute;'></div><div id='jqxScrollAreaUp' style='align:left; valign:top; left: 0px; top: 0px; position: absolute;'></div><div id='jqxScrollThumb' style='align:left; valign:top; left: 0px; top: 0px; position: absolute;'></div><div id='jqxScrollAreaDown' style='align:left; valign:top; left: 0px; top: 0px; position: absolute;'></div><div id='jqxScrollBtnDown' style='align:left; valign:top; left: 0px; top: 0px; position: absolute;'></div></div></div>";
			if (b.WinJS) {
				MSApp.execUnsafeLocalFunction(function () {
					WinJS.Utilities.setInnerHTMLUnsafe(this.element, c)
				})
			} else {
				this.element.innerHTML = c
			} if (this.width != undefined && parseInt(this.width) > 0) {
				this.host.width(parseInt(this.width))
			}
			if (this.height != undefined && parseInt(this.height) > 0) {
				this.host.height(parseInt(this.height))
			}
			this.isPercentage = false;
			if (this.width != null && this.width.toString().indexOf("%") != -1) {
				this.host.width(this.width);
				this.isPercentage = true
			}
			if (this.height != null && this.height.toString().indexOf("%") != -1) {
				this.host.height(this.height);
				this.isPercentage = true
			}
			if (this.isPercentage) {
				var d = this;
				a.jqx.utilities.resize(this.host, function () {
					d._arrange()
				}, false)
			}
			this.thumbCapture = false;
			this.btnUp = this.host.find("#jqxScrollBtnUp");
			this.btnDown = this.host.find("#jqxScrollBtnDown");
			this.btnThumb = this.host.find("#jqxScrollThumb");
			this.areaUp = this.host.find("#jqxScrollAreaUp");
			this.arrowUp = a("<div></div>");
			this.arrowUp.appendTo(this.btnUp);
			this.arrowDown = a("<div></div>");
			this.arrowDown.appendTo(this.btnDown);
			this.areaDown = this.host.find("#jqxScrollAreaDown");
			this.scrollWrap = this.host.find("#jqxScrollWrap");
			this.scrollOuterWrap = this.host.find("#jqxScrollOuterWrap");
			this.btnUp[0].id = "jqxScrollBtnUp" + this.element.id;
			this.btnDown[0].id = "jqxScrollBtnDown" + this.element.id;
			this.btnThumb[0].id = "jqxScrollThumb" + this.element.id;
			this.areaUp[0].id = "jqxScrollAreaUp" + this.element.id;
			this.areaDown[0].id = "jqxScrollAreaDown" + this.element.id;
			this.scrollWrap[0].id = "jqxScrollWrap" + this.element.id;
			this.scrollOuterWrap[0].id = "jqxScrollOuterWrap" + this.element.id;
			if (!this.host.jqxRepeatButton) {
				throw new Error("jqxScrollBar: Missing reference to jqxbuttons.js.");
				return
			}
			this.btnUp.jqxRepeatButton({
				_ariaDisabled: true,
				overrideTheme: true,
				disabled: this.disabled
			});
			this.btnDown.jqxRepeatButton({
				_ariaDisabled: true,
				overrideTheme: true,
				disabled: this.disabled
			});
			this.btnDownInstance = a.data(this.btnDown[0], "jqxRepeatButton").instance;
			this.btnUpInstance = a.data(this.btnUp[0], "jqxRepeatButton").instance;
			this.areaUp.jqxRepeatButton({
				_ariaDisabled: true,
				overrideTheme: true
			});
			this.areaDown.jqxRepeatButton({
				_ariaDisabled: true,
				overrideTheme: true
			});
			this.btnThumb.jqxButton({
				_ariaDisabled: true,
				overrideTheme: true,
				disabled: this.disabled
			});
			this.propertyChangeMap.value = function (e, g, f, h) {
				if (!(isNaN(h))) {
					if (f != h) {
						e.setPosition(parseFloat(h), true)
					}
				}
			};
			this.propertyChangeMap.width = function (e, g, f, h) {
				if (e.width != undefined && parseInt(e.width) > 0) {
					e.host.width(parseInt(e.width));
					e._arrange()
				}
			};
			this.propertyChangeMap.height = function (e, g, f, h) {
				if (e.height != undefined && parseInt(e.height) > 0) {
					e.host.height(parseInt(e.height));
					e._arrange()
				}
			};
			this.propertyChangeMap.theme = function (e, g, f, h) {
				e.setTheme()
			};
			this.propertyChangeMap.max = function (e, g, f, h) {
				if (!(isNaN(h))) {
					if (f != h) {
						e.max = parseInt(h);
						if (e.min > e.max) {
							e.max = e.min + 1
						}
						e._arrange();
						e.setPosition(e.value)
					}
				}
			};
			this.propertyChangeMap.min = function (e, g, f, h) {
				if (!(isNaN(h))) {
					if (f != h) {
						e.min = parseInt(h);
						if (e.min > e.max) {
							e.max = e.min + 1
						}
						e._arrange();
						e.setPosition(e.value)
					}
				}
			};
			this.propertyChangeMap.disabled = function (e, g, f, h) {
				if (f != h) {
					if (h) {
						e.host.addClass(e.toThemeProperty("jqx-fill-state-disabled"))
					} else {
						e.host.removeClass(e.toThemeProperty("jqx-fill-state-disabled"))
					}
					e.btnUp.jqxRepeatButton("disabled", e.disabled);
					e.btnDown.jqxRepeatButton("disabled", e.disabled);
					e.btnThumb.jqxButton("disabled", e.disabled)
				}
			};
			this.propertyChangeMap.touchMode = function (e, g, f, h) {
				if (f != h) {
					e._updateTouchBehavior();
					if (h === true) {
						e.showButtons = false;
						e.refresh()
					} else {
						if (h === false) {
							e.showButtons = true;
							e.refresh()
						}
					}
				}
			};
			this.buttonUpCapture = false;
			this.buttonDownCapture = false;
			this._updateTouchBehavior();
			this.setPosition(this.value);
			this._addHandlers();
			this.setTheme()
		},
		_updateTouchBehavior: function () {
			this.isTouchDevice = a.jqx.mobile.isTouchDevice();
			if (this.touchMode == true) {
				if (a.jqx.browser.msie && a.jqx.browser.version < 9) {
					this.setTheme();
					return
				}
				this.isTouchDevice = true;
				a.jqx.mobile.setMobileSimulator(this.btnThumb[0]);
				this._removeHandlers();
				this._addHandlers();
				this.setTheme()
			} else {
				if (this.touchMode == false) {
					this.isTouchDevice = false
				}
			}
		},
		_addHandlers: function () {
			var d = this;
			if (d.isTouchDevice) {
				this.addHandler(this.btnThumb, a.jqx.mobile.getTouchEventName("touchend"), function (h) {
					var i = d.vertical ? d.toThemeProperty("jqx-scrollbar-thumb-state-pressed") : d.toThemeProperty("jqx-scrollbar-thumb-state-pressed-horizontal");
					var j = d.toThemeProperty("jqx-fill-state-pressed");
					d.btnThumb.removeClass(i);
					d.btnThumb.removeClass(j);
					if (!d.disabled) {
						d.handlemouseup(d, h)
					}
				});
				this.addHandler(this.btnThumb, a.jqx.mobile.getTouchEventName("touchstart"), function (h) {
					if (!d.disabled) {
						if (d.touchMode == true) {
							h.clientX = h.originalEvent.clientX;
							h.clientY = h.originalEvent.clientY
						} else {
							var i = h;
							if (i.originalEvent.touches && i.originalEvent.touches.length) {
								h.clientX = i.originalEvent.touches[0].clientX;
								h.clientY = i.originalEvent.touches[0].clientY
							} else {
								h.clientX = h.originalEvent.clientX;
								h.clientY = h.originalEvent.clientY
							}
						}
						d.handlemousedown(h)
					}
				});
				a.jqx.mobile.touchScroll(this.element, d.max, function (n, m, i, h, j) {
					if (d.host.css("visibility") == "visible") {
						if (d.touchMode == true) {
							j.clientX = j.originalEvent.clientX;
							j.clientY = j.originalEvent.clientY
						} else {
							var l = j;
							if (l.originalEvent.touches && l.originalEvent.touches.length) {
								j.clientX = l.originalEvent.touches[0].clientX;
								j.clientY = l.originalEvent.touches[0].clientY
							} else {
								j.clientX = j.originalEvent.clientX;
								j.clientY = j.originalEvent.clientY
							}
						}
						var k = d.vertical ? d.toThemeProperty("jqx-scrollbar-thumb-state-pressed") : d.toThemeProperty("jqx-scrollbar-thumb-state-pressed-horizontal");
						d.btnThumb.addClass(k);
						d.btnThumb.addClass(d.toThemeProperty("jqx-fill-state-pressed"));
						d.handlemousemove(j)
					}
				}, d.element.id)
			}
			this.addHandler(this.btnUp, "click", function (i) {
				var h = d.step;
				if (d.rtl && !d.vertical) {
					h = -d.step
				}
				if (d.buttonUpCapture && !d.isTouchDevice) {
					if (!d.disabled) {
						d.setPosition(d.value - h)
					}
				} else {
					if (!d.disabled && d.isTouchDevice) {
						d.setPosition(d.value - h)
					}
				}
			});
			this.addHandler(this.btnDown, "click", function (i) {
				var h = d.step;
				if (d.rtl && !d.vertical) {
					h = -d.step
				}
				if (d.buttonDownCapture && !d.isTouchDevice) {
					if (!d.disabled) {
						d.setPosition(d.value + h)
					}
				} else {
					if (!d.disabled && d.isTouchDevice) {
						d.setPosition(d.value + h)
					}
				}
			});
			if (!this.isTouchDevice) {
				try {
					if (document.referrer != "" || window.frameElement) {
						if (window.top != null && window.top != window.self) {
							var g = null;
							if (window.parent && document.referrer) {
								g = document.referrer
							}
							if (g && g.indexOf(document.location.host) != -1) {
								var f = function (h) {
									if (!d.disabled) {
										d.handlemouseup(d, h)
									}
								};
								if (window.top.document.addEventListener) {
									window.top.document.addEventListener("mouseup", f, false)
								} else {
									if (window.top.document.attachEvent) {
										window.top.document.attachEvent("onmouseup", f)
									}
								}
							}
						}
					}
				} catch (e) { }
				this.addHandler(this.btnDown, "mouseup", function (i) {
					if (!d.btnDownInstance.base.disabled && d.buttonDownCapture) {
						d.buttonDownCapture = false;
						d.btnDown.removeClass(d.toThemeProperty("jqx-scrollbar-button-state-pressed"));
						d.btnDown.removeClass(d.toThemeProperty("jqx-fill-state-pressed"));
						d._removeArrowClasses("pressed", "down");
						d.handlemouseup(d, i);
						var h = d.step;
						if (d.rtl && !d.vertical) {
							h = -d.step
						}
						d.setPosition(d.value + h);
						return false
					}
				});
				this.addHandler(this.btnUp, "mouseup", function (i) {
					if (!d.btnUpInstance.base.disabled && d.buttonUpCapture) {
						d.buttonUpCapture = false;
						d.btnUp.removeClass(d.toThemeProperty("jqx-scrollbar-button-state-pressed"));
						d.btnUp.removeClass(d.toThemeProperty("jqx-fill-state-pressed"));
						d._removeArrowClasses("pressed", "up");
						d.handlemouseup(d, i);
						var h = d.step;
						if (d.rtl && !d.vertical) {
							h = -d.step
						}
						d.setPosition(d.value - h);
						return false
					}
				});
				this.addHandler(this.btnDown, "mousedown", function (h) {
					if (!d.btnDownInstance.base.disabled) {
						d.buttonDownCapture = true;
						d.btnDown.addClass(d.toThemeProperty("jqx-fill-state-pressed"));
						d.btnDown.addClass(d.toThemeProperty("jqx-scrollbar-button-state-pressed"));
						d._addArrowClasses("pressed", "down");
						return false
					}
				});
				this.addHandler(this.btnUp, "mousedown", function (h) {
					if (!d.btnUpInstance.base.disabled) {
						d.buttonUpCapture = true;
						d.btnUp.addClass(d.toThemeProperty("jqx-fill-state-pressed"));
						d.btnUp.addClass(d.toThemeProperty("jqx-scrollbar-button-state-pressed"));
						d._addArrowClasses("pressed", "up");
						return false
					}
				})
			}
			var c = "click";
			if (this.isTouchDevice) {
				c = a.jqx.mobile.getTouchEventName("touchend")
			}
			this.addHandler(this.areaUp, c, function (i) {
				if (!d.disabled) {
					var h = d.largestep;
					if (d.rtl && !d.vertical) {
						h = -d.largestep
					}
					d.setPosition(d.value - h);
					return false
				}
			});
			this.addHandler(this.areaDown, c, function (i) {
				if (!d.disabled) {
					var h = d.largestep;
					if (d.rtl && !d.vertical) {
						h = -d.largestep
					}
					d.setPosition(d.value + h);
					return false
				}
			});
			this.addHandler(this.areaUp, "mousedown", function (h) {
				if (!d.disabled) {
					d.areaUpCapture = true;
					return false
				}
			});
			this.addHandler(this.areaDown, "mousedown", function (h) {
				if (!d.disabled) {
					d.areaDownCapture = true;
					return false
				}
			});
			this.addHandler(this.btnThumb, "mousedown", function (h) {
				if (!d.disabled) {
					d.handlemousedown(h)
				}
				return false
			});
			this.addHandler(this.btnThumb, "dragstart", function (h) {
				return false
			});
			this.addHandler(a(document), "mouseup." + this.element.id, function (h) {
				if (!d.disabled) {
					d.handlemouseup(d, h)
				}
			});
			if (!this.isTouchDevice) {
				this.mousemoveFunc = function (h) {
					if (!d.disabled) {
						d.handlemousemove(h)
					}
				};
				this.addHandler(a(document), "mousemove." + this.element.id, this.mousemoveFunc);
				this.addHandler(a(document), "mouseleave." + this.element.id, function (h) {
					if (!d.disabled) {
						d.handlemouseleave(h)
					}
				});
				this.addHandler(a(document), "mouseenter." + this.element.id, function (h) {
					if (!d.disabled) {
						d.handlemouseenter(h)
					}
				});
				if (!d.disabled) {
					this.addHandler(this.btnUp, "mouseenter", function () {
						if (!d.disabled && !d.btnUpInstance.base.disabled && d.touchMode != true) {
							d.btnUp.addClass(d.toThemeProperty("jqx-scrollbar-button-state-hover"));
							d.btnUp.addClass(d.toThemeProperty("jqx-fill-state-hover"));
							d._addArrowClasses("hover", "up")
						}
					});
					this.addHandler(this.btnUp, "mouseleave", function () {
						if (!d.disabled && !d.btnUpInstance.base.disabled && d.touchMode != true) {
							d.btnUp.removeClass(d.toThemeProperty("jqx-scrollbar-button-state-hover"));
							d.btnUp.removeClass(d.toThemeProperty("jqx-fill-state-hover"));
							d._removeArrowClasses("hover", "up")
						}
					});
					var b = d.toThemeProperty("jqx-scrollbar-thumb-state-hover");
					if (!d.vertical) {
						b = d.toThemeProperty("jqx-scrollbar-thumb-state-hover-horizontal")
					}
					this.addHandler(this.btnThumb, "mouseenter", function () {
						if (!d.disabled && d.touchMode != true) {
							d.btnThumb.addClass(b);
							d.btnThumb.addClass(d.toThemeProperty("jqx-fill-state-hover"))
						}
					});
					this.addHandler(this.btnThumb, "mouseleave", function () {
						if (!d.disabled && d.touchMode != true) {
							d.btnThumb.removeClass(b);
							d.btnThumb.removeClass(d.toThemeProperty("jqx-fill-state-hover"))
						}
					});
					this.addHandler(this.btnDown, "mouseenter", function () {
						if (!d.disabled && !d.btnDownInstance.base.disabled && d.touchMode != true) {
							d.btnDown.addClass(d.toThemeProperty("jqx-scrollbar-button-state-hover"));
							d.btnDown.addClass(d.toThemeProperty("jqx-fill-state-hover"));
							d._addArrowClasses("hover", "down")
						}
					});
					this.addHandler(this.btnDown, "mouseleave", function () {
						if (!d.disabled && !d.btnDownInstance.base.disabled && d.touchMode != true) {
							d.btnDown.removeClass(d.toThemeProperty("jqx-scrollbar-button-state-hover"));
							d.btnDown.removeClass(d.toThemeProperty("jqx-fill-state-hover"));
							d._removeArrowClasses("hover", "down")
						}
					})
				}
			}
		},
		destroy: function () {
			var b = this.btnUp;
			var f = this.btnDown;
			var d = this.btnThumb;
			var c = this.scrollWrap;
			var g = this.areaUp;
			var e = this.areaDown;
			e.removeClass();
			g.removeClass();
			f.removeClass();
			b.removeClass();
			d.removeClass();
			b.jqxRepeatButton("destroy");
			f.jqxRepeatButton("destroy");
			g.jqxRepeatButton("destroy");
			e.jqxRepeatButton("destroy");
			d.jqxButton("destroy");
			this._removeHandlers();
			this.host.removeClass();
			this.host.removeData();
			this.host.remove();
			this.host = null;
			this.btnUp = null;
			this.btnDown = null;
			this.scrollWrap = null;
			this.areaUp = null;
			this.areaDown = null;
			this.scrollOuterWrap = null;
			delete this.scrollOuterWrap;
			delete this.scrollWrap;
			delete this.btnDown;
			delete this.areaDown;
			delete this.areaUp;
			delete this.btnDown;
			delete this.btnUp
		},
		_removeHandlers: function () {
			this.removeHandler(this.btnUp, "mouseenter");
			this.removeHandler(this.btnDown, "mouseenter");
			this.removeHandler(this.btnThumb, "mouseenter");
			this.removeHandler(this.btnUp, "mouseleave");
			this.removeHandler(this.btnDown, "mouseleave");
			this.removeHandler(this.btnThumb, "mouseleave");
			this.removeHandler(this.btnUp, "click");
			this.removeHandler(this.btnDown, "click");
			this.removeHandler(this.btnDown, "mouseup");
			this.removeHandler(this.btnUp, "mouseup");
			this.removeHandler(this.btnDown, "mousedown");
			this.removeHandler(this.btnUp, "mousedown");
			this.removeHandler(this.areaUp, "mousedown");
			this.removeHandler(this.areaDown, "mousedown");
			this.removeHandler(this.areaUp, "click");
			this.removeHandler(this.areaDown, "click");
			this.removeHandler(this.btnThumb, "mousedown");
			this.removeHandler(this.btnThumb, "dragstart");
			this.removeHandler(a(document), "mouseup." + this.element.id);
			if (!this.mousemoveFunc) {
				this.removeHandler(a(document), "mousemove." + this.element.id)
			} else {
				this.removeHandler(a(document), "mousemove." + this.element.id, this.mousemoveFunc)
			}
			this.removeHandler(a(document), "mouseleave." + this.element.id);
			this.removeHandler(a(document), "mouseenter." + this.element.id);
			var b = this
		},
		_addArrowClasses: function (c, b) {
			if (c == "pressed") {
				c = "selected"
			}
			if (c != "") {
				c = "-" + c
			}
			if (this.vertical) {
				if (b == "up" || b == undefined) {
					this.arrowUp.addClass(this.toThemeProperty("jqx-icon-arrow-up" + c))
				}
				if (b == "down" || b == undefined) {
					this.arrowDown.addClass(this.toThemeProperty("jqx-icon-arrow-down" + c))
				}
			} else {
				if (b == "up" || b == undefined) {
					this.arrowUp.addClass(this.toThemeProperty("jqx-icon-arrow-left" + c))
				}
				if (b == "down" || b == undefined) {
					this.arrowDown.addClass(this.toThemeProperty("jqx-icon-arrow-right" + c))
				}
			}
		},
		_removeArrowClasses: function (c, b) {
			if (c == "pressed") {
				c = "selected"
			}
			if (c != "") {
				c = "-" + c
			}
			if (this.vertical) {
				if (b == "up" || b == undefined) {
					this.arrowUp.removeClass(this.toThemeProperty("jqx-icon-arrow-up" + c))
				}
				if (b == "down" || b == undefined) {
					this.arrowDown.removeClass(this.toThemeProperty("jqx-icon-arrow-down" + c))
				}
			} else {
				if (b == "up" || b == undefined) {
					this.arrowUp.removeClass(this.toThemeProperty("jqx-icon-arrow-left" + c))
				}
				if (b == "down" || b == undefined) {
					this.arrowDown.removeClass(this.toThemeProperty("jqx-icon-arrow-right" + c))
				}
			}
		},
		setTheme: function () {
			var o = this.btnUp;
			var m = this.btnDown;
			var p = this.btnThumb;
			var e = this.scrollWrap;
			var g = this.areaUp;
			var h = this.areaDown;
			var f = this.arrowUp;
			var i = this.arrowDown;
			this.scrollWrap[0].className = this.toThemeProperty("jqx-reset");
			this.scrollOuterWrap[0].className = this.toThemeProperty("jqx-reset");
			var k = this.toThemeProperty("jqx-reset");
			this.areaDown[0].className = k;
			this.areaUp[0].className = k;
			var d = this.toThemeProperty("jqx-scrollbar") + " " + this.toThemeProperty("jqx-widget") + " " + this.toThemeProperty("jqx-widget-content");
			this.element.className = d;
			m[0].className = this.toThemeProperty("jqx-scrollbar-button-state-normal");
			o[0].className = this.toThemeProperty("jqx-scrollbar-button-state-normal");
			var q = "";
			if (this.vertical) {
				f[0].className = k + " " + this.toThemeProperty("jqx-icon-arrow-up");
				i[0].className = k + " " + this.toThemeProperty("jqx-icon-arrow-down");
				q = this.toThemeProperty("jqx-scrollbar-thumb-state-normal")
			} else {
				f[0].className = k + " " + this.toThemeProperty("jqx-icon-arrow-left");
				i[0].className = k + " " + this.toThemeProperty("jqx-icon-arrow-right");
				q = this.toThemeProperty("jqx-scrollbar-thumb-state-normal-horizontal")
			}
			q += " " + this.toThemeProperty("jqx-fill-state-normal");
			p[0].className = q;
			if (this.disabled) {
				e.addClass(this.toThemeProperty("jqx-fill-state-disabled"));
				e.removeClass(this.toThemeProperty("jqx-scrollbar-state-normal"))
			} else {
				e.addClass(this.toThemeProperty("jqx-scrollbar-state-normal"));
				e.removeClass(this.toThemeProperty("jqx-fill-state-disabled"))
			} if (this.roundedCorners == "all") {
				this.host.addClass(this.toThemeProperty("jqx-rc-all"));
				if (this.vertical) {
					var j = a.jqx.cssroundedcorners("top");
					j = this.toThemeProperty(j);
					o.addClass(j);
					var c = a.jqx.cssroundedcorners("bottom");
					c = this.toThemeProperty(c);
					m.addClass(c)
				} else {
					var n = a.jqx.cssroundedcorners("left");
					n = this.toThemeProperty(n);
					o.addClass(n);
					var l = a.jqx.cssroundedcorners("right");
					l = this.toThemeProperty(l);
					m.addClass(l)
				}
			} else {
				var b = a.jqx.cssroundedcorners(this.roundedCorners);
				b = this.toThemeProperty(b);
				elBtnUp.addClass(b);
				elBtnDown.addClass(b)
			}
			var b = a.jqx.cssroundedcorners(this.roundedCorners);
			b = this.toThemeProperty(b);
			if (!p.hasClass(b)) {
				p.addClass(b)
			}
			if (this.isTouchDevice && this.touchModeStyle != false) {
				this.showButtons = false;
				p.addClass(this.toThemeProperty("jqx-scrollbar-thumb-state-normal-touch"))
			}
		},
		isScrolling: function () {
			if (this.thumbCapture == undefined || this.buttonDownCapture == undefined || this.buttonUpCapture == undefined || this.areaDownCapture == undefined || this.areaUpCapture == undefined) {
				return false
			}
			return this.thumbCapture || this.buttonDownCapture || this.buttonUpCapture || this.areaDownCapture || this.areaUpCapture
		},
		handlemousedown: function (c) {
			if (this.thumbCapture == undefined || this.thumbCapture == false) {
				this.thumbCapture = true;
				var b = this.btnThumb;
				if (b != null) {
					b.addClass(this.toThemeProperty("jqx-fill-state-pressed"));
					if (this.vertical) {
						b.addClass(this.toThemeProperty("jqx-scrollbar-thumb-state-pressed"))
					} else {
						b.addClass(this.toThemeProperty("jqx-scrollbar-thumb-state-pressed-horizontal"))
					}
				}
			}
			this.dragStartX = c.clientX;
			this.dragStartY = c.clientY;
			this.dragStartValue = this.value
		},
		toggleHover: function (c, b) { },
		refresh: function () {
			this._arrange()
		},
		_setElementPosition: function (c, b, d) {
			if (!isNaN(b)) {
				if (parseInt(c[0].style.left) != parseInt(b)) {
					c[0].style.left = b + "px"
				}
			}
			if (!isNaN(d)) {
				if (parseInt(c[0].style.top) != parseInt(d)) {
					c[0].style.top = d + "px"
				}
			}
		},
		_setElementTopPosition: function (b, c) {
			if (!isNaN(c)) {
				b[0].style.top = c + "px"
			}
		},
		_setElementLeftPosition: function (c, b) {
			if (!isNaN(b)) {
				c[0].style.left = b + "px"
			}
		},
		handlemouseleave: function (e) {
			var b = this.btnUp;
			var d = this.btnDown;
			if (this.buttonDownCapture || this.buttonUpCapture) {
				b.removeClass(this.toThemeProperty("jqx-scrollbar-button-state-pressed"));
				d.removeClass(this.toThemeProperty("jqx-scrollbar-button-state-pressed"));
				this._removeArrowClasses("pressed")
			}
			if (this.thumbCapture != true) {
				return
			}
			var c = this.btnThumb;
			var f = this.vertical ? this.toThemeProperty("jqx-scrollbar-thumb-state-pressed") : this.toThemeProperty("jqx-scrollbar-thumb-state-pressed-horizontal");
			c.removeClass(f);
			c.removeClass(this.toThemeProperty("jqx-fill-state-pressed"))
		},
		handlemouseenter: function (e) {
			var b = this.btnUp;
			var d = this.btnDown;
			if (this.buttonUpCapture) {
				b.addClass(this.toThemeProperty("jqx-scrollbar-button-state-pressed"));
				b.addClass(this.toThemeProperty("jqx-fill-state-pressed"));
				this._addArrowClasses("pressed", "up")
			}
			if (this.buttonDownCapture) {
				d.addClass(this.toThemeProperty("jqx-scrollbar-button-state-pressed"));
				d.addClass(this.toThemeProperty("jqx-fill-state-pressed"));
				this._addArrowClasses("pressed", "down")
			}
			if (this.thumbCapture != true) {
				return
			}
			var c = this.btnThumb;
			if (this.vertical) {
				c.addClass(this.toThemeProperty("jqx-scrollbar-thumb-state-pressed"))
			} else {
				c.addClass(this.toThemeProperty("jqx-scrollbar-thumb-state-pressed-horizontal"))
			}
			c.addClass(this.toThemeProperty("jqx-fill-state-pressed"))
		},
		handlemousemove: function (b) {
			var i = this.btnUp;
			var e = this.btnDown;
			var d = 0;
			if (e == null || i == null) {
				return
			}
			if (i != null && e != null && this.buttonDownCapture != undefined && this.buttonUpCapture != undefined) {
				if (this.buttonDownCapture && b.which == d) {
					e.removeClass(this.toThemeProperty("jqx-scrollbar-button-state-pressed"));
					e.removeClass(this.toThemeProperty("jqx-fill-state-pressed"));
					this._removeArrowClasses("pressed", "down");
					this.buttonDownCapture = false
				} else {
					if (this.buttonUpCapture && b.which == d) {
						i.removeClass(this.toThemeProperty("jqx-scrollbar-button-state-pressed"));
						i.removeClass(this.toThemeProperty("jqx-fill-state-pressed"));
						this._removeArrowClasses("pressed", "up");
						this.buttonUpCapture = false
					}
				}
			}
			if (this.thumbCapture != true) {
				return false
			}
			var k = this.btnThumb;
			if (b.which == d && !this.isTouchDevice) {
				this.thumbCapture = false;
				this._arrange();
				var j = this.vertical ? this.toThemeProperty("jqx-scrollbar-thumb-state-pressed") : this.toThemeProperty("jqx-scrollbar-thumb-state-pressed-horizontal");
				k.removeClass(j);
				k.removeClass(this.toThemeProperty("jqx-fill-state-pressed"));
				return true
			}
			if (b.preventDefault != undefined) {
				b.preventDefault()
			}
			if (b.originalEvent != null) {
				b.originalEvent.mouseHandled = true
			}
			if (b.stopPropagation != undefined) {
				b.stopPropagation()
			}
			var l = 0;
			try {
				if (!this.vertical) {
					l = b.clientX - this.dragStartX
				} else {
					l = b.clientY - this.dragStartY
				}
				var f = this._btnAndThumbSize;
				if (!this._btnAndThumbSize) {
					f = (this.vertical) ? i.height() + e.height() + k.height() : i.width() + e.width() + k.width()
				}
				var g = (this.max - this.min) / (this.scrollBarSize - f);
				if (this.thumbStep == "auto") {
					l *= g
				} else {
					l *= g;
					if (Math.abs(this.dragStartValue + l - this.value) >= parseInt(this.thumbStep)) {
						var c = Math.round(parseInt(l) / this.thumbStep) * this.thumbStep;
						if (this.rtl && !this.vertical) {
							this.setPosition(this.dragStartValue - c)
						} else {
							this.setPosition(this.dragStartValue + c)
						}
						return false
					} else {
						return false
					}
				}
				var c = l;
				if (this.rtl && !this.vertical) {
					c = -l
				}
				this.setPosition(this.dragStartValue + c)
			} catch (h) {
				alert(h)
			}
			return false
		},
		handlemouseup: function (d, g) {
			var c = false;
			if (this.thumbCapture) {
				this.thumbCapture = false;
				var e = this.btnThumb;
				var h = this.vertical ? this.toThemeProperty("jqx-scrollbar-thumb-state-pressed") : this.toThemeProperty("jqx-scrollbar-thumb-state-pressed-horizontal");
				e.removeClass(h);
				e.removeClass(this.toThemeProperty("jqx-fill-state-pressed"));
				c = true;
				this._mouseup = new Date()
			}
			this.areaDownCapture = this.areaUpCapture = false;
			if (this.buttonUpCapture || this.buttonDownCapture) {
				var b = this.btnUp;
				var f = this.btnDown;
				this.buttonUpCapture = false;
				this.buttonDownCapture = false;
				b.removeClass(this.toThemeProperty("jqx-scrollbar-button-state-pressed"));
				f.removeClass(this.toThemeProperty("jqx-scrollbar-button-state-pressed"));
				b.removeClass(this.toThemeProperty("jqx-fill-state-pressed"));
				f.removeClass(this.toThemeProperty("jqx-fill-state-pressed"));
				this._removeArrowClasses("pressed");
				c = true;
				this._mouseup = new Date()
			}
			if (c) {
				if (g.preventDefault != undefined) {
					g.preventDefault()
				}
				if (g.originalEvent != null) {
					g.originalEvent.mouseHandled = true
				}
				if (g.stopPropagation != undefined) {
					g.stopPropagation()
				}
			}
		},
		setPosition: function (b, g) {
			var d = this.element;
			if (b == undefined || b == NaN) {
				b = this.min
			}
			if (b >= this.max) {
				b = this.max
			}
			if (b < this.min) {
				b = this.min
			}
			if (this.value !== b || g == true) {
				if (b == this.max) {
					var c = new jQuery.Event("complete");
					this.host.trigger(c)
				}
				var f = this.value;
				if (this._triggervaluechanged) {
					var e = new jQuery.Event("valuechanged");
					e.previousValue = this.value;
					e.currentValue = b
				}
				this.value = b;
				this._positionelements();
				if (this._triggervaluechanged) {
					this.host.trigger(e)
				}
				if (this.valuechanged) {
					this.valuechanged({
						currentValue: this.value,
						previousvalue: f
					})
				}
			}
			return b
		},
		_getThumbSize: function (b) {
			var d = this.max - this.min;
			var c = 0;
			if (d > 1) {
				c = (b / (d + b) * b)
			} else {
				if (d == 1) {
					c = b
				}
			} if (this.thumbSize > 0) {
				c = this.thumbSize
			}
			if (c < this.thumbMinSize) {
				c = this.thumbMinSize
			}
			return Math.min(c, b)
		},
		_positionelements: function () {
			var g = this.element;
			var n = this.areaUp;
			var e = this.areaDown;
			var h = this.btnUp;
			var f = this.btnDown;
			var o = this.btnThumb;
			var b = this.scrollWrap;
			var p = this._height ? this._height : this.host.height();
			var c = this._width ? this._width : this.host.width();
			var l = (!this.vertical) ? p : c;
			if (!this.showButtons) {
				l = 0
			}
			var m = (!this.vertical) ? c : p;
			this.scrollBarSize = m;
			var d = this._getThumbSize(m - 2 * l);
			d = Math.round(d);
			if (d < this.thumbMinSize) {
				d = this.thumbMinSize
			}
			if (p == NaN || p < 10) {
				p = 10
			}
			if (c == NaN || c < 10) {
				c = 10
			}
			l += 2;
			this.btnSize = l;
			var i = this._btnAndThumbSize;
			if (!this._btnAndThumbSize) {
				var i = (this.vertical) ? 2 * this.btnSize + o.outerHeight() : 2 * this.btnSize + o.outerWidth();
				i = Math.round(i)
			}
			var k = (m - i) / (this.max - this.min) * (this.value - this.min);
			if (this.rtl && !this.vertical) {
				k = (m - i) / (this.max - this.min) * (this.max - this.value - this.min)
			}
			k = Math.round(k);
			if (k < 0) {
				k = 0
			}
			if (this.vertical) {
				var j = m - k - i;
				if (j < 0) {
					j = 0
				}
				e[0].style.height = j + "px";
				n[0].style.height = k + "px";
				this._setElementTopPosition(n, l);
				this._setElementTopPosition(o, l + k);
				this._setElementTopPosition(e, l + k + d)
			} else {
				n[0].style.width = k + "px";
				e[0].style.width = m - k - i + "px";
				this._setElementLeftPosition(n, l);
				this._setElementLeftPosition(o, l + k);
				this._setElementLeftPosition(e, 2 + l + k + d)
			}
		},
		_arrange: function () {
			if (this._initialLayout) {
				this._initialLayout = false;
				return
			}
			var d = this.element;
			var g = this.areaUp;
			var r = this.areaDown;
			var c = this.btnUp;
			var k = this.btnDown;
			var s = this.btnThumb;
			var n = this.scrollWrap;
			var l = parseInt(this.element.style.height);
			var o = parseInt(this.element.style.width);
			if (this.isPercentage) {
				var l = this.host.height();
				var o = this.host.width()
			}
			if (isNaN(l)) {
				l = 0
			}
			if (isNaN(o)) {
				o = 0
			}
			this._width = o;
			this._height = l;
			var b = (!this.vertical) ? l : o;
			if (!this.showButtons) {
				b = 0
			}
			c[0].style.width = b + "px";
			c[0].style.height = b + "px";
			k[0].style.width = b + "px";
			k[0].style.height = b + "px";
			if (this.vertical) {
				n[0].style.width = o + 2 + "px"
			} else {
				n[0].style.height = l + 2 + "px"
			}
			this._setElementPosition(c, 0, 0);
			var q = b + 2;
			if (this.vertical) {
				this._setElementPosition(k, 0, l - q)
			} else {
				this._setElementPosition(k, o - q, 0)
			}
			var e = (!this.vertical) ? o : l;
			this.scrollBarSize = e;
			var h = this._getThumbSize(e - 2 * b);
			h = Math.round(h);
			if (h < this.thumbMinSize) {
				h = this.thumbMinSize
			}
			var m = false;
			if (this.isTouchDevice && this.touchModeStyle != false) {
				m = true
			}
			if (!this.vertical) {
				s[0].style.width = h + "px";
				s[0].style.height = l + "px";
				if (m && this.thumbTouchSize !== 0) {
					s.css({
						height: this.thumbTouchSize + "px"
					});
					s.css("margin-top", (this.host.height() - this.thumbTouchSize) / 2)
				}
			} else {
				s[0].style.width = o + "px";
				s[0].style.height = h + "px";
				if (m && this.thumbTouchSize !== 0) {
					s.css({
						width: this.thumbTouchSize + "px"
					});
					s.css("margin-left", (this.host.width() - this.thumbTouchSize) / 2)
				}
			} if (l == NaN || l < 10) {
				l = 10
			}
			if (o == NaN || o < 10) {
				o = 10
			}
			b += 2;
			this.btnSize = b;
			var f = (this.vertical) ? 2 * this.btnSize + (2 + parseInt(s[0].style.height)) : 2 * this.btnSize + (2 + parseInt(s[0].style.width));
			f = Math.round(f);
			this._btnAndThumbSize = f;
			var u = (e - f) / (this.max - this.min) * (this.value - this.min);
			if (this.rtl && !this.vertical) {
				u = (e - f) / (this.max - this.min) * (this.max - this.value - this.min)
			}
			u = Math.round(u);
			if (u === -Infinity || u == Infinity) {
				u = 0
			}
			if (isNaN(u)) {
				u = 0
			}
			if (u < 0) {
				u = 0
			}
			if (this.vertical) {
				var t = (e - u - f);
				if (t < 0) {
					t = 0
				}
				r[0].style.height = t + "px";
				r[0].style.width = o + "px";
				g[0].style.height = u + "px";
				g[0].style.width = o + "px";
				var i = parseInt(this.element.style.height);
				if (this.isPercentage) {
					i = this.host.height()
				}
				s[0].style.visibility = "inherit";
				if (i - 3 * parseInt(b) < 0) {
					s[0].style.visibility = "hidden"
				} else {
					if (i < f) {
						s[0].style.visibility = "hidden"
					} else {
						if (this.element.style.visibility == "visible") {
							s[0].style.visibility = "inherit"
						}
					}
				}
				this._setElementPosition(g, 0, b);
				this._setElementPosition(s, 0, b + u);
				this._setElementPosition(r, 0, b + u + h)
			} else {
				if (u > 0) {
					g[0].style.width = u + "px"
				}
				if (l > 0) {
					g[0].style.height = l + "px"
				}
				var j = (e - u - f);
				if (j < 0) {
					j = 0
				}
				r[0].style.width = j + "px";
				r[0].style.height = l + "px";
				var p = parseInt(this.element.style.width);
				if (this.isPercentage) {
					p = this.host.width()
				}
				s[0].style.visibility = "inherit";
				if (p - 3 * parseInt(b) < 0) {
					s[0].style.visibility = "hidden"
				} else {
					if (p < f) {
						s[0].style.visibility = "hidden"
					} else {
						if (this.element.style.visibility == "visible") {
							s[0].style.visibility = "inherit"
						}
					}
				}
				this._setElementPosition(g, b, 0);
				this._setElementPosition(s, b + u, 0);
				this._setElementPosition(r, 2 + b + u + h, 0)
			}
		}
	})
})(jQuery);