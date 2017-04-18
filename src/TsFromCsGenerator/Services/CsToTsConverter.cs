using System.Text;
using TsFromCsGenerator.Model;
using TsFromCsGenerator.Services;

namespace TsFromCsGenerator
{
	interface ICsToTsConverter
	{
		string Convert(string code, bool asClass, bool isExportedType, bool prefixInterfaces);
	}

	class CsToTsConverter : ICsToTsConverter
	{
		private readonly ICsParser _parser;
		private readonly ITsGenerator _generator;

		public CsToTsConverter(ICsParser parser, ITsGenerator generator)
		{
			_parser = parser;
			_generator = generator;
		}

		public string Convert(string code, bool asClass, bool isExportedType, bool prefixInterfaces)
		{
			StringBuilder tsInterfaces = new StringBuilder();

			foreach (Class @class in _parser.Parse(code))
			{
				if (asClass)
					tsInterfaces.AppendLine(_generator.GenerateClass(@class, isExportedType));
				else
					tsInterfaces.AppendLine(_generator.GenerateInterface(@class, isExportedType, prefixInterfaces));
			}

			return tsInterfaces.ToString();
		}
	}
}
