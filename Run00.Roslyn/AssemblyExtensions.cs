using Roslyn.Compilers.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Run00.Roslyn
{
	public static class AssemblyExtensions
	{
		public static bool HasBreakingChanges(this IAssemblySymbol assembly, IAssemblySymbol comparedTo)
		{
			var types = assembly.GlobalNamespace.GetTypes();
			var comparedToTypes = assembly.GlobalNamespace.GetTypes();

			return (
				from t in types
				join c in comparedToTypes
					on t.ToDisplayString() equals c.ToDisplayString()
				where t.HasBreakingChanges(c)
				select c).Count() > 0;
		}

		public static AssemblyDiff GenerateDiff(this IAssemblySymbol assembly, IAssemblySymbol comparedTo)
		{
			var result = new AssemblyDiff();

			var types = assembly.GlobalNamespace.GetTypes();
			var comparedToTypes = assembly.GlobalNamespace.GetTypes();
			
			var e = comparedToTypes.ToLookup(c => c, SymbolComparer.Instance);
			var g = comparedToTypes.ToLookup(c => c, SymbolComparer.Instance);

			var d = types.FullOuterJoin(comparedToTypes, a => a, b => b, (a, b, c) => new TypeDiff());

			result.AddedTypes = comparedToTypes
				.Where(c => types.Contains(c, SymbolComparer.Instance) == false)
				.Select(c => c.GenerateDiff(null));

			result.DeletedTypes = types
				.Where(t => comparedToTypes.Contains(t, SymbolComparer.Instance) == false)
				.Select(t => t.GenerateDiff(null));

			var diffs = types.Join(comparedToTypes, t => t, c => c, (t, c) => t.GenerateDiff(c), SymbolComparer.Instance);
			
			result.ModifiedTypes = diffs.Where(d =>
				d.AddedMethods.Count() > 0 &&
				d.DeletedMethods.Count() > 0 &&
				d.ModifiedMethods.Count() > 0);

			result.ModifiedTypes = diffs.Where(d => d.RefactoredMethods.Count() > 0);

			assembly.Get
			return result;
		}



		internal static IList<TR> FullOuterJoin<TA, TB, TK, TR>(this IEnumerable<ISymbol> a, IEnumerable<ISymbol> b, Func<TA, TK> selectKeyA, Func<TB, TK> selectKeyB, Func<TA, TB, TK, TR> projection)
			where TA : ISymbol
			where TB : ISymbol
		{
			var alookup = a.ToLookup(g => g, SymbolComparer.Instance);
			var blookup = b.ToLookup(g => g, SymbolComparer.Instance);

			var keys = new HashSet<ISymbol>(a, SymbolComparer.Instance);
			keys.UnionWith(b);

			var join = from key in keys
								 from xa in alookup[key].DefaultIfEmpty()
								 from xb in blookup[key].DefaultIfEmpty()
								 select projection(xa, xb, key);

			return join.ToList();
		}
	}


}
