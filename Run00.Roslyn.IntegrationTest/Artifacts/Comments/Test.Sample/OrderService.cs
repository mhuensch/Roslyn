using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run00.Roslyn.Integration.ControlGroup
{
	public class OrderService : IOrderService
	{
		public IEnumerable<Order> GetOrders()
		{
			return Enumerable.Empty<Order>();
		}
	}
}
