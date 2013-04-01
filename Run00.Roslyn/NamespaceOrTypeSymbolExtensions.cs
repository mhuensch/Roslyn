using Roslyn.Compilers.Common;
using System.Collections.Generic;
using System.Linq;

namespace Run00.Roslyn
{
	public static class NamespaceOrTypeSymbolExtensions
	{
		public static TypeDiff CompareTo(this INamespaceOrTypeSymbol symbol, INamespaceOrTypeSymbol comparedTo)
		{
			var result = new TypeDiff();
			result.Original = symbol;
			result.ComparedTo = comparedTo;
			result.MethodDifferences = symbol.GetAllContractMembers().FullOuterJoin(comparedTo.GetAllContractMembers(), SymbolComparer.Instance, (a, b) => a.CompareTo(b));
			return result;
		}

		public static IEnumerable<ISymbol> GetAllContractMembers(this INamespaceOrTypeSymbol type)
		{
			if (type == null)
				return Enumerable.Empty<ISymbol>();

			var result = new List<ISymbol>();
			foreach (var member in type.GetMembers())
			{
				if (member.IsContractMember())
				{
					result.Add(member);
				}
			}

			foreach (var nested in type.GetTypeMembers())
			{
				result.AddRange(nested.GetAllContractMembers());
			}

			return result;
		}
	}
}
