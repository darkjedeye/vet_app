
var fadeSpeed = 400;

$(document).ready(function () {
	var date = new Date();
	var sDate = (date.getMonth() + 1) + "/" + date.getDate() + "/" + date.getFullYear();
	var aDate = sDate.split("/");
	if (aDate[0] < 10) {
		aDate[0] = "0" + aDate[0].toString();
	}
	$('#DateAdded').val(aDate.join("/"));

	LoadInputEvents();

	if ($("#ID").val() != "") {
		// Loading a previously saved application
		// Make sure everything looks correct
		fadeSpeed = 0;

		$("input[name='IsSponsoring']").triggerHandler('change');
		$("input[name='IsDonating']").triggerHandler('change');
	}
	else {
		// Loading a new application
		// Make sure everything looks correct
		$('#DateAdded').mask('99/99/9999');

		$("#DateAdded").datepicker({
			changeMonth: true,
			changeYear: true
		});

		$('#DateAdded').blur(function () {
			if (
				($(this).val() != null && $(this).size() != 0) &&
				($(this).val().length > 10 ||
				($(this).val().length < 6 && $(this).size() > 0) ||
				$(this).val().split('/').length == 1)) {
				alert('Please enter a date in the valid format: MM/DD/YYYY');
			}
		});

		$('#tdSponsorshipLevelLabel').hide();
		$('#tdSponsorshipLevelField').hide();
		//$('#trSponsor').hide();
		$('#trHasLogoBeenReceived').hide();
		$('#trIsSingageComplete').hide();
		$('#tdDonationAmountLabel').hide();
		$('#tdDonationAmountField').hide();
		$('#trIsDonationRecieved').hide();
	}
});

function LoadInputEvents() {
	$("input[name='IsSponsoring']").change(function () {
		if ($("#IsSponsoring").is(':checked')) {
			$('#tdSponsorshipLevelLabel').fadeIn(fadeSpeed);
			$('#tdSponsorshipLevelField').fadeIn(fadeSpeed);
			//$('#trSponsor').fadeIn(fadeSpeed);
			$('#trHasLogoBeenReceived').fadeIn(fadeSpeed);
			$('#trIsSingageComplete').fadeIn(fadeSpeed);
		}
		else {
			$('#tdSponsorshipLevelLabel').fadeOut(fadeSpeed);
			$('#tdSponsorshipLevelField').fadeOut(fadeSpeed);
			//$('#trSponsor').fadeOut(fadeSpeed);
			$('#trHasLogoBeenReceived').fadeOut(fadeSpeed);
			$('#trIsSingageComplete').fadeOut(fadeSpeed);
		}
	});


	$("input[name='IsDonating']").change(function () {
		if ($("#IsDonating").is(':checked')) {
			$('#tdDonationAmountLabel').fadeIn(fadeSpeed);
			$('#tdDonationAmountField').fadeIn(fadeSpeed);
			$('#trIsDonationRecieved').fadeIn(fadeSpeed);
		}
		else {
			$('#tdDonationAmountLabel').fadeOut(fadeSpeed);
			$('#tdDonationAmountField').fadeOut(fadeSpeed);
			$('#trIsDonationRecieved').fadeOut(fadeSpeed);
		}
	});
}
