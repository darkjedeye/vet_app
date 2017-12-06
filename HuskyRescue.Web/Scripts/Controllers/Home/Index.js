$(document).ready(function () {

	$('#camera').camera();

	var prefix = $("#serverPrefix").val();

	if (prefix != "") {
		var ajax_load = "<img src='/" + prefix + "/Content/images/jQuery/Plugins/loading.gif' alt='loading...' class='center'/>";
		$("#divFostersNeeded").html(ajax_load).load("/" + prefix + "/PetFinder/FosterNeeded");
	}
	else {
		var ajax_load = "<img src='/Content/images/jQuery/Plugins/loading.gif' alt='loading...' class='center'/>";
		$("#divFostersNeeded").html(ajax_load).load("/PetFinder/FosterNeeded");
	}

});
