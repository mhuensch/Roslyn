using Roslyn.Compilers.Common;

namespace Run00.Roslyn
{
	public static class MethodExtensions
	{
		public static ChangeType CompareTo(this IMethodSymbol symbol, IMethodSymbol comparedTo)
		{
			if (symbol == null)
				return ChangeType.Added;

			if (comparedTo == null)
				return ChangeType.Deleted;

			if (symbol.ReturnType != comparedTo.ReturnType)
				return ChangeType.Rewritten;

			if (symbol.DeclaredAccessibility != comparedTo.DeclaredAccessibility)
				return ChangeType.Rewritten;

			if (symbol.Parameters.Count != comparedTo.Parameters.Count)
				return ChangeType.Rewritten;

			for (var index = 0; index < symbol.Parameters.Count; index++)
			{
				if (symbol.Parameters.ElementAt(index).Type == symbol.Parameters.ElementAt(index).Type)
					return ChangeType.Rewritten;
			}

			return ChangeType.None;
		}
	}
}
