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
		public static IEnumerable<TypeDiff> CompareTo(this IProject project, IProject comparedTo)
		{
			var assembly = project.GetCompilation().Assembly;
			var comparedToAssembly = comparedTo.GetCompilation().Assembly;
			return assembly.CompareTo(comparedToAssembly);
		}
	}
}
