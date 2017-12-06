using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using HuskyRescue.Core.Properties;
using NLog.Mvc;

namespace HuskyRescue.Core.ViewModel
{
	/// <summary>
	/// Utility function for sending emails using the System.Net.Mail settings in web.config
	/// </summary>
	public class EmailMessage
	{
		/// <summary>
		/// Subject of the email
		/// </summary>
		public string Subject { get; set; }
		/// <summary>
		/// Body text of emails sent external to TXHR
		/// </summary>
		public string BodyTextExternal { get; set; }
		/// <summary>
		/// Body text of emails sent internally to TXHR
		/// </summary>
		public string BodyTextInternal { get; set; }
		/// <summary>
		/// "Name" associated with external email address. Ex: "Joe Smith"
		/// </summary>
		public string NameExternal { get; set; }
		/// <summary>
		/// "Name" associated with internal email address. Ex: "TX Husky Rescue"
		/// </summary>
		public string NameInternal { get; set; }
		/// <summary>
		/// Email address of external email to send message. Used in To and Reply-To
		/// </summary>
		public string EmailAddressExternal { get; set; }
		/// <summary>
		/// Internal email address to send message. Used in To and Reply-To
		/// </summary>
		public string EmailAddressInternal { get; set; }
		/// <summary>
		/// Name of email attachement
		/// </summary>
		public string AttachmentName { get; set; }
		/// <summary>
		///  memory stream of attachement 
		/// </summary>
		public MemoryStream MemoryStream = null;
		/// <summary>
		/// Email address to use in "from" (different that reply-to). defaulted to WebEmail.
		/// </summary>
		public string EmailSendFromAddress { get; set; }

		/// <summary>
		/// Send to external email address. Default true
		/// </summary>
		public bool SendToExternal { get; set; }
		/// <summary>
		/// Send to internal email address. Default true
		/// </summary>
		public bool SendToInternal { get; set; }
		/// <summary>
		/// Include attachment in email. Default false
		/// </summary>
		public bool IncludeMemoryStreamAttachment { get; set; }
		/// <summary>
		/// Is body text HTML. Default true
		/// </summary>
		public bool IsHtml { get; set; }

		internal MailMessage MailMessageExternal = null;
		internal MailMessage MailMessageInternal = null;

		public List<Attachment> Attachments { get; set; }

		private readonly ILogger logger = new Logger();

		/// <summary>
		/// Default constructor that sets default values for properties
		/// </summary>
		public EmailMessage()
		{
			EmailMessageDefault();
		}

		/// <summary>
		/// Overloaded constructor for passing in memory stream when including an attachment. 
		/// </summary>
		/// <param name="ms"></param>
		public EmailMessage(MemoryStream ms)
		{
			EmailMessageDefault();
			this.IncludeMemoryStreamAttachment = true;
			this.MemoryStream = ms;
		}

		/// <summary>
		/// Deconstructor to make sure private members are destroyed
		/// </summary>
		~EmailMessage()
		{
			if (this.MailMessageExternal != null)
				this.MailMessageExternal.Dispose();

			if (this.MailMessageInternal != null)
				this.MailMessageInternal.Dispose();
		}

		private void EmailMessageDefault()
		{
			this.Subject = string.Empty;
			this.BodyTextExternal = string.Empty;
			this.BodyTextInternal = string.Empty;
			this.EmailAddressExternal = string.Empty;
			this.EmailAddressInternal = string.Empty;
			this.NameExternal = string.Empty;
			this.NameInternal = string.Empty;
			this.AttachmentName = string.Empty;
			this.SendToExternal = true;
			this.SendToInternal = true;
			this.IncludeMemoryStreamAttachment = false;
			this.IsHtml = true;
			this.EmailSendFromAddress = Settings.Default.AdminEmail;
			this.Attachments = new List<Attachment>();
		}

		/// <summary>
		/// public method to send email messages based on values of class' properties
		/// </summary>
		public void SendMessage()
		{
			// Send email to this.EmailAddressExternal if true
			if (SendToExternal && !string.IsNullOrEmpty(EmailAddressExternal))
			{
				MailMessageExternal = new MailMessage()
				{
					Subject = Subject,
					Body = BodyTextExternal
				};
				MailMessageExternal.To.Add(new MailAddress(EmailAddressExternal, NameExternal));
				MailMessageExternal.ReplyToList.Add(new MailAddress(EmailAddressInternal, NameInternal));
				MailMessageExternal.From = new MailAddress(EmailSendFromAddress);
				// Included attachment if true
				if (IncludeMemoryStreamAttachment)
				{
					MemoryStream.Position = 0;
					MailMessageExternal.Attachments.Add(new Attachment(MemoryStream, AttachmentName));
				}
				if (Attachments.Count > 0)
				{
					foreach (var attachment in Attachments)
					{
						MailMessageExternal.Attachments.Add(attachment);
					}
				}
				// Send message
				Send(MailMessageExternal);
			}

			// Send email to this.EmailAddressInternal if true
			if (SendToInternal)
			{
				MailMessageInternal = new MailMessage()
				{
					Subject = Subject,
					Body = BodyTextInternal
				};
				MailMessageInternal.To.Add(new MailAddress(EmailAddressInternal, NameInternal));
				if (!string.IsNullOrEmpty(EmailAddressExternal))
				{
					MailMessageInternal.ReplyToList.Add(new MailAddress(EmailAddressExternal, NameExternal));
				}
				MailMessageInternal.From = new MailAddress(EmailSendFromAddress);
				// Included attachment if true
				if (IncludeMemoryStreamAttachment)
				{
					MemoryStream.Position = 0;
					MailMessageInternal.Attachments.Add(new Attachment(MemoryStream, AttachmentName));
				}
				if (Attachments.Count > 0)
				{
					foreach (var attachment in Attachments)
					{
						MailMessageInternal.Attachments.Add(attachment);
					}
				}
				// Send message
				Send(MailMessageInternal);
			}
		}

		/// <summary>
		/// Private method to send Email Message via SMTP
		/// </summary>
		/// <param name="Message">MailMessage to send</param>
		private void Send(MailMessage Message)
		{
			var SmtpClient = new SmtpClient();
			try
			{
				SmtpClient.Send(Message);
			}
			catch (SmtpFailedRecipientsException ex)
			{
				logger.Error("Smtp Error Failed to All Recipients; " + Message.To.ToString(), ex);
			}
			catch (SmtpFailedRecipientException ex)
			{
				logger.Error("Smtp Error Failed to One Recipient; " + Message.To.ToString(), ex);
			}
			catch (SmtpException ex)
			{
				logger.Error("Smtp Error; " + Message.To.ToString(), ex);
			}
			finally
			{
				SmtpClient.Dispose();
			}
		}
	}
}
