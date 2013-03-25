using System.Collections.Generic;

namespace Run00.Roslyn.UnitTest.Artifacts
{
	internal sealed class UserEqualityComparer : IEqualityComparer<User>
	{
		public bool Equals(User x, User y)
		{
			return x.Id == y.Id;
		}

		public int GetHashCode(User obj)
		{
			return obj.Id.GetHashCode();
		}
	}
}
