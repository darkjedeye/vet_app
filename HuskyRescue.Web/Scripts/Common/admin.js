﻿var App = function () {
	var o = false; var n = false; var l = false; var b = []; var m = {
		blue: "#54728c", red: "#e25856", green: "#94B86E", purple: "#852b99", grey: "#555555", yellow: "#ffb848"
	}; var v = "250px"; var u = function () {
		var x = (navigator.userAgent.match(/msie [8]/i)); var w = (navigator.userAgent.match(/msie [9]/i)); var y = !!navigator.userAgent.match(/MSIE 10/); if (y) {
			$("html").addClass("ie10")
		} $(".navbar li.nav-toggle").click(function () {
			$("body").toggleClass("nav-open")
		}); $(".toggle-sidebar").click(function (A) {
			A.preventDefault(); $("#sidebar").css("width", ""); $("#sidebar > #divider").css("margin-left", ""); $("#content").css("margin-left", ""); $("#container").toggleClass("sidebar-closed")
		}); var z = function () {
			$(".crumbs .crumb-buttons > li").removeClass("first"); $(".crumbs .crumb-buttons > li:visible:first").addClass("first"); if ($("body").hasClass("nav-open")) {
				$("body").toggleClass("nav-open")
			} h(); c()
		}; $(window).setBreakpoints({
			breakpoints: [320, 480, 768, 979, 1200]
		}); $(window).bind("exitBreakpoint320", function () {
			z()
		}); $(window).bind("enterBreakpoint320", function () {
			z()
		}); $(window).bind("exitBreakpoint480", function () {
			z()
		}); $(window).bind("enterBreakpoint480", function () {
			z()
		}); $(window).bind("exitBreakpoint768", function () {
			z()
		}); $(window).bind("enterBreakpoint768", function () {
			z()
		}); $(window).bind("exitBreakpoint979", function () {
			z()
		}); $(window).bind("enterBreakpoint979", function () {
			z()
		}); $(window).bind("exitBreakpoint1200", function () {
			z()
		}); $(window).bind("enterBreakpoint1200", function () {
			z()
		})
	}; var q = function () {
		$("body").height("100%"); var z = $(".header"); var B = z.outerHeight(); var w = $(document).height(); var y = $(window).height(); var x = w - y; if (x <= B) {
			var A = w - x
		} else {
			var A = w
		} A = A - B; var w = $(document).height(); $("body").height(A)
	}; var s = function () {
		q(); if ($(".header").hasClass("navbar-fixed-top")) {
			$("#container").addClass("fixed-header")
		}
	}; var t = function () {
		var w = g(r, 30); $(window).resize(w)
	}; var r = function () {
		q(); if ($.fn.dataTable) {
			var w = $.fn.dataTable.fnTables(true); $(w).each(function () {
				if (typeof $(this).data("horizontalWidth") != "undefined") {
					$(this).dataTable().fnAdjustColumnSizing()
				}
			})
		}
	}; var g = function (A, D, x) {
		var C, y, z, B, w; return function () {
			z = this; y = arguments; B = new Date(); var F = function () {
				var G = (new Date()) - B; if (G < D) {
					C = setTimeout(F, D - G)
				} else {
					C = null; if (!x) {
						w = A.apply(z, y)
					}
				}
			}; var E = x && !C; if (!C) {
				C = setTimeout(F, D)
			} if (E) {
				w = A.apply(z, y)
			} return w
		}
	}; var f = function () {
		if ($(window).width() <= 767) {
			$("body").on("movestart", function (x) {
				if ((x.distX > x.distY && x.distX < -x.distY) || (x.distX < x.distY && x.distX > -x.distY)) {
					x.preventDefault()
				} var w = $(x.target).parents("#project-switcher"); if (w.length) {
					x.preventDefault()
				}
			}).on("swipeleft", function (w) {
				$("body").toggleClass("nav-open")
			}).on("swiperight", function (w) {
				$("body").toggleClass("nav-open")
			})
		}
	}; var d = function () {
		var y = "icon-angle-down", x = "icon-angle-left"; $("li:has(ul)", "#sidebar-content ul").each(function () {
			if ($(this).hasClass("current") || $(this).hasClass("open-default")) {
				$(">a", this).append("<i class='arrow " + y + "'></i>")
			} else {
				$(">a", this).append("<i class='arrow " + x + "'></i>")
			}
		}); if ($("#sidebar").hasClass("sidebar-fixed")) {
			$("#sidebar-content").append('<div class="fill-nav-space"></div>')
		} $("#sidebar-content ul > li > a").on("click", function (B) {
			if ($(this).next().hasClass("sub-menu") == false) {
				return
			} if ($(window).width() > 767) {
				var A = $(this).parent().parent(); A.children("li.open").children("a").children("i.arrow").removeClass(y).addClass(x); A.children("li.open").children(".sub-menu").slideUp(200); A.children("li.open-default").children(".sub-menu").slideUp(200); A.children("li.open").removeClass("open").removeClass("open-default")
			} var z = $(this).next(); if (z.is(":visible")) {
				$("i.arrow", $(this)).removeClass(y).addClass(x); $(this).parent().removeClass("open"); z.slideUp(200, function () {
					$(this).parent().removeClass("open-fixed").removeClass("open-default"); q()
				})
			} else {
				$("i.arrow", $(this)).removeClass(x).addClass(y); $(this).parent().addClass("open"); z.slideDown(200, function () {
					q()
				})
			} B.preventDefault()
		}); var w = function () {
			$("#divider.resizeable").mousedown(function (A) {
				A.preventDefault(); var z = $("#divider").width(); $(document).mousemove(function (C) {
					var B = C.pageX + z; if (B <= 300 && B >= (z * 2 - 3)) {
						if (B >= 240 && B <= 260) {
							$("#sidebar").css("width", 250); $("#sidebar-content").css("width", 250); $("#content").css("margin-left", 250); $("#divider").css("margin-left", 250)
						} else {
							$("#sidebar").css("width", B); $("#sidebar-content").css("width", B); $("#content").css("margin-left", B); $("#divider").css("margin-left", B)
						}
					}
				})
			}); $(document).mouseup(function (z) {
				$(document).unbind("mousemove")
			})
		}; w()
	}; var h = function () {
		var w = /android.*chrom(e|ium)/.test(navigator.userAgent.toLowerCase()); if (/Android|webOS|iPhone|iPad|iPod|BlackBerry/i.test(navigator.userAgent) && w == false) {
			$("#sidebar").css("overflow-y", "auto")
		} else {
			if ($("#sidebar").hasClass("sidebar-fixed") || $(window).width() <= 767) {
				if (w) {
					var x = 100; $("#sidebar").attr("style", "position: absolute !important;"); if ($(window).width() > 979) {
						$("#sidebar").css("margin-top", "-52px")
					} if ($(window).width() <= 767) {
						$("#sidebar").css("margin-left", "-250px").css("margin-top", "-52px")
					}
				} else {
					var x = 7
				} $("#sidebar-content").slimscroll({
					height: "100%", wheelStep: x
				})
			}
		}
	}; var e = function () {
		function w(z) {
			$("body").removeClass(function (A, B) {
				return (B.match(/\btheme-\S+/g) || []).join(" ")
			}); $("body").addClass("theme-" + z); $.cookie("theme", z, {
				path: "/"
			}); if (z == "dark") {
				x("add")
			} else {
				x("remove")
			}
		} function x(z) {
			$("#theme-switcher .btn").each(function () {
				if (z == "add") {
					$(this).addClass("btn-inverse")
				} else {
					$(this).removeClass("btn-inverse")
				}
			})
		} if ($.cookie) {
			$("#theme-switcher label").click(function () {
				var z = $(this).find("input"); var A = z.data("theme"); w(A)
			}); if ($.cookie("theme")) {
				var y = $.cookie("theme"); w(y); $("#theme-switcher input").each(function () {
					var z = $(this); var A = z.data("theme"); if (A == y) {
						z.parent().addClass("active")
					} else {
						z.parent().removeClass("active")
					}
				}); if (y == "dark") {
					x("add")
				} else {
					x("remove")
				}
			}
		}
	}; var i = function () {
		$(".widget .toolbar .widget-collapse").click(function () {
			var z = $(this).parents(".widget"); var w = z.children(".widget-content"); var y = z.children(".widget-chart"); var x = z.children(".divider"); if (z.hasClass("widget-closed")) {
				$(this).children("i").removeClass("icon-angle-up").addClass("icon-angle-down"); w.slideDown(200, function () {
					z.removeClass("widget-closed")
				}); y.slideDown(200); x.slideDown(200)
			} else {
				$(this).children("i").removeClass("icon-angle-down").addClass("icon-angle-up"); w.slideUp(200, function () {
					z.addClass("widget-closed")
				}); y.slideUp(200); x.slideUp(200)
			}
		})
	}; var k = function () {
		$(".table-checkable thead th.checkbox-column :checkbox").on("change", function () {
			var y = $(this).prop("checked"); var w = $(this).parents("table.table-checkable").data("horizontalWidth"); if (typeof w != "undefined") {
				var x = $(this).parents(".dataTables_scroll").find(".dataTables_scrollBody tbody")
			} else {
				var x = $(this).parents("table").children("tbody")
			} x.each(function (A, z) {
				$(z).find(".checkbox-column").each(function (C, B) {
					var D = $(":checkbox", $(B)).prop("checked", y).trigger("change"); if (D.hasClass("uniform")) {
						$.uniform.update(D)
					} $(B).closest("tr").toggleClass("checked", y)
				})
			})
		}); $(".table-checkable tbody tr td.checkbox-column :checkbox").on("change", function () {
			var w = $(this).prop("checked"); $(this).closest("tr").toggleClass("checked", w)
		})
	}; var j = function () {
		var x = function (y) {
			$(y).each(function () {
				var A = $($($(this).attr("href"))); var z = $(this).parent().parent(); if (z.height() > A.height()) {
					A.css("min-height", z.height())
				}
			})
		}; $("body").on("click", '.nav.nav-tabs.tabs-left a[data-toggle="tab"], .nav.nav-tabs.tabs-right a[data-toggle="tab"]', function () {
			x($(this))
		}); x('.nav.nav-tabs.tabs-left > li.active > a[data-toggle="tab"], .nav.nav-tabs.tabs-right > li.active > a[data-toggle="tab"]'); if (location.hash) {
			var w = location.hash.substr(1); $('a[href="#' + w + '"]').click()
		}
	}; var a = function () {
		$(".scroller").each(function () {
			$(this).slimScroll({
				size: "7px", opacity: "0.2", position: "right", height: $(this).attr("data-height"), alwaysVisible: ($(this).attr("data-always-visible") == "1" ? true : false), railVisible: ($(this).attr("data-rail-visible") == "1" ? true : false), disableFadeOut: true
			})
		})
	}; var p = function () {
		c(); $(".project-switcher-btn").click(function (y) {
			y.preventDefault(); w(this); $(this).parent().toggleClass("open"); var z = x(this); $(z).slideToggle(200, function () {
				$(this).toggleClass("open")
			})
		}); $("body").click(function (z) {
			var y = z.target.className.split(" "); if ($.inArray("project-switcher", y) == -1 && $.inArray("project-switcher-btn", y) == -1 && $(z.target).parents().index($(".project-switcher")) == -1 && $(z.target).parents(".project-switcher-btn").length == 0) {
				w()
			}
		}); $(".project-switcher #frame").each(function () {
			$(this).slimScrollHorizontal({
				width: "100%", alwaysVisible: true, color: "#fff", opacity: "0.2", size: "5px"
			})
		}); var w = function (y) {
			$(".project-switcher").each(function () {
				var z = $(this); if (z.is(":visible")) {
					var A = x(y); if (A != ("#" + z.attr("id"))) {
						$(this).slideUp(200, function () {
							$(this).toggleClass("open"); $(".project-switcher-btn").each(function () {
								var B = x(this); if (B == ("#" + z.attr("id"))) {
									$(this).parent().removeClass("open")
								}
							})
						})
					}
				}
			})
		}; var x = function (y) {
			var z = $(y).data("projectSwitcher"); if (typeof z == "undefined") {
				z = "#project-switcher"
			} return z
		}
	}; var c = function () {
		$(".project-switcher").each(function () {
			var x = $(this); x.css("position", "absolute").css("margin-top", "-1000px").show(); var w = 0; $("ul li", this).each(function () {
				w += $(this).outerWidth(true) + 15
			}); x.css("position", "relative").css("margin-top", "0").hide(); $("ul", this).width(w)
		})
	}; return {
		init: function () {
			u(); s(); t(); f(); d(); h(); e(); i(); k(); j(); a(); p()
		}, getLayoutColorCode: function (w) {
			if (m[w]) {
				return m[w]
			} else {
				return ""
			}
		}, blockUI: function (w, x) {
			var w = $(w); w.block({
				message: '<img src="./assets/img/ajax-loading.gif" alt="">', centerY: x != undefined ? x : true, css: {
					top: "10%", border: "none", padding: "2px", backgroundColor: "none"
				}, overlayCSS: {
					backgroundColor: "#000", opacity: 0.05, cursor: "wait"
				}
			})
		}, unblockUI: function (w) {
			$(w).unblock({
				onUnblock: function () {
					$(w).removeAttr("style")
				}
			})
		}
	}
}();