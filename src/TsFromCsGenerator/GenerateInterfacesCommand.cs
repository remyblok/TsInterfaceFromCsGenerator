using System.IO;
using ManyConsole;

namespace TsFromCsGenerator
{
	class GenerateInterfacesCommand : ConsoleCommand
	{
		private readonly ICsToTsConverter _converter;

		private string _fileLocation;
		private string _outLocation;
		private bool _asClass;
		private bool _exported;
		private bool _prefixInterfaces = true;

		public GenerateInterfacesCommand(ICsToTsConverter converter)
		{
			_converter = converter;
			IsCommand("Interfaces", "Generate TS interface from CS model");

			HasRequiredOption("f|file=", "The {path} of the CS file to transform.", p => _fileLocation = p);
			HasRequiredOption("o|out=", "The {path} of output TS file.", p => _outLocation = p);
			HasOption("i|interface", "Should output as a TypeScript interface (default)", p => _asClass = p == null);
			HasOption("pi|prefixinterface", "Output interface type names with a I-prefix (default on)", p => _prefixInterfaces = p != null);
			HasOption("c|class", "Should output as a TypeScript class", p => _asClass = p != null);
			HasOption("e|export", "The generated TS type should be exported", p => _exported = p != null);
		}

		/// <inheritdoc />
		public override int Run(string[] remainingArguments)
		{
			string code = File.ReadAllText(_fileLocation);
			string tsCode = _converter.Convert(code, _asClass, _exported, _prefixInterfaces);
			File.WriteAllText(_outLocation, tsCode);
			return 0;
		}
	}
}
