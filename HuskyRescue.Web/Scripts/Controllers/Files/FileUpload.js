
$(document).ready(function () {
	$('#fineUploaderElementId').fineUploader({
		request: {
			endpoint: '/Files/UploadFile'
		}
	});
});