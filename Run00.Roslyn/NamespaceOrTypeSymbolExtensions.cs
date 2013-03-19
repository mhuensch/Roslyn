using Roslyn.Compilers.Common;
using System.Collections.Generic;
using System.Linq;

namespace Run00.Roslyn
{
	public static class NamespaceOrTypeSymbolExtensions
	{
		public static TypeDiff GenerateDiff(this INamespaceOrTypeSymbol type, INamespaceOrTypeSymbol comparedTo)
		{
			var result = new TypeDiff();

			return result;
		}



		public static bool HasBreakingChanges(this INamespaceOrTypeSymbol type, INamespaceOrTypeSymbol comparedTo)
		{
			var members = type.GetMembers().AsEnumerable();
			var comparedToMembers = comparedTo.GetMembers().AsEnumerable();

			return (
				from m in members
				join c in comparedToMembers
					on m.ToDisplayString() equals c.ToDisplayString()
				where m.HasBreakingChanges(c)
				select c).Count() > 0;
		}

		public static IEnumerable<ISymbol> GetMembers(this INamespaceOrTypeSymbol type)
		{
			var result = new List<ISymbol>();

			var referenceMembers = type.GetMembers().AsEnumerable().Where(m => m.CanBeReferencedByName);
			foreach (var member in referenceMembers)
				result.Add(member);

			foreach (var nested in type.GetTypeMembers())
				result.AddRange(GetMembers(nested));

			return result;
		}
	}

}
