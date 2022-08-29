using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actor1
{
	public class DependencyImplementation : IDependency
	{
		public string GetString() => "some string";
	}
}
