using System.Collections.Generic;

namespace ReplaceImplicitTreeWithComposite.MyWork
{
    public class Orders
    {
        private List<Order> _orders;

        public Orders(List<Order> orders)
        {
            this._orders = orders;
        }

        public int getOrderCount()
        {
            return _orders.Count;
        }

        public Order getOrder(int i)
        {
            return _orders[i];
        }
    }
}