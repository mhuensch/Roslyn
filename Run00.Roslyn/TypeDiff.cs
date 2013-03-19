using Roslyn.Compilers.Common;
using System.Collections.Generic;
namespace Run00.Roslyn
{
	public class TypeDiff
	{
		public INamespaceOrTypeSymbol Original { get; set; }
		public INamespaceOrTypeSymbol ComparedTo { get; set; }

		public IEnumerable<TypeDiff> AddedMethods { get; set; }
		public IEnumerable<TypeDiff> DeletedMethods { get; set; }
		public IEnumerable<TypeDiff> ModifiedMethods { get; set; }
		public IEnumerable<TypeDiff> RefactoredMethods { get; set; }
	}
}
