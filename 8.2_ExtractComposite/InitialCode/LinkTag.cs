using System.Collections.Generic;

namespace ExtractComposite.InitialCode
{
    public class LinkTag : Tag
    {
        protected List<Node> nodeVector;

        protected Dictionary<string, string> parsed;

        public LinkTag(int tagBegin, int tagEnd, string tagContents, string tagLine) : base(tagBegin, tagEnd, tagContents, tagLine)
        {
        }

        public string toPlainTextString()
        {
            StringBuffer sb = new StringBuffer();
            foreach (var node in linkData())
            {
                sb.append(node.toPlainTextString());
            }

            return sb.ToString();
        }

        protected virtual IEnumerable<Node> linkData()
        {
            return nodeVector;
        }

        public string toHTML()
        {
            StringBuffer sb = new StringBuffer();
            putLinkStartTagInfo(sb);
            foreach (var node in linkData())
            {
                sb.append(node.toHTML());
            }
            sb.append("</A>");
            return sb.ToString();
        }

        private void putLinkStartTagInfo(StringBuffer sb)
        {
            sb.append("<A ");
            string value;
            int i = 0;
            foreach (var key in parsed.Keys)
            {
                i++;
                if (key != TAGNAME)
                {
                    value = getParameter(key);
                    sb.append(key + "=\"" + value + "\"");
                    if (i < parsed.Count - 1)
                        sb.append(" ");
                }
            }
            sb.append(">");
        }

        private string getParameter(string key)
        {
            return parsed[key];
        }
    }
}