using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Models
{
	public class GuestResponse : IDataErrorInfo
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public bool? WillAttend { get; set; }


		public string Error	{get { return null; }} // in our example dont uses

		public string this[string columnName]
		{
			get { 
				if (columnName =="Name" && string.IsNullOrEmpty(Name))
					return "Please enter your name"; // не было введено имя

				if (columnName == "Email" && !Regex.IsMatch(Email, ".+\\@.+\\..+"))
					return "Please enter a valid email address"; // введен неверный email

				if (columnName == "Phone" && string.IsNullOrEmpty(Phone))
					return "Please enter your phone number"; // не был введен телефон

				if (columnName == "WillAttend" && !WillAttend.HasValue)
					return "Please specify wheter you'll attend"; // не было указано планирует ли он посетить

				return null;
			}
		}


		public void Submit()
		{
			EnsureCurrentlyValid();

			// отправить по электронной почте
			var message = new StringBuilder();
			message.AppendFormat("Date: {0:yyyy-MM-dd hh:mm}\n", DateTime.Now);
			message.AppendFormat("RSVP from: {0}\n", Name);
			message.AppendFormat("Email: {0}\n", Email);
			message.AppendFormat("phone: {0}\n", Phone);
			message.AppendFormat("Can come: {0}\n", WillAttend.Value ? "Yes" : "No" );

			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Send(new MailMessage("fintalex@mail.ru", "fintalex@mail.ru", Name + (WillAttend.Value ? " will attend" : " won't attend"), message.ToString()));
		}

		private void EnsureCurrentlyValid()
		{ 
			// является достоверным, если IDataErrorInfo.this[] возвращает null
			// для кжадого свойства
			var propsToValidate = new[] { "Name", "Email", "Phone", "WillAttend" };
			bool isValid = propsToValidate.All(x => this[x] == null);
			if (!isValid)
			{ 
				// недопустимый GuestResponse отправлять нельзя
				throw new InvalidOperationException("Can't submit invalid guestResponse");
			}
		}
	}
}