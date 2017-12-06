﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuskyRescue.Core.Pdf.Types
{
	public class PDFCheckBoxFieldType : PDFFieldType {
		public override int Type {
			get { return 2; }
		}

		public override string ToString() {
			return "CheckBox";
		}
	}
}