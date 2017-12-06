jQuery.validator.methods.oldRequired = jQuery.validator.methods.required;

jQuery.validator.addMethod("required", function (value, element, param) {
	if ($(element).attr('data-val-required-allowempty') == 'true') {
		return true;
	}
	return jQuery.validator.methods.oldRequired.call(this, value, element, param);
},
jQuery.validator.messages.required // use default message
);

// http://stackoverflow.com/questions/10883253/mvc-3-field-mandatory-if-another-field-is-filled
jQuery.validator.addMethod('requiredif',
    function (value, element, parameters) {
    	var id = '#' + parameters['dependentproperty'];

    	// get the target value (as a string, 
    	// as that's what actual value will be)
    	var targetvalue = parameters['targetvalue'];
    	targetvalue = (targetvalue == null ? '' : targetvalue).toString();

    	// get the actual value of the target control
    	// note - this probably needs to cater for more 
    	// control types, e.g. radios
    	var control = $(id);
    	var controltype = control.attr('type');
    	var actualvalue =
            controltype === 'checkbox' ?
            control.attr('checked').toString() :
            control.val();

    	// if the condition is true, reuse the existing 
    	// required field validator functionality
    	if ($.trim(targetvalue) === $.trim(actualvalue) || ($.trim(targetvalue) === '*' && $.trim(actualvalue) !== ''))
    		return $.validator.methods.required.call(
              this, value, element, parameters);

    	return true;
    });
// http://stackoverflow.com/questions/10883253/mvc-3-field-mandatory-if-another-field-is-filled
jQuery.validator.unobtrusive.adapters.add(
    'requiredif',
    ['dependentproperty', 'targetvalue'],
    function (options) {
    	options.rules['requiredif'] = {
    		dependentproperty: options.params['dependentproperty'],
    		targetvalue: options.params['targetvalue']
    	};
    	options.messages['requiredif'] = options.message;
    });