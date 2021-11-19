
namespace Maikelsoft.ConsoleUtils
{
	public delegate bool Parser<T>(string text, out T result) where T : struct;
}