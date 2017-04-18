//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;

//namespace TsFromCsGenerator
//{
//	internal class CsToTsConverter
//	{
//		public CsToTsConverter()
//		{

//		}

//		string Convert(string code)
//		{

//			StringBuilder fileDefinition = new StringBuilder();

//			foreach (ClassDeclarationSyntax @class in classes)
//			{
//				fileDefinition.AppendLine(ConvertClass(@class));
//			}
//			return fileDefinition.ToString();
//		}

//		private string ConvertClass(ClassDeclarationSyntax @class)
//		{
//			var properties = @class.DescendantNodes()
//				.Where(s => s.Kind() == SyntaxKind.PropertyDeclaration).OfType<PropertyDeclarationSyntax>()
//				.Where(c => c.Modifiers.Any(m => m.Kind() == SyntaxKind.PublicKeyword));

//			StringBuilder classDefinition = new StringBuilder();
//			classDefinition.AppendFormat("interface {0} {{", @class.Identifier.ValueText);

//			foreach (PropertyDeclarationSyntax property in properties)
//			{
//				classDefinition.AppendLine();
//				classDefinition.AppendFormat("  {0}: {1};", property.Identifier.ValueText, GetTypeScriptType(property.Type));
//			}

//			return classDefinition.ToString();
//		}

//		private string GetTypeScriptType(TypeSyntax propertyType)
//		{
//			PredefinedTypeSyntax predefinedType = propertyType as PredefinedTypeSyntax;

//			if (predefinedType != null)
//			{
//				switch (predefinedType.Keyword.ValueText)
//				{
//					case "sbyte":
//					case "byte":
//					case "int":
//					case "uint":
//					case "short":
//					case "ushort":
//					case "long":
//					case "ulong":
//					case "float":
//					case "double":
//					case "decimal":
//						return "number";
//					case "bool":
//						return "boolean";
//					case "string":
//					case "char":
//						return "string";
//				}
//			}
//			return "any";
//		}
//	}
//}
