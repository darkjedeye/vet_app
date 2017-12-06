$('#storeCartModal').on('opened', function () {
	$(this).foundation('section', 'reflow');
});

// Close cart modal window
$('#buttonCloseCartModal').on('click', function() {
	$('#storeCartModal').foundation('reveal', 'close');
});

// Clicking "Next" button on the modal window "cart" tab
$('#buttonNavCartToInfo').on('click', function () {
	$('#modalPanelInfoPayment').click();
});

// click "Next" button on the modal window "Info & Payment" tab
$('#buttonNavInfoToOrder').on('click', function () {
	$('#modalPanelPlaceOrder').click();
});

// click "Place Order" button on the "Order" tab
$('#buttonPlaceOrder').on('click', function() {
	$.ajax({
		type: "POST",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		url: "WebService.asmx/WebMethodName",
		data: "{}",
		success: function (response) {
			$('#storeCartModal').foundation('reveal', 'open');
		}
	});
});

// click add button on the main store page
$('.cartAddButton').on('click', function() {
	CartItemAdd();
});

// click to copy shipping address to billing address
$('#CopyShippingAddress').on('click', function() {
	var $copyAddress = $('#CopyShippingAddress');

	var $shippingStreet = $('input[name="Order.ShippingAddress.StreetAddress"]');
	var $shippingCity = $('input[name="Order.ShippingAddress.City"]');
	var $shippingState = $('select[name="Order.ShippingAddress.State"]');
	var $shippingPostalCode = $('input[name="Order.ShippingAddress.PostalCode"]');
	var $billingStreet = $('input[name="Order.BillingAddress.StreetAddress"]');
	var $billingCity = $('input[name="Order.BillingAddress.City"]');
	var $billingState = $('select[name="Order.BillingAddress.State"]');
	var $billingPostalCode = $('input[name="Order.BillingAddress.PostalCode"]');

	if ($copyAddress.is(':checked')) {
		$billingStreet.val($shippingStreet.val());
		$billingCity.val($shippingCity.val());
		$billingState.val($shippingState.val());
		$billingPostalCode.val($shippingPostalCode.val());
	} else {
		$billingStreet.val('');
		$billingCity.val('');
		$billingState.val('');
		$billingPostalCode.val('');
	}
	$billingState.trigger('change', true);
});

// Remove an item from the cart
function CartItemRemove() {
	$.ajax({
		type: "POST",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		url: "Store/DeleteCartItem",
		data: "{}",
		success: function (response) {
			$(this).parent().parent().remove();
		}
	});
}

// Add an item to the cart
function CartItemAdd() {
	$.ajax({
		type: "POST",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		url: "Store/CreateCartItem",
		data: "{}",
		success: function (response) {

		}
	});
}

// Update an item in the cart
function CartItemUpdate() {
	$.ajax({
		type: "POST",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		url: "Store/UpdateCartItem",
		data: "{}",
		success: function (response) {

		}
	});
}

// get the user's cart
function CartGet() {
	$.ajax({
		type: "POST",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		url: "Store/GetCart",
		data: "{}",
		success: function (response) {

		}
	});
}

// create a cart
function CreateCart() {
	$.ajax({
		type: "POST",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		url: "Store/UpdateCart",
		data: "{}",
		success: function (response) {

		}
	});
}

// update an entire cart
function CartUpdate() {
	$.ajax({
		type: "POST",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		url: "Store/UpdateCart",
		data: "{}",
		success: function (response) {

		}
	});
}

// place order
function PlaceOrder() {
	$.ajax({
		type: "POST",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		url: "Store/Purchase",
		data: "{}",
		success: function (response) {

		}
	});
}

// Called when cart item's quantity changes to update the price
function CartItemQuantityChange() {
	var guid = GetGuidFromName(this.name);
	var $quantity = $('input[name="CartItems[' + guid + '].Quantity"]');
	var $price = $('input[name="CartItems[' + guid + '].Price"]');
	var $pricePerItem = $('input[name="CartItems[' + guid + '].PricePerItem"]');

	$price.val((parseFloat($pricePerItem.val()) * parseInt($quantity.val())).toFixed(2));

	UpdateCartTotals();
}

// Update total price and total number of items in cart
function UpdateCartTotals() {
	var totalPrice = 0.00;
	var totalNumberItems = 0;
	$.each($('input[name^="CartItems["][name$=".Price"]'), function (index, value) { totalPrice += parseFloat(value.value); });
	$.each($('input[name^="CartItems["][name$=".Quantity"]'), function (index, value) { totalNumberItems += parseFloat(value.value); });
	var total = totalNumberItems.toString() + " items, $" + totalPrice.toFixed(2);
	$('#cartTotals').val(total);
	$('#cartTotalAtPayment').val(total);
}

// used for cart and product tables to get the GUID of the row's items
function GetGuidFromName(name) {
	var start = name.indexOf("[") + 1;
	var end = name.indexOf("]");
	return name.substring(start, end);
}

var viewModel = {
	// function adds the new row to the html
	AddNewItem: function (quantity, pricePerItem, name, productId, cartId) {
		// generate a Guid value used to make the ID and NAME attributes unique for this row
		var guid = viewModel._generateGuid();
		// using JSRENDER we get the template from the itemTemplate script object and replace all "index" with the guid value
		var html = $("#itemTemplate").render({ "index": guid });
		$("#tableItems").append(html);

		var $quantity = $('input[name="CartItems[' + guid + '].Quantity"]');
		var $pricePerItem = $('input[name="CartItems[' + guid + '].PricePerItem"]');
		var $productName = $('input[name="CartItems[' + guid + '].Product.Name"]');
		var $productId = $('input[name="CartItems[' + guid + '].ProductId"]');
		var $cartId = $('input[name="CartItems[' + guid + '].CartId"]');
		
		if (!isNaN(quantity)) {
			$quantity.val(quantity);
		} else {
			$quantity.val(1);
		}
		$pricePerItem.val(pricePerItem);
		$productName.val(name);
		$productId.val(productId);
		if (cartId) {
			$cartId.val(cartId);
		}

		$quantity.on('change', CartItemQuantityChange);
	},

	// generates a unique GUID
	_generateGuid: function () {
		// Source: http://stackoverflow.com/questions/105034/how-to-create-a-guid-uuid-in-javascript/105074#105074
		return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
			var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
			return v.toString(16);
		});
	}
};
