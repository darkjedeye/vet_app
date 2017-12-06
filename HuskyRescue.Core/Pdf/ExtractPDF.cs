using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using HuskyRescue.Core.Pdf.Types;

namespace HuskyRescue.Core.Pdf
{
	public class PDFExtract
	{
		#region private memebers
		private PdfReader pdfReader = null;
		private string strLocation = string.Empty;
		#endregion

		#region constructors
		/// <summary>
		/// Create an iTextSharp PDF object based on an existing PDF document
		/// </summary>
		/// <param name="pdfLocation">location of the PDF document</param>
		public PDFExtract(string pdfLocation) {
			pdfReader = new PdfReader(pdfLocation);
			strLocation = pdfLocation;
		}

		public PDFExtract() {

		}
		#endregion

		#region public properties
		public string PdfLocation {
			get {
				return strLocation;
			}
			set {
				strLocation = value;
				pdfReader = new PdfReader(strLocation);
			}
		}
		#endregion

		#region public methods
		public List<PRAcroForm.FieldInformation> GetPdfFields() {
			return pdfReader.AcroForm.Fields;
		}

		public string PdfToString() {
			return iTextSharp.text.Utilities.ReadFileToString(strLocation);
		}

		public string GetFieldName(string fieldName) {
			return pdfReader.AcroFields.GetField(fieldName);
		}

		public Dictionary<string, string> GetFormData() {
			Dictionary<string, string> frmData = new Dictionary<string, string>();
			//Get the form from the pdf
			AcroFields frm = pdfReader.AcroFields;
			//Extract the data from the fields
			string data = string.Empty;
			foreach( string key in frm.Fields.Keys ) {
				data = frm.GetField(key);
				frmData.Add(key, data);
			}
			return frmData;
		}

		public void PdfFlatten() {
			PdfStamper stamper = new PdfStamper(pdfReader, new FileStream(strLocation.Replace(".pdf", "_flat.pdf"), FileMode.Create));
			stamper.FormFlattening = true;
			AcroFields fields = stamper.AcroFields;

			Dictionary<string, string> fieldData = this.GetFormData();
			foreach( var key in fieldData ) {
				fields.SetField(key.Key, key.Value);
			}

			stamper.Close();
		}
		#endregion
	}
}
