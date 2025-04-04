using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.Application.IService
{
	public interface INumberToWordService 
	{
		decimal InputNumber { get; set; }
		string ConvertToWords();
	}
}
