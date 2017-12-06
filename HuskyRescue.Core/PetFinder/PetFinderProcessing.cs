using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HuskyRescue.Core.Properties;

namespace HuskyRescue.Core.PetFinder
{
	public class PetFinderProcessing
	{
		public static string ApiUrl { get; set; }
		public static string ShelterID { get; set; }
		public static string ApiKey { get; set; }
		public static string ApiSecret { get; set; }
		public static DataFormat Format { get; set; }
		private static petfinderAuthData AuthData { get; set; }

		public StatusCode Status { get; set; }
		public string StatusMessage { get; set; }

		public enum AnimalType
		{
			Barnyard = 0,
			Bird = 1,
			Cat = 2,
			Dog = 3,
			Horse = 4,
			Pig = 5,
			Reptile = 6,
			SmallFurry = 7
		}

		public enum DataFormat
		{
			Xml = 1,
			Json = 2
		}

		public enum AnimalStatus
		{
			None = 0,
			Adoptable = 1,
			Hold = 2,
			Pending = 3,
			Adopted = 4
		}

		public enum AnimalRecordDetail
		{
			ID = 1,
			Basic = 2, //no description
			Full = 3
		}

		public enum StatusCode
		{
			OK = 100,
			InvalidRequest = 200,
			RecordDoesNotExist = 201,
			LimitExceeded = 202,
			InvalidGeographicalLocation = 203,
			RequestUnauthorized = 300,
			AuthenticationFailure = 301,
			GenericInternalError = 999,
		}

		public PetFinderProcessing()
		{
			AuthData = new petfinderAuthData();
		}

		/// <summary>
		/// Convert Enum AnimalType to a string
		/// </summary>
		/// <param name="PetTypeID">Enum AnimalType</param>
		/// <returns>string version of AnimalType to be used with PetFinder API animal types</returns>
		public string PetTypeString(AnimalType PetTypeID)
		{
			string petString = string.Empty;
			switch (PetTypeID)
			{
				case AnimalType.Barnyard:
					petString = "barnyard";
					break;
				case AnimalType.Bird:
					petString = "bird";
					break;
				case AnimalType.Cat:
					petString = "cat";
					break;
				case AnimalType.Dog:
					petString = "dog";
					break;
				case AnimalType.Horse:
					petString = "horse";
					break;
				case AnimalType.Pig:
					petString = "pig";
					break;
				case AnimalType.Reptile:
					petString = "reptile";
					break;
				case AnimalType.SmallFurry:
					petString = "smallfurry";
					break;
				default:
					petString = "dog";
					break;
			}
			return petString;
		}

		/// <summary>
		/// Convert Enum DataFormat to a string
		/// </summary>
		/// <param name="DataFormatID">Enum DataFormat</param>
		/// <returns>string version of DataFormat to be used with PetFinder API data format type</returns>
		public string DataFormatString(DataFormat DataFormatID)
		{
			string formatString = string.Empty;
			switch (DataFormatID)
			{
				case DataFormat.Xml:
					formatString = "xml";
					break;
				case DataFormat.Json:
					formatString = "json";
					break;
				default:
					formatString = "xml";
					break;
			}
			return formatString;
		}

		/// <summary>
		/// Convert Enum AnimalStatus to a string
		/// </summary>
		/// <param name="AnimalStatusID">Enum AnimalStatus</param>
		/// <returns>string version of AnimalStatus to be used with PetFinder API animal status</returns>
		public string AnimalStatusString(AnimalStatus AnimalStatusID)
		{
			string statusString = string.Empty;
			switch (AnimalStatusID)
			{
				case AnimalStatus.Adoptable:
					statusString = "A";
					break;
				case AnimalStatus.Adopted:
					statusString = "X";
					break;
				case AnimalStatus.Hold:
					statusString = "H";
					break;
				case AnimalStatus.Pending:
					statusString = "P";
					break;
				case AnimalStatus.None:
					statusString = string.Empty;
					break;
				default:
					statusString = "A";
					break;
			}
			return statusString;
		}

		/// <summary>
		/// Convert Enum AnimalRecordDetail to a string
		/// </summary>
		/// <param name="AnimalRecordDetailID">Enum AnimalRecordDetail</param>
		/// <returns>string version of AnimalRecordDetail to be used with PetFinder API animal record detail</returns>
		public string AnimalRecuredDetail(AnimalRecordDetail AnimalRecordDetailID)
		{
			string detailString = string.Empty;
			switch (AnimalRecordDetailID)
			{
				case AnimalRecordDetail.Basic:
					detailString = "basic";
					break;
				case AnimalRecordDetail.Full:
					detailString = "full";
					break;
				case AnimalRecordDetail.ID:
					detailString = "id";
					break;
				default:
					detailString = "basic";
					break;
			}
			return detailString;
		}

		/// <summary>
		/// Returns a token valid for a timed session (usually 60 minutes). This token must be passed to all API functions that require a token. 
		/// </summary>
		/// <returns>Token</returns>
		public string AuthGetToken()
		{
			// XML return type: petfinderAuthData

			petfinder petFinder = SendRequest("auth.getToken");

			PetFinderProcessing.AuthData = petFinder.Item as petfinderAuthData;
			return PetFinderProcessing.AuthData.token;
		}

		/// <summary>
		/// Returns a list of breeds for a particular animal. 
		/// </summary>
		/// <param name="AnimalType">Type of Animal</param>
		/// <returns></returns>
		public List<string> GetBreedList(AnimalType AnimalType)
		{
			// XML return type: petfinderBreedList
			List<string> breedList = new List<string>();
			return breedList;
		}

		/// <summary>
		/// Returns a record for a single pet. 
		/// </summary>
		/// <param name="PetID">Pet ID</param>
		/// <returns>Pet</returns>
		public petfinderPetRecord GetPet(int PetID)
		{
			return new petfinderPetRecord();
		}

		/// <summary>
		/// Returns a record for a single shelter. 
		/// </summary>
		/// <returns>petfinderShelterRecord</returns>
		public petfinderShelterRecord GetShelter()
		{
			List<KeyValuePair<string, string>> urlParameters = new List<KeyValuePair<string, string>>();
			urlParameters.Add(new KeyValuePair<string, string>("id", PetFinderProcessing.ShelterID));

			petfinder petFinder = SendRequest("shelter.get", urlParameters);

			return (petfinderShelterRecord)petFinder.Item;
		}

		/// <summary>
		/// Returns a list of IDs or collection of pet records for an individual shelter 
		/// </summary>
		/// <param name="animalStatus">optional (default=A, public may only list adoptable pets); A=adoptable, H=hold, P=pending, X=adopted/removed</param>
		/// <param name="offset">offset into the result set (default is 0)</param>
		/// <param name="count">how many records to return for this particular API call (default is 50)</param>
		/// <param name="recordDetail">How much of the pet record to return: id, basic (no description), full</param>
		/// <returns>petfinderPetRecordList</returns>
		public petfinderPetRecordList GetShelterPets(AnimalStatus animalStatus = AnimalStatus.Adoptable, int offset = 0, int count = 50, AnimalRecordDetail recordDetail = AnimalRecordDetail.Full)
		{
			List<KeyValuePair<string, string>> urlParameters = new List<KeyValuePair<string, string>>();
			urlParameters.Add(new KeyValuePair<string, string>("id", PetFinderProcessing.ShelterID));
			urlParameters.Add(new KeyValuePair<string, string>("status", AnimalStatusString(animalStatus)));
			urlParameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
			urlParameters.Add(new KeyValuePair<string, string>("count", count.ToString()));
			urlParameters.Add(new KeyValuePair<string, string>("output", AnimalRecuredDetail(recordDetail)));

			petfinder petFinder = SendRequest("shelter.getPets", urlParameters);
			return (petfinderPetRecordList)petFinder.Item;
		}

		private petfinder SendRequest(string method, List<KeyValuePair<string, string>> urlParameters = null)
		{
			HttpWebRequest request = null;
			string xmlText = string.Empty;
			petfinder petFinder = null;
			StringBuilder Url = new StringBuilder();

			// add key for api
			Url.Append("key=").Append(Settings.Default.PetFinderKey);

			// add token if we have one
			if (!string.IsNullOrEmpty(PetFinderProcessing.AuthData.token))
			{
				Url.Append("&token=").Append(PetFinderProcessing.AuthData.token);
			}

			// Build URL Parameters
			if (urlParameters != null)
			{
				foreach (KeyValuePair<string, string> pair in urlParameters)
				{
					Url.Append("&").Append(pair.Key).Append("=").Append(pair.Value);
				}
				Url.Append("&format=").Append(DataFormatString(PetFinderProcessing.Format));
			}

			// add sig
			using (MD5 md5Hash = MD5.Create())
			{
				string md5 = GetMd5Hash(md5Hash, Settings.Default.PetFinderSecret + Url.ToString());
				Url.Append("&sig=").Append(md5);
			}

			Url.Insert(0, "http://api.petfinder.com/" + method + "?");

			Trace.TraceInformation(DateTime.Now.ToUniversalTime() + " - PetFinder URL: " + Url.ToString());

			try
			{
				request = WebRequest.Create(Url.ToString()) as HttpWebRequest;
				request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
				request.Method = WebRequestMethods.Http.Get;
				request.KeepAlive = false;
				request.AllowAutoRedirect = false;

				System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(petfinder), "http://www.w3.org/2001/XMLSchema-instance");

				using (WebResponse response = request.GetResponse())
				{
					using (StreamReader reader = new StreamReader(response.GetResponseStream()))
					{
						using (XmlTextReader xmlReader = new XmlTextReader(reader))
						{
							petFinder = (petfinder)xmlSerializer.Deserialize(xmlReader);
						}
					}
				}
			}
			catch
			{
			}

			StatusMessage = petFinder.header.status.message;

			switch (Int32.Parse(petFinder.header.status.code))
			{
				case 100:
					Status = StatusCode.OK;
					break;
				case 200:
					Status = StatusCode.InvalidRequest;
					break;
				case 201:
					Status = StatusCode.RecordDoesNotExist;
					break;
				case 202:
					Status = StatusCode.LimitExceeded;
					break;
				case 203:
					Status = StatusCode.InvalidGeographicalLocation;
					break;
				case 300:
					Status = StatusCode.RequestUnauthorized;
					break;
				case 301:
					Status = StatusCode.AuthenticationFailure;
					break;
				case 999:
					Status = StatusCode.GenericInternalError;
					break;
			}

			Trace.TraceInformation("\t" + Status.ToString() + " " + StatusMessage);
			Trace.Flush();
			return petFinder;
		}

		private string GetMd5Hash(MD5 md5Hash, string input)
		{

			// Convert the input string to a byte array and compute the hash.
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

			// Create a new Stringbuilder to collect the bytes
			// and create a string.
			StringBuilder sBuilder = new StringBuilder();

			// Loop through each byte of the hashed data 
			// and format each one as a hexadecimal string.
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			// Return the hexadecimal string.
			return sBuilder.ToString();
		}

		// Verify a hash against a string.
		private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
		{
			// Hash the input.
			string hashOfInput = GetMd5Hash(md5Hash, input);

			// Create a StringComparer an compare the hashes.
			StringComparer comparer = StringComparer.OrdinalIgnoreCase;

			if (0 == comparer.Compare(hashOfInput, hash))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
