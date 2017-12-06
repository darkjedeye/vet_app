using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;

namespace HuskyRescue.Core.Pdf.Types
{
	//public const int DA_COLOR = 2;
	//public const int DA_FONT = 0;
	//public const int DA_SIZE = 1;
	//public const int FIELD_TYPE_CHECKBOX = 2;
	//public const int FIELD_TYPE_COMBO = 6;
	//public const int FIELD_TYPE_LIST = 5;
	//public const int FIELD_TYPE_NONE = 0;
	//public const int FIELD_TYPE_PUSHBUTTON = 1;
	//public const int FIELD_TYPE_RADIOBUTTON = 3;
	//public const int FIELD_TYPE_SIGNATURE = 7;
	//public const int FIELD_TYPE_TEXT = 4;
	public abstract class PDFFieldType {
		public static PDFFieldType GetPDFFieldType( int type ) {
			switch ( type ) {
				case AcroFields.FIELD_TYPE_TEXT:
					return new PDFTextFieldType();
				case AcroFields.FIELD_TYPE_CHECKBOX:
					return new PDFCheckBoxFieldType();
				case AcroFields.FIELD_TYPE_RADIOBUTTON:
					return new PDFRadioButtonType();
				default:
					return new PDFOtherFieldType() { Type2 = type };
			}
		}

		public abstract int Type { get; }
	}
}