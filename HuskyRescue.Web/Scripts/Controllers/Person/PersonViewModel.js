
var viewModel = {
	addNewPhone: function () {
		var html = $("#phoneNumberTemplate").render({ index: viewModel._generateGuid() });
		$("#PhoneNumberEditor").append(html);

		$(".phoneNumber").mask('(999) 999-9999');
	},
	addNewEmail: function () {
		var html = $("#emailAddressTemplate").render({ index: viewModel._generateGuid() });
		$("#EmailAddresssEditor").append(html);
	},
	_generateGuid: function () {
		// Source: http://stackoverflow.com/questions/105034/how-to-create-a-guid-uuid-in-javascript/105074#105074
		return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
			var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
			return v.toString(16);
		});
	}
};


var EntityTypes =
{
	PhoneNumber: 0,
	EmailAddress: 1,
	StreetAddress: 2,
	Person: 3
}

var ActionTypes =
{
	Create: 0,
	Update: 1,
	Delete: 2
}

function EntityControl(EntityType, InputPrefix, ActionType) {

	var InputPrefix = '[name^=\"' + InputPrefix;
	var InputSuffix = '\"]';

	var highlight = '';

	var EntityObject = new Object();
	var Action = "";
	switch (ActionType) {
		case ActionTypes.Create:
			Action = "Create";
			break;
		case ActionTypes.Update:
			Action = "Edit";
			break;
		case ActionTypes.Delete:
			Action = "Delete";
			break;
	}

	if (ActionType == ActionTypes.Create) {
		$(InputPrefix + '.' + 'EntityID' + InputSuffix).val($("#BaseID").val());
	}
	switch (EntityType) {
		case EntityTypes.PhoneNumber:
			EntityObject = {
				ID: $(InputPrefix + '.' + 'ID' + InputSuffix).val(),
				EntityID: $(InputPrefix + '.' + 'EntityID' + InputSuffix).val(),
				Type: $(InputPrefix + '.' + 'Type' + InputSuffix).val(),
				Number: $(InputPrefix + '.' + 'Number' + InputSuffix).val()
			};

			Action = "/PhoneNumber/" + Action;
			highlight = InputPrefix + InputSuffix;
			break;
		case EntityTypes.EmailAddress:
			EntityObject = {
				ID: $(InputPrefix + '.' + 'ID' + InputSuffix).val(),
				EntityID: $(InputPrefix + '.' + 'EntityID' + InputSuffix).val(),
				Type: $(InputPrefix + '.' + 'Type' + InputSuffix).val(),
				Address: $(InputPrefix + '.' + 'Address' + InputSuffix).val()
			};

			Action = "/EmailAddress/" + Action;
			highlight = InputPrefix + InputSuffix;
			break;
		case EntityTypes.StreetAddress:
			EntityObject = {
				ID: $(InputPrefix + '.' + 'ID' + InputSuffix).val(),
				EntityID: $(InputPrefix + '.' + 'EntityID' + InputSuffix).val(),
				Street: $(InputPrefix + '.' + 'Street' + InputSuffix).val(),
				Street2: $(InputPrefix + '.' + 'Street2' + InputSuffix).val(),
				City: $(InputPrefix + '.' + 'City' + InputSuffix).val(),
				StateID: $(InputPrefix + '.' + 'StateID' + InputSuffix).val(),
				ZIP: $(InputPrefix + '.' + 'ZIP' + InputSuffix).val()
			};
			Action = "/StreetAddress/" + Action;
			highlight = InputPrefix + InputSuffix;;
			break;
		case EntityTypes.Person:
			var BaseInputPrefix = "Entity_Base.";
			EntityObject = {
				ID: $(InputPrefix + 'ID' + InputSuffix).val(),
				BaseID: $(InputPrefix + 'BaseID' + InputSuffix).val(),
				FirstName: $(InputPrefix + 'FirstName' + InputSuffix).val(),
				LastName: $(InputPrefix + 'LastName' + InputSuffix).val(),
				LicenseNumber: $(InputPrefix + 'LicenseNumber' + InputSuffix).val(),
				Entity_Base: {
					ID: $(InputPrefix + BaseInputPrefix + 'ID' + InputSuffix).val(),
					IsActive: $(InputPrefix + BaseInputPrefix + 'IsActive' + InputSuffix).val(),
					IsMailable: $(InputPrefix + BaseInputPrefix + 'IsMailable' + InputSuffix).val(),
					IsEmailable: $(InputPrefix + BaseInputPrefix + 'IsEmailable' + InputSuffix).val(),
					Comments: $(InputPrefix + BaseInputPrefix + 'Comments' + InputSuffix).val()
				}
			};
			highlight = '.personDetail label';
			Action = "/Person/" + Action;
			break;
	}

	var JsonSerializedEntity = JSON.stringify(EntityObject);
	$.ajax({
		type: "POST",
		url: Action,
		dataType: "json",
		contentType: "application/json; charset=utf-8",
		data: JsonSerializedEntity,
		success: function (result) {
			console.log(result);
			if (result.ChangeCount > 0) {
				if (ActionType == ActionTypes.Delete) {
					$(highlight).fadeOutAndRemove();
				}
				else {
					$(highlight).highlightSave();
				}

				if (ActionType == ActionTypes.Create) {
					ID: $(InputPrefix + '.ID' + InputSuffix).val(result.NewID);
				}
			}
		},
		error: function (error) {
			console.log("There was an error posting the data to the server: " + error.responseText);
		}
	});
}

jQuery.fn.fadeOutAndRemove = function () {
	$(this).effect("highlight", { color: "red" }, 1000, function () { $(this).parent().fadeOut("fast"); });
}

jQuery.fn.highlightSave = function () {
	$(this).effect("highlight", { color: "green" }, 2000);
}


function EntityCRUD(InputPrefix, EntityType, ActionType) {
	switch (EntityType.toLowerCase()) {
		case "phone":
			EntityType = EntityTypes.PhoneNumber;
			break;
		case "email":
			EntityType = EntityTypes.EmailAddress;
			break;
		case "address":
			EntityType = EntityTypes.StreetAddress;
			break;
		case "person":
			EntityType = EntityTypes.Person;
			break;
	}

	switch (ActionType.toLowerCase()) {
		case "create":
			ActionType = ActionTypes.Create;
			break;
		case "delete":
			ActionType = ActionTypes.Delete;
			break;
		case "update":
			ActionType = ActionTypes.Update;
			break;
	}

	if (ActionType == ActionTypes.Delete) {
		var BaseIdInput = '[name=\"' + InputPrefix + '.EntityID\"]';
		var InputSet = '[name^=\"' + InputPrefix + '\"]';

		if ($(BaseIdInput).val() == "") {
			$(InputSet).fadeOutAndRemove();
			return;
		}
	}

	EntityControl(EntityType, InputPrefix, ActionType);
}

function AddPhone(InputPrefix) {
	EntityControl(EntityTypes.PhoneNumber, InputPrefix, ActionTypes.Create);
}

function UpdatePhone(InputPrefix) {
	EntityControl(EntityTypes.PhoneNumber, InputPrefix, ActionTypes.Update);
}

function DeletePhone(InputPrefix) {
	var BaseIdInput = '[name=\"' + InputPrefix + '.EntityID\"]';
	var InputSet = '[name^=\"' + InputPrefix + '\"]';

	if ($(BaseIdInput).val() == "") {
		$(InputSet).fadeOutAndRemove();
	}
	else {
		EntityControl(EntityTypes.PhoneNumber, InputPrefix, ActionTypes.Delete);
	}
}

function AddEmail(InputPrefix) {
	EntityControl(EntityTypes.EmailAddress, InputPrefix, ActionTypes.Create);
}

function UpdateEmail(InputPrefix) {
	EntityControl(EntityTypes.EmailAddress, InputPrefix, ActionTypes.Update);
}

function DeleteEmail(InputPrefix) {
	var BaseIdInput = '[name=\"' + InputPrefix + '.EntityID\"]';
	var InputSet = '[name^=\"' + InputPrefix + '\"]';

	if ($(BaseIdInput).val() == "") {
		$(InputSet).fadeOutAndRemove();
	}
	else {
		EntityControl(EntityTypes.EmailAddress, InputPrefix, ActionTypes.Delete);
	}
}



$(document).ready(function () {
	$('#UploadPersonFiles').fineUploader({
		request: {
			endpoint: '/Files/UploadFile', // the URL to the upload action
			paramsInBody: true,
			validation: {
				sizeLimit: 50000
			},
			text: {
				uploadButton: "Click or drop new fule"
			},
			request: {
				paramsInBody: true
			},
			params: {
				EntityID: $('#ID').val(),
				EntityType: 1,
			}
		}
	});
});
