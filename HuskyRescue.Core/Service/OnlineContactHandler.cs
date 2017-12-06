using System;
using System.Linq;
using HuskyRescue.Core.Properties;
using HuskyRescue.Core.ViewModel;
using HuskyRescue.Core.ViewModel.Entity;

namespace HuskyRescue.Core.Service
{
	public class OnlineContactHandler
	{
		public OnlineContactHandler()
		{

		}

		public void SendEmail(Contact contact)
		{
			var reasonForContacting = contact.ContactReasonList.Single(x => x.Selected).Text;

			var subject = "Online Contact From " + contact.NameFirst + " " + contact.NameLast + " for " + reasonForContacting;
			var message = contact.Message;
			message += Environment.NewLine + Environment.NewLine + contact.NameFirst + " " + contact.NameLast;
			message += Environment.NewLine + contact.EmailAddress;
			message += Environment.NewLine + contact.Number;

			var sendto = Settings.Default.ContactEmail;

			if (contact.ContactReasonID.Equals("2") || contact.ContactReasonID.Equals("3"))
			{
				sendto = Settings.Default.IntakeEmail;
			}

			var emailMessage = new EmailMessage
			{
				BodyTextInternal = message,
				Subject = subject,

				EmailAddressExternal = contact.EmailAddress,
				SendToExternal = false,

				EmailAddressInternal = sendto,
				NameInternal = "Texas Husky Rescue",
				SendToInternal = true
			};
			emailMessage.SendMessage();
		}
	}
}
