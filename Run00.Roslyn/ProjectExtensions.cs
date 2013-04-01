using Roslyn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run00.Roslyn
{
	public static class ProjectExtensions
	{
		public static AssemblyDiff CompareTo(this IProject project, IProject comparedTo)
		{
			var result = new AssemblyDiff();
			result.Original = project.GetCompilation().Assembly;
			result.ComparedTo = comparedTo.GetCompilation().Assembly;
			result.TypeDifferences = result.Original.CompareTo(result.ComparedTo);

			if (result.TypeDifferences.Any(d => d.MethodDifferences.Any(m => m.ChangeType != ChangeType.None)))
				return result;

			return result;
		}
	}
}
