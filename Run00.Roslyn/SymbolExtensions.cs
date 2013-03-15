using Roslyn.Compilers.Common;
using System;

namespace Run00.Roslyn
{
	public static class SymbolExtensions
	{
		public static bool HasBreakingChanges(this ISymbol symbol, ISymbol comparedTo)
		{
			switch(symbol.Kind)
			{
				case CommonSymbolKind.Method:
					return ((IMethodSymbol)symbol).HasBreakingChanges((IMethodSymbol)comparedTo);

				default:
					throw new Exception("No symbol type found.");
			}
		}


		public static bool HasBreakingChanges(this ISymbol symbol, ISymbol comparedTo)
		{
		}

	}
}
