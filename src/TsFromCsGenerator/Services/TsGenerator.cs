using System.Text;
using TsFromCsGenerator.Model;

namespace TsFromCsGenerator.Services
{
	interface ITsGenerator
	{
		string GenerateInterface(Class @class, bool export, bool prefixInterfaces);
		string GenerateClass(Class @class, bool export);
	}

	class TsGenerator : ITsGenerator
	{
		private readonly ICsToTsTypeConverter _converter;

		public TsGenerator(ICsToTsTypeConverter converter)
		{
			_converter = converter;
		}

		public string GenerateInterface(Class @class, bool export, bool prefixInterfaces)
		{
			return Generate(@class, "interface", export, prefixInterfaces);
		}

		public string GenerateClass(Class @class, bool export)
		{
			return Generate(@class, "class", export, false);
		}

		private string Generate(Class @class, string type, bool export, bool prefixInterfaces)
		{
			type = (export ? "export" : "") + type;
			string className = (prefixInterfaces ? "I" : "") + @class.Name;

			StringBuilder classDefinition = new StringBuilder();
			classDefinition.AppendFormat("{0} {1} {{", type, className);

			foreach (Property property in @class.Properties)
			{
				classDefinition.AppendLine();
				classDefinition.AppendFormat("  {0}: {1};", property.Name, _converter.GetTypeScriptType(property.CsType));
			}
			classDefinition.AppendLine();
			classDefinition.AppendLine("}");

			return classDefinition.ToString();
		}
	}
}
