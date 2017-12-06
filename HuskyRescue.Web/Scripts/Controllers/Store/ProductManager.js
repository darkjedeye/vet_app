var productCategories;
var parentProducts;

$(document).ready(function () {
	$.ajax({
		dataType: 'json',
		contentType: 'application/json; charset=utf-8',
		cache: false,
		url: '/Store/GetProductCategories',
		type: "GET",
		success: function (data, status, xhr) {
			productCategories = data.Data;
			console.log(data);
		},
		error: function (jqXHR, textStatus, errorThrown) {
			alert(jqXHR.statusText);
		}
	});
	
	$.ajax({
		dataType: 'json',
		contentType: 'application/json; charset=utf-8',
		cache: false,
		url: '/Store/GetParentProducts',
		type: "GET",
		success: function (data, status, xhr) {
			parentProducts = data.Data;
			console.log(data);
		},
		error: function (jqXHR, textStatus, errorThrown) {
			alert(jqXHR.statusText);
		}
	});

	var getAdapter = function () {
		// prepare the data
		var source =
			{
				datatype: "json",
				datafields: [
					{ name: 'Id', type: 'string' },
					{ name: 'ParentProductId', type: 'string' },
					{ name: 'HasVariants', type: 'bool' },
					{ name: 'IsActive', type: 'bool' },
					{ name: 'ProductTypeId', type: 'string' },
					{ name: 'ProductTypeName', map: 'Category>Name', type: 'string' },
					{ name: 'Name', type: 'string' },
					{ name: 'Quantity', type: 'number' },
					{ name: 'SellPrice', type: 'number' },
					{ name: 'Cost', type: 'number' },
					{ name: 'Size', type: 'string' },
					{ name: 'Description', type: 'string' },
					{ name: 'ImageLink1FileName', type: 'string' },
					{ name: 'ImageLink2FileName', type: 'string' },
					{ name: 'ImageLink3FileName', type: 'string' },
					{ name: 'ImageLink1', type: 'string' },
					{ name: 'ImageLink2', type: 'string' },
					{ name: 'ImageLink3', type: 'string' },
					{ name: 'UpdatedOn', type: 'date' },
					{ name: 'UpdatedBy', type: 'string' }
				],
				url: '/Store/GetProducts',
				deleterow: function (rowid, commit) {
					// synchronize with the server - send delete command
					var json = JSON.stringify({ id: $('#grid').jqxGrid('getcellvalue', rowid, "Id") });
					$.ajax({
						dataType: 'json',
						contentType: 'application/json; charset=utf-8',
						cache: false,
						url: '/Store/DeleteProduct',
						data: json,
						type: "POST",
						success: function (data, status, xhr) {
							if (data.Success) {
								// update command is executed.
								commit(true);
							}
							else {
								commit(false);
							}
						},
						error: function (jqXHR, textStatus, errorThrown) {
							alert(jqXHR.statusText);
							commit(false);
						}
					});
				}
			};

		var dataAdapter = new $.jqx.dataAdapter(source);
		return dataAdapter;
	};
	// initialize jqxGrid
	$("#grid").jqxGrid({
		autoheight: true,
		autorowheight: true,
		editable: true,
		filterable: true,
		pageable: true,
		pagesize: 25,
		pagesizeoptions: ['25', '50', '100'],
		selectionmode: 'singlecell',
		showstatusbar: true,
		sortable: true,
		source: getAdapter(),
		width: '100%',
		columns: [
			{ text: 'Id', datafield: 'Id', hidden: true },
			{ text: 'ParentProductId', datafield: 'ParentProductId', hidden: true },
			{ text: 'HasVariants', datafield: 'HasVariants', hidden: true },
			{ text: 'ProductTypeId', datafield: 'ProductTypeId', hidden: true },
			{ text: 'Active?', datafield: 'IsActive', columntype: 'checkbox', width: 60 },
			{
				text: 'Parent Product', datafield: 'ParentProductName', width: 80, columntype: 'dropdownlist',
				createeditor: function (row, column, editor) {
					// assign a new data source to the dropdownlist.
					editor.jqxDropDownList({ autoDropDownHeight: true, selectedIndex: 0, source: parentProducts, displayMember: "Name", valueMember: "Id" });
					editor.on('select', function (event) {
						if (event.args) {
							var item = event.args.item;
							if (item) {
								$("#grid").jqxGrid('setcellvalue', row, "ParentProductId", item.value);
								
							}
						}
					});
				}
			},
			{
				text: 'Category', datafield: 'ProductTypeName', width: 80, columntype: 'dropdownlist',
				createeditor: function (row, column, editor) {
					// assign a new data source to the dropdownlist.
					editor.jqxDropDownList({ autoDropDownHeight: true, selectedIndex: 0, source: productCategories, displayMember: "Name", valueMember: "Id" });
					editor.on('select', function (event) {
						if (event.args) {
							var item = event.args.item;
							if (item) {
								$("#grid").jqxGrid('setcellvalue', row, "ProductTypeId", item.value);
							}
						}
					});
				},
				// update the editor's value before saving it.
				cellvaluechanging: function (row, column, columntype, oldvalue, newvalue) {
					// return the old value, if the new value is empty.
					if (newvalue == "") return oldvalue;
				}
			},
			{
				text: 'Name', datafield: 'Name', width: 150,
				validation: function (cell, value) {
					var len = value.toString().length;
					if (len > 100) {
						return { result: false, message: 'Category name cannot be longer than 100 characters. You have ' + len + '.' };
					}
					if (len == 0) {
						return { result: false, message: 'Category name most have a value' };
					}
					return true;
				}
			},
			{
				text: 'Quantity', datafield: 'Quantity', align: 'right', cellsalign: 'right', columntype: 'numberinput', width: 65,
				validation: function (cell, value) {
					var q = parseInt(value);
					if (q < 0) {
						return { result: false, message: 'Quantity must be greater 0 or greater' };
					}
					return true;
				},
				createeditor: function (row, cellvalue, editor) {
					editor.jqxNumberInput({ decimalDigits: 0, digits: 3, height: '25px' });
				}
			},
			{
				text: 'Sell Price', datafield: 'SellPrice', align: 'right', cellsalight: 'right', cellsformat: 'c2', columntype: 'numberinput', width: 120,
				validation: function (cell, value) {
					if (value < 0) {
						return { result: false, message: "Price should be greater than zero." };
					}
					return true;
				},
				createeditor: function (row, cellvalue, editor) {
					editor.jqxNumberInput({ decimalDigits: 2, digits: 3, min: 0, symbol: '$', height: '25px' });
				}
			},
			{
				text: 'Cost', datafield: 'Cost', align: 'right', cellsalight: 'right', cellsformat: 'c2', columntype: 'numberinput', width: 55,
				validation: function (cell, value) {
					if (value < 0) {
						return { result: false, message: "Cost should be greater than zero." };
					}
					return true;
				},
				createeditor: function (row, cellvalue, editor) {
					editor.jqxNumberInput({ decimalDigits: 2, digits: 3, min: 0, symbol: '$', height: '25px' });
				}
			},
			{ text: 'Size', datafield: 'Size', width: 50 },
			{ text: 'Description', datafield: 'Description', width: 250 },
			{ text: 'ImageLink1', datafield: 'ImageLink1', hidden: true },
			{
				text: 'Image Link 1', datafield: 'ImageLink1FileName', columntype: 'dropdownlist', width: 210,
				createeditor: function (row, column, editor) {
					// assign a new data source to the dropdownlist.
					editor.jqxDropDownList({
						// productImages is defined in Producs.cshtml
						autoOpen: true,
						placeHolder: "Select image",
						selectedIndex: -1,
						source: JSON.parse(productImages),
						displayMember: "ImageName",
						valueMember: "ImagePath",
						width: 200,
						itemHeight: 55,
						autoDropDownHeight: true,
						renderer: function (index, label, value) {
							var imgurl = value;
							var img = '<img height="50" width="45" src="' + imgurl + '"/>';
							var table = '<table style="min-width: 200px;"><tr><td style="width: 55px;" rowspan="2">' + img + '</td><td>' + label + '</td></tr></table>';
							return table;
						}
					});
					editor.on('select', function (event) {
						if (event.args) {
							var item = event.args.item;
							if (item) {
								$("#grid").jqxGrid('setcellvalue', row, "ImageLink1", item.value);
							}
						}
					});
				},
				// update the editor's value before saving it.
				cellvaluechanging: function (row, column, columntype, oldvalue, newvalue) {
					// return the old value, if the new value is empty.
					if (newvalue == "") return "";
				}
			},
			{ text: 'ImageLink2', datafield: 'ImageLink2', hidden: true },
			{
				text: 'Image Link 2', datafield: 'ImageLink2FileName', columntype: 'dropdownlist', width: 210,
				createeditor: function (row, column, editor) {
					// assign a new data source to the dropdownlist.
					editor.jqxDropDownList({
						// productImages is defined in Producs.cshtml
						autoOpen: true,
						placeHolder: "Select image",
						selectedIndex: -1,
						source: JSON.parse(productImages),
						displayMember: "ImageName",
						valueMember: "ImagePath",
						width: 200,
						itemHeight: 55,
						autoDropDownHeight: true,
						renderer: function (index, label, value) {
							var imgurl = value;
							var img = '<img height="50" width="45" src="' + imgurl + '"/>';
							var table = '<table style="min-width: 200px;"><tr><td style="width: 55px;" rowspan="2">' + img + '</td><td>' + label + '</td></tr></table>';
							return table;
						}
					});
					editor.on('select', function (event) {
						if (event.args) {
							var item = event.args.item;
							if (item) {
								$("#grid").jqxGrid('setcellvalue', row, "ImageLink2", item.value);
							}
						}
					});
				},
				// update the editor's value before saving it.
				cellvaluechanging: function (row, column, columntype, oldvalue, newvalue) {
					// return the old value, if the new value is empty.
					if (newvalue == "") return "";
				}
			},
			{ text: 'ImageLink3', datafield: 'ImageLink3', hidden: true },
			{
				text: 'Image Link 3', datafield: 'ImageLink3FileName', columntype: 'dropdownlist', width: 210,
				createeditor: function (row, column, editor) {
					// assign a new data source to the dropdownlist.
					editor.jqxDropDownList({
						// productImages is defined in Producs.cshtml
						autoOpen: true,
						placeHolder: "Select image",
						selectedIndex: -1,
						source: JSON.parse(productImages),
						displayMember: "ImageName",
						valueMember: "ImagePath",
						width: 200,
						itemHeight: 55,
						autoDropDownHeight: true,
						renderer: function (index, label, value) {
							var imgurl = value;
							var img = '<img height="50" width="45" src="' + imgurl + '"/>';
							var table = '<table style="min-width: 200px;"><tr><td style="width: 55px;" rowspan="2">' + img + '</td><td>' + label + '</td></tr></table>';
							return table;
						}
					});
					editor.on('select', function (event) {
						if (event.args) {
							var item = event.args.item;
							if (item) {
								$("#grid").jqxGrid('setcellvalue', row, "ImageLink3", item.value);
							}
						}
					});

				},
				// update the editor's value before saving it.
				cellvaluechanging: function (row, column, columntype, oldvalue, newvalue) {
					// return the old value, if the new value is empty.
					if (newvalue == "") return "";
				}
			},
			{ text: 'Updated On', datafield: 'UpdatedOn', editable: false, cellsformat: 'M/d/yyyy h:mm:ss', cellsalign: 'right', width: 150 },
			{ text: 'Updated By', datafield: 'UpdatedBy', editable: false, width: 100 }
		],
		renderstatusbar: function (statusbar) {
			// appends buttons to the status bar.
			var container = $("<div style='overflow: hidden; position: relative; margin: 5px;'></div>");
			var addButton = $("<div style='float: left; margin-left: 5px;'><i class='icon-plus-sign'></i><span style='margin-left: 4px; position: relative; top: -3px;'>Add</span></div>");
			var deleteButton = $("<div style='float: left; margin-left: 5px;'><i class='icon-remove-sign'></i><span style='margin-left: 4px; position: relative; top: -3px;'>Delete</span></div>");
			var reloadButton = $("<div style='float: left; margin-left: 5px;'><i class='icon-refresh'></i><span style='margin-left: 4px; position: relative; top: -3px;'>Reload</span></div>");
			container.append(addButton);
			container.append(deleteButton);
			container.append(reloadButton);
			statusbar.append(container);
			addButton.jqxButton({ width: 80, height: 20 });
			deleteButton.jqxButton({ width: 85, height: 20 });
			reloadButton.jqxButton({ width: 85, height: 20 });
			// add new row.
			addButton.click(function (event) {
				$("#grid").jqxGrid('addrow', null, {
					Id: '',
					IsActive: true,
					ProductTypeId: '',
					Name: 'New Product Name',
					Quantity: 0,
					SellPrice: 0,
					Cost: 0,
					Size: '',
					Description: '',
					ImageLink1: '',
					ImageLink2: '',
					ImageLink3: ''
				});
			});
			// delete selected row.
			deleteButton.click(function (event) {
				var selectedrowindex = $("#grid").jqxGrid('getselectedcell').rowindex;
				var rowscount = $("#grid").jqxGrid('getdatainformation').rowscount;
				if (selectedrowindex >= 0 && selectedrowindex < rowscount) {
					var id = $("#grid").jqxGrid('getrowid', selectedrowindex);
					var commit = $("#grid").jqxGrid('deleterow', id);
				}
			});
			// reload grid data.
			reloadButton.click(function (event) {
				$("#grid").jqxGrid({ source: getAdapter() });
			});
		}
	});
	$("#grid").on('cellvaluechanged', function (event) {
		var column = args.datafield;
		var row = args.rowindex;
		var value = args.newvalue;
		var oldvalue = args.oldvalue;
		var datafield = args.datafield;

		if (datafield == "Id" || datafield == "UpdatedOn" || datafield == "UpdatedBy" || datafield == "ProductTypeName") {
			return;
		}

		var rowdata = $('#grid').jqxGrid('getrowdata', row);

		var data = {
			Id: rowdata.Id,
			IsActive: rowdata.IsActive,
			ProductTypeId: rowdata.ProductTypeId,
			Name: rowdata.Name,
			Quantity: rowdata.Quantity,
			SellPrice: rowdata.SellPrice,
			Cost: rowdata.Cost,
			Size: rowdata.Size,
			Description: rowdata.Description,
			ImageLink1: rowdata.ImageLink1,
			ImageLink2: rowdata.ImageLink2,
			ImageLink3: rowdata.ImageLink3
		};

		// to the JSON object into a string to send in the POST request
		var json = JSON.stringify(data);
		
		// send the request to the server via POST. 
		$.ajax({
			cache: false,
			dataType: 'json',
			contentType: 'application/json; charset=utf-8',
			url: '/Store/UpdateProduct',
			data: json,
			type: 'POST',
			success: function (data, status, xhr) {
				if (data.Success) {
					// update command is executed.
					$("#grid").jqxGrid('setcellvalue', args.rowindex, "Id", data.Data.Id);
					$("#grid").jqxGrid('setcellvalue', args.rowindex, "UpdatedOn", data.Data.UpdatedOn);
					$("#grid").jqxGrid('setcellvalue', args.rowindex, "UpdatedBy", data.Data.UpdatedBy);
				}
				else {

				}
			},
			error: function (jqXHR, textStatus, errorThrown) {
				// update failed.
			}
		});
	});
});
