﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daramkun.DaramRenamer.Processors.Filename
{
	public class ConcatenateProcessor : IProcessor
	{
		public string Name { get { return "process_concatenate_text"; } }
		public bool CannotMultithreadProcess { get { return false; } }

		[Globalized ( "concat_text", 0 )]
		public string Text { get; set; } = "";
		[Globalized ( "concat_pos", 1 )]
		public OnePointPosition Position { get; set; } = OnePointPosition.EndPoint;
		[Globalized ( "include_extension", 2 )]
		public bool IncludeExtensions { get; set; } = false;

		public bool Process ( FileInfo file )
		{
			if ( Text == null || Text.Length == 0 ) return false;
			string fn = !IncludeExtensions ? Path.GetFileNameWithoutExtension ( file.ChangedFilename ) : file.ChangedFilename;
			string ext = !IncludeExtensions ? Path.GetExtension ( file.ChangedFilename ) : "";
			file.ChangedFilename = Position == OnePointPosition.StartPoint ? $"{Text}{fn}{ext}" :
				( Position == OnePointPosition.EndPoint ? $"{fn}{Text}{ext}" :
				$"{Text}{fn}{Text}{ext}" );
			return true;
		}
	}
}