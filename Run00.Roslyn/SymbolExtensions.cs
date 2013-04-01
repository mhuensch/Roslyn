using Roslyn.Compilers.Common;

namespace Run00.Roslyn
{
	public static class SymbolExtensions
	{
		public static SymbolDiff CompareTo(this ISymbol symbol, ISymbol comparedTo)
		{
			var result = new SymbolDiff();
			result.Original = symbol;
			result.ComparedTo = comparedTo;

			switch (symbol.Kind)
			{
				case CommonSymbolKind.Method:
					result.ChangeType = ((IMethodSymbol)symbol).CompareTo((IMethodSymbol)comparedTo);
					break;
				case CommonSymbolKind.Property:
					result.ChangeType = ((IPropertySymbol)symbol).CompareTo((IPropertySymbol)comparedTo);
					break;
				default:
					result.ChangeType = ChangeType.Incomparable;
					break;
			}

			return result;
		}

		public static bool IsContractMember(this ISymbol symbol)
		{
			return symbol.CanBeReferencedByName && (
				symbol.DeclaredAccessibility == CommonAccessibility.Public ||
				symbol.DeclaredAccessibility == CommonAccessibility.Internal ||
				symbol.DeclaredAccessibility == CommonAccessibility.ProtectedOrInternal
			);
		}
	}
}
