using Roslyn.Compilers.Common;
using System.Collections.Generic;
using System.Linq;
namespace Run00.Roslyn
{
	public class TypeDiff
	{
		public TypeDiff()
		{
			MethodDifferences = Enumerable.Empty<SymbolDiff>();
		}

		public INamespaceOrTypeSymbol Original { get; set; }
		public INamespaceOrTypeSymbol ComparedTo { get; set; }

		public IEnumerable<SymbolDiff> MethodDifferences { get; set; }
	}
}
