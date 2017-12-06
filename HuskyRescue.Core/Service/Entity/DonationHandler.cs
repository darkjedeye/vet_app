using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Text;
using Fabrik.Common;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using HuskyRescue.Core.Properties;
using HuskyRescue.Core.Service.Payments;
using HuskyRescue.Core.ViewModel;
using HuskyRescue.Model;
using Donation = HuskyRescue.Core.ViewModel.Controllers.Donation.Donation;

namespace HuskyRescue.Core.Service.Entity
{
	public class DonationHandler : NewBaseHandler, IBaseDabaseHandler<Donation>
	{
		public DonationHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		public ServiceResultEnum Create(ref Donation obj)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;

			// only perform if payment section was shown to the user
			if (obj.ShowPaymentSection)
			{
					// send information to payment service
					var paymentResult = ServiceResultEnum.Failure;
					var payment = obj.GetPaymentInformation();
					try
					{
						var brainTreeHandler = new BrainTreeHandler();
						paymentResult = brainTreeHandler.SendTransactionRequest(ref payment);
						if (paymentResult == ServiceResultEnum.Success)
						{
							ServiceResult = paymentResult;
							obj.DonationInformation.PaymentTransactionId = payment.TransactionResult.Target.Id;
							Messages.Add("Payment processed successfully");
						}
					}
					catch (Exception ex)
					{
						Messages.Add(ex.Message);
					}

					// check if the payment was not processed
					if (paymentResult == ServiceResultEnum.Failure)
					{
						Messages.Add(payment.TransactionResult.Message);
						var errorMessage = payment.ErrorMessage();
						if (errorMessage.IsNotNullOrEmpty())
						{
							Messages.Add(errorMessage);
						}
						ServiceResult = paymentResult;
						return ServiceResult;
					}
				}

			// payment is a success, save information to the database
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{

					var personHandler = new PersonHandler();
					var person = obj.DonationInformation.Person;
					if (personHandler.Create(ref person) == ServiceResultEnum.Success)
					{
						obj.DonationInformation.BaseId = person.BaseID;

						// convert to database object
						var dbObj = obj.DonationInformation.ToModel();

						// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
						dbObj = context.Entity_Donation.Add(dbObj);

						// commit changes to the database
						NumberChanges = context.SaveChanges();

						// convert the database object back to a presentation object with included changes from the database (if any)
						obj.DonationInformation.Id = dbObj.Id;
					}
				}
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
				Messages.Add(ex.Message);
			}
			catch (DbEntityValidationException ex)
			{
				Messages.AddRange(Common.FormatEntityValidationError(ex));
			}

			// check if database changes were a success
			ServiceResult = NumberChanges > 0 ? ServiceResultEnum.Success : ServiceResultEnum.Failure;
			if (ServiceResult == ServiceResultEnum.Success)
			{
				Messages.Add("Donation saved to database successfully");
			}
			// if the save to database didn't work then keep going as the payment already processed.
			// TODO: log registration information to database for manual entry

			// send emails
			var emailSendResult = ServiceResultEnum.Failure;
			try
			{
				const string signature = @" 
Texas Husky Rescue
1-877-TX-HUSKY (894-8759) (phone/fax)
PO Box 118891, Carrollton, TX 75011";

				var emailBodyToDonor = new StringBuilder();
				emailBodyToDonor.AppendFormat("Thank you, {0}, for your donation of {1} to Texas Husky Rescue.",
				                  obj.DonationInformation.Person.FullName, obj.DonationInformation.Amount.ToString("C"));
				emailBodyToDonor.AppendLine().Append(signature);

				var emailBodyToGroup = new StringBuilder();
				emailBodyToGroup.AppendFormat("Donation received from {0} for {1}", obj.DonationInformation.Person.FullName, obj.DonationInformation.Amount.ToString("C"));
				if (obj.DonationInformation.DonorComments.IsNotNullOrEmpty())
				{
					emailBodyToGroup.AppendLine().Append("Notes from donor: ").AppendLine().Append(obj.DonationInformation.DonorComments);
				}

				var message = new EmailMessage
				{
					BodyTextExternal = emailBodyToDonor.ToString(),
					BodyTextInternal = emailBodyToGroup.ToString(),
					Subject = "Texas Husky Rescue Donation",
					EmailAddressExternal = obj.DonationInformation.Person.Base.EmailAddresses[0].Address,
					EmailAddressInternal = Settings.Default.ContactEmail,
					NameInternal = "Texas Husky Rescue",
					NameExternal = string.Empty
				};

				var emailMessageHandler = new EmailMessageHandler();
				emailSendResult = emailMessageHandler.SendMessage(ref message);
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}

			if (emailSendResult == ServiceResultEnum.Success)
			{
				Messages.Add("Email confirmation sent");
			}

			return ServiceResultEnum.Success;
		}

		public ServiceResultEnum Update(ref Donation obj)
		{
			throw new NotImplementedException();
		}

		public ServiceResultEnum Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public Donation ReadOne(Guid id1, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new NotImplementedException();
		}

		public List<Donation> ReadAll()
		{
			throw new NotImplementedException();
		}

		public List<Donation> ReadFiltered(Donation obj)
		{
			throw new NotImplementedException();
		}
	}
}