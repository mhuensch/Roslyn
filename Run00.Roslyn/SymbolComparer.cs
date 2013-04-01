using Roslyn.Compilers.Common;
using System.Collections.Generic;

namespace Run00.Roslyn
{
	public class SymbolComparer : IEqualityComparer<ISymbol>
	{
		public static SymbolComparer Instance
		{
			get
			{
				if (_instance == null)
					_instance = new SymbolComparer();
				return _instance;
			}
		}
		private static SymbolComparer _instance;

		public bool Equals(ISymbol x, ISymbol y)
		{
			//TODO: find some way to compare project GUIDs
			return x.OriginalDefinition.ToString().Equals(y.OriginalDefinition.ToString());
		}

		public int GetHashCode(ISymbol obj)
		{
			//TODO: find some way to take a hash of the project GUID
			return obj.OriginalDefinition.ToString().GetHashCode();
		}
	}
}
