$(document).ready(function () {
	CountDownTimer();
});

function CountDownTimer()
{
	var lastDate = new Date(2014, 0, 30, 23, 0, 0, 0);
	$('#divCountdown').countdown({
		until: lastDate,
		format: 'dHM'
	});
}