using NumberToWordConverter.Application.IService;

namespace NumberToWordConverter.Application.Service
{
	public class PlaceValuesService : IPlaceValuesService
	{
		private readonly Dictionary<int, string> _placeValues;

		public PlaceValuesService(Dictionary<int, string> placeValues)
		{
			_placeValues = placeValues;
		}
		
		public Dictionary<int, string> GetPlaceValues() => _placeValues;
	}
}
