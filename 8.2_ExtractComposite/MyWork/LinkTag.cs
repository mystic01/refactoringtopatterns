namespace ExtractComposite.MyWork
{
    public class LinkTag : CompositeTag
    {
        public LinkTag(int tagBegin, int tagEnd, string tagContents, string tagLine) : base(tagBegin, tagEnd, tagContents, tagLine)
        {
        }

        public string toPlainTextString()
        {
            StringBuffer sb = new StringBuffer();
            foreach (var node in children())
            {
                sb.append(node.toPlainTextString());
            }

            return sb.ToString();
        }

        public string toHTML()
        {
            StringBuffer sb = new StringBuffer();
            putStartTagInto(sb);
            putChildrenTagInto(sb);
            putEndTagInto(sb);
            return sb.ToString();
        }

        protected override void putEndTagInto(StringBuffer sb)
        {
            sb.append("</A>");
        }

        protected override void putChildrenTagInto(StringBuffer sb)
        {
            foreach (var node in children())
            {
                sb.append(node.toHTML());
            }
        }

        protected override string getTagName()
        {
            return "A";
        }

        protected override string getParameter(string key)
        {
            return parsed[key];
        }
    }
}