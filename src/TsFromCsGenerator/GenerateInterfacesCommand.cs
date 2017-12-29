﻿using System.Collections.Generic;
using System.IO;
using ManyConsole;

namespace TsFromCsGenerator
{
	class GenerateInterfacesCommand : ConsoleCommand
	{
		private readonly ICsToTsConverter _converter;

		private readonly List<string> _fileLocations = new List<string>();
		private string _outLocation;
		private bool _exported;
		private bool _prefixInterfaces;

		public GenerateInterfacesCommand(ICsToTsConverter converter)
		{
			_converter = converter;
			IsCommand("Interfaces", "Generate TS interface from CS model");

			HasRequiredOption("f|file=", "The {path} of the CS file to transform (Multiple possible)", p => _fileLocations.Add(p));
			HasRequiredOption("o|out=", "The {path} of output TS file", p => _outLocation = p);
			HasOption("p|prefixinterface", "Output interface type names with a I-prefix", p => _prefixInterfaces = p != null);
			HasOption("e|export", "The generated TS type should be exported", p => _exported = p != null);
		}

		/// <inheritdoc />
		public override int Run(string[] remainingArguments)
		{
			string tsCode = "";
			foreach (string location in _fileLocations)
			{
				string code = File.ReadAllText(location);
				tsCode += _converter.Convert(code, false, _exported, _prefixInterfaces);
			}

			File.WriteAllText(_outLocation, tsCode);
			return 0;
		}
	}
}
