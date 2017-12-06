function SetPlayerCount() {
	if ($(this).val() == "1") {
		$('#PlayerNumber2').children().slideUp(200);
		$('#PlayerNumber3').children().slideUp(200);
		$('#PlayerNumber4').children().slideUp(200);
	}
	else if ($(this).val() == "2") {
		$('#PlayerNumber2').children().slideDown(200);
		$('#PlayerNumber3').children().slideUp(200);
		$('#PlayerNumber4').children().slideUp(200);
	}
	else if ($(this).val() == "3") {
		$('#PlayerNumber2').children().slideDown(200);
		$('#PlayerNumber3').children().slideDown(200);
		$('#PlayerNumber4').children().slideUp(200);
	}
	else if ($(this).val() == "4") {
		$('#PlayerNumber2').children().slideDown(200);
		$('#PlayerNumber3').children().slideDown(200);
		$('#PlayerNumber4').children().slideDown(200);
	}

	var totalPlayers = parseInt($("#EventRegistration_intListPlayerCount").val());
	var price = parseFloat($('#EventRegistration_Event_TicketPrice').val()).toFixed(2);
	var totalOwed = parseFloat(totalPlayers * price).toFixed(2);
	$('#EventRegistration_AmountPaid').val(totalOwed);
	$('#amountowned').text("Amount due today: $" + totalOwed);

	// remove option (if needed) from billing drop down
	var exists = false;
	var playerListSelectOptions = $('#prefillplayerlist option');
	for (var i = 3; i >= totalPlayers; i--) {
		playerListSelectOptions.each(function () {
			if (parseInt(this.value) === i) {
				exists = true;
				return false;
			}
		});
		if (exists) {
			$("#prefillplayerlist option[value='" + i + "']").remove();

			$('#EventRegistration_Attendees_' + i + '__Person_FirstName').val('');
			$('#EventRegistration_Attendees_' + i + '__Person_LastName').val('');
			$('#EventRegistration_Attendees_' + i + '__Person_Base_Addresses_0__Street').val('');
			$('#EventRegistration_Attendees_' + i + '__Person_Base_Addresses_0__City').val('');
			$('#EventRegistration_Attendees_' + i + '__Person_Base_Addresses_0__ZIP').val('');
			$('#EventRegistration_Attendees_' + i + '__Person_Base_EmailAddresses_0__Address').val('');
			$('#EventRegistration_Attendees_' + i + '__Person_Base_PhoneNumbers_0__Number').val('');
		}
	}
}

function UpdatePaymentPlayerList() {
	var inputName = $(this).prop('id');
	var playerNumber = parseInt(inputName.split('_')[2]);

	var firstNameInput = $('#EventRegistration_Attendees_' + (playerNumber) + '__Person_FirstName');
	var lastNameInput = $('#EventRegistration_Attendees_' + (playerNumber) + '__Person_LastName');

	var playerListSelectOptions = $('#prefillplayerlist option');

	// check if the option is already there
	var exists = false;
	playerListSelectOptions.each(function () {
		if (parseInt(this.value) === playerNumber) {
			exists = true;
			return false;
		}
	});

	// either name input has value
	if (firstNameInput.val() != '' || lastNameInput.val() != '') {
		if (!exists) {
			var newOption = '<option value="' + playerNumber + '">' + firstNameInput.val() + ' ' + lastNameInput.val() + '</option>';
			$('#prefillplayerlist').append(newOption);
		} else {
			$("#prefillplayerlist option[value='" + playerNumber + "']").text(firstNameInput.val() + ' ' + lastNameInput.val());
		}
	}
	else {
		// remove existing option if no name provided
		if (exists) {
			$("#prefillplayerlist option[value='" + playerNumber + "']").remove();
		}
	}
}

function PopulatePaymentInformation() {
	var playerList = $('#prefillplayerlist');
	var selectedPlayer = playerList.val();

	if (parseInt($('#prefillplayerlist').val()) >= 0) {
		var firstName = $('#EventRegistration_Attendees_' + selectedPlayer + '__Person_FirstName').val();
		var lastName = $('#EventRegistration_Attendees_' + selectedPlayer + '__Person_LastName').val();
		var street1 = $('#EventRegistration_Attendees_' + selectedPlayer + '__Person_Base_Addresses_0__Street').val();
		var stateId = $('#EventRegistration_Attendees_' + selectedPlayer + '__Person_Base_Addresses_0__StateID').val();
		var city = $('#EventRegistration_Attendees_' + selectedPlayer + '__Person_Base_Addresses_0__City').val();
		var zip = $('#EventRegistration_Attendees_' + selectedPlayer + '__Person_Base_Addresses_0__ZIP').val();
		var email = $('#EventRegistration_Attendees_' + selectedPlayer + '__Person_Base_EmailAddresses_0__Address').val();
		var phone = $('#EventRegistration_Attendees_' + selectedPlayer + '__Person_Base_PhoneNumbers_0__Number').val();

		$('#BillingInformation_Person_FirstName').val(firstName);
		$('#BillingInformation_Person_LastName').val(lastName);
		$('#BillingInformation_Person_Base_Addresses_0__Street').val(street1);
		$('#BillingInformation_Person_Base_Addresses_0__StateID').val(stateId);
		$('#BillingInformation_Person_Base_Addresses_0__City').val(city);
		$('#BillingInformation_Person_Base_Addresses_0__ZIP').val(zip);
		$('#BillingInformation_Person_Base_EmailAddresses_0__Address').val(email);
		$('#BillingInformation_Person_Base_PhoneNumbers_0__Number').val(phone);
	} else {
		$('#BillingInformation_Person_FirstName').val('');
		$('#BillingInformation_Person_LastName').val('');
		$('#BillingInformation_Person_Base_Addresses_0__Street').val('');
		$('#BillingInformation_Person_Base_Addresses_0__StateID').val('');
		$('#BillingInformation_Person_Base_Addresses_0__City').val('');
		$('#BillingInformation_Person_Base_Addresses_0__ZIP').val('');
		$('#BillingInformation_Person_Base_EmailAddresses_0__Address').val('');
		$('#BillingInformation_Person_Base_PhoneNumbers_0__Number').val('');
	}
}

// assign functions to events
for (var i = 0; i < 4; i++) {
	var firstNameInput = $('#EventRegistration_Attendees_' + (i) + '__Person_FirstName');
	var lastNameInput = $('#EventRegistration_Attendees_' + (i) + '__Person_LastName');
	firstNameInput.on('change', UpdatePaymentPlayerList);
	lastNameInput.on('change', UpdatePaymentPlayerList);
}

$('#prefillplayerlist').on('change', PopulatePaymentInformation);

// default player count to 1 (index 0)
$("#EventRegistration_intListPlayerCount").val("1");
$('#EventRegistration_intListPlayerCount').on('change', SetPlayerCount);
$('#EventRegistration_intListPlayerCount').trigger('change');

// when submitting the form
 $('#formGolfReg').submit(function () {
	// check for any invalid fields
	if ($(this).find('[data-invalid]').length > 0) {
		return false;
	}

	$('#EventRegistration_TicketsBought').val($('#EventRegistration_intListPlayerCount').val());

	$('input[type=submit]', this).attr('disabled', 'disabled');
	return true;
});