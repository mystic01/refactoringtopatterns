using System.Collections.Generic;

namespace ReplaceImplicitTreeWithComposite.MyWork
{
    public class Order
    {
        private int _id;
        private readonly List<Product> _products;

        public Order(int id, List<Product> products)
        {
            _id = id;
            _products = products;
        }

        public int getOrderId()
        {
            return _id;
        }

        public int getProductCount()
        {
            return _products.Count;
        }

        public Product getProduct(int i)
        {
            return _products[i];
        }
    }
}