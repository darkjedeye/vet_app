/// <reference path="../../../_references.js" />

function Error(response, status, error) {
	alert("Oops! " + response.statusText);
}

function PopUp(response, status, error) {
	alert(response.responseText);
	alert(response.Success);
}

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

function IsVetInfoProvided() {
	if ($("#ApplicantVeterinarian_NameOffice").val() != "" && $("#ApplicantVeterinarian_NameDr").val() != "" && $("#ApplicantVeterinarian_PhoneNumber").val() != "") {
		return true;
	}
	else {
		return false;
	}
}

var fadeSpeed = 400;

$(document).ready(function () {
	LoadInputEvents();

	if ($("#ID").val() != "" && $("#ID").val() != "00000000-0000-0000-0000-000000000000") {
		// Loading a previously saved application
		// Make sure everything looks correct
		fadeSpeed = 0;

		$("#ResidenceOwnershipID").triggerHandler('change');
		$("input[name='ResidenceIsPetDepositRequired']").triggerHandler('change');
		$("input[name='ResidenceIsYardFenced']").triggerHandler('change');
		$("input[name='IsAppOrSpouseStudent']").triggerHandler('change');
		$("input[name='IsAppTravelFrequent']").triggerHandler('change');
		$("input[name='FilterAppIsCatOwner']").triggerHandler('change');

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

		$("form :input").attr("disabled", true);
	}
	else {
		// Loading a new application
		// Make sure everything looks correct
		LoadNewApp();
		for (var i = 0; i < 4; i++) {
			var ctrl = '#ApplicantOwnedAnimal_' + (i) + '__Name';
			$(ctrl).triggerHandler('change');
			$('#ApplicantOwnedAnimal_' + (i) + '__AlteredReason').parent().fadeOut(fadeSpeed);
			$('#ApplicantOwnedAnimal_' + (i) + '__HwPreventionReason').parent().fadeOut(fadeSpeed);
			$('#ApplicantOwnedAnimal_' + (i) + '__FullyVaccinatedReason').parent().fadeOut(fadeSpeed);
			$('#ApplicantOwnedAnimal_' + (i) + '__IsStillOwnedReason').parent().fadeOut(fadeSpeed);
		}

		$("#formApp").submit(function () {
			if ($('#formApp').valid() && (AppAnimalHasName() && IsVetInfoProvided())) {
				//its valid
				$('input[type=submit]', this).attr("disabled", "disabled");
				return true;
			}
			else {
				$('input[type=submit]').removeAttr('disabled');
				$('#formApp').validate();
				if ($('#formApp').validate().errorList.length > 0)
				{
					$('#formApp').validate().showErrors();
					return false;
				}
				if (AppAnimalHasName() && !IsVetInfoProvided()) {
					// Adopter Animal provided and not all vet info provided - prompt for information
					$('#modalVetReq').foundation('reveal', 'open');
					return false;
				}
			}
		});
	}
});

function LoadInputEvents() {
	$('#ResidenceOwnershipID').change(function () {
		if ($(this).val() == "2") {
			$('#divResidenceIsPetAllowed').fadeIn(fadeSpeed).show();
			$('#divResidenceIsPetSizeWeightLimit').fadeIn(fadeSpeed).show();
			$('#divResidenceLandlord').fadeIn(fadeSpeed).show();
		}
		else {
			$('#divResidenceIsPetAllowed').fadeOut(fadeSpeed).hide();
			$('#divResidenceIsPetSizeWeightLimit').fadeOut(fadeSpeed).hide();
			$('#divResidenceLandlord').fadeOut(fadeSpeed).hide();
		}
	});

	$("input[name='ResidenceIsPetDepositRequired']").change(function () {
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
	});

	$("input[name='ResidenceIsPetAllowed']").change(function () {
		if ($("input[name='ResidenceIsPetAllowed']:checked").val() == "True") {
			$('#divResidencePetDeposit1').fadeIn(fadeSpeed).show();
		}
		else {
			$('#divResidencePetDeposit1').fadeOut(fadeSpeed).hide();
		}
	});

	$("input[name='ResidenceIsYardFenced']").change(function () {
		if ($("input[name='ResidenceIsYardFenced']:checked").val() == 'True') {
			$('#divResidenceFenceType').fadeIn(fadeSpeed).show();
			$('#divResidenceFenceHeight').fadeIn(fadeSpeed).show();
		}
		else {
			$('#divResidenceFenceType').fadeOut(fadeSpeed).hide();
			$('#divResidenceFenceHeight').fadeOut(fadeSpeed).hide();
		}
	});

	$("input[name='IsAppOrSpouseStudent']").change(function () {
		if ($("input[name='IsAppOrSpouseStudent']:checked").val() == 'True') {
			$('#divStudentTypeList').fadeIn(fadeSpeed).show();
		}
		else {
			$('#divStudentTypeList').fadeOut(fadeSpeed).hide();
		}
	});

	$("input[name='IsAppTravelFrequent']").change(function () {
		if ($("input[name='IsAppTravelFrequent']:checked").val() == 'True') {
			$('#divAppTravelFrequency').fadeIn(fadeSpeed).show();
		}
		else {
			$('#divAppTravelFrequency').fadeOut(fadeSpeed).hide();
		}
	});

	$("input[name='FilterAppIsCatOwner']").change(function () {
		if ($("input[name='FilterAppIsCatOwner']:checked").val() == 'True') {
			$('#divFilterAppCatsOwnedCount').fadeIn(fadeSpeed).show();
		}
		else {
			$('#divFilterAppCatsOwnedCount').fadeOut(fadeSpeed).hide();
		}
	});

	// Hide/Show the "Is Altered" reason for all animals
	for (var i = 0; i < 4; i++) {
		var ctrl = '#ApplicantOwnedAnimal_' + (i) + '__Name';
		$(ctrl).change(function () {
			if ($(this).val() != "") {
				$(this).parent().next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed);
				$(this).parent().parent().next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed).next().fadeIn(fadeSpeed);
			}
			else {
				$(this).parent().next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed);
				$(this).parent().parent().next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed).next().fadeOut(fadeSpeed);
			}
			$(this).blur();
		});
	}

	for (var i = 0; i < 4; i++) {
		var ctrl = '#ApplicantOwnedAnimal_' + (i) + '__Name';
		$(ctrl).blur(function () {
			if ($(this).val() != "") {
				$(this).parent().next().next().children().first().focus();
			}
			else {
			}
		});
	}

	// Hide/Show the "Is Altered" reason for all animals
	for (var i = 0; i < 4; i++) {
		var ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsAltered']";
		$(ctrl).change(function () {
			if ($(this).val() == "False")
				$(this).parent().next().fadeIn(fadeSpeed);
			else
				$(this).parent().next().fadeOut(fadeSpeed);
		});
	}

	// Hide/Show the "Is Hw Prevention" reason for all animals
	for (var i = 0; i < 4; i++) {
		var ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsHwPrevention']";
		$(ctrl).change(function () {
			if ($(this).val() == "False")
				$(this).parent().next().fadeIn(fadeSpeed);
			else
				$(this).parent().next().fadeOut(fadeSpeed);
		});
	}

	// Hide/Show the "Is Fully Vaccinated" reason for all animals
	for (var i = 0; i < 4; i++) {
		var ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsFullyVaccinated']";
		$(ctrl).change(function () {
			if ($(this).val() == "False")
				$(this).parent().next().fadeIn(fadeSpeed);
			else
				$(this).parent().next().fadeOut(fadeSpeed);
		});
	}

	// Hide/Show the "Is Still Owned" reason for all animals
	for (var i = 0; i < 4; i++) {
		var ctrl = "input[name='ApplicantOwnedAnimal[" + (i) + "].IsStillOwned']";
		$(ctrl).change(function () {
			if ($(this).val() == "False")
				$(this).parent().next().fadeIn(fadeSpeed);
			else
				$(this).parent().next().fadeOut(fadeSpeed);
		});
	}

	var date1 = new Date();
	var date2 = new Date(date1.getFullYear() - 18, date1.getMonth(), date1.getDate());
	var dayMax = (date2 / (1000 * 60 * 60 * 24)) - (date1 / (1000 * 60 * 60 * 24));
	$('.datepicker2').datepicker({
		autoSize: true,
		changeYear: true,
		dateFormat: "mm/dd/yy",
		defaultDate: date2,
		maxDate: date2,
		minDate: null,
		yearRange: "1900:" + date2.getFullYear.toString()
	});

	$('#AppCellPhone').mask('(999) 999-9999');
	$('#AppHomePhone').mask('(999) 999-9999');
	$('#ResidenceLandlordNumber').mask('(999) 999-9999');
	$('#ApplicantVeterinarian_PhoneNumber').mask('(999) 999-9999');
	$('#AppDateBirth').mask('99/99/9999');
	$('#AppAddressZIP').mask('99999');
}

function LoadNewApp() {
	$('#divResidenceIsPetAllowed').hide();
	$('#divResidenceIsPetSizeWeightLimit').hide();
	$('#divResidenceLandlord').hide();

	$('#divResidencePetDeposit1').hide();
	$('#divResidencePetDeposit2').hide();
	$('#divResidencePetDeposit3').hide();
	$('#divResidencePetDeposit4').hide();

	$('#divResidenceFenceType').hide();
	$('#divResidenceFenceHeight').hide();

	$('#divStudentTypeList').hide();

	$('#divAppTravelFrequency').hide();

	$('#divFilterAppCatsOwnedCount').hide();
}