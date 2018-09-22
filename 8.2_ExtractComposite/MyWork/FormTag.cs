namespace ExtractComposite.MyWork
{
    public class FormTag : CompositeTag
    {
        protected string formMethod;
        protected string formURL;
        protected string formName;

        private readonly string lineSeparator = "<br>";

        public FormTag(int tagBegin, int tagEnd, string tagContents, string tagLine) : base(tagBegin, tagEnd, tagContents, tagLine)
        {
        }

        public string toPlainTextString()
        {
            StringBuffer stringRepresentation = new StringBuffer();
            foreach (var node in children())
            {
                stringRepresentation.append(node.toPlainTextString());
            }

            return stringRepresentation.ToString();
        }

        public string toHTML()
        {
            StringBuffer rawBuffer = new StringBuffer();

            putStartTagInto(rawBuffer);
            putChildrenTagInto(rawBuffer);
            putEndTagInto(rawBuffer);
            return rawBuffer.ToString();
        }

        protected override void putEndTagInto(StringBuffer rawBuffer)
        {
            rawBuffer.append("</FORM>");
        }

        protected override void putChildrenTagInto(StringBuffer rawBuffer)
        {
            rawBuffer.append(lineSeparator);

            Node prevNode = null;
            foreach (var node in children())
            {
                if (prevNode != null)
                {
                    //This is an new line.
                    rawBuffer.append(lineSeparator);
                }

                rawBuffer.append(node.toHTML());
                prevNode = node;
            }
        }

        protected override string getTagName()
        {
            return "FORM";
        }

        protected override string getParameter(string key)
        {
            return base.parsed[key];
        }
    }
}