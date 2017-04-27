using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Interfaces
{
	public enum EngineType
	{
		Diesel,
		Lpg,
		Petrol,
	}

	public interface IEngine
	{
		float Capacity { get; }

		EngineType Type { get; }

		string GetDescription();
	}
}
