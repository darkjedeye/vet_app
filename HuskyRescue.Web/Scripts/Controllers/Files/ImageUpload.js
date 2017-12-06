var fadeSpeed = 400;

$(document).ready(function () {
	$("#SelectedFolder").change(function () {
		if ($(this).val() == 'NEW') {
			$('#NewFolderLabel').fadeIn(fadeSpeed);
			$('#NewFolderField').fadeIn(fadeSpeed);
		}
		else {
			$('#NewFolderLabel').fadeOut(fadeSpeed);
			$('#NewFolderField').fadeOut(fadeSpeed);
		}
	});

	$("#SelectedFolder").triggerHandler('change');

});