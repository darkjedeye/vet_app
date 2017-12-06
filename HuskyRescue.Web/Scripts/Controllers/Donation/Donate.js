function PopulatePaymentInformation() {
	var copyDonorInfo = $('#copydonorinfo');

	if (copyDonorInfo.prop('checked')) {
		var firstName = $('#DonationInformation_Person_FirstName').val();
		var lastName = $('#DonationInformation_Person_LastName').val();
		var street1 = $('#DonationInformation_Person_Base_Addresses_0__Street').val();
		var stateId = $('#DonationInformation_Person_Base_Addresses_0__StateID').val();
		var city = $('#DonationInformation_Person_Base_Addresses_0__City').val();
		var zip = $('#DonationInformation_Person_Base_Addresses_0__ZIP').val();
		var email = $('#DonationInformation_Person_Base_EmailAddresses_0__Address').val();
		var phone = $('#DonationInformation_Person_Base_PhoneNumbers_0__Number').val();

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

$('#copydonorinfo').on('click', PopulatePaymentInformation);

// when submitting the form
$('#formDonate').submit(function () {
	// check for any invalid fields
	if ($(this).find('[data-invalid]').length > 0) {
		return false;
	}

	$('input[type=submit]', this).attr('disabled', 'disabled');
	return true;
});