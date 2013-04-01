using Roslyn.Compilers.Common;

namespace Run00.Roslyn
{
	public static class PropertyExtensions
	{
		public static ChangeType CompareTo(this IPropertySymbol symbol, IPropertySymbol comparedTo)
		{
			if (symbol == null)
				return ChangeType.Added;

			if (comparedTo == null)
				return ChangeType.Deleted;

			if (symbol.Type != comparedTo.Type)
				return ChangeType.Rewritten;

			if (symbol.DeclaredAccessibility != comparedTo.DeclaredAccessibility)
				return ChangeType.Rewritten;

			return ChangeType.None;
		}
	}
}
