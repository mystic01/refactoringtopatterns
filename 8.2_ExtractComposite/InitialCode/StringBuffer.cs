namespace ExtractComposite.InitialCode
{
    public class StringBuffer
    {
        private string _content = string.Empty;

        public void append(string text)
        {
            _content += text;
        }

        public override string ToString()
        {
            return _content;
        }
    }
}