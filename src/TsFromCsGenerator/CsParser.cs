﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TsFromCsGenerator.Model;

namespace TsFromCsGenerator
{
	class CsParser
	{
		public IEnumerable<Class> Parse(string code)
		{
			SyntaxTree tree = SyntaxFactory.ParseSyntaxTree(code);
			CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetCompilationUnitRoot();
			var classes = root.DescendantNodes()
				.Where(s => s.Kind() == SyntaxKind.ClassDeclaration)
				.OfType<ClassDeclarationSyntax>()
				.Where(c => c.Modifiers.Any(m => m.Kind() == SyntaxKind.PublicKeyword))
				.Select(c => new Class
				{
					Name = c.Identifier.ValueText,
					Properties = GetProperties(c)
				});

			return classes.ToArray();
		}

		private IEnumerable<Property> GetProperties(ClassDeclarationSyntax @class)
		{
			var properties = @class.DescendantNodes()
				.Where(s => s.Kind() == SyntaxKind.PropertyDeclaration)
				.OfType<PropertyDeclarationSyntax>()
				.Where(c => c.Modifiers.Any(m => m.Kind() == SyntaxKind.PublicKeyword))
				.Select(p => new Property()
				{
					Name = p.Identifier.ValueText,
					CsType = p.Type,
				});
			return properties.ToArray();
		}
	}
}
