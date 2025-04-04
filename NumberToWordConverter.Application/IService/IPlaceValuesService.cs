using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.Application.IService
{
	public interface IPlaceValuesService
	{
		Dictionary<int, string> GetPlaceValues();
	}
}
