function SetPaymentAmount() {

	var numberTickets = parseInt($('#EventRegistration_TicketsBought').val());
	var ticketPrice = parseFloat($('#EventRegistration_Event_TicketPrice').val()).toFixed(2);
	var totalOwed = parseFloat(numberTickets * ticketPrice).toFixed(2);

	//totalTicketPrice

	$('#EventRegistration_AmountPaid').val(totalOwed);
	$('#totalTicketPrice').val(totalOwed);
	$('#amountowned').text("Amount due today: $" + totalOwed);
}

function CopyContactInfoToPaymentInfo() {
	if ($('#prefillpaymentinfo').prop('checked')) {
		var firstName = $('#EventRegistration_Attendees_0__Person_FirstName').val();
		var lastName = $('#EventRegistration_Attendees_0__Person_LastName').val();
		var street1 = $('#EventRegistration_Attendees_0__Person_Base_Addresses_0__Street').val();
		var stateId = $('#EventRegistration_Attendees_0__Person_Base_Addresses_0__StateID').val();
		var city = $('#EventRegistration_Attendees_0__Person_Base_Addresses_0__City').val();
		var zip = $('#EventRegistration_Attendees_0__Person_Base_Addresses_0__ZIP').val();
		var email = $('#EventRegistration_Attendees_0__Person_Base_EmailAddresses_0__Address').val();
		var phone = $('#EventRegistration_Attendees_0__Person_Base_PhoneNumbers_0__Number').val();

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

$('#EventRegistration_TicketsBought').on('change', SetPaymentAmount);
$('#prefillpaymentinfo').on('change', CopyContactInfoToPaymentInfo);

$('#formRoughRiders')
	.on('invalid', function () {
		var invalid_fields = $(this).find('[data-invalid]');
		console.log(invalid_fields);
		$('input[type=submit]', this).removeProp('disabled');
	})
	.on('valid', function () {
		$('input[type=submit]', this).prop('disabled', 'disabled');
	});