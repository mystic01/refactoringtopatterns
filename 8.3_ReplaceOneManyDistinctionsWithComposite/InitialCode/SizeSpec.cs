namespace ReplaceOneManyDistinctionsWithComposite.InitialCode
{
    public class SizeSpec : Spec
    {
        private readonly ProductSize _size;

        public SizeSpec(ProductSize size)
        {
            _size = size;
        }

        public override bool isSatisfiedBy(Product product)
        {
            return product.Size == _size;
        }
    }
}