using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roslyn.Compilers;
using Roslyn.Compilers.Common;
using Run00.MsTest;
using Run00.Roslyn.UnitTest.Artifacts;
using System.Collections.Generic;
using System.Linq;

namespace Run00.Roslyn.UnitTest.ForAssemblyExtensions
{
	[TestClass, CategorizeByConventionClass(typeof(GenerateDiff))]
	public class GenerateDiff
	{
		[TestMethod, CategorizeByConvention]
		public void WhenComparingTypes_ShouldReturnTypeDiffForEachUniqueType()
		{
			//Arrange
			var moqOrigAssembly = MockAssemblyUsing("1", "2");
			var moqNewAssembly = MockAssemblyUsing("2", "3");

			//Act
			var result = moqOrigAssembly.Object.CompareTo(moqNewAssembly.Object);

			//Assert
			Assert.AreEqual(3, result.Count());
		}

		private static Mock<IAssemblySymbol> MockAssemblyUsing(string idOne, string idTwo)
		{
			var types = new List<INamedTypeSymbol>();

			var typeOne = new Mock<INamedTypeSymbol>(MockBehavior.Strict);
			typeOne.Setup(a => a.ToDisplayString(null, null)).Returns(idOne);
			types.Add(typeOne.Object);

			var typeTwo = new Mock<INamedTypeSymbol>(MockBehavior.Strict);
			typeTwo.Setup(a => a.ToDisplayString(null, null)).Returns(idTwo);
			types.Add(typeTwo.Object);

			var newTypeSymbols = ReadOnlyArray<INamedTypeSymbol>.CreateFrom(types);

			var moqNewNamespace = new Mock<INamespaceSymbol>(MockBehavior.Strict);
			moqNewNamespace.Setup(n => n.GetTypeMembers()).Returns(newTypeSymbols).Verifiable();
			moqNewNamespace.Setup(n => n.GetNamespaceMembers()).Returns(Enumerable.Empty<INamespaceSymbol>()).Verifiable();

			var result = new Mock<IAssemblySymbol>(MockBehavior.Strict);
			result.Setup(a => a.GlobalNamespace).Returns(moqNewNamespace.Object).Verifiable();

			return result;
		}
	}
}
