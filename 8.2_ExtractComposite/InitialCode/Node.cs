namespace ExtractComposite.InitialCode
{
    public class Node
    {
        private readonly string _text;

        public Node(string text)
        {
            _text = text;
        }

        public string toPlainTextString()
        {
            return _text;
        }

        public string toHTML()
        {
            return "<" + _text + ">";
        }
    }
}