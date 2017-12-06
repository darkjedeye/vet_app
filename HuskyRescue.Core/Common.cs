using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using iTextSharp.text;

namespace HuskyRescue.Core
{
	/// <summary>
	/// Common methods provided through a static class
	/// </summary>
	public static class Common
	{
		/// <summary>
		/// get the name of a class property to a string
		/// http://stackoverflow.com/questions/4266426/c-sharp-how-to-get-the-name-in-string-of-a-class-property
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expr"></param>
		/// <returns></returns>
		public static string NameOf<T>(Expression<Func<T>> expr)
		{
			return ((MemberExpression)expr.Body).Member.Name;
		}

		public static List<string> FormatEntityValidationError(DbEntityValidationException ex)
		{
			var Messages = new List<string>();
			foreach (var eve in ex.EntityValidationErrors)
			{
				var message = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
											 eve.Entry.Entity.GetType().Name, eve.Entry.State);
				message = eve.ValidationErrors.Aggregate(message, (current, ve) => current + String.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
				Trace.WriteLine(message);
				Messages.Add(message);
			}
			return Messages;
		}
	}
}
