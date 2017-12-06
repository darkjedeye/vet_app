using AutoMapper;

namespace HuskyRescue.Core.Mappers
{
	public static class AutoMapperConfiguration
	{
		/// <summary>
		/// Initialize the auto-mapper rules for the ViewModel <==> Model mappings
		/// </summary>
		public static void Configure()
		{
			Mapper.Initialize(map =>
			{
				map.AddProfile<Blog.Comments>();
				map.AddProfile<Blog.Post>();
				map.AddProfile<Blog.Tags>();
				map.AddProfile<Entity.Address>();
				map.AddProfile<Entity.Applicant>();
				map.AddProfile<Entity.ApplicantOwnedAnimal>();
				map.AddProfile<Entity.ApplicantVeterinanrian>();
				map.AddProfile<Entity.Base>();
				map.AddProfile<Entity.Business>();
				map.AddProfile<Entity.Dog>();
				map.AddProfile<Entity.Donation>();
				map.AddProfile<Entity.DonationItems>();
				map.AddProfile<Entity.EmailAddress>();
				map.AddProfile<Entity.Event>();
				map.AddProfile<Entity.EventAttendee>();
				map.AddProfile<Entity.EventRegistration>();
				map.AddProfile<Entity.EventSponsor>();
				map.AddProfile<Entity.EventSponsorshipLevel>();
				map.AddProfile<Entity.EventSponsorshipLevelType>();
				map.AddProfile<Entity.File>();
				map.AddProfile<Entity.Person>();
				map.AddProfile<Entity.PhoneNumber>();
				map.AddProfile<Enum.BusinessType>();
				map.AddProfile<Enum.DonationItemType>();
				map.AddProfile<Enum.EmailType>();
				map.AddProfile<Enum.EntityType>();
				map.AddProfile<Enum.EventAttendeeType>();
				map.AddProfile<Enum.EventDonationPurpose>();
				map.AddProfile<Enum.EventType>();
				map.AddProfile<Enum.Gender>();
				map.AddProfile<Enum.LogActivityEventType>();
				map.AddProfile<Enum.Misc>();
				map.AddProfile<Enum.PetDepositCoverageType>();
				map.AddProfile<Enum.PhoneNumberType>();
				map.AddProfile<Enum.ResidenceOwnershipType>();
				map.AddProfile<Enum.ResidenceType>();
				map.AddProfile<Enum.StreetAddressType>();
				map.AddProfile<Enum.StudentType>();
				map.AddProfile<Enum.UsaStates>();
				map.AddProfile<Logging.Log>();
				map.AddProfile<Logging.LogUserActivity>();
				map.AddProfile<Store.Cart>();
				map.AddProfile<Store.CartItem>();
				map.AddProfile<Store.OptionType>();
				map.AddProfile<Store.OptionValue>();
				map.AddProfile<Store.Order>();
				map.AddProfile<Store.OrderDetail>();
				map.AddProfile<Store.Payment>();
				map.AddProfile<Store.PaymentMethod>();
				map.AddProfile<Store.Product>();
				map.AddProfile<Store.ProductCategory>();
				map.AddProfile<Store.ProductImage>();
				map.AddProfile<Store.ProductProperty>();
				map.AddProfile<Store.ProductVariant>();
				map.AddProfile<Store.Shipment>();
				map.AddProfile<Store.ShippingMethod>();
				map.AddProfile<System.SystemConfig>();
				map.AddProfile<System.SystemConfigCategory>();
			});
		}
	}
}
