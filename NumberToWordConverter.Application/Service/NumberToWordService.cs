using NumberToWordConverter.Application.IService;
using NumberToWordsConverter.Helpers;

namespace NumberToWordConverter.Application.Service	
{
	public class NumberToWordService : INumberToWordService
	{
		
		public decimal InputNumber { get; set; }

		private const Int64 Thousand = 1000;

		private readonly Dictionary<int, string> PlaceValues = new Dictionary<int, string>();

		private readonly Dictionary<int, string> Units = new()
		{
			{ 0, "Zero" }, 
			{ 1, "One" }, 
			{ 2, "Two" }, 
			{ 3, "Three" }, 
			{ 4, "Four" }, 
			{ 5, "Five" }, 
			{ 6, "Six" }, 
			{ 7, "Seven" }, 
			{ 8, "Eight" }, 
			{ 9, "Nine" },
			{ 10, "Ten" }, 
			{ 11, "Eleven" }, 
			{ 12, "Twelve" }, 
			{ 13, "Thirteen" }, 
			{ 14, "Fourteen" }, 
			{ 15, "Fifteen" }, 
			{ 16, "Sixteen" }	,
			{ 17, "Seventeen" }, 
			{ 18, "Eighteen" }, 
			{ 19, "Nineteen" }
		};

		private readonly Dictionary<int, string> Tens = new()
		{
			{ 10, "Ten" }, 
			{ 20, "Twenty" }, 
			{ 30, "Thirty" }, 
			{ 40, "Forty" }, 
			{ 50, "Fifty" }, 
			{ 60, "Sixty" }, 
			{ 70, "Seventy" }, 
			{ 80, "Eighty" }, 
			{ 90, "Ninety" }
		};

		public NumberToWordService(Dictionary<int, string> placeValues)
		{
			this.PlaceValues = placeValues;
		}

		public string ConvertToWords()
		{
			return $"{GetDollarPart()} AND {GetCentPart()}".SqueezeSpace().ToUpper();
		}

		public string	GetDollarPart()
		{
			Int64 dollars = (Int64)InputNumber;
			var dollarWord = $"{GetWords(dollars)} {(dollars == 1 ? "DOLLAR" : "DOLLARS")}";

			if (dollars < 0)
				return $"Negative {dollarWord}";

			return dollarWord;
		}

		private	string GetCentPart()
		{
			int cents = (int)((InputNumber - (Int64)InputNumber) * 100);
			var centWord = $"{GetWords(cents)}  {(cents == 1 ? "CENT" : "CENTS")}";
			return centWord;
		}

		private string GetWords(Int64 number) {
			if (number == 0)
				return "ZERO";

			string numberNames = string.Empty;
			var numbersGrouped = SplitIntoGroupOfThree(number);	

			var lengthOfGroups = numbersGrouped.Count;
			for (int i = lengthOfGroups - 1; i >=0; i--)
			{
				var currentNumber = numbersGrouped[i];
				if (i == 0)
				{
					if (currentNumber != 0)
						numberNames += IntegerToWords(currentNumber);
				}
				else
				{
					if (currentNumber != 0)
					{
						numberNames += $"{IntegerToWords(numbersGrouped[i])} {PlaceValues[i]} ";
						numberNames = numberNames.Replace("AND", "");
					}
				}
			}

			return numberNames.Trim(); 
		}

		private static List<int> SplitIntoGroupOfThree(Int64 number)
		{
			var groups = new List<int>();
			while (number > 0)
			{
				groups.Add((int)(number % Thousand));
				number /= Thousand;
			}
			return groups;
		}

		private	string IntegerToWords(Int64 number)
		{
			string numberNames = string.Empty;

			if (number == 0)
				return Units[0];

			if (number / 100 > 0)
			{
				numberNames += $"{IntegerToWords(number / 100)} HUNDRED ";
				number %= 100;
			}

			if (number > 0)
			{
				if (!string.IsNullOrWhiteSpace(numberNames))
					numberNames += "AND ";

				if (number < 20)
				{
					numberNames += Units[(int)number];
				}
				else
				{
					int tens = ((int)number / 10) * 10;
					int units = (int)number % 10;
					numberNames += Tens[tens];
					if (units > 0)
						numberNames += "-" + Units[units];
				}
			}

			return numberNames;
		}

	}
}
