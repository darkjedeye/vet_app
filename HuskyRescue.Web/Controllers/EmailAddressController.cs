using AnimalRescue.Web.Helpers;
using System.Web.Mvc;
using AnimalRescue.Web.ViewModel;

namespace AnimalRescue.Web.Controllers
{
	public class EmailAddressController : Controller
	{
		//
		// POST: /EmailAddress/Create
		[HttpPost]
		public JsonResult Create(Entity_EmailAddressViewModel EmailAddress)
		{
			string ID = "";
			int ChangeCount = 0;
			using (Model.AnimalRescueEntities context = new Model.AnimalRescueEntities())
			{
				context.Connection.Open();

				ChangeCount = context.Entity_EmailAddressCreate(EmailAddress, out ID, true);

				context.Connection.Close();
			}

			var result = new { ChangeCount = ChangeCount, NewID = ID };
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		//
		// POST: /EmailAddress/Edit/5
		[HttpPost]
		public JsonResult Edit(Entity_EmailAddressViewModel EmailAddress)
		{
			int ChangeCount = 0;

			using (Model.AnimalRescueEntities context = new Model.AnimalRescueEntities())
			{
				context.Connection.Open();

				ChangeCount = context.Entity_EmailAddressUpdate(EmailAddress, true);

				context.Connection.Close();
			}

			var result = new { ChangeCount = ChangeCount };
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		//
		// POST: /EmailAddress/Delete/5
		[HttpPost]
		public JsonResult Delete(Entity_EmailAddressViewModel EmailAddressVM)
		{
			int ChangeCount = 0;

			using (Model.AnimalRescueEntities context = new Model.AnimalRescueEntities())
			{
				context.Connection.Open();

				ChangeCount = context.Entity_EmailAddressDelete(EmailAddressVM, true);

				context.Connection.Close();
			}

			var result = new { ChangeCount = ChangeCount };
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}
