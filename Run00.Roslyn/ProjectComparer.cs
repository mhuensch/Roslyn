using Roslyn.Services;
using System.Collections.Generic;

namespace Run00.Roslyn
{
	public class ProjectComparer : IEqualityComparer<IProject>
	{
		public static ProjectComparer Instance
		{
			get
			{
				if (_instance == null)
					_instance = new ProjectComparer();
				return _instance;
			}
		}
		private static ProjectComparer _instance;

		public bool Equals(IProject x, IProject y)
		{
			//TODO: find some way to compare project GUIDs
			return x.Name.Equals(y.Name);
		}

		public int GetHashCode(IProject obj)
		{
			//TODO: find some way to take a hash of the project GUID
			return obj.Name.GetHashCode();
		}
	}
}
