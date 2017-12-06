using System;
using System.Collections.Generic;
using System.Linq;

namespace HuskyRescue.Core.TrackABeast
{
	public class ReadCsv
	{
		public IEnumerable<Animal> ReadFromCsv( IEnumerable<TABAnimal> animalsParsed )
		{
			return
				from b in animalsParsed
				where b.Active.ToUpper().Equals( "Y" ) && b.AdReady.ToUpper().Equals( "Y" ) && !b.PlacementStatus.ToUpper().Equals( "ADOPTED" )
				orderby b.Name
				select new Animal(
					b.Name,
					b.Sex,
					CalculateAge( b.Birthdate, b.Name ),
					false,
					false,
					b.SpecialNeeds.Length > 0,
					b.PlacementStatus.ToUpper().Equals( "ON TRIAL" ),
					DetermineFosterNeeded(b.PlacementStatus));
		}

		private bool DetermineFosterNeeded(string location)
		{
			bool isFosterNeeded = false;
			switch (location)
			{
				case "Boarded":
					isFosterNeeded = true;
					break;
				default:
					isFosterNeeded = false;
					break;
			}
			return isFosterNeeded;
		}

		private string CalculateAgeX( DateTime birthDate, string name )
		{
			DateTime now = new DateTime();
			now = DateTime.Now;
			int ageYear = now.Year - birthDate.Year;
			int ageMonth = now.Month - birthDate.Month;
			string age = string.Empty;

			if ( ( now.Month < birthDate.Month || ( now.Month == birthDate.Month && now.Day < birthDate.Day ) ) && ageYear > 1 ) ageYear--;
			if ( now.Month < birthDate.Month || ( now.Month == birthDate.Month && now.Day < birthDate.Day ) ) ageMonth++;
			if ( ageYear > 1 ) { age += ageYear.ToString() + " years "; }
			else if ( ageYear == 1 ) { age += ageYear.ToString() + " year "; }
			if ( ageMonth > 1 ) { age += ageMonth.ToString() + " months"; }
			else if ( ageMonth == 1 ) { age += ageMonth.ToString() + " month"; }
			return age;
		}

		private string CalculateAge( DateTime birthDate, string name )
		{
			int ageInYears = 0;
			int ageInMonths = 0;
			int ageInDays = 0;
			string age = string.Empty;

			CalculateAge2( birthDate, out ageInYears, out ageInMonths, out ageInDays );

			if ( ageInYears > 1 ) { age += ageInYears.ToString() + " years "; }
			else if ( ageInYears == 1 ) { age += ageInYears.ToString() + " year "; }
			if ( ageInMonths > 1 ) { age += ageInMonths.ToString() + " months"; }
			else if ( ageInMonths == 1 ) { age += ageInMonths.ToString() + " month"; }

			return age;
		}

		///
		/// Calculate the Age of a person given the birthdate.
		///
		void CalculateAge2( DateTime adtDateOfBirth, out int aintNoOfYears, out int aintNoOfMonths, out int aintNoOfDays )
		{
			// get current date.
			DateTime adtCurrentDate = DateTime.Now;
 
			// find the literal difference
			aintNoOfDays = adtCurrentDate.Day - adtDateOfBirth.Day;
			aintNoOfMonths = adtCurrentDate.Month - adtDateOfBirth.Month;
			aintNoOfYears = adtCurrentDate.Year - adtDateOfBirth.Year;
 
			if (aintNoOfDays < 0)
			{
				aintNoOfDays += DateTime.DaysInMonth(adtCurrentDate.Year, adtCurrentDate.Month);
				aintNoOfMonths--;
			}
 
			if (aintNoOfMonths < 0)
			{
				aintNoOfMonths += 12;
				aintNoOfYears--;
			}
		}
	}
}
