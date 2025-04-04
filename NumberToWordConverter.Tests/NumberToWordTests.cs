using NumberToWordConverter.Application.Service;

namespace NumberToWordConverter.Tests
{
	public class NumberToWordTests
	{
		private static readonly Dictionary<int, string> placeValues = new()
		{
			{ 1, "Thousand" },
			{ 2, "Million" },
			{ 3, "Billion" },
			{ 4, "Trillion" }   
		};


		[Fact]
		public void ConvertToWord_ShouldReturnCorrectString_ForWholeNumber()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = 123
			};

			var result = service.ConvertToWords();

			Assert.Contains("ONE HUNDRED AND TWENTY-THREE DOLLARS", result);
			Assert.Contains("ZERO CENTS", result);
		}

		[Fact]
		public void ConvertToWord_ShouldReturnCorrectString_ForSingleDigitWholeNumber()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = 1
			};

			var result = service.ConvertToWords();

			Assert.Contains("ONE DOLLAR", result);
			Assert.Contains("ZERO CENTS", result);
		}

		[Fact]
		public void ConvertToWord_ShouldReturnCorrectString_ForDecimalNumber()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = 123.45m
			};

			var result = service.ConvertToWords();

			Assert.Contains("ONE HUNDRED AND TWENTY-THREE DOLLARS", result);
			Assert.Contains("FORTY-FIVE CENTS", result);
		}

		[Fact]
		public void ConvertToWord_ShouldReturnNegative_ForNegativeNumber()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = -123.45m
			};

			var result = service.ConvertToWords();

			Assert.StartsWith("NEGATIVE", result);
		}

		[Fact]
		public void ConvertToWord_ShouldHandleZeroCorrectly()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = 0
			};

			var result = service.GetDollarPart();

			Assert.Contains("ZERO DOLLARS", result);
		}

		[Fact]
		public void ConvertToWord_ShouldHandleNegativeZeroCorrectly()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = -0
			};
			var result = service.GetDollarPart();
			Assert.Contains("ZERO DOLLARS", result);
		}

		[Fact]
		public void ConvertToWord_ShouldHandleLargeNumbersCorrectly()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = 1234567890.12m
			};
			var result = service.ConvertToWords();
			Assert.Contains("ONE BILLION TWO HUNDRED THIRTY-FOUR MILLION FIVE HUNDRED SIXTY-SEVEN THOUSAND EIGHT HUNDRED AND NINETY DOLLARS", result);
			Assert.Contains("TWELVE CENTS", result);
		}

		[Fact]
		public void ConvertToWord_ShouldHandleHyphenCorrectly()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = 897.12m
			};
			var result = service.ConvertToWords();
			Assert.Contains("-", result);
		}

		[Fact]
		public void ConvertToWord_ShouldReturnCorrectString_ForEdgeCases()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = 1000.00m
			};

			var result = service.ConvertToWords();
			Assert.Contains("ONE THOUSAND DOLLARS", result);
			Assert.Contains("ZERO CENTS", result);
		}

		[Fact]
		public void ConvertToWord_ShouldReturnCorrectString_ForEdgeCasesOfLargeNumbers()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = 1000000000.00m
			};

			var result = service.ConvertToWords();
			Assert.Contains("ONE BILLION DOLLARS", result);
			Assert.Contains("ZERO CENTS", result);
		}

		[Fact]
		public void ConvertToWord_ShouldReturnCorrectString_ForEdgeCasesOfSmallNumbers()
		{
			var service = new NumberToWordService(placeValues)
			{
				InputNumber = 10.00m
			};

			var result = service.ConvertToWords();
			Assert.Contains("TEN DOLLARS", result);
			Assert.Contains("ZERO CENTS", result);
		}
	}
}