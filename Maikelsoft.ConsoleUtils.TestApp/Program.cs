using System;

namespace Maikelsoft.ConsoleUtils.TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			// Read boolean
			bool b1 = ConsoleHelpers.ReadYesNo("Really?");
			Console.WriteLine($"You answered: {b1}");
			bool b2 = ConsoleHelpers.ReadYesNo("Really ({0}/{1} or {2} for other key)?", false);
			Console.WriteLine($"You answered: {b2}");
			bool b3 = ConsoleHelpers.ReadYesNo("Really?", true);
			Console.WriteLine($"You answered: {b3}");
			bool b4 = ConsoleHelpers.ReadBool("Boollie [{0}, {1}]", 'T', 'F');
			Console.WriteLine($"You answered: {b4}");
			
			// Read int
			int i1 = ConsoleHelpers.ReadInt("Please enter an integer value (or {0} for default):", 2);
			Console.WriteLine($"You answered: {i1}");
			//int i2 = ConsoleHelpers.ReadInt("Please enter an integer value", 100);
			//Console.WriteLine($"You answered: {i2}");

			ConsoleHelpers.WaitForAnyKey();
		}
	}
}
