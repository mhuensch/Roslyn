using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.Services;
using Run00.MsTest;
using System.IO;
using System.Linq;

namespace Run00.Roslyn.IntegrationTest
{
	[TestClass, CategorizeByConventionClass(typeof(IntegrationTests))]
	[DeploymentItem(@"..\..\Artifacts")]
	public class IntegrationTests
	{
		[TestMethod, CategorizeByConvention]
		public void WhenComparingIdenticalProjects_ShouldReturnAllTypesWithNullDiffrences()
		{
			var controlGroup = Solution.Load(Path.Combine(Directory.GetCurrentDirectory(), @"ControlGroup\Test.Sample.sln"));
			var testGroup = Solution.Load(Path.Combine(Directory.GetCurrentDirectory(), @"ControlGroup\Test.Sample.sln"));

			var results = controlGroup.CompareTo(testGroup);
			Assert.AreEqual(1, results.Count(), "More than one assembly difference returned.");

			var assemblyDiff = results.First();
			var expectedName = "Run00.Roslyn.Integration.ControlGroup";
			Assert.AreEqual(expectedName, assemblyDiff.Original.Name);
			Assert.AreEqual(expectedName, assemblyDiff.ComparedTo.Name);

			var typeDiffs = assemblyDiff.TypeDifferences;
			Assert.AreEqual(4, typeDiffs.Count(), "More than four types compared.");
			Assert.AreEqual("IOrderService", typeDiffs.ElementAt(0).Original.Name);
			Assert.AreEqual("IOrderService", typeDiffs.ElementAt(0).ComparedTo.Name);
			Assert.AreEqual("Order", typeDiffs.ElementAt(1).Original.Name);
			Assert.AreEqual("Order", typeDiffs.ElementAt(1).ComparedTo.Name);
			Assert.AreEqual("LineItem", typeDiffs.ElementAt(2).Original.Name);
			Assert.AreEqual("LineItem", typeDiffs.ElementAt(2).ComparedTo.Name);
			Assert.AreEqual("OrderService", typeDiffs.ElementAt(3).Original.Name);
			Assert.AreEqual("OrderService", typeDiffs.ElementAt(3).ComparedTo.Name);


			foreach (var diff in typeDiffs)
			{
				Assert.AreEqual(0, diff.MethodDifferences.Count(), "No added methods expected.");
			}


			//var mainSolution = Solution.Load(@"C:\SourceCode\Run00\Command\Run00.Command.sln");
			//var mainDocuments = mainSolution.Projects.SelectMany(p => p.Documents).ToList();

			//var devSolution = Solution.Load(@"C:\Users\MediaAdmin\Desktop\Command\Run00.Command.sln");
			//var devDocuments = devSolution.Projects.SelectMany(p => p.Documents).ToList();
			//var devCompliation = devSolution.Projects.First().GetCompilation();
			//var devAssem = devCompliation.Assembly;

			//var types = GetTypes(devAssem.GlobalNamespace);


			//var gNamespace = devAssem.GlobalNamespace;
			//var symbols = GetMembers(devAssem.GlobalNamespace);


			//var member = symbols.First().ContainingType;

			//var testSymbol = symbols.Where(s => s.Kind == CommonSymbolKind.Method && ((IMethodSymbol)s).Parameters.Count != 0).First();
			//var methodSym = testSymbol as IMethodSymbol;
			//methodSym.Parameters.Count.ToString();

			//var type = devAssem.GetTypeByMetadataName(GetTypes(mainSolution.Projects.First().GetCompilation().Assembly.GlobalNamespace).First().ToDisplayString());

			////Refactored changes
			//var tree = SyntaxTree.ParseText(devSolution.Projects.First().Documents.Where(d => d.Name == "CommandBase.cs").First().GetText());
			//var tree2 = SyntaxTree.ParseText(mainSolution.Projects.First().Documents.Where(d => d.Name == "CommandBase.cs").First().GetText());
			//var spans = tree.GetChangedSpans(tree2);
			//var result = tree.GetLineSpan(spans.First(), false);
			//var something = tree.GetChanges(tree2);
			//var test = devDocuments[1].GetCodeRefactorings(spans.First());
		}

		[TestMethod, CategorizeByConvention]
		public void WhenComparingProjectsWithCommentChanges_ShouldReturnAllTypesWithNullDiffrences()
		{
			var controlGroup = Solution.Load(Path.Combine(Directory.GetCurrentDirectory(), @"ControlGroup\Test.Sample.sln"));
			var testGroup = Solution.Load(Path.Combine(Directory.GetCurrentDirectory(), @"Comments\Test.Sample.sln"));

			var results = controlGroup.CompareTo(testGroup);
			Assert.AreEqual(1, results.Count(), "More than one assembly difference returned.");

			var assemblyDiff = results.First();
			var expectedName = "Run00.Roslyn.Integration.ControlGroup";
			Assert.AreEqual(expectedName, assemblyDiff.Original.Name);
			Assert.AreEqual(expectedName, assemblyDiff.ComparedTo.Name);

			var typeDiffs = assemblyDiff.TypeDifferences;
			Assert.AreEqual(4, typeDiffs.Count(), "More than four types compared.");
			Assert.AreEqual("IOrderService", typeDiffs.ElementAt(0).Original.Name);
			Assert.AreEqual("IOrderService", typeDiffs.ElementAt(0).ComparedTo.Name);
			Assert.AreEqual("Order", typeDiffs.ElementAt(1).Original.Name);
			Assert.AreEqual("Order", typeDiffs.ElementAt(1).ComparedTo.Name);
			Assert.AreEqual("LineItem", typeDiffs.ElementAt(2).Original.Name);
			Assert.AreEqual("LineItem", typeDiffs.ElementAt(2).ComparedTo.Name);
			Assert.AreEqual("OrderService", typeDiffs.ElementAt(3).Original.Name);
			Assert.AreEqual("OrderService", typeDiffs.ElementAt(3).ComparedTo.Name);


			foreach (var diff in typeDiffs)
			{
				Assert.AreEqual(0, diff.MethodDifferences.Count(), "No added methods expected.");
			}
		}

		[TestMethod, CategorizeByConvention]
		public void WhenComparingProjectsWithDeletedItems_ShouldReturnDeletedDiffrences()
		{
			var controlGroup = Solution.Load(Path.Combine(Directory.GetCurrentDirectory(), @"ControlGroup\Test.Sample.sln"));
			var testGroup = Solution.Load(Path.Combine(Directory.GetCurrentDirectory(), @"Deleted\Test.Sample.sln"));

			var results = controlGroup.CompareTo(testGroup);
			Assert.AreEqual(1, results.Count(), "More than one assembly difference returned.");

			var assemblyDiff = results.First();
			var expectedName = "Run00.Roslyn.Integration.ControlGroup";
			Assert.AreEqual(expectedName, assemblyDiff.Original.Name);
			Assert.AreEqual(expectedName, assemblyDiff.ComparedTo.Name);

			var typeDiffs = assemblyDiff.TypeDifferences;
			Assert.AreEqual(4, typeDiffs.Count(), "More than four types compared.");
			Assert.AreEqual("IOrderService", typeDiffs.ElementAt(0).Original.Name);
			Assert.AreEqual("IOrderService", typeDiffs.ElementAt(0).ComparedTo.Name);
			Assert.AreEqual("Order", typeDiffs.ElementAt(1).Original.Name);
			Assert.AreEqual("Order", typeDiffs.ElementAt(1).ComparedTo.Name);
			Assert.AreEqual("OrderService", typeDiffs.ElementAt(3).Original.Name);
			Assert.AreEqual("OrderService", typeDiffs.ElementAt(3).ComparedTo.Name);

			Assert.AreEqual("LineItem", typeDiffs.ElementAt(2).Original.Name);
			Assert.IsNull(typeDiffs.ElementAt(2).ComparedTo);

			var orderDiff = typeDiffs.ElementAt(1);
			Assert.AreEqual(1, orderDiff.MethodDifferences.Where(d => d.ChangeType != ChangeType.Deleted).Count());
			Assert.AreEqual("LineItems", orderDiff.MethodDifferences.Where(d => d.ChangeType == ChangeType.Deleted).First().Original.Name);

		}
	}
}
