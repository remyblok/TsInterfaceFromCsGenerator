using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TsFromCsGenerator.Services;

namespace TsFromCsGenerator.Tests
{
	[TestClass]
	public class CsParserTests
	{
		[TestMethod]
		public void SimpleModelGenerateTest()
		{
			CsParser parser = new CsParser();
			string code = File.ReadAllText("Content\\CsParserTests\\SimpleModel.cs");

			var classes = parser.Parse(code);

			classes.Should().ContainSingle("because there is a single class in the model");

			var @class = classes.Single();

			@class.Name.Should().Be("SimpleModel", "because the model is named SimpleModel");
			@class.Properties.Should().HaveCount(17, "because there are 17 properties in the model");
		}

		[TestMethod]
		public void MultipleClassesGenerateTest()
		{
			CsParser parser = new CsParser();
			string code = File.ReadAllText("Content\\CsParserTests\\MultipleClassesModel.cs");

			var classes = parser.Parse(code);

			classes.Should().HaveCount(2, "because there are two classes in the file");
		}

		[TestMethod]
		public void NonPublicClassesGenerateTest()
		{
			CsParser parser = new CsParser();
			string code = File.ReadAllText("Content\\CsParserTests\\NonPublicClasses.cs");

			var classes = parser.Parse(code);

			classes.Should().BeEmpty("because the classes are not public");
		}

		[TestMethod]
		public void NonPublicPropertiesGenerateTest()
		{
			CsParser parser = new CsParser();
			string code = File.ReadAllText("Content\\CsParserTests\\NonPublicProperties.cs");

			var classes = parser.Parse(code);

			classes.Should().ContainSingle("because there is a single class in the file");

			var @class = classes.Single();

			@class.Properties.Should().HaveCount(0, "because non of the properties are public");
		}

		[TestMethod]
		public void InnerClasssGenerateTest()
		{
			CsParser parser = new CsParser();
			string code = File.ReadAllText("Content\\CsParserTests\\InnerClass.cs");

			var classes = parser.Parse(code);

			classes.Should().ContainSingle("because there is a single class in the file, the inner class is ignored");
		}
	}
}
