/*
jQWidgets v3.0.3 (2013-Oct-01)
Copyright (c) 2011-2013 jQWidgets.
License: http://jqwidgets.com/license/
*/

(function (a) {
	a.extend(a.jqx._jqxGrid.prototype, {
		exportdata: function (p, x, w, n, q, s, f) {
			if (!a.jqx.dataAdapter.ArrayExporter) {
				throw "jqxGrid: Missing reference to jqxdata.export.js!"
			}
			if (w == undefined) {
				w = true
			}
			var F = this;
			if (n == undefined) {
				var n = this.getrows();
				if (n.length == 0) {
					throw "No data to export."
				}
			}
			this.exporting = true;
			if (this.altrows) {
				this._renderrows(this.virtualsizeinfo)
			}
			var D = q != undefined ? q : false;
			var C = {};
			var m = {};
			var u = [];
			var l = this.host.find(".jqx-grid-cell:first");
			var v = this.host.find(".jqx-grid-cell-alt:first");
			l.removeClass(this.toThemeProperty("jqx-grid-cell-selected"));
			l.removeClass(this.toThemeProperty("jqx-fill-state-pressed"));
			v.removeClass(this.toThemeProperty("jqx-grid-cell-selected"));
			v.removeClass(this.toThemeProperty("jqx-fill-state-pressed"));
			l.removeClass(this.toThemeProperty("jqx-grid-cell-hover"));
			l.removeClass(this.toThemeProperty("jqx-fill-state-hover"));
			v.removeClass(this.toThemeProperty("jqx-grid-cell-hover"));
			v.removeClass(this.toThemeProperty("jqx-fill-state-hover"));
			var g = "cell";
			var e = 1;
			var E = "column";
			var c = 1;
			var h = [];
			for (var z = 0; z < this.columns.records.length; z++) {
				var d = this.columns.records[z];
				if (d.cellclassname != "") {
					d.customCellStyles = new Array();
					if (typeof d.cellclassname == "string") {
						d.customCellStyles.push(d.cellclassname)
					} else {
						for (var A = 0; A < n.length; A++) {
							var t = this.getrowboundindex(A);
							var b = d.cellclassname(t, d.displayfield, n[A][d.displayfield]);
							if (b) {
								d.customCellStyles[A] = b
							}
						}
					}
				}
			}
			a.each(this.columns.records, function (I) {
				var L = a(F.table[0].rows[0].cells[I]);
				if (F.table[0].rows.length > 1) {
					var j = a(F.table[0].rows[1].cells[I])
				}
				var H = this;
				var J = function (N) {
					N.removeClass(F.toThemeProperty("jqx-grid-cell-selected"));
					N.removeClass(F.toThemeProperty("jqx-fill-state-pressed"));
					N.removeClass(F.toThemeProperty("jqx-grid-cell-hover"));
					N.removeClass(F.toThemeProperty("jqx-fill-state-hover"));
					if (H.customCellStyles) {
						for (var O in H.customCellStyles) {
							N.removeClass(H.customCellStyles[O])
						}
					}
				};
				J(L);
				if (j) {
					J(j)
				}
				if (this.displayfield == null) {
					return true
				}
				if (F.showaggregates) {
					if (F.getcolumnaggregateddata) {
						h.push(F.getcolumnaggregateddata(this.displayfield, this.aggregates, true, n))
					}
				}
				var K = F._getexportcolumntype(this);
				if (this.exportable && (!this.hidden || D)) {
					C[this.displayfield] = {};
					C[this.displayfield].text = this.text;
					C[this.displayfield].width = parseInt(this.width);
					if (isNaN(C[this.displayfield].width)) {
						C[this.displayfield].width = 60
					}
					C[this.displayfield].formatString = this.cellsformat;
					C[this.displayfield].localization = F.gridlocalization;
					C[this.displayfield].type = K;
					C[this.displayfield].cellsAlign = this.cellsalign;
					C[this.displayfield].hidden = !w
				}
				g = "cell" + e;
				var M = a(this.element);
				if (this.element == undefined) {
					M = a(this.uielement)
				}
				E = "column" + c;
				if (p == "html" || p == "xls" || p == "pdf") {
					var i = function (N, V, U, O, T, Q, P, R, S) {
						m[N] = {};
						m[N]["font-size"] = V.css("font-size");
						m[N]["font-weight"] = V.css("font-weight");
						m[N]["font-style"] = V.css("font-style");
						m[N]["background-color"] = Q._getexportcolor(V.css("background-color"));
						m[N]["color"] = Q._getexportcolor(V.css("color"));
						m[N]["border-color"] = Q._getexportcolor(V.css("border-top-color"));
						if (U) {
							m[N]["text-align"] = T.align
						} else {
							m[N]["text-align"] = T.cellsalign;
							m[N]["formatString"] = T.cellsformat;
							m[N]["dataType"] = K
						} if (p == "html" || p == "pdf") {
							m[N]["border-top-width"] = V.css("border-top-width");
							m[N]["border-left-width"] = V.css("border-left-width");
							m[N]["border-right-width"] = V.css("border-right-width");
							m[N]["border-bottom-width"] = V.css("border-bottom-width");
							m[N]["border-top-style"] = V.css("border-top-style");
							m[N]["border-left-style"] = V.css("border-left-style");
							m[N]["border-right-style"] = V.css("border-right-style");
							m[N]["border-bottom-style"] = V.css("border-bottom-style");
							if (U) {
								if (P == 0) {
									m[N]["border-left-width"] = V.css("border-right-width")
								}
								m[N]["border-top-width"] = V.css("border-right-width");
								m[N]["border-bottom-width"] = V.css("border-bottom-width")
							} else {
								if (P == 0) {
									m[N]["border-left-width"] = V.css("border-right-width")
								}
							}
							m[N]["height"] = V.css("height")
						}
						if (T.exportable && (!T.hidden || D)) {
							if (R == true) {
								if (!C[T.displayfield].customCellStyles) {
									C[T.displayfield].customCellStyles = new Array()
								}
								C[T.displayfield].customCellStyles[S] = N
							} else {
								if (U) {
									C[T.displayfield].style = N
								} else {
									if (!O) {
										C[T.displayfield].cellStyle = N
									} else {
										C[T.displayfield].cellAltStyle = N
									}
								}
							}
						}
					};
					i(E, M, true, false, this, F, I);
					c++;
					i(g, L, false, false, this, F, I);
					if (F.altrows) {
						g = "cellalt" + e;
						i(g, j, false, true, this, F, I)
					}
					if (this.customCellStyles) {
						for (var G in H.customCellStyles) {
							L.removeClass(H.customCellStyles[G])
						}
						for (var G in H.customCellStyles) {
							L.addClass(H.customCellStyles[G]);
							i(g + H.customCellStyles[G], L, false, false, this, F, I, true, G);
							L.removeClass(H.customCellStyles[G])
						}
					}
					e++
				}
			});
			if (this.showaggregates) {
				var B = [];
				var y = p == "xls" ? "AG" : "";
				var k = this.groupable ? this.groups.length : 0;
				if (this.rowdetails) {
					k++
				}
				if (h.length > 0) {
					a.each(this.columns.records, function (j) {
						if (this.aggregates) {
							for (var H = 0; H < this.aggregates.length; H++) {
								if (!B[H]) {
									B[H] = {}
								}
								if (B[H]) {
									var I = F._getaggregatename(this.aggregates[H]);
									var J = F._getaggregatetype(this.aggregates[H]);
									var G = h[j - k];
									if (G) {
										B[H][this.displayfield] = y + I + ": " + G[J]
									}
								}
							}
						}
					});
					a.each(this.columns.records, function (j) {
						for (var G = 0; G < B.length; G++) {
							if (B[G][this.displayfield] == undefined) {
								B[G][this.displayfield] = y
							}
						}
					})
				}
				a.each(B, function () {
					n.push(this)
				})
			}
			var r = a.jqx.dataAdapter.ArrayExporter(n, C, m);
			if (x == undefined) {
				this._renderrows(this.virtualsizeinfo);
				var o = r.exportTo(p);
				if (this.showaggregates) {
					a.each(B, function () {
						n.pop(this)
					})
				}
				this.exporting = false;
				return o
			} else {
				r.exportToFile(p, x, s, f)
			} if (this.showaggregates) {
				a.each(B, function () {
					n.pop(this)
				})
			}
			this._renderrows(this.virtualsizeinfo);
			this.exporting = false
		},
		_getexportcolor: function (l) {
			var f = l;
			if (l == "transparent") {
				f = "#FFFFFF"
			}
			if (!f || !f.toString()) {
				f = "#FFFFFF"
			}
			if (f.toString().indexOf("rgb") != -1) {
				var i = f.split(",");
				if (f.toString().indexOf("rgba") != -1) {
					var d = parseInt(i[0].substring(5));
					var h = parseInt(i[1]);
					var j = parseInt(i[2]);
					var k = parseInt(i[3].substring(1, 4));
					var m = {
						r: d,
						g: h,
						b: j
					};
					var e = this._rgbToHex(m);
					if (d == 0 && h == 0 && j == 0 && k == 0) {
						return "#ffffff"
					}
					return "#" + e
				}
				var d = parseInt(i[0].substring(4));
				var h = parseInt(i[1]);
				var j = parseInt(i[2].substring(1, 4));
				var m = {
					r: d,
					g: h,
					b: j
				};
				var e = this._rgbToHex(m);
				return "#" + e
			} else {
				if (f.toString().indexOf("#") != -1) {
					if (f.toString().length == 4) {
						var c = f.toString().substring(1, 4);
						f += c
					}
				}
			}
			return f
		},
		_rgbToHex: function (b) {
			return this._intToHex(b.r) + this._intToHex(b.g) + this._intToHex(b.b)
		},
		_intToHex: function (c) {
			var b = (parseInt(c).toString(16));
			if (b.length == 1) {
				b = ("0" + b)
			}
			return b.toUpperCase()
		},
		_getexportcolumntype: function (f) {
			var g = this;
			var e = "string";
			var d = g.source.datafields || ((g.source._source) ? g.source._source.datafields : null);
			if (d) {
				var i = "";
				a.each(d, function () {
					if (this.name == f.displayfield) {
						if (this.type) {
							i = this.type
						}
						return false
					}
				});
				if (i) {
					return i
				}
			}
			if (f != null) {
				if (this.dataview.cachedrecords == undefined) {
					return e
				}
				var b = null;
				if (!this.virtualmode) {
					if (this.dataview.cachedrecords.length == 0) {
						return e
					}
					b = this.dataview.cachedrecords[0][f.displayfield];
					if (b != null && b.toString() == "") {
						return "string"
					}
				} else {
					a.each(this.dataview.cachedrecords, function () {
						b = this[f.displayfield];
						return false
					})
				} if (b != null) {
					if (f.cellsformat.indexOf("c") != -1) {
						return "number"
					}
					if (f.cellsformat.indexOf("n") != -1) {
						return "number"
					}
					if (f.cellsformat.indexOf("p") != -1) {
						return "number"
					}
					if (f.cellsformat.indexOf("d") != -1) {
						return "date"
					}
					if (f.cellsformat.indexOf("y") != -1) {
						return "date"
					}
					if (f.cellsformat.indexOf("M") != -1) {
						return "date"
					}
					if (f.cellsformat.indexOf("m") != -1) {
						return "date"
					}
					if (f.cellsformat.indexOf("t") != -1) {
						return "date"
					}
					if (typeof b == "boolean") {
						e = "boolean"
					} else {
						if (a.jqx.dataFormat.isNumber(b)) {
							e = "number"
						} else {
							var h = new Date(b);
							if (h.toString() == "NaN" || h.toString() == "Invalid Date") {
								if (a.jqx.dataFormat) {
									h = a.jqx.dataFormat.tryparsedate(b);
									if (h != null) {
										if (h && h.getFullYear()) {
											if (h.getFullYear() == 1970 && h.getMonth() == 0 && h.getDate() == 1) {
												var c = new Number(b);
												if (!isNaN(c)) {
													return "number"
												}
												return "string"
											}
										}
										return "date"
									} else {
										e = "string"
									}
								} else {
									e = "string"
								}
							} else {
								e = "date"
							}
						}
					}
				}
			}
			return e
		}
	})
})(jQuery);