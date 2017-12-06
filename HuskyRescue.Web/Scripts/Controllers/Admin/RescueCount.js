function UpdateCount() {
	var Action = "/Admin/UpdateCount";

	var EntityObject = {
		count: $('#count').val()
	};

	var JsonSerializedEntity = JSON.stringify(EntityObject);
	$.ajax({
		type: "POST",
		url: Action,
		dataType: "json",
		contentType: "application/json; charset=utf-8",
		data: JsonSerializedEntity,
		success: function (result) {
			console.log(result);
			if (parseInt(result.RescueCount) > 0) {
				$('#count').highlightSave();
				$('#rescueCount').text(result.RescueCount + " huskies saved and counting").highlightSave();
			}
		},
		error: function (error) {
			console.log("There was an error posting the data to the server: " + error.responseText);
		}
	});
}

$('#countUpdate').on('click', UpdateCount);

$('#count').on('keyup', function (e) {
	if (e.which == 13 && event.keyCode == 13) {
		UpdateCount();
		//e.preventDefault();
	}
});

jQuery.fn.highlightSave = function () {
	$(this).effect("highlight", { color: "green" }, 2000);
}