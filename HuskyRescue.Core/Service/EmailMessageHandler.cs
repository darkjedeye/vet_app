using System;
using System.Net.Mail;
using HuskyRescue.Core.ViewModel;

namespace HuskyRescue.Core.Service
{
	public class EmailMessageHandler : NewBaseHandler
	{
		/// <summary>
		/// public method to send email messages based on values of class' properties
		/// </summary>
		public ServiceResultEnum SendMessage(ref EmailMessage emailMessage)
		{
			// Send email to this.EmailAddressExternal if true
			if (emailMessage.SendToExternal && !string.IsNullOrEmpty(emailMessage.EmailAddressExternal))
			{
				emailMessage.MailMessageExternal = new MailMessage
				{
					Subject = emailMessage.Subject,
					Body = emailMessage.BodyTextExternal
				};
				emailMessage.MailMessageExternal.To.Add(new MailAddress(emailMessage.EmailAddressExternal, emailMessage.NameExternal));
				emailMessage.MailMessageExternal.ReplyToList.Add(new MailAddress(emailMessage.EmailAddressInternal, emailMessage.NameInternal));
				emailMessage.MailMessageExternal.From = new MailAddress(emailMessage.EmailSendFromAddress);

				// Included attachment if true
				if (emailMessage.IncludeMemoryStreamAttachment)
				{
					emailMessage.MemoryStream.Position = 0;
					emailMessage.MailMessageExternal.Attachments.Add(new Attachment(emailMessage.MemoryStream, emailMessage.AttachmentName));
				}
				if (emailMessage.Attachments.Count > 0)
				{
					foreach (var attachment in emailMessage.Attachments)
					{
						emailMessage.MailMessageExternal.Attachments.Add(attachment);
					}
				}
				// Send message
				Send(emailMessage.MailMessageExternal);
			}

			// Send email to this.EmailAddressInternal if true
			if (emailMessage.SendToInternal)
			{
				emailMessage.MailMessageInternal = new MailMessage
				{
					Subject = emailMessage.Subject,
					Body = emailMessage.BodyTextInternal
				};
				emailMessage.MailMessageInternal.To.Add(new MailAddress(emailMessage.EmailAddressInternal, emailMessage.NameInternal));
				if (!string.IsNullOrEmpty(emailMessage.EmailAddressExternal))
				{
					emailMessage.MailMessageInternal.ReplyToList.Add(new MailAddress(emailMessage.EmailAddressExternal, emailMessage.NameExternal));
				}
				emailMessage.MailMessageInternal.From = new MailAddress(emailMessage.EmailSendFromAddress);
				// Included attachment if true
				if (emailMessage.IncludeMemoryStreamAttachment)
				{
					emailMessage.MemoryStream.Position = 0;
					emailMessage.MailMessageInternal.Attachments.Add(new Attachment(emailMessage.MemoryStream, emailMessage.AttachmentName));
				}
				if (emailMessage.Attachments.Count > 0)
				{
					foreach (var attachment in emailMessage.Attachments)
					{
						emailMessage.MailMessageInternal.Attachments.Add(attachment);
					}
				}
				// Send message
				Send(emailMessage.MailMessageInternal);
			}

			return ServiceResult;
		}

		/// <summary>
		/// Private method to send Email Message via SMTP
		/// </summary>
		/// <param name="Message">MailMessage to send</param>
		private void Send(MailMessage Message)
		{
			var smtpClient = new SmtpClient();
			try
			{
				smtpClient.Send(Message);
				//TODO: research send async
			}
			catch (SmtpFailedRecipientsException ex)
			{
				//logger.Error("Smtp Error Failed to All Recipients; " + Message.To.ToString(), ex);
				Messages.Add("Smtp Error Failed to All Recipients; " + Message.To + Environment.NewLine + ex.Message);
			}
			catch (SmtpFailedRecipientException ex)
			{
				//logger.Error("Smtp Error Failed to One Recipient; " + Message.To.ToString(), ex);
				Messages.Add("Smtp Error Failed to One Recipients; " + Message.To + Environment.NewLine + ex.Message);
			}
			catch (SmtpException ex)
			{
				//logger.Error("Smtp Error; " + Message.To.ToString(), ex);
				Messages.Add("Smtp Error; " + Message.To + Environment.NewLine + ex.Message);
			}
			finally
			{
				smtpClient.Dispose();
			}
			//made it to here - success
			ServiceResult = ServiceResultEnum.Success;
		}
	}
}
