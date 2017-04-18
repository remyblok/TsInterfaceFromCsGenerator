using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TsFromCsGenerator.Model;
using TsFromCsGenerator.Services;

namespace TsFromCsGenerator.Tests
{
	[TestClass]
	public class TsGeneratorTests
	{
		[TestMethod]
		public void SimpleInterfaceGeneratorTest()
		{
			Class @class = new Class
			{
				Name = "Some",
				Properties = new[]
				{
					new Property
					{
						Name = "Prop",
						CsType = null,
					}
				}
			};

			ICsToTsTypeConverter typeConverter = Substitute.For<ICsToTsTypeConverter>();
			typeConverter.GetTypeScriptType(null).Returns("");

			TsGenerator generator = new TsGenerator(typeConverter);

			string generatedCode = generator.GenerateInterface(@class, false, false);

			generatedCode.Should().Contain("Some", "because this is the class name");
			generatedCode.Should().Contain("interface", "because we are generating an interface");
			generatedCode.Should().Contain("Prop:", "because that is the name op the property");
			generatedCode.Should().NotContain("export", "because export is false");
		}

		[TestMethod]
		public void SimpleClassGeneratorTest()
		{
			Class @class = new Class
			{
				Name = "Some",
				Properties = new[]
				{
					new Property
					{
						Name = "Prop",
						CsType = null,
					}
				}
			};

			ICsToTsTypeConverter typeConverter = Substitute.For<ICsToTsTypeConverter>();
			typeConverter.GetTypeScriptType(null).Returns("");

			TsGenerator generator = new TsGenerator(typeConverter);

			string generatedCode = generator.GenerateClass(@class, false);

			generatedCode.Should().Contain("Some", "because this is the class name");
			generatedCode.Should().Contain("class", "because we are generating an interface");
			generatedCode.Should().Contain("Prop:", "because that is the name op the property");
			generatedCode.Should().NotContain("export", "because export is false");
		}

		[TestMethod]
		public void SimpleExportedInterfaceGeneratorTest()
		{
			Class @class = new Class
			{
				Name = "Some",
				Properties = new[]
				{
					new Property
					{
						Name = "Prop",
						CsType = null,
					}
				}
			};

			ICsToTsTypeConverter typeConverter = Substitute.For<ICsToTsTypeConverter>();
			typeConverter.GetTypeScriptType(null).Returns("");

			TsGenerator generator = new TsGenerator(typeConverter);

			string generatedCode = generator.GenerateInterface(@class, true, false);

			generatedCode.Should().Contain("Some", "because this is the class name");
			generatedCode.Should().Contain("interface", "because we are generating an interface");
			generatedCode.Should().Contain("Prop:", "because that is the name op the property");
			generatedCode.Should().Contain("export", "because export is true");
		}

		[TestMethod]
		public void SimpleExportedClassGeneratorTest()
		{
			Class @class = new Class
			{
				Name = "Some",
				Properties = new[]
				{
					new Property
					{
						Name = "Prop",
						CsType = null,
					}
				}
			};

			ICsToTsTypeConverter typeConverter = Substitute.For<ICsToTsTypeConverter>();
			typeConverter.GetTypeScriptType(null).Returns("");

			TsGenerator generator = new TsGenerator(typeConverter);

			string generatedCode = generator.GenerateClass(@class, true);

			generatedCode.Should().Contain("Some", "because this is the class name");
			generatedCode.Should().Contain("class", "because we are generating an interface");
			generatedCode.Should().Contain("Prop:", "because that is the name op the property");
			generatedCode.Should().Contain("export", "because export is true");
		}
	}
}
//SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.BoolKeyword))
