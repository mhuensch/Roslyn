using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.Services;
using System.Linq;

namespace Run00.Roslyn.IntegrationTest
{
	[TestClass, DeploymentItem(@"..\..\Artifacts")]
	public class Tests
	{
		[TestMethod]
		public void TestMethod1()
		{
			var controlGroup = Solution.Load(@"ControlGroup\Test.Sample.sln");
			var testGroup = Solution.Load(@"ControlGroup\Test.Sample.sln");
			var test = controlGroup.Projects.First();
			var results = controlGroup.CompareTo(testGroup);


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
	}
}
