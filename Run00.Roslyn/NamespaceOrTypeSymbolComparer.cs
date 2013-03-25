using Roslyn.Compilers.Common;
using System.Collections.Generic;

namespace Run00.Roslyn
{
	public class NamespaceOrTypeSymbolComparer : IEqualityComparer<INamespaceOrTypeSymbol>
	{
		public static NamespaceOrTypeSymbolComparer Instance
		{
			get
			{
				if (_instance == null)
					_instance = new NamespaceOrTypeSymbolComparer();
				return _instance;
			}
		}
		private static NamespaceOrTypeSymbolComparer _instance;

		public bool Equals(INamespaceOrTypeSymbol x, INamespaceOrTypeSymbol y)
		{
			return x.ToDisplayString().Equals(y.ToDisplayString());
		}

		public int GetHashCode(INamespaceOrTypeSymbol obj)
		{
			return obj.ToDisplayString().GetHashCode();
		}
	}
}
