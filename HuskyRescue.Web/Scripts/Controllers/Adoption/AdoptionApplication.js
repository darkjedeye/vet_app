function Error(response, status, error) {
	alert("Oops! " + response.statusText);
}

function PopUp(response, status, error) {
	alert(response.responseText);
	alert(response.Success);
}

// loop through each the Applicant's pets and if any have a value then validate the rest of the pet's fields
function AppAnimalHasName() {
	var validated = false;
	$(".AppAnimalName").each(function () {
		if ($(this).val() != '') {
			validated = true;
			return false; // will break the each
		} else {
			validated = false;
		}
	});
	return validated;
}

// determine if all of the Applicant's vet information has been provided
function IsVetInfoProvided() {
	if ($("#ApplicantVeterinarian_NameOffice").val() != "" && $("#ApplicantVeterinarian_NameDr").val() != "" && $("#ApplicantVeterinarian_PhoneNumber").val() != "") {
		return true;
	}
	else {
		return false;
	}
}

// determine if all of the landloard information has been provided - if needed
function IsLandLordInfoNeeded() {
	if ($('#ResidenceOwnershipID').val() == "2" && $('#ResidenceLandlordName').val() == "" && $('#ResidenceLandlordNumber').val() == "") {
		return true;
	}
	else {
		return false;
	}
}

// used to set a common speed for fading in/out hidden fields
var fadeSpeed = 400;

// when validating the form print all invalid fields to the browser's console
function logInvalidFields(index, element) {
	console.log("a[" + index + "] = " + element.name);
}

$(document).ready(function () {
	// assign all events to the inputs
	LoadInputEvents();

	// determine if this is loading an existing application or a new one (the else)
	if ($("#ID").val() != "" && $("#ID").val() != "00000000-0000-0000-0000-000000000000") {
		// Loading a previously saved application

		// set fade speed to zero - instant hide/show hidden fields
		fadeSpeed = 0;

		// "A" is for Adoption application vs. Foster application
		if ($("#ApplicantType").val() == "A") { IsAllAdultsAgreedOnAdoption(); }

		// run each function associated with inputs to make sure the correct fields are shown/hidden based on the values provided
		ResidenceOwnershipID();
		ResidenceIsPetDepositRequired();
		ResidenceIsPetAllowed();
		ResidenceIsYardFenced();
		IsAppOrSpouseStudent();
		IsAppTravelFrequent();
		FilterAppIsCatOwner();

		// trigger each event associated with all of the applicant's pets
		for (var i = 0; i < 4; i++) {
			var ctrl = '#ApplicantOwnedAnimal_' + (i) + '__Name';
			$(ctrl).triggerHandler('change');

			ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsAltered']:checked";
			$(ctrl).trigger('change');

			ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsHwPrevention']:checked";
			$(ctrl).trigger('change');

			ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsFullyVaccinated']:checked";
			$(ctrl).triggerHandler('change');

			ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsStillOwned']:checked";
			$(ctrl).triggerHandler('change');
		}
	}
	else {
		// Loading a new application

		// setup the application for a new Applicant
		LoadNewApp();

		// loop through each of the Applicant's pets and make sure they are hidden
		for (var i = 0; i < 4; i++) {
			var ctrl = '#ApplicantOwnedAnimal_' + (i) + '__Name';
			$(ctrl).triggerHandler('change');
			$('#ApplicantOwnedAnimal_' + (i) + '__AlteredReason').parent().parent().fadeOut(fadeSpeed);
			$('#ApplicantOwnedAnimal_' + (i) + '__HwPreventionReason').parent().parent().fadeOut(fadeSpeed);
			$('#ApplicantOwnedAnimal_' + (i) + '__FullyVaccinatedReason').parent().parent().fadeOut(fadeSpeed);
			$('#ApplicantOwnedAnimal_' + (i) + '__IsStillOwnedReason').parent().parent().fadeOut(fadeSpeed);
		}

		// what to do when form is submitted for validation before going to the server
		$("#formApp").on("valid invalid", function (e) {
			e.stopPropagation();
			e.preventDefault();

			switch (e.type) {
				case "valid":
					// any extra code to be performed if valid goes here
					break;
				case "invalid":
					var invalidFields = $(this).find('[data-invalid]');
					// log all invalid fields to the browser's console
					invalidFields.each(logInvalidFields);
					$('input[type=submit]').removeAttr('disabled');
					break;
			}
		});

		// what to do when the form is submitted (different than when validating)
		$("#formApp").submit(function () {
			// show modal if vet information is not provided
			if (AppAnimalHasName()) {
				if (!IsVetInfoProvided()) {
					$('#modalVetReq').foundation('reveal', 'open');
					return false;
				}
			}

			// show modal of land lord information is not provided
			if (IsLandLordInfoNeeded()) {
				$('#modalLandLordReq').foundation('reveal', 'open');
				return false;
			}

			// check for any invalid fields
			if ($(this).find('[data-invalid]').length > 0) {
				return false;
			}

			$('input[type=submit]', this).attr("disabled", "disabled");
			$('#formApp').loading({ align: 'bottom-center', img: '/content/images/jQuery/Plugins/processing.gif', text: 'Processing...', effect: 'update', mask: 'true' });
			return true;
		});
	}
});

function ResidenceOwnershipID() {
	if ($('#ResidenceOwnershipID').val() == "2") {
		$('#divResidenceIsPetAllowed').fadeIn(fadeSpeed).show();
		$('#divResidenceIsPetSizeWeightLimit').fadeIn(fadeSpeed).show();
		$('#divResidenceLandlord').fadeIn(fadeSpeed).show();
	}
	else {
		$('#divResidenceIsPetAllowed').fadeOut(fadeSpeed).hide();
		$('#divResidenceIsPetSizeWeightLimit').fadeOut(fadeSpeed).hide();
		$('#divResidenceLandlord').fadeOut(fadeSpeed).hide();
	}
}

function IsAllAdultsAgreedOnAdoption() {
	if ($("input[name='IsAllAdultsAgreedOnAdoption']:checked").val() != 'True') {
		$('#divIsAllAdultsAgreedOnAdoptionReason').fadeIn(fadeSpeed).show();
	}
	else {
		$('#divIsAllAdultsAgreedOnAdoptionReason').fadeOut(fadeSpeed).hide();
	}
}

function ResidenceIsPetDepositRequired() {
	if ($("input[name='ResidenceIsPetDepositRequired']:checked").val() == "True") {
		$('#divResidencePetDeposit2').fadeIn(fadeSpeed).show();
		$('#divResidencePetDeposit3').fadeIn(fadeSpeed).show();
		$('#divResidencePetDeposit4').fadeIn(fadeSpeed).show();
	}
	else {
		$('#divResidencePetDeposit2').fadeOut(fadeSpeed).hide();
		$('#divResidencePetDeposit3').fadeOut(fadeSpeed).hide();
		$('#divResidencePetDeposit4').fadeOut(fadeSpeed).hide();
	}
}

function ResidenceIsPetAllowed() {
	if ($("input[name='ResidenceIsPetAllowed']:checked").val() == "True") {
		$('#divResidencePetDeposit1').fadeIn(fadeSpeed).show();
	}
	else {
		$('#divResidencePetDeposit1').fadeOut(fadeSpeed).hide();
	}
}

function ResidenceIsYardFenced() {
	if ($("input[name='ResidenceIsYardFenced']:checked").val() == 'True') {
		$('#divResidenceFenceType').fadeIn(fadeSpeed).show();
		$('#divResidenceFenceHeight').fadeIn(fadeSpeed).show();
	}
	else {
		$('#divResidenceFenceType').fadeOut(fadeSpeed).hide();
		$('#divResidenceFenceHeight').fadeOut(fadeSpeed).hide();
	}
}

function IsAppOrSpouseStudent() {
	if ($("input[name='IsAppOrSpouseStudent']:checked").val() == 'True') {
		$('#divStudentTypeList').fadeIn(fadeSpeed).show();
	}
	else {
		$('#divStudentTypeList').fadeOut(fadeSpeed).hide();
	}
}

function IsAppTravelFrequent() {
	if ($("input[name='IsAppTravelFrequent']:checked").val() == 'True') {
		$('#divAppTravelFrequency').fadeIn(fadeSpeed).show();
	}
	else {
		$('#divAppTravelFrequency').fadeOut(fadeSpeed).hide();
	}
}

function FilterAppIsCatOwner() {
	if ($("input[name='FilterAppIsCatOwner']:checked").val() == 'True') {
		$('#divFilterAppCatsOwnedCount').fadeIn(fadeSpeed).show();
	}
	else {
		$('#divFilterAppCatsOwnedCount').fadeOut(fadeSpeed).hide();
	}
}

// configure the functions to events of various inputs in the form
function LoadInputEvents() {
	if ($("#ApplicantType").val() == "A") {
		$("input[name='IsAllAdultsAgreedOnAdoption']").on('change', function () { IsAllAdultsAgreedOnAdoption(); });
	}

	$('#ResidenceOwnershipID').change(function () { ResidenceOwnershipID(); });

	$("input[name='ResidenceIsPetDepositRequired']").on('change', function () { ResidenceIsPetDepositRequired(); });

	$("input[name='ResidenceIsPetAllowed']").on('change', function () { ResidenceIsPetAllowed(); });

	$("input[name='ResidenceIsYardFenced']").on('change', function () { ResidenceIsYardFenced(); });

	$("input[name='IsAppOrSpouseStudent']").on('change', function () { IsAppOrSpouseStudent(); });

	$("input[name='IsAppTravelFrequent']").on('change', function () { IsAppTravelFrequent(); });

	$("input[name='FilterAppIsCatOwner']").on('change', function () { FilterAppIsCatOwner(); });

	// Hide/Show the "Is Altered" reason for all animals
	for (var i = 0; i < 4; i++) {
		var ctrl = '#ApplicantOwnedAnimal_' + (i) + '__Name';
		$(ctrl).change(function () {
			if ($(this).val() != "") {
				//input label    div      div col  div row  
				$(this).parent().parent().parent().parent().next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed);
				$(this).parent().parent().parent().next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed);
			}
			else {
				//input label    div      div col  div row  
				$(this).parent().parent().parent().parent().next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed);
				$(this).parent().parent().parent().next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed);
			}
		});
	}

	// Hide/Show the "Is Altered" reason for all animals
	for (var i = 0; i < 4; i++) {
		var ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsAltered']";
		$(ctrl).on('change', function () {
			if ($(this).val() == "False")
				$(this).parent().parent().next().fadeIn(fadeSpeed);
			else
				$(this).parent().parent().next().fadeOut(fadeSpeed);
		});
	}

	// Hide/Show the "Is Hw Prevention" reason for all animals
	for (var i = 0; i < 4; i++) {
		var ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsHwPrevention']";
		$(ctrl).on('change', function () {
			if ($(this).val() == "False")
				$(this).parent().parent().next().fadeIn(fadeSpeed);
			else
				$(this).parent().parent().next().fadeOut(fadeSpeed);
		});
	}

	// Hide/Show the "Is Fully Vaccinated" reason for all animals
	for (var i = 0; i < 4; i++) {
		var ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsFullyVaccinated']";
		$(ctrl).on('change', function () {
			if ($(this).val() == "False")
				$(this).parent().parent().next().fadeIn(fadeSpeed);
			else
				$(this).parent().parent().next().fadeOut(fadeSpeed);
		});
	}

	// Hide/Show the "Is Still Owned" reason for all animals
	for (var i = 0; i < 4; i++) {
		var ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsStillOwned']";
		$(ctrl).on('change', function () {
			if ($(this).val() == "False")
				$(this).parent().parent().next().fadeIn(fadeSpeed);
			else
				$(this).parent().parent().next().fadeOut(fadeSpeed);
		});
	}

	if ($('#AppDateBirth').val() != "") {
		var dateSplit = $('#AppDateBirth').val().split('/');
		if (dateSplit[0].length == 1) {
			dateSplit[0] = "0" + dateSplit[0];
			$('#AppDateBirth').val(dateSplit.join('/'));
		}
	}
	$('#AppDateBirth').mask('99/99/9999');
}

function checkdate(input) {
	var validformat = /^\d{2}\/\d{2}\/\d{4}$/; //Basic check for format validity
	var returnval = false;
	if (!validformat.test(input.val()))
		alert("Invalid Date Format. Please correct and submit again.");
	else { //Detailed check for valid date ranges
		var monthfield = input.val().split("/")[0];
		var dayfield = input.val().split("/")[1]
		var yearfield = input.val().split("/")[2];
		var dayobj = new Date(yearfield, monthfield - 1, dayfield);
		if ((dayobj.getMonth() + 1 != monthfield) || (dayobj.getDate() != dayfield) || (dayobj.getFullYear() != yearfield))
			alert("Invalid Day, Month, or Year range detected. Please correct and submit again.");
		else
			returnval = true;
	}
	return returnval;
}

function LoadNewApp() {
	$('#divResidenceIsPetAllowed').hide();
	$('#divResidenceIsPetSizeWeightLimit').hide();
	$('#divResidenceLandlord').hide();

	$('#divResidencePetDeposit1').hide();
	$('#divResidencePetDeposit2').hide();
	$('#divResidencePetDeposit3').hide();
	$('#divResidencePetDeposit4').hide();

	if ($("#ApplicantType").val() == "A") { $('#divIsAllAdultsAgreedOnAdoptionReason').hide(); }

	$('#divResidenceFenceType').hide();
	$('#divResidenceFenceHeight').hide();

	$('#divStudentTypeList').hide();

	$('#divAppTravelFrequency').hide();

	$('#divFilterAppCatsOwnedCount').hide();
}