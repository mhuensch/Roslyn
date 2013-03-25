
namespace Run00.Roslyn
{
	public static class SymbolExtensions
	{
		//public static bool HasBreakingChanges(this ISymbol symbol, ISymbol comparedTo)
		//{
		//	switch (symbol.Kind)
		//	{
		//		case CommonSymbolKind.Method:
		//			return ((IMethodSymbol)symbol).HasBreakingChanges((IMethodSymbol)comparedTo);

		//		default:
		//			throw new Exception("No symbol type found.");
		//	}
		//}


		//public static bool HasBreakingChanges(this IMethodSymbol symbol, IMethodSymbol comparedTo)
		//{
		//	if (symbol.Name != comparedTo.Name)
		//		return true;

		//	if (symbol.ReturnType.HasBreakingChanges(comparedTo.ReturnType))
		//		return true;

		//	for (var x = 0; x < symbol.Parameters.Count; x++)
		//	{

		//	}

		//	return false;
		//}
	}
}
