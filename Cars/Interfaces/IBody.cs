using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Interfaces
{
	public enum BodyType
	{
		Combi,
		Sedan,
		Cabriolet,
		Coupe
	}

	public enum Color
	{
		Black,
		White,
		NeonPink,
		Blue,
		Rouge,
		VenusYellow
	}

	public interface IBody
	{
		string Color { get; }

		BodyType Type { get; }

		string GetDescription();
	}
}
