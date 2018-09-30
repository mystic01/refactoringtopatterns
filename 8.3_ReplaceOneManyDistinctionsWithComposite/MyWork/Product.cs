using System.Drawing;

namespace ReplaceOneManyDistinctionsWithComposite.MyWork
{
    public class Product
    {
        public string Id { get; }
        public string Name { get; }
        public Color Color { get; }
        public float Price { get; }
        public ProductSize Size { get; }

        public Product(string id, string name, Color color, float price, ProductSize size)
        {
            this.Id = id;
            this.Name = name;
            this.Color = color;
            this.Price = price;
            this.Size = size;
        }
    }
}