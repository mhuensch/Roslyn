using Roslyn.Compilers.Common;
using System.Collections.Generic;

namespace Run00.Roslyn
{
	public class AssemblyDiff
	{
		public IAssemblySymbol Original { get; set; }
		public IAssemblySymbol ComparedTo { get; set; }

		public IEnumerable<TypeDiff> AddedTypes { get; set; }
		public IEnumerable<TypeDiff> DeletedTypes { get; set; }
		public IEnumerable<TypeDiff> ModifiedTypes { get; set; }
		public IEnumerable<TypeDiff> RefactoredTypes { get; set; }
	}
}

