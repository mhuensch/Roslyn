using Roslyn.Compilers.Common;
using System.Collections.Generic;

namespace Run00.Roslyn
{
	public static class AssemblyExtensions
	{
		public static IEnumerable<TypeDiff> CompareTo(this IAssemblySymbol assembly, IAssemblySymbol comparedTo)
		{
			var types = assembly.GlobalNamespace.GetTypes();
			var comparedToTypes = comparedTo.GlobalNamespace.GetTypes();
			var result = types.FullOuterJoin(comparedToTypes, NamespaceOrTypeSymbolComparer.Instance, (a, b) => a.CompareTo(b));
			return result;
		}
	}
}
