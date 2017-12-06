$(document).ready(function () {
	var ticketList = $("#TicketsBought");
	ticketList.append($("<option/>", { value: "1", text: " 1 Ticket  -  $50", selected: "true" }));
	ticketList.append($("<option/>", { value: "3", text: " 3 Tickets - $100" }));
	ticketList.append($("<option/>", { value: "4", text: " 4 Tickets - $150" }));
	ticketList.append($("<option/>", { value: "6", text: " 6 Tickets - $200" }));
	ticketList.append($("<option/>", { value: "7", text: " 7 Tickets - $250" }));
	ticketList.append($("<option/>", { value: "9", text: " 9 Tickets - $300" }));
	ticketList.append($("<option/>", { value: "10", text: "10 Tickets - $350" }));
	ticketList.append($("<option/>", { value: "12", text: "12 Tickets - $400" }));
	ticketList.append($("<option/>", { value: "13", text: "13 Tickets - $450" }));
	ticketList.append($("<option/>", { value: "15", text: "15 Tickets - $500" }));
	ticketList.append($("<option/>", { value: "16", text: "16 Tickets - $550" }));
	ticketList.append($("<option/>", { value: "18", text: "18 Tickets - $600" }));
	ticketList.append($("<option/>", { value: "19", text: "19 Tickets - $650" }));
	ticketList.append($("<option/>", { value: "21", text: "21 Tickets - $700" }));
	ticketList.append($("<option/>", { value: "22", text: "22 Tickets - $750" }));
	ticketList.append($("<option/>", { value: "24", text: "24 Tickets - $800" }));
	ticketList.append($("<option/>", { value: "25", text: "25 Tickets - $850" }));
	ticketList.append($("<option/>", { value: "27", text: "27 Tickets - $900" }));
	ticketList.append($("<option/>", { value: "28", text: "28 Tickets - $950" }));
	ticketList.append($("<option/>", { value: "30", text: "30 Tickets - $1,000" }));
	// refresh the select list
	Foundation.libs.forms.refresh_custom_select(ticketList, true);

	// Removed mask because AmEx can be 4 digits. https://txhr.codeplex.com/workitem/29
	$(".CreditCardExpireMonth").mask('99');
	$(".CreditCardExpireYear").mask('9999');

	$("#braintree-payment-form").on("valid invalid", function (e) {
		e.stopPropagation();
		e.preventDefault();

		switch (e.type) {
			case "valid":
				// any extra code to be performed if valid goes here
				break;
			case "invalid":
				console.log('valid!');
				var invalidFields = $(this).find('[data-invalid]');
				invalidFields.each(logInvalidFields);
				$('input[type=submit]').removeAttr('disabled');
				break;
		}
	});
	$("#braintree-payment-form").submit(function () {
		// check for any invalid fields
		if ($(this).find('[data-invalid]').length > 0) {
			return false;
		}

		$('input[type=submit]', this).attr("disabled", "disabled");
		$('#formApp').loading({ align: 'bottom-center', img: '/content/images/jQuery/Plugins/processing.gif', text: 'Processing...', effect: 'update', mask: 'true' });
		return true;
	});

	DisplayCreditCardPayment();

	//$("#braintree-payment-form").submit(OnSubmitForm);
});

function logInvalidFields(index, element) {
	console.log("a[" + index + "] = " + element.name);
}

function DisplayCreditCardPayment() {
	if ($('#PaymentMethod').val() == "6") {
		$('#CreditCardPayInfo').fadeIn(200).show();
	}
	else {
		$('#CreditCardPayInfo').fadeOut(200).hide();
	}
}

function OnSubmitForm() {
	if ($('#braintree-payment-form').valid() && (CheckCreditCardProvided() && IsVetInfoProvided())) {
		return true;
	}
	else {
		return false;
	}
}

function CheckCreditCardProvided() {
	if ($("#PayInfo_CreditCardNumber").val() != "" && $("#PayInfo_CreditCardCVV").val() != "" && $("#PayInfo_CreditCardExpireMonth").val() != "" && $("#PayInfo_CreditCardExpireYear").val() != "") {
		return true;
	}
	else {
		if ($("#PayInfo_CreditCardNumber").val() == "") {
			$("#valid_PayInfo_CreditCardNumber").show();
		}
		else {
			$("#valid_PayInfo_CreditCardNumber").hide();
		}

		if ($("#PayInfo_CreditCardCVV").val() == "") {
			$("#valid_PayInfo_CreditCardCVV").show();
		}
		else {
			$("#valid_PayInfo_CreditCardCVV").hide();
		}

		if ($("#PayInfo_CreditCardExpireMonth").val() == "") {
			$("#valid_PayInfo_CreditCardExpireMonth").show();
		}
		else {
			$("#valid_PayInfo_CreditCardExpireMonth").hide();
		}

		if ($("#PayInfo_CreditCardExpireYear").val() == "") {
			$("#valid_PayInfo_CreditCardExpireYear").show();
		}
		else {
			$("#valid_PayInfo_CreditCardExpireYear").hide();
		}

		return false;
	}
}

