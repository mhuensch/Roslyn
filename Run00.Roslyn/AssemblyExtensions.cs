using Roslyn.Compilers.Common;
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
	}

}
