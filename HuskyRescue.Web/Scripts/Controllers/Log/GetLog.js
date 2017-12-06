var grid;
var columns = [
	{ id: "Id", name: "Id", field: "Id", width: 50 },
	{ id: "TimeStamp", name: "Time Stamp", field: "TimeStamp", width: 220 },
	{ id: "Level", name: "Level", field: "Level", width: 100 },
	{ id: "Logger", name: "Logger", field: "Logger", width: 170 },
	{ id: "Message", name: "Message", field: "Message", width: 250 },
	{ id: "ExceptionType", name: "Exception Type", field: "ExceptionType", width: 150 },
	{ id: "Operation", name: "Operation", field: "Operation", width: 150 },
	{ id: "ExceptionMessage", name: "Exception Message", field: "ExceptionMessage", width: 400 },
	{ id: "StackTrace", name: "Stack Trace", field: "StackTrace", width: 500 }
];


var options = {
	enableCellNavigation: true,
	enableColumnReorder: false,
	autoHeight: true,
	headerRowHeight: 45

};

$(function () {
	var myData = [];
	$.getJSON('/Log/GetLog', function (data) {
		myData = data;
		grid = new Slick.Grid("#logGrid", myData, columns, options);
	});
});
