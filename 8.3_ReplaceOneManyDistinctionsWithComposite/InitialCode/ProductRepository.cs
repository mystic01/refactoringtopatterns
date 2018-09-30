using System.Collections.Generic;

namespace ReplaceOneManyDistinctionsWithComposite.InitialCode
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

        public List<Product> selectBy(List<Spec> specs)
        {
            List<Product> foundProducts = new List<Product>();
            List<Product>.Enumerator products = iterator();
            while (products.MoveNext())
            {
                Product product = products.Current;
                List<Spec>.Enumerator specifications = specs.GetEnumerator();
                bool satisfiesAllSpecs = true;
                while (specifications.MoveNext())
                {
                    Spec productSpec = specifications.Current;
                    satisfiesAllSpecs &= productSpec.isSatisfiedBy(product);
                }
                if (satisfiesAllSpecs)
                    foundProducts.Add(product);
            }
            return foundProducts;
        }
    }

    public enum ProductSize
    {
        SMALL, MEDIUM, LARGE,
        NOT_APPLICABLE
    }
}