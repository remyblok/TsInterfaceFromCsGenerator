using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TsFromCsGenerator.Services
{
	internal interface ICsToTsTypeConverter
	{
		string GetTypeScriptType(TypeSyntax propertyType);
	}

	class CsToTsTypeConverter : ICsToTsTypeConverter
	{

		public string GetTypeScriptType(TypeSyntax propertyType)
		{
			PredefinedTypeSyntax predefinedType = propertyType as PredefinedTypeSyntax;

			if (predefinedType != null)
			{
				switch (predefinedType.Keyword.ValueText)
				{
					case "sbyte":
					case "byte":
					case "int":
					case "uint":
					case "short":
					case "ushort":
					case "long":
					case "ulong":
					case "float":
					case "double":
					case "decimal":
						return "number";
					case "bool":
						return "boolean";
					case "string":
					case "char":
						return "string";
				}
			}
			return "any";
		}
	}
}
