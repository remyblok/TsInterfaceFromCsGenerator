using System;

namespace TsFromCsGenerator.Tests.Content
{
	public class PublicClassWithNonPublicProperties
	{
		private string StringProp { get; set; }
		internal string Prop2 { get; set; }
		protected string Prop3 { get; set; }
	}
}
