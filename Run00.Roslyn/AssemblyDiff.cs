using Roslyn.Compilers.Common;
using System.Collections.Generic;
using System.Linq;

namespace Run00.Roslyn
{
	public class AssemblyDiff
	{
		public AssemblyDiff()
		{
			TypeDifferences = Enumerable.Empty<TypeDiff>();
		}

		public IAssemblySymbol Original { get; set; }
		public IAssemblySymbol ComparedTo { get; set; }

		public IEnumerable<TypeDiff> TypeDifferences { get; set; }
	}
}
