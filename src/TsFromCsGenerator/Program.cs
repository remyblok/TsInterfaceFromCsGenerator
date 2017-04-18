using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autofac;
using ManyConsole;
using TsFromCsGenerator.Services;

namespace TsFromCsGenerator
{
	public class Program
	{
		static int Main(string[] args)
		{
			var container = DependecyInjectionConfig();

			var commands = container.Resolve<IEnumerable<ConsoleCommand>>();

			int retValue = ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out);

			if (retValue != 0 && Debugger.IsAttached)
				Console.ReadLine();

			return retValue;
		}

		private static IContainer DependecyInjectionConfig()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterType<CsParser>().AsImplementedInterfaces();
			builder.RegisterType<TsGenerator>().AsImplementedInterfaces();
			builder.RegisterType<CsToTsConverter>().AsImplementedInterfaces();
			builder.RegisterType<CsToTsTypeConverter>().AsImplementedInterfaces();

			builder.RegisterType<GenerateInterfacesCommand>().As<ConsoleCommand>();

			return builder.Build();
		}
	}
}
