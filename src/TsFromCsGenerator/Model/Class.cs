using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsFromCsGenerator.Model
{
	class Class
	{
		public string Name { get; set; }
		public IEnumerable<Property> Properties { get; set; }
	}
}
