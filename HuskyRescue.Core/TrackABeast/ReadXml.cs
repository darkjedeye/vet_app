using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace HuskyRescue.Core.TrackABeast
{
	public class ReadXmlAnimals
	{
		public IEnumerable<Animal> ReadFromXmlFile(string filePath)
		{
			XDocument doc = XDocument.Load(filePath);
			return
				from b in doc.Element("Dogs").Elements("dog")
				orderby (string)b.Element("name")
				select new Animal(
					(string)b.Element("name"),
					(string)b.Element("gender"),
					(string)b.Element("age"),
					(string)b.Attribute("isCatFriendly") != string.Empty ? (bool)b.Attribute("isCatFriendly") : false,
					(string)b.Attribute("isKidFriendly") != string.Empty ? (bool)b.Attribute("isKidFriendly") : false,
					(string)b.Attribute("isSpecialNeeds") != string.Empty ? (bool)b.Attribute("isSpecialNeeds") : false,
					(string)b.Attribute("isOnTrial") != string.Empty ? (bool)b.Attribute("isOnTrial") : false,
					(string)b.Attribute("IsFosterNeeded") != string.Empty ? (bool)b.Attribute("IsFosterNeeded") : false);
		}
	}
}
