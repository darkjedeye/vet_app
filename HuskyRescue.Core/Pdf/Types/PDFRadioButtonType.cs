using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuskyRescue.Core.Pdf.Types
{
	class PDFRadioButtonType : PDFFieldType
	{
		public override int Type {
			get { return 3; }
		}

		public override string ToString() {
			return "Radio Button";
		}
	}
}