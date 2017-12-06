using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using HuskyRescue.Core.Properties;
using HuskyRescue.Core.ViewModel.RescueGroups;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HuskyRescue.Core.Service.RescueGroups
{
	public class AnimalHandler
	{
		public string GetDefinition()
		{
			var data = new
			{
				apikey = Properties.Settings.Default.RescueGroupsApiKey,
				objectType = "animals",
				objectAction = "define"
			};

			var jsonData = JsonConvert.SerializeObject(data);

			var request = (HttpWebRequest)WebRequest.Create(Settings.Default.RescueGroupsUri);
			request.Method = "POST";
			request.ContentType = "application/json";
			var bytes = Encoding.UTF8.GetBytes(jsonData);
			request.ContentLength = bytes.Length;

			var requestStream = request.GetRequestStream();
			requestStream.Write(bytes, 0, bytes.Length);

			var result = string.Empty;
			try
			{
				var response = request.GetResponse();
				var stream = response.GetResponseStream();
				var reader = new StreamReader(stream);

				result = reader.ReadToEnd();
				if (stream != null) stream.Dispose();
				reader.Dispose();
			}
			catch (WebException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (ProtocolViolationException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (NotSupportedException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}

			return result;
		}

		public List<Animal> PublicSearch()
		{
			var animals = new List<Animal>();
			var data = new
			{
				apikey = Properties.Settings.Default.RescueGroupsApiKey,
				objectType = "animals",
				objectAction = "publicSearch",
				search = new
				{
					resultStart = 0,
					resultLimit = 100,
					resultSort = "animalName",
					resultOrder = "asc",
					filters = new[]
					{
						new
						{
							fieldName = "animalStatus",
							operation = "equal",
							criteria = "Available"
						},
						new
						{
							fieldName = "animalOrgID",
							operation = "equal",
							criteria = "3427"
						}
					},
					fields = new[]
					         {
					         "animalID",
							"animalAltered",
							"animalBirthdate",
							"animalBreed",
							"animalColor",
							"animalCratetrained",
							"animalDescription",
							"animalEnergyLevel",
							"animalExerciseNeeds",
							"animalEyeColor",
							"animalGeneralAge",
							"animalHousetrained",
							"animalLeashtrained",
							"animalMixedBreed",
							"animalName",
							"animalNeedsFoster",
							"animalOKWithAdults",
							"animalOKWithCats",
							"animalOKWithDogs",
							"animalOKWithKids",
							"animalOthernames",
							"animalPictures",
							"animalRescueID",
							"animalSex",
							"animalSpecialneeds",
							"animalSpecialneedsDescription",
							"animalStatus",
							"animalSummary",
							"animalThumbnailUrl"
					         }
				}
			};

			var jsonData = JsonConvert.SerializeObject(data);

			var request = (HttpWebRequest)WebRequest.Create(Settings.Default.RescueGroupsUri);
			request.Method = "POST";
			request.ContentType = "application/json";
			var bytes = Encoding.UTF8.GetBytes(jsonData);
			request.ContentLength = bytes.Length;

			var requestStream = request.GetRequestStream();
			requestStream.Write(bytes, 0, bytes.Length);

			var result = string.Empty;
			try
			{
				var response = request.GetResponse();
				var stream = response.GetResponseStream();
				var reader = new StreamReader(stream);

				result = reader.ReadToEnd();
				if (stream != null) stream.Dispose();
				reader.Dispose();
			}
			catch (WebException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (ProtocolViolationException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (NotSupportedException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}

			dynamic s = JObject.Parse(result);
			if (s.data != null)
			{
				foreach (var animal in s.data)
				{
					if (animal != null)
					{
						var a = new Animal
						{
							animalID = animal.Value.animalID != null ? animal.Value.animalID.Value : string.Empty,
							animalAltered = animal.Value.animalAltered != null ? animal.Value.animalAltered.Value : string.Empty,
							animalBirthdate = animal.Value.animalBirthdate != null ? animal.Value.animalBirthdate.Value : string.Empty,
							animalBreed = animal.Value.animalBreed != null ? animal.Value.animalBreed.Value : string.Empty,
							animalColor = animal.Value.animalColor != null ? animal.Value.animalColor.Value : string.Empty,
							animalCratetrained = animal.Value.animalCratetrained != null ? animal.Value.animalCratetrained.Value : string.Empty,
							animalDescription = animal.Value.animalDescription != null ? animal.Value.animalDescription.Value : string.Empty,
							animalEnergyLevel = animal.Value.animalEnergyLevel != null ? animal.Value.animalEnergyLevel.Value : string.Empty,
							animalExerciseNeeds = animal.Value.animalExerciseNeeds != null ? animal.Value.animalExerciseNeeds.Value : string.Empty,
							animalEyeColor = animal.Value.animalEyeColor != null ? animal.Value.animalEyeColor.Value : string.Empty,
							animalGeneralAge = animal.Value.animalGeneralAge != null ? animal.Value.animalGeneralAge.Value : string.Empty,
							animalHousetrained = animal.Value.animalHousetrained != null ? animal.Value.animalHousetrained.Value : string.Empty,
							animalLeashtrained = animal.Value.animalLeashtrained != null ? animal.Value.animalLeashtrained.Value : string.Empty,
							animalMixedBreed = animal.Value.animalMixedBreed != null ? animal.Value.animalMixedBreed.Value : string.Empty,
							animalName = animal.Value.animalName != null ? animal.Value.animalName.Value : string.Empty,
							animalNeedsFoster = animal.Value.animalNeedsFoster != null ? animal.Value.animalNeedsFoster.Value : string.Empty,
							animalOKWithAdults = animal.Value.animalOKWithAdults != null ? animal.Value.animalOKWithAdults.Value : string.Empty,
							animalOKWithCats = animal.Value.animalOKWithCats != null ? animal.Value.animalOKWithCats.Value : string.Empty,
							animalOKWithDogs = animal.Value.animalOKWithDogs != null ? animal.Value.animalOKWithDogs.Value : string.Empty,
							animalOKWithKids = animal.Value.animalOKWithKids != null ? animal.Value.animalOKWithKids.Value : string.Empty,
							animalOthernames = animal.Value.animalOthernames != null ? animal.Value.animalOthernames.Value : string.Empty,
							animalOrgID = animal.Value.animalOrgID != null ? animal.Value.animalOrgID.Value : string.Empty,
							animalRescueID = animal.Value.animalRescueID != null ? animal.Value.animalRescueID.Value : string.Empty,
							animalSex = animal.Value.animalSex != null ? animal.Value.animalSex.Value : string.Empty,
							animalSpecialneeds = animal.Value.animalSpecialneeds != null ? animal.Value.animalSpecialneeds.Value : string.Empty,
							animalSpecialneedsDescription = animal.Value.animalSpecialneedsDescription != null ? animal.Value.animalSpecialneedsDescription.Value : string.Empty,
							animalStatus = animal.Value.animalStatus != null ? animal.Value.animalStatus.Value : string.Empty,
							animalSummarypublic = animal.Value.animalSummarypublic != null ? animal.Value.animalSummarypublic.Value : string.Empty,
							animalThumbnailUrl = animal.Value.animalThumbnailUrl != null ? animal.Value.animalThumbnailUrl.Value : string.Empty
						};

						foreach (var picture in animal.Value.animalPictures)
						{
							a.animalPictures.Add(new AnimalPicture
							                     {
													 mediaID = picture.mediaID != null ? picture.mediaID.Value : string.Empty,
													 fileSize = picture.fileSize != null ? picture.fileSize.Value : string.Empty,
													 resolutionX = picture.resolutionX != null ? picture.resolutionX.Value : string.Empty,
													 resolutionY = picture.resolutionY != null ? picture.resolutionY.Value : string.Empty,
													 mediaOrder = picture.mediaOrder != null ? picture.mediaOrder.Value : string.Empty,
													 fileNameFullsize = picture.fileNameFullsize != null ? picture.fileNameFullsize.Value : string.Empty,
													 fileNameThumbnail = picture.fileNameThumbnail != null ? picture.fileNameThumbnail.Value : string.Empty,
													 urlSecureFullsize = picture.urlSecureFullsize != null ? picture.urlSecureFullsize.Value : string.Empty,
													 urlSecureThumbnail = picture.urlSecureThumbnail != null ? picture.urlSecureThumbnail.Value : string.Empty,
													 urlInsecureFullsize = picture.urlInsecureFullsize != null ? picture.urlInsecureFullsize.Value : string.Empty,
													 urlInsecureThumbnail = picture.urlInsecureThumbnail != null ? picture.urlInsecureThumbnail.Value : string.Empty
							                     });
						}
						animals.Add(a);
					}
				}
			}
			return animals;
		}

		public RootAnimal GetProfile(string id)
		{

			{
				var data = new
				{
					apikey = Properties.Settings.Default.RescueGroupsApiKey,
					objectType = "animals",
					objectAction = "publicSearch",
					search = new
					{
						resultStart = 0,
						resultLimit = 1,
						resultSort = "animalName",
						resultOrder = "asc",
						filters = new[]
					{
						new
						{
							fieldName = "animalID",
							operation = "equal",
							criteria = id
						},
						new
						{
							fieldName = "animalOrgID",
							operation = "equal",
							criteria = "3427"
						},
						new
						{
							fieldName = "animalStatus",
							operation = "equal",
							criteria = "Available"
						}
					},
						fields = new[] { 
							"animalID",
							"animalAltered",
							"animalBirthdate",
							"animalBreed",
							"animalColor",
							"animalCratetrained",
							"animalDescription",
							"animalEnergyLevel",
							"animalExerciseNeeds",
							"animalEyeColor",
							"animalGeneralAge",
							"animalHousetrained",
							"animalLeashtrained",
							"animalMixedBreed",
							"animalName",
							"animalNeedsFoster",
							"animalOKWithAdults",
							"animalOKWithCats",
							"animalOKWithDogs",
							"animalOKWithKids",
							"animalOthernames",
							"animalPictures",
							"animalRescueID",
							"animalSex",
							"animalSpecialneeds",
							"animalSpecialneedsDescription",
							"animalStatus",
							"animalSummary"
						}
					}
				};

				var jsonData = JsonConvert.SerializeObject(data);

				var request = (HttpWebRequest)WebRequest.Create(Settings.Default.RescueGroupsUri);
				request.Method = "POST";
				request.ContentType = "application/json";
				var bytes = Encoding.UTF8.GetBytes(jsonData);
				request.ContentLength = bytes.Length;

				var requestStream = request.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);

				var result = string.Empty;
				try
				{
					var response = request.GetResponse();
					var stream = response.GetResponseStream();
					var reader = new StreamReader(stream);

					result = reader.ReadToEnd();
					if (stream != null) stream.Dispose();
					reader.Dispose();
				}
				catch (WebException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (ProtocolViolationException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (InvalidOperationException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (NotSupportedException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (Exception ex)
				{
					Trace.WriteLine(ex.Message);
				}

				return JsonConvert.DeserializeObject<RootAnimal>(result);
			}
		}
	}
}
