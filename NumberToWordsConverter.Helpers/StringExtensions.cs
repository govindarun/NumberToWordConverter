using System.Text.RegularExpressions;

namespace NumberToWordsConverter.Helpers
{
	public static class StringExtensions
	{
		// Matches multiples of any whitespace characters including newlines.
		// Used by SqueezeSpace() to squeeze multiple spaces into a single space
		private static readonly Regex RegexMultipleWhitespace = new Regex(@"\s+", RegexOptions.Compiled);

		public static string SqueezeSpace(this string value)
		{
			if (string.IsNullOrEmpty(value))
				return string.Empty;

			return RegexMultipleWhitespace.Replace(value.Trim(), " ");
		}
	}
}
