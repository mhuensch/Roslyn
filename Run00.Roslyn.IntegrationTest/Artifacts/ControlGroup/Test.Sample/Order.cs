using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Run00.Roslyn.Integration.ControlGroup
{
	[DataContract]
	public class Order
	{
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public IEnumerable<LineItem> LineItems { get; set; }
	}
}
