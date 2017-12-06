$(document).ready(function () {
	$('#contactForm')
		.on('invalid', function () {
			var invalid_fields = $(this).find('[data-invalid]');
			console.log(invalid_fields);
			$('input[type=submit]').removeAttr('disabled');
			//$('#contactForm').validate().showErrors();
		});
	$('#contactForm')
		.on('valid', function () {
			console.log('valid!');
			$('input[type=submit]', this).attr("disabled", "disabled");
			$('#contactForm').loading({ align: 'center', img: '/content/images/Plugins/processing.gif', text: 'Processing...', effect: 'update', mask: 'true' });
		});

	$('#NameFirst').focus();
});
