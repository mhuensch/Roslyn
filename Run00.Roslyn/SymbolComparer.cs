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
			return x.ToDisplayString().Equals(y.ToDisplayString());
		}

		public int GetHashCode(ISymbol obj)
		{
			return obj.ToDisplayString().GetHashCode();
		}
	}
}
