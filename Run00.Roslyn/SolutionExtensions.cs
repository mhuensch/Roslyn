using Roslyn.Services;
using System.Collections.Generic;

namespace Run00.Roslyn
{
	public static class SolutionExtensions
	{
		public static IEnumerable<IEnumerable<TypeDiff>> CompareTo(this ISolution solution, ISolution comparedTo)
		{
			var projects = solution.Projects;
			var comparedToProjects = comparedTo.Projects;

			var result = projects.FullOuterJoin(comparedToProjects, ProjectComparer.Instance, (a, b) => a.CompareTo(b));
			return result;
		}
	}
}
