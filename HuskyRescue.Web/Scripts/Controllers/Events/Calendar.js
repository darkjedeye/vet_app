
$(document).ready(function () {

	// page is now ready, initialize the calendar...

	$('#calendar').fullCalendar({
		events: 'http://www.google.com/calendar/feeds/contact%40texashuskyrescue.org/public/basic'
	});

});