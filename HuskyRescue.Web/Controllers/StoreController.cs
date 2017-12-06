using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Core.ViewModel.Store;
using HuskyRescue.Core.Service.Store;
using HuskyRescue.Web.Infrastructure;
using NLog.Mvc;
using System;
using System.Web.Mvc;
using EventHandler = HuskyRescue.Core.Service.Entity.EventHandler;

namespace HuskyRescue.Web.Controllers
{
	public class StoreController : BaseController
	{
		/*
		private readonly CartHandler _cartHandler = new CartHandler();
		private readonly CartItemHandler _cartItemHandler = new CartItemHandler();
		private readonly EventHandler _eventHandler = new EventHandler();
		private readonly OptionTypeHandler _optionTypeHandler = new OptionTypeHandler();
		private readonly OptionValueHandler _optionValueHandler = new OptionValueHandler();
		private readonly OrderHandler _orderHandler = new OrderHandler();
		private readonly OrderDetailHandler _orderDetailHandler = new OrderDetailHandler();
		private readonly PaymentHandler _paymentHandler = new PaymentHandler();
		private readonly PaymentMethodHandler _paymentMethodHandler = new PaymentMethodHandler();
		private readonly ProductHandler _productHandler = new ProductHandler();
		private readonly ProductCategoryHandler _productCategoryHandler = new ProductCategoryHandler();
		private readonly ProductImageHandler _productImageHandler = new ProductImageHandler();
		private readonly ProductPropertyHandler _productPropertyHandler = new ProductPropertyHandler();
		private readonly ProductVariantHandler _productVariantHandler = new ProductVariantHandler();
		private readonly ShipmentHandler _shipmentHandler = new ShipmentHandler();
		private readonly ShippingMethodHandler _shippingMethodHandler = new ShippingMethodHandler();
		private readonly ILogger _logger;

		public StoreController(ILogger logger)
		{
			_logger = logger;
		}
		public StoreController()
		{

		}

		#region Product Properties
		/// <summary>
		/// Navigate to the Create Product Property page
		/// </summary>
		/// <returns></returns>
		[Authorize]
		public ActionResult PropertyIndex()
		{

			return View(manager.StoreProductProperty(null, HuskyRescueEntitiesManager.Action.GetList));
		}
		
		[Authorize]
		public ActionResult PropertyCreate()
		{
			return View(new ProductProperty());
		}

		/// <summary>
		/// Handle request to create a product property object - return error or success
		/// </summary>
		/// <param name="productProperty">De-serialized product property from HTML form or JSON</param>
		/// <returns>JSON or View</returns>
		[Authorize]
		[HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken]
		public ActionResult PropertyCreate(ProductProperty productProperty)
		{
			// assume no error occurs
			var isError = false;
			// only used if this is an AJAX request
			JsonResponseObject response = null;
			if (Request.IsAjaxRequest())
				response = new JsonResponseObject();
			try
			{
				// Create the property object in the database
				// Method returns object with database generated unique Id
				var dbResult = manager.StoreProductProperty(productProperty, HuskyRescueEntitiesManager.Action.Create).Single();
			}
			catch (Exception ex)
			{
				isError = true;
				_logger.Error("Create Store Product Property", ex);

				if (Request.IsAjaxRequest())
				{
					response.Success = false;
					response.Exception = ex;
					response.Message = ex.Message;
				}
			}

			// Check for the type of response to return and where to re-direct the user
			if (Request.IsAjaxRequest())
			{
				return new JsonNetResult { Data = response };
			}
			else
			{
				if (isError)
				{
					return View(productProperty);
				}
				else
				{
					return RedirectToAction("PropertyIndex");
				}
			}
		}

		[Authorize]
		public ActionResult PropertyEdit(Guid id)
		{
			return View(manager.StoreProductProperty(new ProductProperty() {Id = id}, HuskyRescueEntitiesManager.Action.GetOne).Single());
		}

		/// <summary>
		/// Handle request to create a product property object - return error or success
		/// </summary>
		/// <param name="productProperty">De-serialized product property from HTML form or JSON</param>
		/// <returns>JSON or View</returns>
		[Authorize]
		[HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken]
		public ActionResult PropertyEdit(ProductProperty productProperty)
		{
			// assume no error occurs
			var isError = false;
			// only used if this is an AJAX request
			JsonResponseObject response = null;
			if (Request.IsAjaxRequest())
				response = new JsonResponseObject();
			try
			{
				// Create the property object in the database
				// Method returns object with database generated unique Id
				var dbResult = manager.StoreProductProperty(productProperty, HuskyRescueEntitiesManager.Action.Update).Single();
			}
			catch (Exception ex)
			{
				isError = true;
				_logger.Error("Edit Store Product Property", ex);

				if (Request.IsAjaxRequest())
				{
					response.Success = false;
					response.Exception = ex;
					response.Message = ex.Message;
				}
			}

			// Check for the type of response to return and where to re-direct the user
			if (Request.IsAjaxRequest())
			{
				return new JsonNetResult { Data = response };
			}
			else
			{
				if (isError)
				{
					return View(productProperty);
				}
				else
				{
					return RedirectToAction("PropertyIndex");
				}
			}
		}
		#endregion

		#region Product Options

		#endregion

		#region Product Categories

		#endregion

		#region Shipping
		[Authorize]
		public ActionResult ShippingMethodIndex()
		{
			return View(manager.StoreShippingMethod(null, HuskyRescueEntitiesManager.Action.GetList));
		}

		[Authorize]
		public ActionResult ShippingMethodCreate()
		{
			return View(new ShippingMethod());
		}

		[Authorize]
		[HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken]
		public ActionResult ShippingMethodCreate(ShippingMethod shippingMethod)
		{
			// assume no error occurs
			var isError = false;
			// only used if this is an AJAX request
			JsonResponseObject response = null;
			if (Request.IsAjaxRequest())
				response = new JsonResponseObject();
			try
			{
				// Create the property object in the database
				// Method returns object with database generated unique Id
				var dbResult = manager.StoreShippingMethod(shippingMethod, HuskyRescueEntitiesManager.Action.Create).Single();
			}
			catch (Exception ex)
			{
				isError = true;
				_logger.Error("Create Store Shipping Method", ex);

				if (Request.IsAjaxRequest())
				{
					response.Success = false;
					response.Exception = ex;
					response.Message = ex.Message;
				}
			}

			// Check for the type of response to return and where to re-direct the user
			if (Request.IsAjaxRequest())
			{
				return new JsonNetResult { Data = response };
			}
			else
			{
				if (isError)
				{
					return View(shippingMethod);
				}
				else
				{
					return RedirectToAction("ShippingMethodIndex");
				}
			}
		}

		[Authorize]
		public ActionResult ShippingMethodEdit(Guid id)
		{
			return View(manager.StoreShippingMethod(new ShippingMethod() { Id = id }, HuskyRescueEntitiesManager.Action.GetOne).Single());
		}

		[Authorize]
		[HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken]
		public ActionResult ShippingMethodEdit(ShippingMethod shippingMethod)
		{
			// assume no error occurs
			var isError = false;
			// only used if this is an AJAX request
			JsonResponseObject response = null;
			if (Request.IsAjaxRequest())
				response = new JsonResponseObject();
			try
			{
				// Create the property object in the database
				// Method returns object with database generated unique Id
				var dbResult = manager.StoreShippingMethod(shippingMethod, HuskyRescueEntitiesManager.Action.Update).Single();
			}
			catch (Exception ex)
			{
				isError = true;
				_logger.Error("Edit Store Shipping Method", ex);

				if (Request.IsAjaxRequest())
				{
					response.Success = false;
					response.Exception = ex;
					response.Message = ex.Message;
				}
			}

			// Check for the type of response to return and where to re-direct the user
			if (Request.IsAjaxRequest())
			{
				return new JsonNetResult { Data = response };
			}
			else
			{
				if (isError)
				{
					return View(shippingMethod);
				}
				else
				{
					return RedirectToAction("ShippingMethodIndex");
				}
			}
		}

		#endregion

		#region Payments

		#endregion

		#region Products

		#endregion

		#region Product Variants

		#endregion

		#region Carts

		#endregion

		#region Orders

		#endregion

		public ActionResult Index()
		{
			_logger.Trace("/Store/Index (get) called");

			var store = new Store
						{
							Products =
								manager.StoreProduct(new Product() { IsActive = true },
													 HuskyRescueEntitiesManager.Action.GetList, true),
						};
			var addressStateList = manager.UsaStates().ToSelectListItems("TX");
			store.Order.BillingAddress.AddressStateList = addressStateList;
			store.Order.ShippingAddress.AddressStateList = addressStateList;

			return View(store);
		}

		[HttpPost, ValidateJsonAntiForgeryToken]
		public ActionResult Purchase()
		{
			throw new NotImplementedException();
		}
		 */
	}
}
