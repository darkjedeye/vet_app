using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuskyRescue.Core.Pdf.Types
{
	public class PDFOtherFieldType : PDFFieldType
	{
		#region static PDFOtherFieldType()

		/// <summary>
		/// Initializes the <see cref="T:PDFOtherFieldType"/> class.    
		/// </summary>
		static PDFOtherFieldType() {

		}
		#endregion

		public override int Type {
			get { return -1; }
		}

		public int Type2 { get; set; }

		public override string ToString() {
			return "Other " + Type2.ToString();
		}
	}
}