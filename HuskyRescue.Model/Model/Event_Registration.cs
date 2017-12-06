using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using System.Linq.Expressions;

namespace HuskyRescue.Model
{
	public partial class Event_Registration
	{
		public static Expression<Func<Event_Registration, bool>> IsInActiveEvent()
		{
			return e => e.Event.IsActive == true;
		}

		public static Expression<Func<Event_Registration, bool>> SubmittedOnOrBefore(DateTime date)
		{
			return e => e.DateSubmitted <= date;
		}

		public static Expression<Func<Event_Registration, bool>> SubmittedOnOrAfter(DateTime date)
		{
			return e => e.DateSubmitted >= date;
		}

		public static Expression<Func<Event_Registration, bool>> SubmittedBetweenInclusive(DateTime start, DateTime end)
		{
			return e => (e.DateSubmitted >= start && e.DateSubmitted <= end);
		}

		public static Expression<Func<Event_Registration, bool>> ContainsInComment(params string[] keywords)
		{
			var predicate = PredicateBuilder.False<Event_Registration>();
			foreach (string keyword in keywords)
			{
				string temp = keyword;
				predicate = predicate.Or(e => e.Comments.Contains(temp));
			}
			return predicate;
		}
	}
}
