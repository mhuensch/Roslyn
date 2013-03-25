using Microsoft.VisualStudio.TestTools.UnitTesting;
using Run00.MsTest;
using Run00.Roslyn.UnitTest.Artifacts;
using System.Collections.Generic;
using System.Linq;

namespace Run00.Roslyn.UnitTest.ForEnumerableOfTExtensions
{
	[TestClass, CategorizeByConventionClass(typeof(FullOuterJoin))]
	public class FullOuterJoin
	{
		[TestMethod, CategorizeByConvention]
		public void WhenDiffrentValuesAreProvided_ShouldReturnFullyJoinedList()
		{
			//Arrange
			var right = new User[] { 
				new User { Id = 1, Name = "John" },
				new User { Id = 2, Name = "Sue" } };
			var left = new User[] { 
				new User { Id = 1, Name = "Bob" },
				new User { Id = 3, Name = "Smith" } 
			};


			//Act
			var result = right.FullOuterJoin(left, new UserEqualityComparer(), (r, l) => new UserContainer() { One = r, Two = l});

			//Assert
			Assert.AreEqual(3, result.Count());
			Assert.AreEqual(1, result.ElementAt(0).One.Id);
			Assert.AreEqual(1, result.ElementAt(0).Two.Id);
			Assert.AreEqual(2, result.ElementAt(1).One.Id);
			Assert.AreEqual(null, result.ElementAt(1).Two);
			Assert.AreEqual(null, result.ElementAt(2).One);
			Assert.AreEqual(3, result.ElementAt(2).Two.Id);
		}
	}
}
