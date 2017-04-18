﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TsFromCsGenerator.Model
{
	class Property
	{
		public string Name { get; set; }
		public TypeSyntax CsType { get; set; }
	}
}
