$(document).ready(function () {
	var getAdapter = function () {
		// prepare the data
		var source =
			{
				datatype: "json",
				datafields: [
					{ name: 'Id', type: 'string' },
					{ name: 'Name', type: 'string' },
					{ name: 'Description', type: 'string' },
					{ name: 'BannerImageLink', type: 'string' }
				],
				url: '/Store/GetProductCategories',
				deleterow: function (rowid, commit) {
					// synchronize with the server - send delete command
					var json = JSON.stringify({ id: $('#grid').jqxGrid('getcellvalue', rowid, "Id") });
					$.ajax({
						dataType: 'json',
						contentType: 'application/json; charset=utf-8',
						cache: false,
						url: '/Store/DeleteProductCategory',
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
	}
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
			{
				text: "Id", datafield: "Id", hidden: true
			},
			{
				text: "Name", datafield: "Name", width: 250,
				validation: function (cell, value) {
					var len = value.toString().length;
					if (len > 100) {
						return { result: false, message: "Category name cannot be longer than 100 characters. You have " + len + "." };
					}
					if (len == 0) {
						return { result: false, message: "Category name most have a value" };
					}
					return true;
				}
			},
			{
				text: "Description", datafield: "Description",
				validation: function (cell, value) {
					var len = value.toString().length;
					if (len > 1000) {
						return { result: false, message: "Category description cannot be longer than 1000 characters. You have " + len + "." };
					}
					if (len == 0) {
						return { result: false, message: "Category description most have a value" };
					}
					return true;
				}
			}
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
					Name: 'New category',
					Description: 'Description of new category',
					BannerImageLink: ''
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

		if (datafield == "Id") {
			return;
		}

		var rowdata = $('#grid').jqxGrid('getrowdata', row);

		var data = {
			Id: rowdata.Id,
			Name: rowdata.Name,
			Description: rowdata.Description
		};
		var json = JSON.stringify(data);
		$.ajax({
			cache: false,
			dataType: 'json',
			contentType: 'application/json; charset=utf-8',
			url: '/Store/UpdateProductCategory',
			data: json,
			type: 'POST',
			success: function (data, status, xhr) {
				if (data.Success) {
					// update command is executed.
					$("#grid").jqxGrid('setcellvalue', args.rowindex, "Id", data.Data.Id);
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
