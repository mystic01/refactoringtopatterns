using System.Collections.Generic;

namespace ReplaceOneManyDistinctionsWithComposite.MyWork
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>();

        public List<Product>.Enumerator iterator()
        {
            return products.GetEnumerator();
        }

        public List<Product> selectBy(Spec spec)
        {
            List<Product> foundProducts = new List<Product>();
            List<Product>.Enumerator products = iterator();
            while (products.MoveNext())
            {
                Product product = products.Current;
                if (spec.isSatisfiedBy(product))
                    foundProducts.Add(product);
            }

            return foundProducts;
        }

        public void add(Product product)
        {
            products.Add(product);
        }
    }

    public enum ProductSize
    {
        SMALL, MEDIUM, LARGE,
        NOT_APPLICABLE
    }
}