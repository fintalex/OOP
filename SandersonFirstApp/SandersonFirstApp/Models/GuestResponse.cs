using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
	}
}