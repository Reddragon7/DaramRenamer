﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Daramkun.DaramRenamer.Conditions
{
	public class RegexpCondition : ICondition
	{
		public string Name { get { return "condition_regexp"; } }

		[Globalized ( "regexp", 0 )]
		public Regex RegularExpression { get; set; }

		public bool IsValid ( FileInfo file )
		{
			return RegularExpression.IsMatch ( file.ChangedFilename );
		}
	}
}