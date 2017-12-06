/*
jQWidgets v3.0.3 (2013-Oct-01)
Copyright (c) 2011-2013 jQWidgets.
License: http://jqwidgets.com/license/
*/

(function (i) {
	i.jqx.dataAdapter = function (J, e) {
		if (J != undefined) {
			if (J.dataFields !== undefined) {
				J.datafields = J.dataFields
			}
			if (J.dataType !== undefined) {
				J.datatype = J.dataType
			}
			if (J.localData !== undefined) {
				J.localdata = J.localData
			}
			if (J.sortColumn !== undefined) {
				J.sortcolumn = J.sortColumn
			}
			if (J.sortDirection !== undefined) {
				J.sortdirection = J.sortDirection
			}
			if (J.sortOrder !== undefined) {
				J.sortdirection = J.sortOrder
			}
			if (J.formatData !== undefined) {
				J.formatdata = J.formatData
			}
			if (J.processData !== undefined) {
				J.processdata = J.processData
			}
			if (J.pageSize !== undefined) {
				J.pagesize = J.pageSize
			}
			if (J.pageNum !== undefined) {
				J.pagenum = J.pageNum
			}
			if (J.updateRow !== undefined) {
				J.updaterow = J.updateRow
			}
			if (J.addRow !== undefined) {
				J.addrow = J.addRow
			}
			if (J.deleteRow !== undefined) {
				J.deleterow = J.deleteRow
			}
			if (J.contentType !== undefined) {
				J.contenttype = J.contentType
			}
			if (J.totalRecords != undefined) {
				J.totalRecords = J.totalRecords
			}
			if (J.loadError != undefined) {
				J.loadError = J.loadError
			}
			if (J.sortComparer != undefined) {
				J.sortcomparer = J.sortComparer
			}
		}
		this._source = J;
		this._options = e || {};
		this.records = new Array();
		this._downloadComplete = new Array();
		this._bindingUpdate = new Array();
		if (J != undefined && J.localdata != null && typeof J.localdata == "function") {
			var I = J.localdata();
			if (I != null) {
				J._localdata = J.localdata;
				var H = this;
				if (J._localdata.subscribe) {
					H._oldlocaldata = [];
					J._localdata.subscribe(function (K) {
						var L = function (M) {
							if (jQuery.isArray(M)) {
								return jQuery.makeArray(L(i(M)))
							}
							return jQuery.extend(true, {}, M)
						};
						if (H.suspendKO == false || H.suspendKO == undefined || H._oldlocaldata.length == 0) {
							H._oldlocaldata = L(K)
						}
					}, J._localdata, "beforeChange");
					J._localdata.subscribe(function (L) {
						if (H.suspendKO == false || H.suspendKO == undefined) {
							var K = "";
							H._oldrecords = H.records;
							if (H._oldlocaldata.length == 0) {
								J.localdata = J._localdata()
							}
							if (H._oldlocaldata.length == 0) {
								K = "change"
							} else {
								if (H._oldlocaldata.length == L.length) {
									K = "update"
								}
								if (H._oldlocaldata.length > L.length) {
									K = "remove"
								}
								if (H._oldlocaldata.length < L.length) {
									K = "add"
								}
							}
							H.dataBind(null, K)
						}
					}, J._localdata, "change");
					H._knockoutdatasource = true
				}
				J.localdata = I
			}
		}
		if (this._options.autoBind == true) {
			this.dataBind()
		}
	};
	i.jqx.dataAdapter.prototype = {
		getrecords: function () {
			return this.records
		},
		beginUpdate: function () {
			this.isUpdating = true
		},
		endUpdate: function (e) {
			this.isUpdating = false;
			if (e != false) {
				if (this._changedrecords && this._changedrecords.length > 0) {
					this.callBindingUpdate("update");
					this._changedrecords = []
				} else {
					this.dataBind(null, "")
				}
			}
		},
		formatDate: function (H, J, I) {
			var e = i.jqx.dataFormat.formatdate(H, J, I);
			return e
		},
		formatNumber: function (H, J, I) {
			var e = i.jqx.dataFormat.formatnumber(H, J, I);
			return e
		},
		dataBind: function (R, X) {
			if (this.isUpdating == true) {
				return
			}
			var U = this._source;
			if (!U) {
				return
			}
			i.jqx.dataFormat.datescache = new Array();
			if (U.dataFields != null) {
				U.datafields = U.dataFields
			}
			if (U.recordstartindex == undefined) {
				U.recordstartindex = 0
			}
			if (U.recordendindex == undefined) {
				U.recordendindex = 0
			}
			if (U.loadallrecords == undefined) {
				U.loadallrecords = true
			}
			if (U.sort != undefined) {
				this.sort = U.sort
			}
			if (U.filter != undefined) {
				this.filter = U.filter
			} else {
				this.filter = null
			} if (U.sortcolumn != undefined) {
				this.sortcolumn = U.sortcolumn
			}
			if (U.sortdirection != undefined) {
				this.sortdirection = U.sortdirection
			}
			if (U.sortcomparer != undefined) {
				this.sortcomparer = U.sortcomparer
			}
			this.records = new Array();
			var K = this._options || {};
			this.virtualmode = K.virtualmode != undefined ? K.virtualmode : false;
			this.totalrecords = K.totalrecords != undefined ? K.totalrecords : 0;
			this.pageable = K.pageable != undefined ? K.pageable : false;
			this.pagesize = K.pagesize != undefined ? K.pagesize : 0;
			this.pagenum = K.pagenum != undefined ? K.pagenum : 0;
			this.cachedrecords = K.cachedrecords != undefined ? K.cachedrecords : new Array();
			this.originaldata = new Array();
			this.recordids = new Array();
			this.updaterow = K.updaterow != undefined ? K.updaterow : null;
			this.addrow = K.addrow != undefined ? K.addrow : null;
			this.deleterow = K.deleterow != undefined ? K.deleterow : null;
			this.cache = K.cache != undefined ? K.cache : false;
			this.unboundmode = false;
			if (U.formatdata != undefined) {
				K.formatData = U.formatdata
			}
			if (U.data != undefined) {
				if (K.data == undefined) {
					K.data = {}
				}
				i.extend(K.data, U.data)
			}
			if (U.mapchar != undefined) {
				this.mapChar = U.mapchar ? U.mapchar : ">"
			} else {
				this.mapChar = K.mapChar ? K.mapChar : ">"
			} if (K.unboundmode || U.unboundmode) {
				this.unboundmode = K.unboundmode || U.unboundmode
			}
			if (U.cache != undefined) {
				this.cache = U.cache
			}
			if (this.koSubscriptions) {
				for (var Z = 0; Z < this.koSubscriptions.length; Z++) {
					this.koSubscriptions[Z].dispose()
				}
			}
			this.koSubscriptions = new Array();
			if (this.pagenum < 0) {
				this.pagenum = 0
			}
			var ae = this;
			var Q = U.datatype;
			if (U.datatype === "csv" || U.datatype === "tab" || U.datatype == "text") {
				Q = "text"
			}
			var N = K.async != undefined ? K.async : true;
			if (U.async != undefined) {
				N = U.async
			}
			switch (Q) {
				case "local":
				case "array":
				case "observablearray":
				default:
					if (U.localdata == undefined && U.length) {
						U.localdata = new Array();
						for (var W = 0; W < U.length; W++) {
							U.localdata[U.localdata.length] = U[W];
							U[W].uid = W
						}
					}
					var M = U.localdata.length;
					this.totalrecords = this.virtualmode ? (U.totalrecords || M) : M;
					if (this.unboundmode) {
						this.totalrecords = this.unboundmode ? (U.totalrecords || M) : M;
						var aa = U.datafields ? U.datafields.length : 0;
						if (aa > 0) {
							for (var W = 0; W < this.totalrecords; W++) {
								var I = {};
								for (var V = 0; V < aa; V++) {
									I[U.datafields[V].name] = ""
								}
								I.uid = W;
								U.localdata[U.localdata.length] = I
							}
						}
					}
					if (this.totalrecords == undefined) {
						this.totalrecords = 0
					}
					var aa = U.datafields ? U.datafields.length : 0;
					var H = function (ak, am) {
						var al = {};
						for (var ai = 0; ai < am; ai++) {
							var ah = U.datafields[ai];
							var an = "";
							if (undefined == ah || ah == null) {
								continue
							}
							if (ah.map) {
								if (i.isFunction(ah.map)) {
									an = ah.map(ak)
								} else {
									var af = ah.map.split(ae.mapChar);
									if (af.length > 0) {
										var aj = ak;
										for (var ag = 0; ag < af.length; ag++) {
											aj = aj[af[ag]]
										}
										an = aj
									} else {
										an = ak[ah.map]
									}
								} if (an != undefined && an != null) {
									an = an.toString()
								} else {
									if (an == undefined && an != null) {
										an = ""
									}
								}
							}
							if (an == "") {
								an = ak[ah.name];
								if (an != undefined && an != null) {
									if (U._localdata && an.subscribe) {
										an = an()
									} else {
										an = an.toString()
									}
								}
							}
							an = ae.getvaluebytype(an, ah);
							if (ah.displayname != undefined) {
								al[ah.displayname] = an
							} else {
								al[ah.name] = an
							}
						}
						return al
					};
					if (U._localdata) {
						this._changedrecords = [];
						this.records = new Array();
						var ad = U._localdata();
						i.each(ad, function (ai, al) {
							if (typeof al === "string") {
								ae.records.push(al)
							} else {
								var ag = {};
								var ak = 0;
								var aj = this;
								i.each(this, function (au, ax) {
									var ao = null;
									var ay = "string";
									if (aa > 0) {
										var aA = false;
										for (var at = 0; at < aa; at++) {
											var ar = U.datafields[at];
											if (ar != undefined && ar.name == au) {
												aA = true;
												ao = ar.map;
												ay = ar.type;
												break
											}
										}
										if (!aA) {
											return true
										}
									}
									var aq = i.isFunction(aj[au]);
									if (aq) {
										var az = aj[au]();
										if (ay != "string") {
											az = ae.getvaluebytype(az, {
												type: ay
											})
										}
										ag[au] = az;
										if (aj[au].subscribe) {
											var aw = ai;
											ae.koSubscriptions[ae.koSubscriptions.length] = aj[au].subscribe(function (aC) {
												var aB = aw;
												ag[au] = aC;
												var aD = {
													index: aB,
													oldrecord: ag,
													record: ag
												};
												ae._changedrecords.push(aD);
												if (ae.isUpdating) {
													return
												}
												ae.callBindingUpdate("update");
												ae._changedrecords = [];
												return false
											})
										}
									} else {
										var az = aj[au];
										if (ao != null) {
											var an = ao.split(ae.mapChar);
											if (an.length > 0) {
												var av = aj;
												for (var ap = 0; ap < an.length; ap++) {
													av = av[an[ap]]
												}
												az = av
											} else {
												az = aj[ao]
											}
										}
										if (ay != "string") {
											az = ae.getvaluebytype(az, {
												type: ay
											})
										}
										ag[au] = az;
										if (ag[au] != undefined) {
											ak += ag[au].toString().length + ag[au].toString().substr(0, 1)
										}
									}
								});
								var ah = ae.getid(U.id, aj, ai);
								ag.uid = ah;
								ae.records.push(ag);
								ag._koindex = ak;
								if (ae._oldrecords) {
									var af = ae.records.length - 1;
									if (X == "update") {
										if (ae._oldrecords[af]._koindex != ak) {
											var am = {
												index: af,
												oldrecord: ae._oldrecords[af],
												record: ag
											};
											ae._changedrecords.push(am)
										}
									}
								}
							}
						});
						if (X == "add") {
							var M = ae.records.length;
							for (var W = 0; W < M; W++) {
								var I = ae.records[W];
								var L = false;
								for (var T = 0; T < ae._oldrecords.length; T++) {
									if (ae._oldrecords[T]._koindex === I._koindex) {
										L = true;
										break
									}
								}
								if (!L) {
									ae._changedrecords.push({
										index: W,
										oldrecord: null,
										record: I,
										position: (W != 0 ? "last" : "first")
									})
								}
							}
						} else {
							if (X == "remove") {
								var M = ae._oldrecords.length;
								for (var W = 0; W < M; W++) {
									var P = ae._oldrecords[W];
									if (!ae.records[W]) {
										ae._changedrecords.push({
											index: W,
											oldrecord: P,
											record: null
										})
									} else {
										if (ae.records[W]._koindex != P._koindex) {
											ae._changedrecords.push({
												index: W,
												oldrecord: P,
												record: null
											})
										}
									}
								}
							}
						}
					} else {
						if (!i.isArray(U.localdata)) {
							this.records = new Array();
							i.each(U.localdata, function (ah) {
								var ag = ae.getid(U.id, this, ah);
								if (aa > 0) {
									var af = this;
									var ai = H(af, aa);
									ai.uid = ag;
									ae.records[ae.records.length] = ai
								} else {
									this.uid = ag;
									ae.records[ae.records.length] = this
								}
							})
						} else {
							if (aa == 0) {
								i.each(U.localdata, function (ah, ai) {
									var af = i.extend({}, this);
									if (typeof ai === "string") {
										ae.records = U.localdata;
										return false
									} else {
										var ag = ae.getid(U.id, af, ah);
										if (typeof (ag) === "object") {
											ag = ah
										}
										af.uid = ag;
										ae.records[ae.records.length] = af
									}
								})
							} else {
								i.each(U.localdata, function (ah) {
									var af = this;
									var ai = H(af, aa);
									var ag = ae.getid(U.id, ai, ah);
									if (typeof (ag) === "object") {
										ag = ah
									}
									var af = i.extend({}, ai);
									af.uid = ag;
									ae.records[ae.records.length] = af
								})
							}
						}
					}
					this.originaldata = U.localdata;
					this.cachedrecords = this.records;
					this.addForeignValues(U);
					if (K.uniqueDataFields) {
						var S = this.getUniqueRecords(this.records, K.uniqueDataFields);
						this.records = S;
						this.cachedrecords = S
					}
					if (K.beforeLoadComplete) {
						var ab = K.beforeLoadComplete(ae.records, this.originaldata);
						if (ab != undefined) {
							ae.records = ab;
							ae.cachedrecords = ab
						}
					}
					if (K.autoSort && K.autoSortField) {
						var O = Object.prototype.toString;
						Object.prototype.toString = (typeof field == "function") ? field : function () {
							return this[K.autoSortField]
						};
						ae.records.sort(function (ag, af) {
							if (ag === undefined) {
								ag = null
							}
							if (af === undefined) {
								af = null
							}
							if (ag === null && af === null) {
								return 0
							}
							if (ag === null && af !== null) {
								return 1
							}
							if (ag !== null && af === null) {
								return -1
							}
							ag = ag.toString();
							af = af.toString();
							if (i.jqx.dataFormat.isNumber(ag) && i.jqx.dataFormat.isNumber(af)) {
								if (ag < af) {
									return -1
								}
								if (ag > af) {
									return 1
								}
								return 0
							} else {
								if (i.jqx.dataFormat.isDate(ag) && i.jqx.dataFormat.isDate(af)) {
									if (ag < af) {
										return -1
									}
									if (ag > af) {
										return 1
									}
									return 0
								} else {
									if (!i.jqx.dataFormat.isNumber(ag) && !i.jqx.dataFormat.isNumber(af)) {
										ag = String(ag).toLowerCase();
										af = String(af).toLowerCase()
									}
								}
							}
							try {
								if (ag < af) {
									return -1
								}
								if (ag > af) {
									return 1
								}
							} catch (ah) {
								var ai = ah
							}
							return 0
						});
						Object.prototype.toString = O
					}
					ae.buildHierarchy();
					if (i.isFunction(K.loadComplete)) {
						K.loadComplete(U.localdata)
					}
					break;
				case "json":
				case "jsonp":
				case "xml":
				case "xhtml":
				case "script":
				case "text":
					if (U.localdata != null) {
						if (i.isFunction(U.beforeprocessing)) {
							U.beforeprocessing(U.localdata)
						}
						if (U.datatype === "xml") {
							ae.loadxml(U.localdata, U.localdata, U)
						} else {
							if (Q === "text") {
								ae.loadtext(U.localdata, U)
							} else {
								ae.loadjson(U.localdata, U.localdata, U)
							}
						}
						ae.addForeignValues(U);
						if (K.uniqueDataFields) {
							var S = ae.getUniqueRecords(ae.records, K.uniqueDataFields);
							ae.records = S;
							ae.cachedrecords = S
						}
						ae.buildHierarchy.call(ae);
						if (i.isFunction(K.loadComplete)) {
							K.loadComplete(U.localdata)
						}
						return
					}
					var ac = K.data != undefined ? K.data : {};
					if (U.processdata) {
						U.processdata(ac)
					}
					if (i.isFunction(K.processData)) {
						K.processData(ac)
					}
					if (i.isFunction(K.formatData)) {
						var e = K.formatData(ac);
						if (e != undefined) {
							ac = e
						}
					}
					var Y = "application/x-www-form-urlencoded";
					if (K.contentType) {
						Y = K.contentType
					}
					var J = "GET";
					if (U.type) {
						J = U.type
					}
					if (K.type) {
						J = K.type
					}
					if (U.url && U.url.length > 0) {
						if (i.isFunction(K.loadServerData)) {
							ae._requestData(ac, U, K)
						} else {
							this.xhr = i.jqx.data.ajax({
								dataType: Q,
								cache: this.cache,
								type: J,
								url: U.url,
								async: N,
								contentType: Y,
								data: ac,
								success: function (ai, af, al) {
									if (i.isFunction(U.beforeprocessing)) {
										var ak = U.beforeprocessing(ai, af, al);
										if (ak != undefined) {
											ai = ak
										}
									}
									if (i.isFunction(K.downloadComplete)) {
										var ak = K.downloadComplete(ai, af, al);
										if (ak != undefined) {
											ai = ak
										}
									}
									if (ai == null) {
										ae.records = new Array();
										ae.cachedrecords = new Array();
										ae.originaldata = new Array();
										ae.callDownloadComplete();
										if (i.isFunction(K.loadComplete)) {
											K.loadComplete(new Array())
										}
										return
									}
									var ag = ai;
									if (ai.records) {
										ag = ai.records
									}
									if (ai.totalrecords != undefined) {
										U.totalrecords = ai.totalrecords
									}
									if (U.datatype === "xml") {
										ae.loadxml(null, ag, U)
									} else {
										if (Q === "text") {
											ae.loadtext(ag, U)
										} else {
											ae.loadjson(null, ag, U)
										}
									}
									ae.addForeignValues(U);
									if (K.uniqueDataFields) {
										var ah = ae.getUniqueRecords(ae.records, K.uniqueDataFields);
										ae.records = ah;
										ae.cachedrecords = ah
									}
									if (K.beforeLoadComplete) {
										var aj = K.beforeLoadComplete(ae.records, ai);
										if (aj != undefined) {
											ae.records = aj;
											ae.cachedrecords = aj
										}
									}
									ae.buildHierarchy.call(ae);
									ae.callDownloadComplete();
									if (i.isFunction(K.loadComplete)) {
										K.loadComplete(ai, af, al, ae.records)
									}
								},
								error: function (ah, af, ag) {
									if (i.isFunction(U.loaderror)) {
										U.loaderror(ah, af, ag)
									}
									if (i.isFunction(K.loadError)) {
										K.loadError(ah, af, ag)
									}
									ah = null;
									ae.callDownloadComplete()
								},
								beforeSend: function (ag, af) {
									if (i.isFunction(K.beforeSend)) {
										K.beforeSend(ag, af)
									}
									if (i.isFunction(U.beforesend)) {
										U.beforesend(ag, af)
									}
								}
							})
						}
					} else {
						ae.callDownloadComplete();
						if (i.isFunction(K.loadComplete)) {
							K.loadComplete(data)
						}
					}
					break
			}
			this.callBindingUpdate(X)
		},
		buildHierarchy: function () {
			var e = this._source;
			var L = new Array();
			if (!e.datafields) {
				return
			}
			var M = false;
			var O = "";
			for (var J = 0; J < e.datafields.length; J++) {
				var I = e.datafields[J];
				if (I && I.type == "array") {
					O = I;
					M = true
				}
			}
			if (M) {
				if (!e.hierarchicalDataFields || e.hierarchicalDataFields.length == 0) {
					throw new Error("jqxDataAdapter: hierarchicalDataFields Array is not initialized!")
				}
				this.hierarchy = this.records;
				for (var J = 0; J < this.records.length; J++) {
					var K = this.records[J];
					K.records = K[O.name];
					K.level = 0;
					K.parent = null;
					K.label = K[e.hierarchicalDataFields[0].name];
					K.data = K;
					if (K.expanded === undefined) {
						K.expanded = false
					}
					var N = function (S, Q) {
						if (!Q) {
							S.records = new Array();
							return
						}
						for (var R = 0; R < Q.length; R++) {
							var P = Q[R];
							P.records = P[O.name];
							P.level = S.level + 1;
							P.parent = S;
							P.label = P[e.hierarchicalDataFields[0].name];
							P.data = P;
							if (P.expanded === undefined) {
								P.expanded = false
							}
							N(P, P.records)
						}
					};
					N(K, K.records)
				}
				return
			}
			if (e.hierarchicalDataFields) {
				var H = new Array();
				for (var J = 0; J < e.hierarchicalDataFields.length; J++) {
					H.push(e.hierarchicalDataFields[J].name)
				}
				var L = this.getGroupedRecords(H, "records", "label", null, "data", null, "parent")
			}
			this.hierarchy = L;
			return L
		},
		addForeignValues: function (H) {
			var Q = this;
			var V = H.datafields ? H.datafields.length : 0;
			for (var N = 0; N < V; N++) {
				var L = H.datafields[N];
				if (L != undefined) {
					if (L.values != undefined) {
						if (L.value == undefined) {
							L.value = L.name
						}
						if (L.values.value == undefined) {
							L.values.value = L.value
						}
						var T = new Array();
						var K, M;
						if (Q.pageable && Q.virtualmode) {
							K = Q.pagenum * Q.pagesize;
							M = K + Q.pagesize;
							if (M > Q.totalrecords) {
								M = Q.totalrecords
							}
						} else {
							K = 0;
							M = Q.records.length
						}
						for (var O = K; O < M; O++) {
							var P = Q.records[O];
							var I = L.name;
							var U = P[L.value];
							if (T[U] != undefined) {
								P[I] = T[U]
							} else {
								for (var J = 0; J < L.values.source.length; J++) {
									var S = L.values.source[J];
									var e = S[L.values.value];
									if (e == undefined) {
										e = S.uid
									}
									if (e == U) {
										var R = S[L.values.name];
										P[I] = R;
										T[U] = R;
										break
									}
								}
							}
						}
					} else {
						if (L.value != undefined) {
							for (var O = 0; O < Q.records.length; O++) {
								var P = Q.records[O];
								P[L.name] = P[L.value]
							}
						}
					}
				}
			}
		},
		abort: function () {
			if (this.xhr && this.xhr.readyState != 4) {
				this.xhr.abort();
				me.callDownloadComplete()
			}
		},
		_requestData: function (H, J, e) {
			var I = this;
			var K = function (L) {
				if (L.totalrecords) {
					J.totalrecords = L.totalrecords;
					I.totalrecords = L.totalrecords
				}
				if (L.records) {
					I.records = L.records;
					I.cachedrecords = L.records
				}
				if (i.isFunction(e.loadComplete)) {
					e.loadComplete(data)
				}
				I.callDownloadComplete()
			};
			e.loadServerData(H, J, K)
		},
		getUniqueRecords: function (I, L) {
			if (I && L) {
				var e = I.length;
				var Q = L.length;
				var N = new Array();
				var O = new Array();
				for (var P = 0; P < e; P++) {
					var M = I[P];
					var J = "";
					if (M == undefined) {
						continue
					}
					for (var K = 0; K < Q; K++) {
						var H = L[K];
						J += M[H] + "_"
					}
					if (!O[J]) {
						N[N.length] = M
					}
					O[J] = true
				}
			}
			return N
		},
		getAggregatedData: function (Q, M, K) {
			var J = K;
			if (!J) {
				J = this.records
			}
			var N = {};
			var I = J.length;
			if (I == 0) {
				return
			}
			if (I == undefined) {
				return
			}
			for (var O = 0; O < I; O++) {
				var P = J[O];
				for (var L = 0; L < Q.length; L++) {
					var H = Q[L];
					var S = P[H.name];
					if (H.aggregates) {
						N[H.name] = N[H.name] || {};
						var e = function (T) {
							for (obj in T) {
								var U = N[H.name][obj];
								if (U == null) {
									N[H.name][obj] = 0;
									U = 0
								}
								if (i.isFunction(T[obj])) {
									U = T[obj](U, S, H.name, P)
								}
								N[H.name][obj] = U
							}
						};
						var R = parseFloat(S);
						if (isNaN(R)) {
							R = false
						} else {
							R = true
						} if (R) {
							S = parseFloat(S)
						}
						if (typeof S === "number" && isFinite(S)) {
							i.each(H.aggregates, function () {
								var T = N[H.name][this];
								if (T == null) {
									T = 0;
									if (this == "min") {
										T = 9999999999999
									}
									if (this == "max") {
										T = -9999999999999
									}
								}
								if (this == "sum" || this == "avg" || this == "stdev" || this == "stdevp" || this == "var" || this == "varp") {
									T += parseFloat(S)
								} else {
									if (this == "product") {
										if (O == 0) {
											T = parseFloat(S)
										} else {
											T *= parseFloat(S)
										}
									} else {
										if (this == "min") {
											T = Math.min(T, parseFloat(S))
										} else {
											if (this == "max") {
												T = Math.max(T, parseFloat(S))
											} else {
												if (this == "count") {
													T++
												} else {
													if (typeof (this) == "object") {
														e(this);
														return
													}
												}
											}
										}
									}
								}
								N[H.name][this] = T
							})
						} else {
							i.each(H.aggregates, function () {
								if (this == "min" || this == "max" || this == "count" || this == "product" || this == "sum" || this == "avg" || this == "stdev" || this == "stdevp" || this == "var" || this == "varp") {
									var T = N[H.name][this];
									if (T == null) {
										T = 0
									}
									N[H.name][this] = T;
									return true
								}
								if (typeof (this) == "object") {
									e(this)
								}
							})
						}
					}
				}
			}
			for (var L = 0; L < Q.length; L++) {
				var H = Q[L];
				if (N[H.name]["avg"] != undefined) {
					var S = N[H.name]["avg"];
					N[H.name]["avg"] = S / J.length
				} else {
					if (N[H.name]["count"] != undefined) {
						N[H.name]["count"] = I
					}
				} if (N[H.name]["stdev"] || N[H.name]["stdevp"] || N[H.name]["var"] || N[H.name]["varp"]) {
					i.each(H.aggregates, function (Z) {
						if (this == "stdev" || this == "var" || this == "varp" || this == "stdevp") {
							var aa = N[H.name][this];
							var Y = I;
							var T = (aa / I);
							var V = 0;
							for (var W = 0; W < I; W++) {
								var X = J[W];
								var ab = X[H.name];
								V += (ab - T) * (ab - T)
							}
							var U = (this == "stdevp" || this == "varp") ? Y : Y - 1;
							if (U == 0) {
								U = 1
							}
							if (this == "var" || this == "varp") {
								N[H.name][this] = V / U
							} else {
								if (this == "stdevp" || this == "stdev") {
									N[H.name][this] = Math.sqrt(V / U)
								}
							}
						}
					})
				}
				if (H.formatStrings) {
					i.each(H.aggregates, function (U) {
						var T = H.formatStrings[U];
						if (T) {
							if (this == "min" || this == "max" || this == "count" || this == "product" || this == "sum" || this == "avg" || this == "stdev" || this == "stdevp" || this == "var" || this == "varp") {
								var V = N[H.name][this];
								N[H.name][this] = i.jqx.dataFormat.formatnumber(V, T, M)
							} else {
								if (typeof this == "object") {
									for (obj in this) {
										var V = N[H.name][obj];
										N[H.name][obj] = i.jqx.dataFormat.formatnumber(V, T, M)
									}
								}
							}
						}
					})
				}
			}
			return N
		},
		bindDownloadComplete: function (H, e) {
			this._downloadComplete[this._downloadComplete.length] = {
				id: H,
				func: e
			}
		},
		unbindDownloadComplete: function (H) {
			for (var e = 0; e < this._downloadComplete.length; e++) {
				if (this._downloadComplete[e].id == H) {
					this._downloadComplete[e].func = null;
					this._downloadComplete.splice(e, 1);
					break
				}
			}
		},
		callDownloadComplete: function () {
			for (var e = 0; e < this._downloadComplete.length; e++) {
				var H = this._downloadComplete[e];
				if (H.func != null) {
					H.func()
				}
			}
		},
		setSource: function (e) {
			this._source = e
		},
		generatekey: function () {
			var e = function () {
				return (((1 + Math.random()) * 65536) | 0).toString(16).substring(1)
			};
			return (e() + e() + "-" + e() + "-" + e() + "-" + e() + "-" + e() + e() + e())
		},
		getGroupedRecords: function (ah, ak, U, ac, ai, Z, ab) {
			var ae = 0;
			var Y = this;
			var I = new Array();
			for (var M = 0; M < ah.length; M++) {
				I[M] = Y.generatekey()
			}
			if (!ak) {
				ak = "items"
			}
			if (!U) {
				U = "group"
			}
			if (!ai) {
				ai = "record"
			}
			if (!ab) {
				ab = "parentItem"
			}
			if (undefined === Z) {
				Z = "value"
			}
			var Q = new Array();
			var K = 0;
			var J = new Array();
			var P = ah.length;
			var aj = new Array();
			var al = this.records;
			var N = al.length;
			var ad = function (am) {
				var an = am;
				if (ac) {
					i.each(ac, function () {
						if (this.name && this.map) {
							an[this.map] = an[this.name]
						}
					})
				}
				return an
			};
			for (var T = 0; T < N; T++) {
				var ag = ad(al[T]);
				id = ag[Y.uniqueId];
				var H = new Array();
				var V = 0;
				for (M = 0; M < P; M++) {
					var O = ah[M];
					var aa = ag[O];
					if (null == aa) {
						continue
					}
					H[V++] = {
						value: aa,
						hash: I[M]
					}
				}
				if (H.length != P) {
					break
				}
				var W = null;
				var R = "";
				var e = -1;
				for (var X = 0; X < H.length; X++) {
					e++;
					var af = H[X].value;
					var L = H[X].hash;
					R = R + "_" + L + "_" + af;
					if (J[R] != undefined && J[R] != null) {
						W = J[R];
						continue
					}
					if (W == null) {
						W = {
							level: 0
						};
						W[ab] = null;
						W[U] = af;
						W[ai] = ag;
						if (ag.expanded !== undefined) {
							W.expanded = ag.expanded
						} else {
							W.expanded = false
						} if (Z) {
							W[Z] = ag[Z]
						}
						W[ak] = new Array();
						Q[K++] = W
					} else {
						var S = {
							level: W.level + 1
						};
						S[ab] = W;
						S[U] = af;
						S[ak] = new Array();
						S[ai] = ag;
						if (ag.expanded !== undefined) {
							S.expanded = ag.expanded
						} else {
							S.expanded = false
						} if (Z) {
							S[Z] = ag[Z]
						}
						W[ak][W[ak].length] = S;
						W = S
					}
					J[R] = W;
					if (W != null && X === H.length - 1) {
						W.leaf = true
					}
				}
			}
			return Q
		},
		getRecordsHierarchy: function (K, I, X, S) {
			var e = new Array();
			var H = this.records;
			if (this.records.length == 0) {
				return null
			}
			var V = X != null ? X : "items";
			var P = [];
			var Y = H;
			var N = Y.length;
			var T = function (Z) {
				var aa = Z;
				if (S) {
					i.each(S, function () {
						if (this.name && this.map) {
							aa[this.map] = aa[this.name]
						}
					})
				}
				return aa
			};
			for (var U = 0; U < N; U++) {
				var W = i.extend({}, Y[U]);
				var R = W[I];
				var Q = W[K];
				P[Q] = {
					parentid: R,
					item: W
				}
			}
			for (var U = 0; U < N; U++) {
				var W = i.extend({}, Y[U]);
				var R = W[I];
				var Q = W[K];
				if (P[R] != undefined) {
					var W = {
						parentid: R,
						item: P[Q].item
					};
					var O = P[R].item;
					if (!O[V]) {
						O[V] = []
					}
					var L = O[V].length;
					var J = W.item;
					var M = T(J);
					O[V][L] = M;
					P[R].item = O;
					P[Q] = W
				} else {
					var J = P[Q].item;
					var M = T(J);
					e[e.length] = M
				}
			}
			return e
		},
		bindBindingUpdate: function (H, e) {
			this._bindingUpdate[this._bindingUpdate.length] = {
				id: H,
				func: e
			}
		},
		unbindBindingUpdate: function (H) {
			for (var e = 0; e < this._bindingUpdate.length; e++) {
				if (this._bindingUpdate[e].id == H) {
					this._bindingUpdate[e].func = null;
					this._bindingUpdate.splice(e, 1);
					break
				}
			}
		},
		callBindingUpdate: function (e) {
			for (var I = 0; I < this._bindingUpdate.length; I++) {
				var H = this._bindingUpdate[I];
				if (H.func != null) {
					H.func(e)
				}
			}
		},
		getid: function (J, H, I) {
			if (i(J, H).length > 0) {
				return i(J, H).text()
			}
			if (J) {
				if (J.toString().length > 0) {
					var e = i(H).attr(J);
					if (e != null && e.toString().length > 0) {
						return e
					}
				}
			}
			return I
		},
		loadjson: function (ae, af, R) {
			if (typeof (ae) == "string") {
				ae = i.parseJSON(ae)
			}
			if (R.root == undefined) {
				R.root = ""
			}
			if (R.record == undefined) {
				R.record = ""
			}
			var ae = ae || af;
			if (!ae) {
				ae = []
			}
			var ad = this;
			if (R.root != "") {
				var K = R.root.split(ad.mapChar);
				if (K.length > 1) {
					var aa = ae;
					for (var Q = 0; Q < K.length; Q++) {
						if (aa != undefined) {
							aa = aa[K[Q]]
						}
					}
					ae = aa
				} else {
					if (ae[R.root] != undefined) {
						ae = ae[R.root]
					} else {
						i.each(ae, function (ah) {
							var ag = this;
							if (this == R.root) {
								ae = this;
								return false
							} else {
								if (this[R.root] != undefined) {
									ae = this[R.root]
								}
							}
						})
					} if (!ae) {
						var K = R.root.split(ad.mapChar);
						if (K.length > 0) {
							var aa = ae;
							for (var Q = 0; Q < K.length; Q++) {
								if (aa != undefined) {
									aa = aa[K[Q]]
								}
							}
							ae = aa
						}
					}
				}
			} else {
				if (!ae.length) {
					for (obj in ae) {
						if (i.isArray(ae[obj])) {
							ae = ae[obj];
							break
						}
					}
				}
			} if (ae != null && ae.length == undefined) {
				ae = i.makeArray(ae)
			}
			if (ae == null || ae.length == undefined) {
				alert("JSON Parse error.");
				return
			}
			if (ae.length == 0) {
				this.totalrecords = 0;
				return
			}
			var J = ae.length;
			this.totalrecords = this.virtualmode ? (R.totalrecords || J) : J;
			this.records = new Array();
			this.originaldata = new Array();
			var W = this.records;
			var T = !this.pageable ? R.recordstartindex : this.pagesize * this.pagenum;
			this.recordids = new Array();
			if (R.loadallrecords) {
				T = 0;
				J = this.totalrecords
			}
			var P = 0;
			if (this.virtualmode) {
				T = !this.pageable ? R.recordstartindex : this.pagesize * this.pagenum;
				P = T;
				T = 0;
				J = this.totalrecords
			}
			var Y = R.datafields ? R.datafields.length : 0;
			if (Y == 0) {
				var e = ae[0];
				var ab = new Array();
				for (obj in e) {
					var H = obj;
					ab[ab.length] = {
						name: H
					}
				}
				R.datafields = ab;
				Y = ab.length
			}
			var M = T;
			for (var V = T; V < J; V++) {
				var I = ae[V];
				if (I == undefined) {
					break
				}
				if (R.record && R.record != "") {
					I = I[R.record];
					if (I == undefined) {
						continue
					}
				}
				var ac = this.getid(R.id, I, V);
				if (typeof (ac) === "object") {
					ac = V
				}
				if (!this.recordids[ac]) {
					this.recordids[ac] = I;
					var L = {};
					for (var U = 0; U < Y; U++) {
						var N = R.datafields[U];
						var S = "";
						if (undefined == N || N == null) {
							continue
						}
						if (N.map) {
							if (i.isFunction(N.map)) {
								S = N.map(I)
							} else {
								var K = N.map.split(ad.mapChar);
								if (K.length > 0) {
									var Z = I;
									for (var Q = 0; Q < K.length; Q++) {
										if (Z != undefined) {
											Z = Z[K[Q]]
										}
									}
									S = Z
								} else {
									S = I[N.map]
								}
							} if (S != undefined && S != null) {
								S = S.toString()
							} else {
								if (S == undefined && S != null) {
									S = ""
								}
							}
						}
						if (S == "" && !N.map) {
							S = I[N.name];
							if (S == undefined && S != null) {
								S = ""
							}
							if (N.value != undefined) {
								if (S != undefined) {
									var X = S[N.value];
									if (X != undefined) {
										S = X
									}
								}
							}
						}
						S = this.getvaluebytype(S, N);
						if (N.displayname != undefined) {
							L[N.displayname] = S
						} else {
							L[N.name] = S
						} if (N.type === "array") {
							var O = function (aj) {
								if (!aj) {
									return
								}
								for (var ap = 0; ap < aj.length; ap++) {
									var am = aj[ap];
									for (var an = 0; an < Y; an++) {
										var ai = R.datafields[an];
										var ao = "";
										if (undefined == ai || ai == null) {
											continue
										}
										if (ai.map) {
											if (i.isFunction(ai.map)) {
												ao = ai.map(am)
											} else {
												var ag = ai.map.split(ad.mapChar);
												if (ag.length > 0) {
													var al = am;
													for (var ah = 0; ah < ag.length; ah++) {
														if (al != undefined) {
															al = al[ag[ah]]
														}
													}
													ao = al
												} else {
													ao = am[ai.map]
												}
											} if (ao != undefined && ao != null) {
												ao = ao.toString()
											} else {
												if (ao == undefined && ao != null) {
													ao = ""
												}
											}
										}
										if (ao == "" && !ai.map) {
											ao = am[ai.name];
											if (ao == undefined && ao != null) {
												ao = ""
											}
											if (ai.value != undefined) {
												if (ao != undefined) {
													var ak = ao[ai.value];
													if (ak != undefined) {
														ao = ak
													}
												}
											}
										}
										ao = this.getvaluebytype(ao, ai);
										if (ai.displayname != undefined) {
											am[ai.displayname] = ao
										} else {
											am[ai.name] = ao
										} if (ai.type === "array") {
											O.call(this, ao)
										}
									}
								}
							};
							O.call(this, S)
						}
					}
					if (R.recordendindex <= 0 || T < R.recordendindex) {
						W[P + M] = i.extend({}, L);
						W[P + M].uid = ac;
						this.originaldata[P + M] = i.extend({}, W[V]);
						M++
					}
				}
			}
			this.records = W;
			this.cachedrecords = this.records
		},
		loadxml: function (K, ad, S) {
			if (typeof (K) == "string") {
				K = ad = i(i.parseXML(K));
				K = null
			}
			if (S.root == undefined) {
				S.root = ""
			}
			if (S.record == undefined) {
				S.record = ""
			}
			var K;
			if (i.jqx.browser.msie && ad) {
				if (ad.xml != undefined) {
					K = i(S.root + " " + S.record, i.parseXML(ad.xml))
				} else {
					K = K || i(S.root + " " + S.record, ad)
				}
			} else {
				K = K || i(S.root + " " + S.record, ad)
			} if (!K) {
				K = []
			}
			var J = K.length;
			if (K.length == 0) {
				return
			}
			this.totalrecords = this.virtualmode ? (S.totalrecords || J) : J;
			this.records = new Array();
			this.originaldata = new Array();
			var Y = this.records;
			var V = !this.pageable ? S.recordstartindex : this.pagesize * this.pagenum;
			this.recordids = new Array();
			if (S.loadallrecords) {
				V = 0;
				J = this.totalrecords
			}
			var Q = 0;
			if (this.virtualmode) {
				V = !this.pageable ? S.recordstartindex : this.pagesize * this.pagenum;
				Q = V;
				V = 0;
				J = this.totalrecords
			}
			var Z = S.datafields ? S.datafields.length : 0;
			if (Z == 0) {
				var e = K[0];
				var ab = new Array();
				for (obj in e) {
					var H = obj;
					ab[ab.length] = {
						name: H
					}
				}
				S.datafields = ab;
				Z = ab.length
			}
			var R = V;
			for (var X = V; X < J; X++) {
				var I = K[X];
				if (I == undefined) {
					break
				}
				var ac = this.getid(S.id, I, X);
				if (!this.recordids[ac]) {
					this.recordids[ac] = I;
					var L = {};
					for (var W = 0; W < Z; W++) {
						var O = S.datafields[W];
						var U = "";
						if (undefined == O || O == null) {
							continue
						}
						if (O.map) {
							if (i.isFunction(O.map)) {
								U = O.map(I)
							} else {
								var M = O.map.indexOf("[");
								if (M < 0) {
									U = i(O.map, I).text()
								} else {
									var aa = O.map.substring(0, M - 1);
									var N = O.map.indexOf("]");
									var P = O.map.substring(M + 1, N);
									U = i(aa, I).attr(P);
									if (U == undefined) {
										U = ""
									}
								} if (U == "") {
									U = i(I).attr(O.map);
									if (U == undefined) {
										U = ""
									}
								}
							}
						}
						if (U == "") {
							U = i(O.name, I).text();
							if (U == "") {
								U = i(I).attr(O.name);
								if (U == undefined) {
									U = ""
								}
							}
							if (U == "") {
								if (I.nodeName && I.nodeName == O.name && I.firstChild) {
									U = i(I.firstChild).text()
								}
							}
						}
						var T = U;
						U = this.getvaluebytype(U, O);
						if (O.displayname != undefined) {
							L[O.displayname] = U
						} else {
							L[O.name] = U
						}
					}
					if (S.recordendindex <= 0 || V < S.recordendindex) {
						Y[Q + R] = i.extend({}, L);
						Y[Q + R].uid = ac;
						this.originaldata[Q + R] = i.extend({}, Y[X]);
						R++
					}
				}
			}
			this.records = Y;
			this.cachedrecords = this.records
		},
		loadtext: function (X, P) {
			if (X == null) {
				return
			}
			var e = P.rowDelimiter || this.rowDelimiter || "\n";
			var L = X.split(e);
			var J = L.length;
			this.totalrecords = this.virtualmode ? (P.totalrecords || J) : J;
			this.records = new Array();
			this.originaldata = new Array();
			var U = this.records;
			var R = !this.pageable ? P.recordstartindex : this.pagesize * this.pagenum;
			this.recordids = new Array();
			if (P.loadallrecords) {
				R = 0;
				J = this.totalrecords
			}
			var N = 0;
			if (this.virtualmode) {
				R = !this.pageable ? P.recordstartindex : this.pagesize * this.pagenum;
				N = R;
				R = 0;
				J = this.totalrecords
			}
			var V = P.datafields.length;
			var O = P.columnDelimiter || this.columnDelimiter;
			if (!O) {
				O = (P.datatype === "tab") ? "\t" : ","
			}
			for (var T = R; T < J; T++) {
				var I = L[T];
				var W = this.getid(P.id, I, T);
				if (!this.recordids[W]) {
					this.recordids[W] = I;
					var K = {};
					var H = L[T].split(O);
					for (var S = 0; S < V; S++) {
						if (S >= H.length) {
							continue
						}
						var M = P.datafields[S];
						var Q = H[S];
						if (M.map && i.isFunction(M.map)) {
							Q = M.map(I)
						}
						if (M.type) {
							Q = this.getvaluebytype(Q, M)
						}
						var Y = M.map || M.name || S.toString();
						K[Y] = Q
					}
					U[N + T] = i.extend({}, K);
					U[N + T].uid = W;
					this.originaldata[N + T] = i.extend({}, U[T])
				}
			}
			this.records = U;
			this.cachedrecords = this.records
		},
		getvaluebytype: function (K, H) {
			var I = K;
			if (K == null) {
				return K
			}
			if (H.type == "date") {
				if (K == "NaN") {
					K = ""
				} else {
					var J = new Date(K);
					if (typeof K == "string") {
						if (H.format) {
							var e = i.jqx.dataFormat.parsedate(K, H.format);
							if (e != null) {
								J = e
							}
						}
					}
					if (J.toString() == "NaN" || J.toString() == "Invalid Date") {
						if (i.jqx.dataFormat) {
							K = i.jqx.dataFormat.tryparsedate(K)
						} else {
							K = J
						}
					} else {
						K = J
					} if (K == null) {
						K = I
					}
				}
			} else {
				if (H.type == "float" || H.type == "number" || H.type == "decimal") {
					if (K == "NaN") {
						K = ""
					} else {
						var K = parseFloat(K);
						if (isNaN(K)) {
							K = I
						}
					}
				} else {
					if (H.type == "int" || H.type == "integer") {
						var K = parseInt(K);
						if (isNaN(K)) {
							K = I
						}
					} else {
						if (H.type == "bool" || H.type == "boolean") {
							if (K != null) {
								if (K.toLowerCase != undefined) {
									if (K.toLowerCase() == "false") {
										K = false
									} else {
										if (K.toLowerCase() == "true") {
											K = true
										}
									}
								}
							}
							if (K == 1) {
								K = true
							} else {
								if (K == 0 && K !== "") {
									K = false
								} else {
									K = ""
								}
							}
						}
					}
				}
			}
			return K
		}
	};
	i.jqx.dataFormat = {};
	i.extend(i.jqx.dataFormat, {
		regexTrim: /^\s+|\s+$/g,
		regexInfinity: /^[+-]?infinity$/i,
		regexHex: /^0x[a-f0-9]+$/i,
		regexParseFloat: /^[+-]?\d*\.?\d*(e[+-]?\d+)?$/,
		toString: Object.prototype.toString,
		isBoolean: function (e) {
			return typeof e === "boolean"
		},
		isObject: function (e) {
			return (e && (typeof e === "object" || i.isFunction(e))) || false
		},
		isDate: function (e) {
			return e instanceof Date
		},
		arrayIndexOf: function (J, I) {
			if (J.indexOf) {
				return J.indexOf(I)
			}
			for (var e = 0, H = J.length; e < H; e++) {
				if (J[e] === I) {
					return e
				}
			}
			return -1
		},
		isString: function (e) {
			return typeof e === "string"
		},
		isNumber: function (e) {
			return typeof e === "number" && isFinite(e)
		},
		isNull: function (e) {
			return e === null
		},
		isUndefined: function (e) {
			return typeof e === "undefined"
		},
		isValue: function (e) {
			return (this.isObject(e) || this.isString(e) || this.isNumber(e) || this.isBoolean(e))
		},
		isEmpty: function (e) {
			if (!this.isString(e) && this.isValue(e)) {
				return false
			} else {
				if (!this.isValue(e)) {
					return true
				}
			}
			e = i.trim(e).replace(/\&nbsp\;/ig, "").replace(/\&#160\;/ig, "");
			return e === ""
		},
		startsWith: function (H, e) {
			return H.indexOf(e) === 0
		},
		endsWith: function (H, e) {
			return H.substr(H.length - e.length) === e
		},
		trim: function (e) {
			return (e + "").replace(this.regexTrim, "")
		},
		isArray: function (e) {
			return this.toString.call(e) === "[object Array]"
		},
		defaultcalendar: function () {
			var e = {
				"/": "/",
				":": ":",
				firstDay: 0,
				days: {
					names: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
					namesAbbr: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
					namesShort: ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"]
				},
				months: {
					names: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", ""],
					namesAbbr: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", ""]
				},
				AM: ["AM", "am", "AM"],
				PM: ["PM", "pm", "PM"],
				eras: [{
					name: "A.D.",
					start: null,
					offset: 0
				}],
				twoDigitYearMax: 2029,
				patterns: {
					d: "M/d/yyyy",
					D: "dddd, MMMM dd, yyyy",
					t: "h:mm tt",
					T: "h:mm:ss tt",
					f: "dddd, MMMM dd, yyyy h:mm tt",
					F: "dddd, MMMM dd, yyyy h:mm:ss tt",
					M: "MMMM dd",
					Y: "yyyy MMMM",
					S: "yyyy\u0027-\u0027MM\u0027-\u0027dd\u0027T\u0027HH\u0027:\u0027mm\u0027:\u0027ss",
					ISO: "yyyy-MM-dd hh:mm:ss",
					ISO2: "yyyy-MM-dd HH:mm:ss",
					d1: "dd.MM.yyyy",
					d2: "dd-MM-yyyy",
					zone1: "yyyy-MM-ddTHH:mm:ss-HH:mm",
					zone2: "yyyy-MM-ddTHH:mm:ss+HH:mm",
					custom: "yyyy-MM-ddTHH:mm:ss.fff"
				},
				percentsymbol: "%",
				currencysymbol: "$",
				currencysymbolposition: "before",
				decimalseparator: ".",
				thousandsseparator: ","
			};
			return e
		},
		expandFormat: function (K, J) {
			J = J || "F";
			var I, H = K.patterns,
				e = J.length;
			if (e === 1) {
				I = H[J];
				if (!I) {
					throw "Invalid date format string '" + J + "'."
				}
				J = I
			} else {
				if (e === 2 && J.charAt(0) === "%") {
					J = J.charAt(1)
				}
			}
			return J
		},
		getEra: function (I, H) {
			if (!H) {
				return 0
			}
			if (typeof I === "string") {
				return 0
			}
			var L, K = I.getTime();
			for (var J = 0, e = H.length; J < e; J++) {
				L = H[J].start;
				if (L === null || K >= L) {
					return J
				}
			}
			return 0
		},
		toUpper: function (e) {
			return e.split("\u00A0").join(" ").toUpperCase()
		},
		toUpperArray: function (e) {
			var J = [];
			for (var I = 0, H = e.length; I < H; I++) {
				J[I] = this.toUpper(e[I])
			}
			return J
		},
		getEraYear: function (H, J, e, K) {
			var I = H.getFullYear();
			if (!K && J.eras) {
				I -= J.eras[e].offset
			}
			return I
		},
		toUpper: function (e) {
			if (e) {
				return e.toUpperCase()
			}
			return ""
		},
		getDayIndex: function (K, J, H) {
			var e, L = K.days,
				I = K._upperDays;
			if (!I) {
				K._upperDays = I = [this.toUpperArray(L.names), this.toUpperArray(L.namesAbbr), this.toUpperArray(L.namesShort)]
			}
			J = J.toUpperCase();
			if (H) {
				e = this.arrayIndexOf(I[1], J);
				if (e === -1) {
					e = this.arrayIndexOf(I[2], J)
				}
			} else {
				e = this.arrayIndexOf(I[0], J)
			}
			return e
		},
		getMonthIndex: function (N, M, I) {
			var e = N.months,
				H = N.monthsGenitive || N.months,
				K = N._upperMonths,
				L = N._upperMonthsGen;
			if (!K) {
				N._upperMonths = K = [this.toUpperArray(e.names), this.toUpperArray(e.namesAbbr)];
				N._upperMonthsGen = L = [this.toUpperArray(H.names), this.toUpperArray(H.namesAbbr)]
			}
			M = this.toUpper(M);
			var J = this.arrayIndexOf(I ? K[1] : K[0], M);
			if (J < 0) {
				J = this.arrayIndexOf(I ? L[1] : L[0], M)
			}
			return J
		},
		appendPreOrPostMatch: function (J, e) {
			var I = 0,
				L = false;
			for (var K = 0, H = J.length; K < H; K++) {
				var M = J.charAt(K);
				switch (M) {
					case "'":
						if (L) {
							e.push("'")
						} else {
							I++
						}
						L = false;
						break;
					case "\\":
						if (L) {
							e.push("\\")
						}
						L = !L;
						break;
					default:
						e.push(M);
						L = false;
						break
				}
			}
			return I
		},
		getTokenRegExp: function () {
			return /\/|dddd|ddd|dd|d|MMMM|MMM|MM|M|yyyy|yy|y|hh|h|HH|H|mm|m|ss|s|tt|t|fff|ff|f|zzz|zz|z|gg|g/g
		},
		formatlink: function (e, I) {
			var H = "";
			if (I && I.target) {
				H = "target=" + I.target
			}
			if (H != "") {
				return "<a " + H + ' href="' + e + '">' + e + "</a>"
			}
			return '<a href="' + e + '">' + e + "</a>"
		},
		formatemail: function (e) {
			return '<a href="mailto:' + e + '">' + e + "</a>"
		},
		formatnumber: function (T, S, O) {
			if (O == undefined || O == null || O == "") {
				O = this.defaultcalendar()
			}
			if (S === "" || S === null) {
				return T
			}
			if (!this.isNumber(T)) {
				T *= 1
			}
			var P;
			if (S.length > 1) {
				P = parseInt(S.slice(1), 10)
			}
			var V = {};
			var Q = S.charAt(0).toUpperCase();
			V.thousandsSeparator = O.thousandsseparator;
			V.decimalSeparator = O.decimalseparator;
			switch (Q) {
				case "D":
				case "d":
				case "F":
				case "f":
					V.decimalPlaces = P;
					break;
				case "N":
				case "n":
					V.decimalPlaces = 0;
					break;
				case "C":
				case "c":
					V.decimalPlaces = P;
					if (O.currencysymbolposition == "before") {
						V.prefix = O.currencysymbol
					} else {
						V.suffix = O.currencysymbol
					}
					break;
				case "P":
				case "p":
					V.suffix = O.percentsymbol;
					V.decimalPlaces = P;
					break;
				default:
					throw "Bad number format specifier: " + Q
			}
			if (this.isNumber(T)) {
				var K = (T < 0);
				var I = T + "";
				var R = (V.decimalSeparator) ? V.decimalSeparator : ".";
				var e;
				if (this.isNumber(V.decimalPlaces)) {
					var L = V.decimalPlaces;
					var N = Math.pow(10, L);
					I = (T * N).toFixed(0) / N + "";
					e = I.lastIndexOf(".");
					if (L > 0) {
						if (e < 0) {
							I += R;
							e = I.length - 1
						} else {
							if (R !== ".") {
								I = I.replace(".", R)
							}
						}
						while ((I.length - 1 - e) < L) {
							I += "0"
						}
					}
				}
				if (V.thousandsSeparator) {
					var U = V.thousandsSeparator;
					e = I.lastIndexOf(R);
					e = (e > -1) ? e : I.length;
					var J = I.substring(e);
					var H = -1;
					for (var M = e; M > 0; M--) {
						H++;
						if ((H % 3 === 0) && (M !== e) && (!K || (M > 1))) {
							J = U + J
						}
						J = I.charAt(M - 1) + J
					}
					I = J
				}
				I = (V.prefix) ? V.prefix + I : I;
				I = (V.suffix) ? I + V.suffix : I;
				return I
			} else {
				return T
			}
		},
		tryparsedate: function (T, M) {
			if (M == undefined || M == null) {
				M = this.defaultcalendar()
			}
			var Q = this;
			if (T == "") {
				return null
			}
			if (T != null && !T.substring) {
				T = T.toString()
			}
			if (T != null && T.substring(0, 6) == "/Date(") {
				var R = /^\/Date\((-?\d+)(\+|-)?(\d+)?\)\/$/;
				var J = new Date(+T.replace(/\/Date\((\d+)\)\//, "$1"));
				if (J == "Invalid Date") {
					var K = T.match(/^\/Date\((\d+)([-+]\d\d)(\d\d)\)\/$/);
					var J = null;
					if (K) {
						J = new Date(1 * K[1] + 3600000 * K[2] + 60000 * K[3])
					}
				}
				if (J == null || J == "Invalid Date" || isNaN(J)) {
					var N = R.exec(T);
					if (N) {
						var U = new Date(parseInt(N[1]));
						if (N[2]) {
							var e = parseInt(N[3]);
							if (N[2] === "-") {
								e = -e
							}
							var P = U.getUTCMinutes();
							U.setUTCMinutes(P - e)
						}
						if (!isNaN(U.valueOf())) {
							return U
						}
					}
				}
				return J
			}
			patterns = M.patterns;
			for (prop in patterns) {
				J = Q.parsedate(T, patterns[prop], M);
				if (J) {
					if (prop == "ISO") {
						var I = Q.parsedate(T, patterns.ISO2, M);
						if (I) {
							return I
						}
					}
					return J
				}
			}
			if (T != null) {
				var I = null;
				var S = [":", "/", "-"];
				var O = true;
				for (var H = 0; H < S.length; H++) {
					if (T.indexOf(S[H]) != -1) {
						O = false
					}
				}
				if (O) {
					var L = new Number(T);
					if (!isNaN(L)) {
						return new Date(L)
					}
				}
			}
			return null
		},
		getparseregexp: function (e, R) {
			var T = e._parseRegExp;
			if (!T) {
				e._parseRegExp = T = {}
			} else {
				var K = T[R];
				if (K) {
					return K
				}
			}
			var Q = this.expandFormat(e, R).replace(/([\^\$\.\*\+\?\|\[\]\(\)\{\}])/g, "\\\\$1"),
				O = ["^"],
				H = [],
				N = 0,
				J = 0,
				W = this.getTokenRegExp(),
				L;
			while ((L = W.exec(Q)) !== null) {
				var V = Q.slice(N, L.index);
				N = W.lastIndex;
				J += this.appendPreOrPostMatch(V, O);
				if (J % 2) {
					O.push(L[0]);
					continue
				}
				var I = L[0],
					M = I.length,
					S;
				switch (I) {
					case "dddd":
					case "ddd":
					case "MMMM":
					case "MMM":
					case "gg":
					case "g":
						S = "(\\D+)";
						break;
					case "tt":
					case "t":
						S = "(\\D*)";
						break;
					case "yyyy":
					case "fff":
					case "ff":
					case "f":
						S = "(\\d{" + M + "})";
						break;
					case "dd":
					case "d":
					case "MM":
					case "M":
					case "yy":
					case "y":
					case "HH":
					case "H":
					case "hh":
					case "h":
					case "mm":
					case "m":
					case "ss":
					case "s":
						S = "(\\d\\d?)";
						break;
					case "zzz":
						S = "([+-]?\\d\\d?:\\d{2})";
						break;
					case "zz":
					case "z":
						S = "([+-]?\\d\\d?)";
						break;
					case "/":
						S = "(\\" + e["/"] + ")";
						break;
					default:
						throw "Invalid date format pattern '" + I + "'.";
						break
				}
				if (S) {
					O.push(S)
				}
				H.push(L[0])
			}
			this.appendPreOrPostMatch(Q.slice(N), O);
			O.push("$");
			var U = O.join("").replace(/\s+/g, "\\s+"),
				P = {
					regExp: U,
					groups: H
				};
			return T[R] = P
		},
		outOfRange: function (I, e, H) {
			return I < e || I > H
		},
		expandYear: function (L, J) {
			var H = new Date(),
				e = getEra(H);
			if (J < 100) {
				var I = L.twoDigitYearMax;
				I = typeof I === "string" ? new Date().getFullYear() % 100 + parseInt(I, 10) : I;
				var K = this.getEraYear(H, L, e);
				J += K - (K % 100);
				if (J > I) {
					J -= 100
				}
			}
			return J
		},
		parsedate: function (ab, ai, W) {
			if (W == undefined || W == null) {
				W = this.defaultcalendar()
			}
			ab = this.trim(ab);
			var T = W,
				an = this.getparseregexp(T, ai),
				N = new RegExp(an.regExp).exec(ab);
			if (N === null) {
				return null
			}
			var aj = an.groups,
				Z = null,
				R = null,
				am = null,
				al = null,
				S = null,
				L = 0,
				ae, ad = 0,
				ak = 0,
				e = 0,
				I = null,
				U = false;
			for (var af = 0, ah = aj.length; af < ah; af++) {
				var H = N[af + 1];
				if (H) {
					var aa = aj[af],
						K = aa.length,
						M = parseInt(H, 10);
					switch (aa) {
						case "dd":
						case "d":
							al = M;
							if (this.outOfRange(al, 1, 31)) {
								return null
							}
							break;
						case "MMM":
						case "MMMM":
							am = this.getMonthIndex(T, H, K === 3);
							if (this.outOfRange(am, 0, 11)) {
								return null
							}
							break;
						case "M":
						case "MM":
							am = M - 1;
							if (this.outOfRange(am, 0, 11)) {
								return null
							}
							break;
						case "y":
						case "yy":
						case "yyyy":
							R = K < 4 ? this.expandYear(T, M) : M;
							if (this.outOfRange(R, 0, 9999)) {
								return null
							}
							break;
						case "h":
						case "hh":
							L = M;
							if (L === 12) {
								L = 0
							}
							if (this.outOfRange(L, 0, 11)) {
								return null
							}
							break;
						case "H":
						case "HH":
							L = M;
							if (this.outOfRange(L, 0, 23)) {
								return null
							}
							break;
						case "m":
						case "mm":
							ad = M;
							if (this.outOfRange(ad, 0, 59)) {
								return null
							}
							break;
						case "s":
						case "ss":
							ak = M;
							if (this.outOfRange(ak, 0, 59)) {
								return null
							}
							break;
						case "tt":
						case "t":
							U = T.PM && (H === T.PM[0] || H === T.PM[1] || H === T.PM[2]);
							if (!U && (!T.AM || (H !== T.AM[0] && H !== T.AM[1] && H !== T.AM[2]))) {
								return null
							}
							break;
						case "f":
						case "ff":
						case "fff":
							e = M * Math.pow(10, 3 - K);
							if (this.outOfRange(e, 0, 999)) {
								return null
							}
							break;
						case "ddd":
						case "dddd":
							S = this.getDayIndex(T, H, K === 3);
							if (this.outOfRange(S, 0, 6)) {
								return null
							}
							break;
						case "zzz":
							var J = H.split(/:/);
							if (J.length !== 2) {
								return null
							}
							ae = parseInt(J[0], 10);
							if (this.outOfRange(ae, -12, 13)) {
								return null
							}
							var P = parseInt(J[1], 10);
							if (this.outOfRange(P, 0, 59)) {
								return null
							}
							I = (ae * 60) + (startsWith(H, "-") ? -P : P);
							break;
						case "z":
						case "zz":
							ae = M;
							if (this.outOfRange(ae, -12, 13)) {
								return null
							}
							I = ae * 60;
							break;
						case "g":
						case "gg":
							var V = H;
							if (!V || !T.eras) {
								return null
							}
							V = trim(V.toLowerCase());
							for (var ag = 0, ac = T.eras.length; ag < ac; ag++) {
								if (V === T.eras[ag].name.toLowerCase()) {
									Z = ag;
									break
								}
							}
							if (Z === null) {
								return null
							}
							break
					}
				}
			}
			var Q = new Date(),
				Y, O = T.convert;
			Y = Q.getFullYear();
			if (R === null) {
				R = Y
			} else {
				if (T.eras) {
					R += T.eras[(Z || 0)].offset
				}
			} if (am === null) {
				am = 0
			}
			if (al === null) {
				al = 1
			}
			if (O) {
				Q = O.toGregorian(R, am, al);
				if (Q === null) {
					return null
				}
			} else {
				Q.setFullYear(R, am, al);
				if (Q.getDate() !== al) {
					return null
				}
				if (S !== null && Q.getDay() !== S) {
					return null
				}
			} if (U && L < 12) {
				L += 12
			}
			Q.setHours(L, ad, ak, e);
			if (I !== null) {
				var X = Q.getMinutes() - (I + Q.getTimezoneOffset());
				Q.setHours(Q.getHours() + parseInt(X / 60, 10), X % 60)
			}
			return Q
		},
		cleardatescache: function () {
			this.datescache = new Array()
		},
		formatdate: function (Z, ad, U) {
			if (U == undefined || U == null) {
				U = this.defaultcalendar()
			}
			if (typeof Z === "string") {
				return Z
			}
			var J = Z.toString() + "_" + ad;
			if (this.datescache && this.datescache[J]) {
				return this.datescache[J]
			}
			if (!ad || !ad.length || ad === "i") {
				var af;
				af = this.formatDate(Z, U.patterns.F, culture);
				return af
			}
			var aa = U.eras,
				H = ad === "s";
			ad = this.expandFormat(U, ad);
			af = [];
			var M, ab = ["0", "00", "000"],
				Q, R, e = /([^d]|^)(d|dd)([^d]|$)/g,
				ae = 0,
				W = this.getTokenRegExp(),
				I;

			function O(ag, aj) {
				var ai, ah = ag + "";
				if (aj > 1 && ah.length < aj) {
					ai = (ab[aj - 2] + ah);
					return ai.substr(ai.length - aj, aj)
				} else {
					ai = ah
				}
				return ai
			}

			function ac() {
				if (Q || R) {
					return Q
				}
				Q = e.test(ad);
				R = true;
				return Q
			}

			function K(ah, ag) {
				if (I) {
					return I[ag]
				}
				if (ah.getMonth != undefined) {
					switch (ag) {
						case 0:
							return ah.getFullYear();
						case 1:
							return ah.getMonth();
						case 2:
							return ah.getDate()
					}
				}
			}
			for (; ;) {
				var N = W.lastIndex,
					V = W.exec(ad);
				var S = ad.slice(N, V ? V.index : ad.length);
				ae += this.appendPreOrPostMatch(S, af);
				if (!V) {
					break
				}
				if (ae % 2) {
					af.push(V[0]);
					continue
				}
				var X = V[0],
					L = X.length;
				switch (X) {
					case "ddd":
					case "dddd":
						var T = (L === 3) ? U.days.namesAbbr : U.days.names;
						af.push(T[Z.getDay()]);
						break;
					case "d":
					case "dd":
						Q = true;
						af.push(O(K(Z, 2), L));
						break;
					case "MMM":
					case "MMMM":
						var Y = K(Z, 1);
						af.push(U.months[L === 3 ? "namesAbbr" : "names"][Y]);
						break;
					case "M":
					case "MM":
						af.push(O(K(Z, 1) + 1, L));
						break;
					case "y":
					case "yy":
					case "yyyy":
						Y = this.getEraYear(Z, U, this.getEra(Z, aa), H);
						if (L < 4) {
							Y = Y % 100
						}
						af.push(O(Y, L));
						break;
					case "h":
					case "hh":
						M = Z.getHours() % 12;
						if (M === 0) {
							M = 12
						}
						af.push(O(M, L));
						break;
					case "H":
					case "HH":
						af.push(O(Z.getHours(), L));
						break;
					case "m":
					case "mm":
						af.push(O(Z.getMinutes(), L));
						break;
					case "s":
					case "ss":
						af.push(O(Z.getSeconds(), L));
						break;
					case "t":
					case "tt":
						Y = Z.getHours() < 12 ? (U.AM ? U.AM[0] : " ") : (U.PM ? U.PM[0] : " ");
						af.push(L === 1 ? Y.charAt(0) : Y);
						break;
					case "f":
					case "ff":
					case "fff":
						af.push(O(Z.getMilliseconds(), 3).substr(0, L));
						break;
					case "z":
					case "zz":
						M = Z.getTimezoneOffset() / 60;
						af.push((M <= 0 ? "+" : "-") + O(Math.floor(Math.abs(M)), L));
						break;
					case "zzz":
						M = Z.getTimezoneOffset() / 60;
						af.push((M <= 0 ? "+" : "-") + O(Math.floor(Math.abs(M)), 2) + ":" + O(Math.abs(Z.getTimezoneOffset() % 60), 2));
						break;
					case "g":
					case "gg":
						if (U.eras) {
							af.push(U.eras[getEra(Z, aa)].name)
						}
						break;
					case "/":
						af.push(U["/"]);
						break;
					default:
						throw "Invalid date format pattern '" + X + "'.";
						break
				}
			}
			var P = af.join("");
			if (!this.datescache) {
				this.datescache = new Array()
			}
			this.datescache[J] = P;
			return P
		}
	});
	i.jqx.data = {};
	var l, E, p = /#.*$/,
		a = /^(.*?):[ \t]*([^\r\n]*)\r?$/mg,
		f = /^(?:about|app|app\-storage|.+\-extension|file|res|widget):$/,
		j = /^(?:GET|HEAD)$/,
		o = /^\/\//,
		k = /\?/,
		b = /<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>/gi,
		d = /([?&])_=[^&]*/,
		h = /^([\w\+\.\-]+:)(?:\/\/([^\/?#:]*)(?::(\d+)|)|)/,
		t = /\s+/,
		F = jQuery.fn.load,
		G = {}, C = {}, q = ["*/"] + ["*"];
	try {
		E = location.href
	} catch (A) {
		E = document.createElement("a");
		E.href = "";
		E = E.href
	}
	l = h.exec(E.toLowerCase()) || [];

	function r(e) {
		return function (K, M) {
			if (typeof K !== "string") {
				M = K;
				K = "*"
			}
			var H, N, O, J = K.toLowerCase().split(t),
				I = 0,
				L = J.length;
			if (jQuery.isFunction(M)) {
				for (; I < L; I++) {
					H = J[I];
					O = /^\+/.test(H);
					if (O) {
						H = H.substr(1) || "*"
					}
					N = e[H] = e[H] || [];
					N[O ? "unshift" : "push"](M)
				}
			}
		}
	}

	function v(H, Q, L, O, N, J) {
		N = N || Q.dataTypes[0];
		J = J || {};
		J[N] = true;
		var P, M = H[N],
			I = 0,
			e = M ? M.length : 0,
			K = (H === G);
		for (; I < e && (K || !P) ; I++) {
			P = M[I](Q, L, O);
			if (typeof P === "string") {
				if (!K || J[P]) {
					P = undefined
				} else {
					Q.dataTypes.unshift(P);
					P = v(H, Q, L, O, P, J)
				}
			}
		}
		if ((K || !P) && !J["*"]) {
			P = v(H, Q, L, O, "*", J)
		}
		return P
	}

	function u(I, J) {
		var H, e, K = i.jqx.data.ajaxSettings.flatOptions || {};
		for (H in J) {
			if (J[H] !== undefined) {
				(K[H] ? I : (e || (e = {})))[H] = J[H]
			}
		}
		if (e) {
			jQuery.extend(true, I, e)
		}
	}
	i.extend(i.jqx.data, {
		ajaxSetup: function (H, e) {
			if (e) {
				u(H, i.jqx.data.ajaxSettings)
			} else {
				e = H;
				H = i.jqx.data.ajaxSettings
			}
			u(H, e);
			return H
		},
		ajaxSettings: {
			url: E,
			isLocal: f.test(l[1]),
			global: true,
			type: "GET",
			contentType: "application/x-www-form-urlencoded; charset=UTF-8",
			processData: true,
			async: true,
			accepts: {
				xml: "application/xml, text/xml",
				html: "text/html",
				text: "text/plain",
				json: "application/json, text/javascript",
				"*": q
			},
			contents: {
				xml: /xml/,
				html: /html/,
				json: /json/
			},
			responseFields: {
				xml: "responseXML",
				text: "responseText"
			},
			converters: {
				"* text": window.String,
				"text html": true,
				"text json": jQuery.parseJSON,
				"text xml": jQuery.parseXML
			},
			flatOptions: {
				context: true,
				url: true
			}
		},
		ajaxPrefilter: r(G),
		ajaxTransport: r(C),
		ajax: function (M, J) {
			if (typeof M === "object") {
				J = M;
				M = undefined
			}
			J = J || {};
			var P, ad, K, Y, R, V, I, X, Q = i.jqx.data.ajaxSetup({}, J),
				af = Q.context || Q,
				T = af !== Q && (af.nodeType || af instanceof jQuery) ? jQuery(af) : jQuery.event,
				ae = jQuery.Deferred(),
				aa = jQuery.Callbacks("once memory"),
				N = Q.statusCode || {}, U = {}, ab = {}, L = 0,
				O = "canceled",
				W = {
					readyState: 0,
					setRequestHeader: function (ag, ah) {
						if (!L) {
							var e = ag.toLowerCase();
							ag = ab[e] = ab[e] || ag;
							U[ag] = ah
						}
						return this
					},
					getAllResponseHeaders: function () {
						return L === 2 ? ad : null
					},
					getResponseHeader: function (ag) {
						var e;
						if (L === 2) {
							if (!K) {
								K = {};
								while ((e = a.exec(ad))) {
									K[e[1].toLowerCase()] = e[2]
								}
							}
							e = K[ag.toLowerCase()]
						}
						return e === undefined ? null : e
					},
					overrideMimeType: function (e) {
						if (!L) {
							Q.mimeType = e
						}
						return this
					},
					abort: function (e) {
						e = e || O;
						if (Y) {
							Y.abort(e)
						}
						S(0, e);
						return this
					}
				};

			function S(ak, ag, al, ai) {
				var e, ao, am, aj, an, ah = ag;
				if (L === 2) {
					return
				}
				L = 2;
				if (R) {
					clearTimeout(R)
				}
				Y = undefined;
				ad = ai || "";
				W.readyState = ak > 0 ? 4 : 0;
				if (al) {
					aj = B(Q, W, al)
				}
				if (ak >= 200 && ak < 300 || ak === 304) {
					if (Q.ifModified) {
						an = W.getResponseHeader("Last-Modified");
						if (an) {
							jQuery.lastModified[P] = an
						}
						an = W.getResponseHeader("Etag");
						if (an) {
							jQuery.etag[P] = an
						}
					}
					if (ak === 304) {
						ah = "notmodified";
						e = true
					} else {
						e = c(Q, aj);
						ah = e.state;
						ao = e.data;
						am = e.error;
						e = !am
					}
				} else {
					am = ah;
					if (!ah || ak) {
						ah = "error";
						if (ak < 0) {
							ak = 0
						}
					}
				}
				W.status = ak;
				W.statusText = (ag || ah) + "";
				if (e) {
					ae.resolveWith(af, [ao, ah, W])
				} else {
					ae.rejectWith(af, [W, ah, am])
				}
				W.statusCode(N);
				N = undefined;
				if (I) {
					T.trigger("ajax" + (e ? "Success" : "Error"), [W, Q, e ? ao : am])
				}
				aa.fireWith(af, [W, ah]);
				if (I) {
					T.trigger("ajaxComplete", [W, Q]);
					if (!(--jQuery.active)) {
						jQuery.event.trigger("ajaxStop")
					}
				}
			}
			ae.promise(W);
			W.success = W.done;
			W.error = W.fail;
			W.complete = aa.add;
			W.statusCode = function (ag) {
				if (ag) {
					var e;
					if (L < 2) {
						for (e in ag) {
							N[e] = [N[e], ag[e]]
						}
					} else {
						e = ag[W.status];
						W.always(e)
					}
				}
				return this
			};
			Q.url = ((M || Q.url) + "").replace(p, "").replace(o, l[1] + "//");
			Q.dataTypes = jQuery.trim(Q.dataType || "*").toLowerCase().split(t);
			if (Q.crossDomain == null) {
				V = h.exec(Q.url.toLowerCase());
				Q.crossDomain = !!(V && (V[1] !== l[1] || V[2] !== l[2] || (V[3] || (V[1] === "http:" ? 80 : 443)) != (l[3] || (l[1] === "http:" ? 80 : 443))))
			}
			if (Q.data && Q.processData && typeof Q.data !== "string") {
				Q.data = jQuery.param(Q.data, Q.traditional)
			}
			v(G, Q, J, W);
			if (L === 2) {
				return W
			}
			I = Q.global;
			Q.type = Q.type.toUpperCase();
			Q.hasContent = !j.test(Q.type);
			if (I && jQuery.active++ === 0) {
				jQuery.event.trigger("ajaxStart")
			}
			if (!Q.hasContent) {
				if (Q.data) {
					Q.url += (k.test(Q.url) ? "&" : "?") + Q.data;
					delete Q.data
				}
				P = Q.url;
				if (Q.cache === false) {
					var H = jQuery.now(),
						ac = Q.url.replace(d, "$1_=" + H);
					Q.url = ac + ((ac === Q.url) ? (k.test(Q.url) ? "&" : "?") + "_=" + H : "")
				}
			}
			if (Q.data && Q.hasContent && Q.contentType !== false || J.contentType) {
				W.setRequestHeader("Content-Type", Q.contentType)
			}
			if (Q.ifModified) {
				P = P || Q.url;
				if (jQuery.lastModified[P]) {
					W.setRequestHeader("If-Modified-Since", jQuery.lastModified[P])
				}
				if (jQuery.etag[P]) {
					W.setRequestHeader("If-None-Match", jQuery.etag[P])
				}
			}
			W.setRequestHeader("Accept", Q.dataTypes[0] && Q.accepts[Q.dataTypes[0]] ? Q.accepts[Q.dataTypes[0]] + (Q.dataTypes[0] !== "*" ? ", " + q + "; q=0.01" : "") : Q.accepts["*"]);
			for (X in Q.headers) {
				W.setRequestHeader(X, Q.headers[X])
			}
			if (Q.beforeSend && (Q.beforeSend.call(af, W, Q) === false || L === 2)) {
				return W.abort()
			}
			O = "abort";
			for (X in {
				success: 1,
				error: 1,
				complete: 1
			}) {
				W[X](Q[X])
			}
			Y = v(C, Q, J, W);
			if (!Y) {
				S(-1, "No Transport")
			} else {
				W.readyState = 1;
				if (I) {
					T.trigger("ajaxSend", [W, Q])
				}
				if (Q.async && Q.timeout > 0) {
					R = setTimeout(function () {
						W.abort("timeout")
					}, Q.timeout)
				}
				try {
					L = 1;
					Y.send(U, S)
				} catch (Z) {
					if (L < 2) {
						S(-1, Z)
					} else {
						throw Z
					}
				}
			}
			return W
		},
		active: 0,
		lastModified: {},
		etag: {}
	});

	function B(P, O, L) {
		var K, M, J, e, H = P.contents,
			N = P.dataTypes,
			I = P.responseFields;
		for (M in I) {
			if (M in L) {
				O[I[M]] = L[M]
			}
		}
		while (N[0] === "*") {
			N.shift();
			if (K === undefined) {
				K = P.mimeType || O.getResponseHeader("content-type")
			}
		}
		if (K) {
			for (M in H) {
				if (H[M] && H[M].test(K)) {
					N.unshift(M);
					break
				}
			}
		}
		if (N[0] in L) {
			J = N[0]
		} else {
			for (M in L) {
				if (!N[0] || P.converters[M + " " + N[0]]) {
					J = M;
					break
				}
				if (!e) {
					e = M
				}
			}
			J = J || e
		} if (J) {
			if (J !== N[0]) {
				N.unshift(J)
			}
			return L[J]
		}
	}

	function c(R, J) {
		var P, H, N, L, O = R.dataTypes.slice(),
			I = O[0],
			Q = {}, K = 0;
		if (R.dataFilter) {
			J = R.dataFilter(J, R.dataType)
		}
		if (O[1]) {
			for (P in R.converters) {
				Q[P.toLowerCase()] = R.converters[P]
			}
		}
		for (;
			(N = O[++K]) ;) {
			if (N !== "*") {
				if (I !== "*" && I !== N) {
					P = Q[I + " " + N] || Q["* " + N];
					if (!P) {
						for (H in Q) {
							L = H.split(" ");
							if (L[1] === N) {
								P = Q[I + " " + L[0]] || Q["* " + L[0]];
								if (P) {
									if (P === true) {
										P = Q[H]
									} else {
										if (Q[H] !== true) {
											N = L[0];
											O.splice(K--, 0, N)
										}
									}
									break
								}
							}
						}
					}
					if (P !== true) {
						if (P && R["throws"]) {
							J = P(J)
						} else {
							try {
								J = P(J)
							} catch (M) {
								return {
									state: "parsererror",
									error: P ? M : "No conversion from " + I + " to " + N
								}
							}
						}
					}
				}
				I = N
			}
		}
		return {
			state: "success",
			data: J
		}
	}
	var y = [],
		n = /\?/,
		D = /(=)\?(?=&|$)|\?\?/,
		z = jQuery.now();
	i.jqx.data.ajaxSetup({
		jsonp: "callback",
		jsonpCallback: function () {
			var e = y.pop() || (jQuery.expando + "_" + (z++));
			this[e] = true;
			return e
		}
	});
	i.jqx.data.ajaxPrefilter("json jsonp", function (Q, L, P) {
		var O, e, N, J = Q.data,
			H = Q.url,
			I = Q.jsonp !== false,
			M = I && D.test(H),
			K = I && !M && typeof J === "string" && !(Q.contentType || "").indexOf("application/x-www-form-urlencoded") && D.test(J);
		if (Q.dataTypes[0] === "jsonp" || M || K) {
			O = Q.jsonpCallback = jQuery.isFunction(Q.jsonpCallback) ? Q.jsonpCallback() : Q.jsonpCallback;
			e = window[O];
			if (M) {
				Q.url = H.replace(D, "$1" + O)
			} else {
				if (K) {
					Q.data = J.replace(D, "$1" + O)
				} else {
					if (I) {
						Q.url += (n.test(H) ? "&" : "?") + Q.jsonp + "=" + O
					}
				}
			}
			Q.converters["script json"] = function () {
				if (!N) {
					jQuery.error(O + " was not called")
				}
				return N[0]
			};
			Q.dataTypes[0] = "json";
			window[O] = function () {
				N = arguments
			};
			P.always(function () {
				window[O] = e;
				if (Q[O]) {
					Q.jsonpCallback = L.jsonpCallback;
					y.push(O)
				}
				if (N && jQuery.isFunction(e)) {
					e(N[0])
				}
				N = e = undefined
			});
			return "script"
		}
	});
	i.jqx.data.ajaxSetup({
		accepts: {
			script: "text/javascript, application/javascript, application/ecmascript, application/x-ecmascript"
		},
		contents: {
			script: /javascript|ecmascript/
		},
		converters: {
			"text script": function (e) {
				jQuery.globalEval(e);
				return e
			}
		}
	});
	i.jqx.data.ajaxPrefilter("script", function (e) {
		if (e.cache === undefined) {
			e.cache = false
		}
		if (e.crossDomain) {
			e.type = "GET";
			e.global = false
		}
	});
	i.jqx.data.ajaxTransport("script", function (I) {
		if (I.crossDomain) {
			var e, H = document.head || document.getElementsByTagName("head")[0] || document.documentElement;
			return {
				send: function (J, K) {
					e = document.createElement("script");
					e.async = "async";
					if (I.scriptCharset) {
						e.charset = I.scriptCharset
					}
					e.src = I.url;
					e.onload = e.onreadystatechange = function (M, L) {
						if (L || !e.readyState || /loaded|complete/.test(e.readyState)) {
							e.onload = e.onreadystatechange = null;
							if (H && e.parentNode) {
								H.removeChild(e)
							}
							e = undefined;
							if (!L) {
								K(200, "success")
							}
						}
					};
					H.insertBefore(e, H.firstChild)
				},
				abort: function () {
					if (e) {
						e.onload(0, 1)
					}
				}
			}
		}
	});
	var w, x = window.ActiveXObject ? function () {
		for (var e in w) {
			w[e](0, 1)
		}
	} : false,
		m = 0;

	function g() {
		try {
			return new window.XMLHttpRequest()
		} catch (H) { }
	}

	function s() {
		try {
			return new window.ActiveXObject("Microsoft.XMLHTTP")
		} catch (H) { }
	}
	i.jqx.data.ajaxSettings.xhr = window.ActiveXObject ? function () {
		return !this.isLocal && g() || s()
	} : g;
	(function (e) {
		jQuery.extend(jQuery.support, {
			ajax: !!e,
			cors: !!e && ("withCredentials" in e)
		})
	})(i.jqx.data.ajaxSettings.xhr());
	if (jQuery.support.ajax) {
		i.jqx.data.ajaxTransport(function (e) {
			if (!e.crossDomain || jQuery.support.cors) {
				var H;
				return {
					send: function (N, I) {
						var L, K, M = e.xhr();
						if (e.username) {
							M.open(e.type, e.url, e.async, e.username, e.password)
						} else {
							M.open(e.type, e.url, e.async)
						} if (e.xhrFields) {
							for (K in e.xhrFields) {
								M[K] = e.xhrFields[K]
							}
						}
						if (e.mimeType && M.overrideMimeType) {
							M.overrideMimeType(e.mimeType)
						}
						if (!e.crossDomain && !N["X-Requested-With"]) {
							N["X-Requested-With"] = "XMLHttpRequest"
						}
						try {
							for (K in N) {
								M.setRequestHeader(K, N[K])
							}
						} catch (J) { }
						M.send((e.hasContent && e.data) || null);
						H = function (W, Q) {
							var R, P, O, U, T;
							try {
								if (H && (Q || M.readyState === 4)) {
									H = undefined;
									if (L) {
										M.onreadystatechange = jQuery.noop;
										if (x) {
											delete w[L]
										}
									}
									if (Q) {
										if (M.readyState !== 4) {
											M.abort()
										}
									} else {
										R = M.status;
										O = M.getAllResponseHeaders();
										U = {};
										T = M.responseXML;
										if (T && T.documentElement) {
											U.xml = T
										}
										try {
											U.text = M.responseText
										} catch (V) { }
										try {
											P = M.statusText
										} catch (V) {
											P = ""
										}
										if (!R && e.isLocal && !e.crossDomain) {
											R = U.text ? 200 : 404
										} else {
											if (R === 1223) {
												R = 204
											}
										}
									}
								}
							} catch (S) {
								if (!Q) {
									I(-1, S)
								}
							}
							if (U) {
								I(R, P, U, O)
							}
						};
						if (!e.async) {
							H()
						} else {
							if (M.readyState === 4) {
								setTimeout(H, 0)
							} else {
								L = ++m;
								if (x) {
									if (!w) {
										w = {};
										jQuery(window).unload(x)
									}
									w[L] = H
								}
								M.onreadystatechange = H
							}
						}
					},
					abort: function () {
						if (H) {
							H(0, 1)
						}
					}
				}
			}
		})
	}
	i.jqx.filter = function () {
		this.operator = "and";
		var M = 0;
		var J = 1;
		var P = ["EMPTY", "NOT_EMPTY", "CONTAINS", "CONTAINS_CASE_SENSITIVE", "DOES_NOT_CONTAIN", "DOES_NOT_CONTAIN_CASE_SENSITIVE", "STARTS_WITH", "STARTS_WITH_CASE_SENSITIVE", "ENDS_WITH", "ENDS_WITH_CASE_SENSITIVE", "EQUAL", "EQUAL_CASE_SENSITIVE", "NULL", "NOT_NULL"];
		var R = ["EQUAL", "NOT_EQUAL", "LESS_THAN", "LESS_THAN_OR_EQUAL", "GREATER_THAN", "GREATER_THAN_OR_EQUAL", "NULL", "NOT_NULL"];
		var S = ["EQUAL", "NOT_EQUAL", "LESS_THAN", "LESS_THAN_OR_EQUAL", "GREATER_THAN", "GREATER_THAN_OR_EQUAL", "NULL", "NOT_NULL"];
		var L = ["EQUAL", "NOT_EQUAL"];
		var K = new Array();
		var Q = new Array();
		this.evaluate = function (X) {
			var V = true;
			for (var W = 0; W < K.length; W++) {
				var U = K[W].evaluate(X);
				if (W == 0) {
					V = U
				} else {
					if (Q[W] == J || Q[W] == "or") {
						V = V || U
					} else {
						V = V && U
					}
				}
			}
			return V
		};
		this.getfilterscount = function () {
			return K.length
		};
		this.setoperatorsbyfiltertype = function (U, V) {
			switch (U) {
				case "numericfilter":
					R = V;
					break;
				case "stringfilter":
					P = V;
					break;
				case "datefilter":
					S = V;
					break;
				case "booleanfilter":
					L = V;
					break
			}
		};
		this.getoperatorsbyfiltertype = function (U) {
			var V = new Array();
			switch (U) {
				case "numericfilter":
					V = R.slice(0);
					break;
				case "stringfilter":
					V = P.slice(0);
					break;
				case "datefilter":
					V = S.slice(0);
					break;
				case "booleanfilter":
					V = L.slice(0);
					break
			}
			return V
		};
		var O = function () {
			var U = function () {
				return (((1 + Math.random()) * 65536) | 0).toString(16).substring(1)
			};
			return (U() + "-" + U() + "-" + U())
		};
		this.createfilter = function (Y, V, X, W, U, Z) {
			if (Y == null || Y == undefined) {
				return null
			}
			switch (Y) {
				case "numericfilter":
					return new N(V, X.toUpperCase());
				case "stringfilter":
					return new T(V, X.toUpperCase());
				case "datefilter":
					return new H(V, X.toUpperCase(), U, Z);
				case "booleanfilter":
					return new I(V, X.toUpperCase());
				case "custom":
					return new e(V, X.toUpperCase(), W)
			}
			throw new Error("jqxGrid: There is no such filter type. The available filter types are: 'numericfilter', 'stringfilter', 'datefilter' and 'booleanfilter'");
			return null
		};
		this.getfilters = function () {
			var U = new Array();
			for (var V = 0; V < K.length; V++) {
				var W = {
					value: K[V].filtervalue,
					condition: K[V].comparisonoperator,
					operator: Q[V],
					type: K[V].type
				};
				U[V] = W
			}
			return U
		};
		this.addfilter = function (U, V) {
			K[K.length] = V;
			V.key = O();
			Q[Q.length] = U
		};
		this.removefilter = function (V) {
			for (var U = 0; U < K.length; U++) {
				if (K[U].key == V.key) {
					K.splice(U, 1);
					Q.splice(U, 1);
					break
				}
			}
		};
		this.getoperatorat = function (U) {
			if (U == undefined || U == null) {
				return null
			}
			if (U < 0 || U > K.length) {
				return null
			}
			return Q[U]
		};
		this.setoperatorat = function (V, U) {
			if (V == undefined || V == null) {
				return null
			}
			if (V < 0 || V > K.length) {
				return null
			}
			Q[U] = U
		};
		this.getfilterat = function (U) {
			if (U == undefined || U == null) {
				return null
			}
			if (U < 0 || U > K.length) {
				return null
			}
			return K[U]
		};
		this.setfilterat = function (U, V) {
			if (U == undefined || U == null) {
				return null
			}
			if (U < 0 || U > K.length) {
				return null
			}
			V.key = O();
			K[U] = V
		};
		this.clear = function () {
			K = new Array();
			Q = new Array()
		};
		var T = function (V, U) {
			this.filtervalue = V;
			this.comparisonoperator = U;
			this.type = "stringfilter";
			this.evaluate = function (Z) {
				var Y = this.filtervalue;
				var W = this.comparisonoperator;
				if (Z == null || Z == undefined || Z == "") {
					if (W == "NULL") {
						return true
					}
					return false
				}
				var aa = "";
				try {
					aa = Z.toString()
				} catch (X) {
					return true
				}
				switch (W) {
					case "EQUAL":
						return i.jqx.string.equalsIgnoreCase(aa, Y);
					case "EQUAL_CASE_SENSITIVE":
						return i.jqx.string.equals(aa, Y);
					case "NOT_EQUAL":
						return !i.jqx.string.equalsIgnoreCase(aa, Y);
					case "NOT_EQUAL_CASE_SENSITIVE":
						return !i.jqx.string.equals(aa, Y);
					case "CONTAINS":
						return i.jqx.string.containsIgnoreCase(aa, Y);
					case "CONTAINS_CASE_SENSITIVE":
						return i.jqx.string.contains(aa, Y);
					case "DOES_NOT_CONTAIN":
						return !i.jqx.string.containsIgnoreCase(aa, Y);
					case "DOES_NOT_CONTAIN_CASE_SENSITIVE":
						return !i.jqx.string.contains(aa, Y);
					case "EMPTY":
						return aa == "";
					case "NOT_EMPTY":
						return aa != "";
					case "NOT_NULL":
						return aa != null;
					case "STARTS_WITH":
						return i.jqx.string.startsWithIgnoreCase(aa, Y);
					case "ENDS_WITH":
						return i.jqx.string.endsWithIgnoreCase(aa, Y);
					case "ENDS_WITH_CASE_SENSITIVE":
						return i.jqx.string.endsWith(aa, Y);
					case "STARTS_WITH_CASE_SENSITIVE":
						return i.jqx.string.startsWith(aa, Y);
					default:
						return false
				}
			}
		};
		var I = function (V, U) {
			this.filtervalue = V;
			this.comparisonoperator = U;
			this.type = "booleanfilter";
			this.evaluate = function (Y) {
				var X = this.filtervalue;
				var W = this.comparisonoperator;
				if (Y == null || Y == undefined) {
					if (W == "NULL") {
						return true
					}
					return false
				}
				var Z = Y;
				switch (W) {
					case "EQUAL":
						return Z == X || Z.toString() == X.toString();
					case "NOT_EQUAL":
						return Z != X && Z.toString() != X.toString();
					default:
						return false
				}
			}
		};
		var N = function (V, U) {
			this.filtervalue = V;
			this.comparisonoperator = U;
			this.type = "numericfilter";
			this.evaluate = function (Z) {
				var Y = this.filtervalue;
				var W = this.comparisonoperator;
				if (Z === null || Z === undefined || Z === "") {
					if (W == "NOT_NULL") {
						return false
					}
					if (W == "NULL") {
						return true
					} else {
						return false
					}
				} else {
					if (W == "NULL") {
						return false
					}
					if (W == "NOT_NULL") {
						return true
					}
				}
				var aa = Z;
				try {
					aa = parseFloat(aa)
				} catch (X) {
					if (Z.toString() != "") {
						return false
					}
				}
				switch (W) {
					case "EQUAL":
						return aa == Y;
					case "NOT_EQUAL":
						return aa != Y;
					case "GREATER_THAN":
						return aa > Y;
					case "GREATER_THAN_OR_EQUAL":
						return aa >= Y;
					case "LESS_THAN":
						return aa < Y;
					case "LESS_THAN_OR_EQUAL":
						return aa <= Y;
					case "STARTS_WITH":
						return i.jqx.string.startsWithIgnoreCase(aa.toString(), Y.toString());
					case "ENDS_WITH":
						return i.jqx.string.endsWithIgnoreCase(aa.toString(), Y.toString());
					case "ENDS_WITH_CASE_SENSITIVE":
						return i.jqx.string.endsWith(aa.toString(), Y.toString());
					case "STARTS_WITH_CASE_SENSITIVE":
						return i.jqx.string.startsWith(aa.toString(), Y.toString());
					case "CONTAINS":
						return i.jqx.string.containsIgnoreCase(aa.toString(), Y.toString());
					case "CONTAINS_CASE_SENSITIVE":
						return i.jqx.string.contains(aa.toString(), Y.toString());
					case "DOES_NOT_CONTAIN":
						return !i.jqx.string.containsIgnoreCase(aa.toString(), Y.toString());
					case "DOES_NOT_CONTAIN_CASE_SENSITIVE":
						return !i.jqx.string.contains(aa.toString(), Y.toString());
					default:
						return true
				}
			}
		};
		var H = function (X, V, W, aa) {
			this.filtervalue = X;
			this.type = "datefilter";
			if (W != undefined && aa != undefined) {
				var Y = i.jqx.dataFormat.parsedate(X, W, aa);
				if (Y != null) {
					this.filterdate = Y
				} else {
					var U = i.jqx.dataFormat.tryparsedate(X, aa);
					if (U != null) {
						this.filterdate = U
					}
				}
			} else {
				var Z = new Date(X);
				if (Z.toString() == "NaN" || Z.toString() == "Invalid Date") {
					this.filterdate = i.jqx.dataFormat.tryparsedate(X)
				} else {
					this.filterdate = Z
				}
			} if (!this.filterdate) {
				var Z = new Date(X);
				if (Z.toString() == "NaN" || Z.toString() == "Invalid Date") {
					this.filterdate = i.jqx.dataFormat.tryparsedate(X)
				} else {
					this.filterdate = Z
				}
			}
			this.comparisonoperator = V;
			this.evaluate = function (ai) {
				var aj = this.filtervalue;
				var ag = this.comparisonoperator;
				if (ai == null || ai == undefined || ai == "") {
					if (ag == "NOT_NULL") {
						return false
					}
					if (ag == "NULL") {
						return true
					} else {
						return false
					}
				} else {
					if (ag == "NULL") {
						return false
					}
					if (ag == "NOT_NULL") {
						return true
					}
				}
				var ab = new Date();
				ab.setFullYear(1900, 0, 1);
				ab.setHours(12, 0, 0, 0);
				try {
					var ae = new Date(ai);
					if (ae.toString() == "NaN" || ae.toString() == "Invalid Date") {
						ai = i.jqx.dataFormat.tryparsedate(ai)
					} else {
						ai = ae
					}
					ab = ai
				} catch (af) {
					if (ai.toString() != "") {
						return false
					}
				}
				if (this.filterdate != null) {
					aj = this.filterdate
				} else {
					if (aj.indexOf) {
						if (aj.indexOf(":") != -1 || !isNaN(parseInt(aj))) {
							var ah = new Date(ab);
							ah.setHours(12, 0, 0, 0);
							var ac = aj.split(":");
							for (var ad = 0; ad < ac.length; ad++) {
								if (ad == 0) {
									ah.setHours(ac[ad])
								}
								if (ad == 1) {
									ah.setMinutes(ac[ad])
								}
								if (ad == 2) {
									ah.setSeconds(ac[ad])
								}
							}
							aj = ah
						}
					}
				} if (ab == null) {
					ab = ""
				}
				switch (ag) {
					case "EQUAL":
						return ab.toString() == aj.toString();
					case "NOT_EQUAL":
						return ab.toString() != aj.toString();
					case "GREATER_THAN":
						return ab > aj;
					case "GREATER_THAN_OR_EQUAL":
						return ab >= aj;
					case "LESS_THAN":
						return ab < aj;
					case "LESS_THAN_OR_EQUAL":
						return ab <= aj;
					case "STARTS_WITH":
						return i.jqx.string.startsWithIgnoreCase(ab.toString(), aj.toString());
					case "ENDS_WITH":
						return i.jqx.string.endsWithIgnoreCase(ab.toString(), aj.toString());
					case "ENDS_WITH_CASE_SENSITIVE":
						return i.jqx.string.endsWith(ab.toString(), aj.toString());
					case "STARTS_WITH_CASE_SENSITIVE":
						return i.jqx.string.startsWith(ab.toString(), aj.toString());
					case "CONTAINS":
						return i.jqx.string.containsIgnoreCase(ab.toString(), aj.toString());
					case "CONTAINS_CASE_SENSITIVE":
						return i.jqx.string.contains(ab.toString(), aj.toString());
					case "DOES_NOT_CONTAIN":
						return !i.jqx.string.containsIgnoreCase(ab.toString(), aj.toString());
					case "DOES_NOT_CONTAIN_CASE_SENSITIVE":
						return !i.jqx.string.contains(ab.toString(), aj.toString());
					default:
						return true
				}
			}
		};
		var e = function (V, U, W) {
			this.filtervalue = V;
			this.comparisonoperator = U;
			this.evaluate = function (Y, X) {
				return W(this.filtervalue, Y, this.comparisonoperator)
			}
		}
	}
})(jQuery);