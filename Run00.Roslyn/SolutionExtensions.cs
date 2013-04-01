using Roslyn.Services;
using System.Collections.Generic;

namespace Run00.Roslyn
{
	public static class SolutionExtensions
	{
		public static IEnumerable<AssemblyDiff> CompareTo(this ISolution solution, ISolution comparedTo)
		{
			var projects = solution.Projects;
			var comparedToProjects = comparedTo.Projects;
			return projects.FullOuterJoin(comparedToProjects, ProjectComparer.Instance, (a, b) => a.CompareTo(b));
		}
	}
}
