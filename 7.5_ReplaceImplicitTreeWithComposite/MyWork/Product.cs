namespace ReplaceImplicitTreeWithComposite.MyWork
{
    public class Product
    {
        private readonly string _id;
        private readonly int _size;
        private readonly string _name;
        private readonly int _price;

        public Product(string id, int size, string name, int price)
        {
            _id = id;
            _size = size;
            _name = name;
            _price = price;
        }

        public string getId()
        {
            return _id;
        }

        public int getSize()
        {
            return _size;
        }

        public string getName()
        {
            return _name;
        }

        public int getPrice()
        {
            return _price;
        }
    }
}