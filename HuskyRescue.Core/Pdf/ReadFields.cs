using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using HuskyRescue.Core.Pdf.Types;

namespace HuskyRescue.Core.Pdf
{
	public class ReadFields
	{
		#region constructors
		/// <summary>
		/// Create an iTextSharp PDF object based on an existing PDF document
		/// </summary>
		/// <param name="pdfLocation">location of the PDF document</param>
		public ReadFields( string pdfLocation ) {
			PdfLocation = pdfLocation;
		}

		public ReadFields() {

		}
		#endregion

		#region public properties
		public string PdfLocation { get; set; }
		#endregion

		#region public methods
		public List<string> GetFieldInfo() {
			var fieldInfo = new List<string>();

			if ( System.IO.File.Exists( PdfLocation ) ) {
				var reader = new PdfReader( PdfLocation );
				var formFields = reader.AcroFields;
				foreach ( System.Collections.Generic.KeyValuePair<string,iTextSharp.text.pdf.AcroFields.Item> entry in formFields.Fields ) {
					var formFieldType = PDFFieldType.GetPDFFieldType( formFields.GetFieldType( entry.Key.ToString() ) );

					if ( formFieldType is PDFCheckBoxFieldType || formFieldType is PDFRadioButtonType )
						fieldInfo.Add( string.Format( "{0} - {1} - Export Value: {2}",
													entry.Key,
													formFieldType,
													PDFHelper.GetExportValue( entry.Value as AcroFields.Item ) ) );
					else
						fieldInfo.Add( string.Format( "{0} - {1}", entry.Key, formFieldType ) );

					formFieldType = null;
				}
				formFields = null;
				reader.Close();
			}


			return fieldInfo;
		}

		public List<string> GetFormData() {
			List<string> dataList = new List<string>();
			PdfReader pdfReader = new PdfReader( PdfLocation );
			System.Collections.Generic.IDictionary<string,iTextSharp.text.pdf.AcroFields.Item> fields = pdfReader.AcroFields.Fields;
			AcroFields.Item acroFieldItem;
			PdfDictionary pdfDictionary;
			int flags;
			int fieldInstance = 0;
			

			foreach(var field in fields){
				acroFieldItem = field.Value;
				/* http://api.itextpdf.com/com/itextpdf/text/pdf/AcroFields.Item.html
				 * field.Value.GetMerged		Retrieve the merged dictionary for the given instance.
				 * field.Value.GetPage			Retrieve the page number of the given instance
				 * field.Value.GetTabOrder		Gets the tabOrder
				 * field.Value.GetValue			Retrieve the value dictionary of the given instance
				 * field.Value.GetWidget		Retrieve the widget dictionary of the given instance
				 * field.Value.GetWidgetRef		Retrieve the reference to the given instance
				 * 
				 * field.Value.MarkUsed			Mark all the item dictionaries used matching the given flags
				 * field.Value.Size				Preferred method of determining the number of instances of a given field
				 * */

				// Size should always be one unless there is more than one of a field with the same name
				fieldInstance = 0;
				do {
					// http://api.itextpdf.com/com/itextpdf/text/pdf/PdfDictionary.html
					// http://api.itextpdf.com/com/itextpdf/text/pdf/PdfName.html
					/* PDF Name http://www.pdf-tools.com/public/downloads/pdf-reference/pdfreference12.pdf
					 * 
					 * AP		Appearance dictionary
					 * AS		Appearance state
					 * BS		Border Style
					 * D		Dash Array
					 * N		Normal appearance
					 * R		Rollover appearance
					 * W		Width
					 * 
					 * */
					pdfDictionary = field.Value.GetMerged( fieldInstance );
					flags = pdfDictionary.GetAsNumber( PdfName.FF ).IntValue;
					
					fieldInstance++;
				} while ( fieldInstance < field.Value.Size );

				dataList.Add( field.Key + " " + field.Value );
			}
			pdfReader.Close();
			fields.Clear();
			acroFieldItem = null;
			pdfDictionary = null;
			return dataList;
		}

		#endregion
	}
}
