using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Interfaces
{
	public interface IInterior
	{
		IEnumerable<string> Features { get; }

		string GetDescription();
	}
}
