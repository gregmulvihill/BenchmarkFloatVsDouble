using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BenchmarkFloatVsDouble
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("OSDescription: {0}", RuntimeInformation.OSDescription);
			Console.WriteLine("OSArchitecture: {0}", RuntimeInformation.OSArchitecture);
			Console.WriteLine("ProcessArchitecture: {0}", RuntimeInformation.ProcessArchitecture);
			Console.WriteLine("FrameworkDescription: {0}", RuntimeInformation.FrameworkDescription);

			Console.WriteLine();

			var ev = Environment.GetEnvironmentVariables();
			Console.WriteLine("PROCESSOR_ARCHITEW6432: {0}", ev["PROCESSOR_ARCHITEW6432"]);
			Console.WriteLine("PROCESSOR_ARCHITECTURE: {0}", ev["PROCESSOR_ARCHITECTURE"]);
			Console.WriteLine("PROCESSOR_IDENTIFIER: {0}", ev["PROCESSOR_IDENTIFIER"]);
			Console.WriteLine("NUMBER_OF_PROCESSORS: {0}", ev["NUMBER_OF_PROCESSORS"]);

			Console.WriteLine();

			Console.WriteLine("Is64BitProcess: {0}", Environment.Is64BitProcess);
			Console.WriteLine("Is64BitOperatingSystem: {0}", Environment.Is64BitOperatingSystem);

			Console.WriteLine();

			using (var p = Process.GetCurrentProcess())
			{
				p.PriorityClass = ProcessPriorityClass.RealTime;
			}

			var template = "{0,15}, {1,15}, {2,15}, {3,15}";

			Console.WriteLine(
			 template,
			 "Func1Double",
			 "Func1Float",
			 "Func2Double",
			 "Func2Float");

			var count = 100 * 1000 * 1000;
			var v1 = 1.23456789D;
			var v2 = 1.23456789F;

			for (var ii = 0; ii < 10; ii++)
			{
				var t1 = Environment.TickCount;
				for (var i = 0; i < count; i++) Func1Double(v1);
				var d1 = Environment.TickCount - t1;

				var t2 = Environment.TickCount;
				for (var i = 0; i < count; i++) Func1Float(v2);
				var d2 = Environment.TickCount - t2;

				var t3 = Environment.TickCount;
				for (var i = 0; i < count; i++) Func2Double(v1);
				var d3 = Environment.TickCount - t3;

				var t4 = Environment.TickCount;
				for (var i = 0; i < count; i++) Func2Float(v2);
				var d4 = Environment.TickCount - t4;

				Console.WriteLine(template, d1, d2, d3, d4);
			}

			Console.WriteLine("Done");
			Console.ReadKey();
		}

		public static double Func1Double(double x)
		{
			return Math.Exp(-x * x);
		}

		public static float Func1Float(float x)
		{
			return (float)Math.Exp(-x * x);
		}

		public static double Func2Double(double x)
		{
			return 1d - (1d / (1d + (x * x)));
		}

		public static float Func2Float(float x)
		{
			return 1f - (1f / (1f + (x * x)));
		}
	}
}

