
function ToggleSizeOptions() {
	var $TableSizeOptions = $('#tableSizeOptions :input');
	$TableSizeOptions.setDisabled(!$('#ShowSizeOptions').prop('checked'));
}

// get product details from the database
function GetProductDetail(productId) {
	var json = JSON.stringify({ id: productId });
	$.ajax({
		dataType: 'json',
		contentType: 'application/json; charset=utf-8',
		cache: false,
		url: '/Store/GetProduct',
		data: json,
		type: "POST",
		success: function (data, status, xhr) {
			console.log(data);
			if (data.Success) {
				var product = data.Data;
				// update command is executed.
				SetProductValues(product.ProductTypeId, product.Name, product.SellPrice, product.Cost, product.Description, product.ImageLink1, product.ImageLink2, product.ImageLink3);
			}
			else {
				SetProductValues();
			}
		},
		error: function (jqXHR, textStatus, errorThrown) {
			console.log(data);
			SetProductValues();
		}
	});
}

function SetProductValues(productTypeId, name, sellPrice, cost, description, imageLink1, imageLink2, imageLink3) {
	var $productTypeId = $('select[name="ProductTypeId"]');
	var $name = $('input[name="Name"]');
	var $sellPrice = $('input[name="SellPrice"]');
	var $cost = $('input[name="Cost"]');
	var $description = $('textarea[name="Description"]');
	var $imageLink1 = $('input[name="ImageLink1"]');
	var $imageLink2 = $('input[name="ImageLink2"]');
	var $imageLink3 = $('input[name="ImageLink3"]');

	// check if any arguments are passed in
	if (arguments.length === 0) {
		// QUESTION set values to blank - do we want to do this?
	} else {
		$productTypeId.val(productTypeId);
		$name.val(name);
		$sellPrice.val(sellPrice);
		$cost.val(cost);
		$description.val(description);
		$imageLink1.val(imageLink1);
		$imageLink2.val(imageLink2);
		$imageLink3.val(imageLink3);
	}
	$productTypeId.trigger('change', true);
}

$('#ShowSizeOptions').on('click', ToggleSizeOptions);

ToggleSizeOptions();

$('#formProduct')
	.on('invalid', function() {
		var invalidFields = $(this).find('[data-invalid]');
		console.log(invalidFields);
	})
	.on('valid', function() {
		console.log('valid!');
	});

$('#IsActive').focus();