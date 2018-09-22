using System.Collections.Generic;

namespace ExtractComposite.MyWork
{
    public abstract class CompositeTag : Tag
    {
        protected List<Node> _children;
        protected Dictionary<string, string> parsed;

        public CompositeTag(int tagBegin, int tagEnd, string tagContents, string tagLine) : base(tagBegin, tagEnd, tagContents, tagLine)
        {
        }

        protected virtual List<Node> children()
        {
            return _children;
        }

        protected abstract void putEndTagInto(StringBuffer sb);

        protected abstract void putChildrenTagInto(StringBuffer sb);

        protected virtual void putStartTagInto(StringBuffer sb)
        {
            sb.append("<" + getTagName() +" ");
            string value;
            int i = 0;
            foreach (var key in parsed.Keys)
            {
                if (key != TAGNAME)
                {
                    value = getParameter(key);
                    sb.append(key + "=\"" + value + "\"");
                    if (i < parsed.Count - 1)
                        sb.append(" ");
                }
                i++;
            }
            sb.append(">");
        }

        protected abstract string getTagName();

        protected abstract string getParameter(string key);
    }
}