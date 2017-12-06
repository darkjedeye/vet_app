using System.IO;
using System.Web.UI;
using System.Web.Mvc;
using HtmlAgilityPack;

namespace HuskyRescue.Core.TrackABeast
{
	/// <summary>
	/// Class that implements methods to generate HTML for dog listing page
	/// </summary>
	public class HtmlGenerator {
		string imgSrcPrefix=@"/mp/Data/Sites/1/FolderGalleries/dogs/";
		string imgSrcSuffix=@"/thumb.jpg";

		/// <summary>
		/// Generate HTML document based on enumeration of animal objects
		/// </summary>
		/// <param name="rdc">Class that contains information necessary to render animals into HTML table</param>
		/// <returns>HTML as a string</returns>
		public string HtmlGen(RenderDataClass rdc) {
			StringWriter stringWriter = new StringWriter();
			int animalCount = 0;
			int columnWidth = 100 / rdc.ColumnCount;
			using( HtmlTextWriter writer = new HtmlTextWriter(stringWriter) ) {
				writer.RenderBeginTag(HtmlTextWriterTag.Div);
					writer.AddAttribute(HtmlTextWriterAttribute.Align, "center");
					writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "1");
					writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "1");
					writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "90%");
					writer.RenderBeginTag(HtmlTextWriterTag.Table);
						writer.RenderBeginTag(HtmlTextWriterTag.Colgroup);
						for( int i =0; i < rdc.ColumnCount; i++ ) {
							writer.AddAttribute(HtmlTextWriterAttribute.Width, columnWidth.ToString() + "%");
							writer.RenderBeginTag(HtmlTextWriterTag.Col);
							writer.RenderEndTag();
						}
						writer.RenderEndTag();//colgroup

						writer.RenderBeginTag(HtmlTextWriterTag.Tbody);
						foreach( Animal animal in rdc.Animals ) {
							if( animalCount % rdc.ColumnCount == 0 ) {
								writer.RenderBeginTag(HtmlTextWriterTag.Tr);
							}
							writer.RenderBeginTag(HtmlTextWriterTag.Td);
							writer.RenderBeginTag(HtmlTextWriterTag.Table);
							writer.RenderBeginTag(HtmlTextWriterTag.Tbody);
							writer.RenderBeginTag(HtmlTextWriterTag.Tr);
							writer.RenderBeginTag(HtmlTextWriterTag.Td);
							writer.AddAttribute(HtmlTextWriterAttribute.Href, "/mp/" + animal.Name + ".aspx");
							writer.RenderBeginTag(HtmlTextWriterTag.A);
							writer.AddAttribute(HtmlTextWriterAttribute.Alt, "");
							writer.AddAttribute(HtmlTextWriterAttribute.Src, imgSrcPrefix + animal.Name + imgSrcSuffix);
							writer.RenderBeginTag(HtmlTextWriterTag.Img);
							writer.RenderEndTag();
							writer.RenderEndTag();//a
							writer.RenderEndTag();//td
							writer.AddAttribute(HtmlTextWriterAttribute.Valign, "top");
							writer.RenderBeginTag(HtmlTextWriterTag.Td);
							writer.RenderBeginTag(HtmlTextWriterTag.H5);
							//writer.Write( animal.Name + GetOnTrial( animal.IsOnTrial == true ) );// + GetSpecialNeeds(animal.IsSpecialNeeds));
							writer.Write(animal.Name + GetTrialFoster(animal.IsOnTrial == true, animal.IsFosterNeeded == true));// + GetSpecialNeeds(animal.IsSpecialNeeds));
							writer.RenderEndTag();//h5
							writer.WriteBreak();
							writer.RenderBeginTag(HtmlTextWriterTag.Em);
							writer.Write("Sex: " + animal.Gender);
							writer.WriteBreak();
							writer.Write("Age: " + animal.Age);
							writer.RenderEndTag();//em
							writer.RenderEndTag();//td
							writer.RenderEndTag();//tr
							writer.RenderEndTag();//tbody
							writer.RenderEndTag();//table
							writer.RenderEndTag();//td
							if( ( animalCount + 1 ) % rdc.ColumnCount == 0 ) {
								writer.RenderEndTag();//tr
							}
							animalCount++;
						}
						writer.RenderEndTag(); // Tbody
					writer.RenderEndTag(); // Table
				writer.RenderEndTag(); // Div
				//writer.RenderEndTag();//Div
			}//end using
			return stringWriter.ToString();
		}

		private string GetOnTrial(bool trial) {
			if( trial )
				return " (on trial) ";
			else
				return string.Empty;
		}

		private string GetTrialFoster(bool trial, bool foster)
		{
			string result = string.Empty;
			if (trial)
				result = " (on trial) ";
			if (foster)
				result = " (foster needed) ";
			return result;
		}

		private string GetSpecialNeeds(bool special) {
			if( special )
				return " - Special Needs";
			else
				return string.Empty;
		}
	}
}