$(document).ready(function () {
	$("input[name='IsTicketsSold']").on('change', IsTicketsSold);

	IsTicketsSold();
});

function IsTicketsSold()
{
	if ($("input[name='IsTicketsSold']:checked").val() == 'True') {
		$('#divTicketPrice').show();
	}
	else {
		$('#divTicketPrice').hide();
		$('#TicketPrice').val("");
	}
}