using System.Collections.Generic;
using System.ServiceModel;

namespace Run00.Roslyn.Integration.ControlGroup
{
	[ServiceContract]
	public interface IOrderService
	{
		[OperationContract]
		IEnumerable<Order> GetOrders();
	}
}
