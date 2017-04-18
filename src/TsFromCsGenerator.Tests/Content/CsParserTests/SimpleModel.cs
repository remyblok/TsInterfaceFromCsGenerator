using System;

namespace TsFromCsGenerator.Tests.Content
{
	public class SimpleModel
	{
		public sbyte SbyteProp { get; set; }
		public byte ByteProp { get; set; }
		public int IntProp { get; set; }
		public uint UintProp { get; set; }
		public short ShortProp { get; set; }
		public ushort UshortProp { get; set; }
		public long LongProp { get; set; }
		public ulong UlongProp { get; set; }
		public float FloatProp { get; set; }
		public double DoubleProp { get; set; }
		public decimal DecimalProp { get; set; }

		public bool BoolProp { get; set; }
		public string StringProp { get; set; }
		public char CharProp { get; set; }

		public object ObjectProp { get; set; }

		public DateTime DateTimeProp { get; set; }
		public DayOfWeek EnumProp { get; set; }
	}
}
