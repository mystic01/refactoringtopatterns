using System.Drawing;

namespace ReplaceOneManyDistinctionsWithComposite.MyWork
{
    public class ColorSpec : Spec
    {
        private readonly Color _color;

        public ColorSpec(Color color)
        {
            this._color = color;
        }

        public override bool isSatisfiedBy(Product product)
        {
            return product.Color == _color;
        }
    }
}