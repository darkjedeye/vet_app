using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HuskyRescue.Core.ViewModel.Entity;
using HuskyRescue.Core.ViewModel.Enum;
using HuskyRescue.Core.ViewModel.Store;

namespace HuskyRescue.Core.ViewModel.Extensions
{
	public static class ToSelectListItemsHelper
	{
		public static IEnumerable<SelectListItem> ToSelectListItems(
			  this IEnumerable<UsaStates> items, string selectedId)
		{
			return

				items.OrderBy(x => x.Value)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (x.ID.Trim().Equals(selectedId.Trim(), StringComparison.CurrentCultureIgnoreCase)),
							  Text = x.Value,
							  Value = x.ID
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			  this IEnumerable<Gender> items, string selectedId)
		{
			return

				items.OrderBy(x => x.Value)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (x.ID.Trim().Equals(selectedId.Trim(), StringComparison.CurrentCultureIgnoreCase)),
							  Text = x.Value,
							  Value = x.ID
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			  this IEnumerable<PhoneNumberType> items, string selectedId)
		{
			return

				items.OrderBy(x => x.Value)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (x.ID.Trim().Equals(selectedId.Trim(), StringComparison.CurrentCultureIgnoreCase)),
							  Text = x.Value,
							  Value = x.ID
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			  this IEnumerable<EmailType> items, string selectedId)
		{
			return

				items.OrderBy(x => x.Value)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (x.ID.Trim().Equals(selectedId.Trim(), StringComparison.CurrentCultureIgnoreCase)),
							  Text = x.Value,
							  Value = x.ID
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			  this IEnumerable<BusinessType> items, string selectedId)
		{
			return

				items.OrderBy(x => x.Value)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (x.ID.Trim().Equals(selectedId.Trim(), StringComparison.CurrentCultureIgnoreCase)),
							  Text = x.Value,
							  Value = x.ID
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			  this IEnumerable<StreetAddressType> items, string selectedId)
		{
			return

				items.OrderBy(x => x.Value)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (x.ID.Trim().Equals(selectedId.Trim(), StringComparison.CurrentCultureIgnoreCase)),
							  Text = x.Value,
							  Value = x.ID
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			  this IEnumerable<StudentType> items, string selectedId = null)
		{
			return

				items.OrderBy(x => x.Value)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (!string.IsNullOrEmpty(selectedId)) && x.ID.Equals(int.Parse(selectedId)),
							  Text = x.Value,
							  Value = x.ID.ToString()
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			  this IEnumerable<ResidenceType> items, string selectedId = null)
		{
			return

				items.OrderBy(x => x.Value)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (!string.IsNullOrEmpty(selectedId)) && x.ID.Equals(int.Parse(selectedId)),
							  Text = x.Value,
							  Value = x.ID.ToString()
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			  this IEnumerable<ResidenceOwnershipType> items, string selectedId = null)
		{
			return

				items.OrderBy(x => x.Value)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (!string.IsNullOrEmpty(selectedId)) && x.ID.Equals(int.Parse(selectedId)),
							  Text = x.Value,
							  Value = x.ID.ToString()
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			  this IEnumerable<PetDepositCoverageType> items, string selectedId = null)
		{
			return

				items.OrderBy(x => x.Value)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (!string.IsNullOrEmpty(selectedId)) && x.ID.Equals(int.Parse(selectedId)),
							  Text = x.Value,
							  Value = x.ID.ToString()
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
		  this IEnumerable<Business> items, Guid id)
		{
			return

				items.OrderBy(x => x.BusinessName)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (x.ID.Equals(id) && x.Base.IsDeleted.Equals(false)),
							  Text = x.BusinessName,
							  Value = x.ID.ToString()
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
		  this IEnumerable<ContactReason> items, String id)
		{
			return

				items.OrderBy(x => x.Reason)
					  .Select(x =>
						  new SelectListItem
						  {
							  Selected = (x.ID.Equals(id)),
							  Text = x.Reason,
							  Value = x.ID.ToString()
						  });
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			this IEnumerable<Business> events, Guid? id)
		{
			return
				events.OrderBy(x => x.BusinessName)
					.Select(x =>
						new SelectListItem
						{
							Selected = (x.ID.Equals(id)),
							Text = x.BusinessName,
							Value = x.ID.ToString()
						});
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			this IEnumerable<Person> events, Guid? id)
		{
			return
				events.OrderBy(x => x.LastName)
					.Select(x =>
						new SelectListItem
						{
							Selected = (x.ID.Equals(id)),
							Text = (x.LastName + ", " + x.FirstName),
							Value = x.ID.ToString()
						});
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			this IEnumerable<EventSponsorshipLevelType> levels, int? id)
		{
			return
				levels.OrderBy(x => x.Name)
					.Select(x =>
						new SelectListItem
						{
							Selected = (x.ID == id),
							Text = x.Name + " - " + x.SponsorAmount,
							Value = x.ID.ToString()
						});
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			this IEnumerable<Event> levels, Guid? id)
		{
			return
				levels.OrderBy(x => x.Name)
					.Select(x =>
						new SelectListItem
						{
							Selected = (x.Id == id),
							Text = x.Name + " on " + x.DateOfEvent,
							Value = x.Id.ToString()
						});
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			this IEnumerable<DonationItemType> items, int id)
		{
			return
				items.OrderBy(x => x.Value)
					.Select(x =>
						new SelectListItem
						{
							Selected = (x.ID == id),
							Text = x.Value,
							Value = x.ID.ToString()
						});
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			this IEnumerable<EventDonationPurpose> items, int id)
		{
			return
				items.OrderBy(x => x.Value)
					.Select(x =>
						new SelectListItem
						{
							Selected = (x.ID == id),
							Text = x.Value,
							Value = x.ID.ToString()
						});
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			this IEnumerable<Product> items, Guid id)
		{
			return
				items.OrderBy(x => x.Name)
					.Select(x =>
						new SelectListItem
						{
							Selected = (x.Id == id),
							Text = x.Name,
							Value = x.Id.ToString()
						});
		}

		public static IEnumerable<SelectListItem> ToSelectListItems(
			this IEnumerable<ProductCategory> items, Guid id)
		{
			return
				items.OrderBy(x => x.Name)
					.Select(x =>
						new SelectListItem
						{
							Selected = (x.Id == id),
							Text = x.Name,
							Value = x.Id.ToString()
						});
		}
	}
}
