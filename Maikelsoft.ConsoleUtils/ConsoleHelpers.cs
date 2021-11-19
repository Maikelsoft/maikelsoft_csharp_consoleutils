using System;

namespace Maikelsoft.ConsoleUtils
{
	public static class ConsoleHelpers
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		public static void WaitForAnyKey(string text = "Press any key to return...")
		{
			Console.WriteLine(text);
			Console.ReadKey(true);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static bool ReadYesNo(string text, bool defaultValue) =>
			ReadBool(text, 'Y', 'N', defaultValue);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static bool ReadYesNo(string text) => ReadBool(text, 'Y', 'N');

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <param name="trueChar"></param>
		/// <param name="falseChar"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static bool ReadBool(string text, char trueChar, char falseChar, bool defaultValue)
		{
			string formattedText = string.Format(text, trueChar, falseChar, defaultValue);
			if (formattedText.Length > 0 && !formattedText.EndsWith(' '))
			{
				formattedText += ' ';
			}

			Console.Write(formattedText);
			ConsoleKeyInfo key = Console.ReadKey(true);

			if (key.KeyChar == char.ToLower(trueChar))
			{
				Console.WriteLine(trueChar);
				return true;
			}

			if (key.KeyChar == char.ToLower(falseChar))
			{
				Console.WriteLine(falseChar);
				return false;
			}

			Console.WriteLine(defaultValue ? trueChar : falseChar);
			return defaultValue;
		}

		public static bool ReadBool(string text, char trueChar, char falseChar)
		{
			string formattedText = string.Format(text, trueChar, falseChar);
			if (formattedText.Length > 0 && !formattedText.EndsWith(' '))
			{
				formattedText += ' ';
			}

			Console.Write(formattedText);
			bool? result = null;
			do
			{
				ConsoleKeyInfo key = Console.ReadKey(true);
				if (key.KeyChar == char.ToLower(trueChar))
				{
					Console.Write(trueChar);
					result = true;
				}
				else if (key.KeyChar == char.ToLower(falseChar))
				{
					Console.Write(falseChar);
					result = false;
				}
				else
				{
					Console.Beep();
				}
			} while (!result.HasValue);

			Console.WriteLine();
			return result.Value;
		}

		#region Read Number

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="text"></param>
		/// <param name="parser"></param>
		/// <returns></returns>
		public static T ReadNumber<T>(string text, Parser<T> parser) where T : struct, IFormattable =>
			ReadNumber(text, parser, _ => true);

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="text"></param>
		/// <param name="parser"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		public static T ReadNumber<T>(string text, Parser<T> parser, Func<T, bool> validate)
			where T : struct, IFormattable
		{
			if (text.Length > 0 && !text.EndsWith(' '))
			{
				text += ' ';
			}

			T? result = null;
			do
			{
				Console.Write(text);
				string? line = Console.ReadLine();
				if (line != null && parser(line, out T number) && validate(number))
				{
					result = number;
				}
				else
				{
					Console.Beep();
				}
			} while (!result.HasValue);

			return result.Value;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="text"></param>
		/// <param name="parser"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static T ReadNumber<T>(string text, Parser<T> parser, T defaultValue)
			where T : struct, IFormattable =>
			ReadNumber(text, parser, defaultValue, _ => true);

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="text"></param>
		/// <param name="parser"></param>
		/// <param name="defaultValue"></param>
		/// <param name="validate"></param>
		/// <returns></returns>
		public static T ReadNumber<T>(string text, Parser<T> parser, T defaultValue, Func<T, bool> validate)
			where T : struct, IFormattable
		{
			string formattedText = string.Format(text, defaultValue);
			if (formattedText.Length > 0 && !formattedText.EndsWith(' '))
			{
				formattedText += ' ';
			}

			T? result = null;
			do
			{
				Console.Write(formattedText);

				string? line = Console.ReadLine();
				if (string.IsNullOrEmpty(line))
				{
					result = defaultValue;
				}
				else
				{
					if (parser(line, out T number) && validate(number))
					{
						result = number;
					}
					else
					{
						Console.Beep();
					}
				}
			} while (!result.HasValue);

			return result.Value;
		}

		#endregion

		#region Read Int

		public static int ReadInt(string text) => ReadNumber<int>(text, int.TryParse);

		public static int ReadInt(string text, Func<int, bool> validate) =>
			ReadNumber(text, int.TryParse, validate);

		public static int ReadInt(string text, int defaultValue) =>
			ReadNumber(text, int.TryParse, defaultValue);

		public static int ReadInt(string text, int defaultValue, Func<int, bool> validate) =>
			ReadNumber(text, int.TryParse, defaultValue, validate);

		#endregion

		#region Read Double

		public static double ReadDouble(string text) => ReadNumber<double>(text, double.TryParse);

		public static double ReadDouble(string text, Func<double, bool> validate) =>
			ReadNumber(text, double.TryParse, validate);

		public static double ReadDouble(string text, double defaultValue) =>
			ReadNumber(text, double.TryParse, defaultValue);

		public static double ReadDouble(string text, double defaultValue, Func<double, bool> validate) =>
			ReadNumber(text, double.TryParse, defaultValue, validate);

		#endregion

		#region Read Float

		public static float ReadFloat(string text) => ReadNumber<float>(text, float.TryParse);

		public static float ReadFloat(string text, Func<float, bool> validate) =>
			ReadNumber(text, float.TryParse, validate);

		public static float ReadFloat(string text, float defaultValue) =>
			ReadNumber(text, float.TryParse, defaultValue);

		public static float ReadFloat(string text, float defaultValue, Func<float, bool> validate) =>
			ReadNumber(text, float.TryParse, defaultValue, validate);

		#endregion

		#region Read Decimal

		public static decimal ReadDecimal(string text) => ReadNumber<decimal>(text, decimal.TryParse);

		public static decimal ReadDecimal(string text, Func<decimal, bool> validate) =>
			ReadNumber(text, decimal.TryParse, validate);

		public static decimal ReadDecimal(string text, decimal defaultValue) =>
			ReadNumber(text, decimal.TryParse, defaultValue);

		public static decimal ReadDecimal(string text, decimal defaultValue, Func<decimal, bool> validate) =>
			ReadNumber(text, decimal.TryParse, defaultValue, validate);

		#endregion
	}
}