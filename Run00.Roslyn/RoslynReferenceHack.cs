using Roslyn.Compilers.CSharp;
using Roslyn.Services.CSharp.Classification;

namespace Run00.Roslyn
{
	internal static class RoslynReferenceHack
	{
		/// <summary>
		/// This method is here in order to force the inclusion of Roslyn.Compilers.CSharp and Roslyn.Services.CSharp
		/// </summary>
		private static void Include()
		{
			typeof(AliasSymbol).ToString();
			typeof(SyntaxClassifier).ToString();
		}
	}
}