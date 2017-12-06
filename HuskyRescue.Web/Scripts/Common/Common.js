(function ($) {
	
	$.fn.setDisabled = function (b) {
		return this.each(function () {
			if (b)
				this.disabled = b;
			else
				this.disabled = !this.disabled;
		});
	};

	$.fn.toggleDisabled = function () {
		return this.each(function () {
			this.disabled = !this.disabled;
		});
	};

	$.fn.toggleReadOnly = function () {
		return this.each(function () {
			this.readonly = !this.readonly;
		});
	};
})(jQuery);

(function ($) {
	$(document).on('state:visible', function (e) {
		if (e.value == false) {
			$('[required]', e.target).removeAttr('required');
		}
		if (e.value == true) {
			$('.required', e.target).attr('required', true);
		}
	});
}(jQuery));

function setGritterMessageFromCookie() {
	$.each(new Array('Success', 'Error', 'Warning', 'Info'), function (i, alert) {
		var cookie = $.cookie('Gritter.' + alert);

		if (cookie && String(cookie) != 'null') {
			$.gritter.add({
				title: alert,
				text: cookie,
				class_name: 'gritter-' + alert,
				sticky: true
			});

			deleteGritterMessageCookie(alert);
			return;
		}
	});
}

// Delete the named gritter cookie
function deleteGritterMessageCookie(alert) {
	$.cookie("Gritter." + alert, null, { path: '/' });
}

function ConfigureFoundation() {
	$(document).foundation({
		 abide: {
		 	patterns: {
		 		length_3: /^.{0,3}$/,
		 		length_10: /^.{0,10}$/,
		 		length_20: /^.{0,20}$/,
		 		length_30: /^.{0,30}$/,
		 		length_50: /^.{0,50}$/,
		 		length_80: /^.{0,80}$/,
		 		length_100: /^.{0,100}$/,
		 		length_200: /^.{0,200}$/,
		 		length_255: /^.{0,255}$/,
		 		length_500: /^.{0,500}$/,
		 		length_1000: /^.{0,1000}$/,
		 		length_4000: /^.{0,4000}$/,
		 		phone: /^([\+][0-9]{1,3}([ \.\-])?)?([\(]{1}[0-9]{3}[\)])?([0-9A-Z \.\-]{1,32})((x|ext|extension)?[0-9]{1,4}?)$/
		 	}
		 }
	});

}
