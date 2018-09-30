using System;

namespace ReplaceOneManyDistinctionsWithComposite.InitialCode
{
    public class BelowPriceSpec : Spec
    {
        private readonly float _price;

        public BelowPriceSpec(float price)
        {
            _price = price;
        }

        public override bool isSatisfiedBy(Product product)
        {
            return Math.Abs(product.Price - _price) < 0.000001;
        }
    }
}