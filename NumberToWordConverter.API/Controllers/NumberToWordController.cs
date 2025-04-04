using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NumberToWordConverter.Application.IService;
using NumberToWordConverter.Application.Service;

namespace NumberToWordConverter.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class NumberToWordController : ControllerBase
	{
		private readonly ILogger<NumberToWordController> _logger;
		private readonly IPlaceValuesService _placeValueService;
		private readonly INumberToWordService _numberToWordService;
		
		public NumberToWordController(ILogger<NumberToWordController> logger, INumberToWordService numberToWordService)
		{
			_logger = logger;
			this._numberToWordService = numberToWordService;
		}

		[HttpGet(Name = "GetNumberName")]
		public IActionResult Get(decimal inputNumber)
		{
			//var words = new NumberToWordService(_placeValueService.GetPlaceValues()) { InputNumber = inputNumber }.ConvertToWords();
			_numberToWordService.InputNumber = inputNumber;
			var words = _numberToWordService.ConvertToWords();

			return Ok(words);
		}
	}
}
