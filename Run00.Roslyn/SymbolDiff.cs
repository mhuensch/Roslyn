using Roslyn.Compilers.Common;
namespace Run00.Roslyn
{
	public class SymbolDiff
	{
		public ISymbol Original { get; set; }
		public ISymbol ComparedTo { get; set; }
		public ChangeType ChangeType { get; set; }
	}
}
