using System.Collections.Generic;

namespace ExtractComposite.InitialCode
{
    public class FormTag : Tag
    {
        protected List<Node> allNodeVector;
        protected Dictionary<string, string> table;
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
            foreach (var node in getAllNodesVector())
            {
                stringRepresentation.append(node.toPlainTextString());
            }

            return stringRepresentation.ToString();
        }

        protected virtual List<Node> getAllNodesVector()
        {
            return allNodeVector;
        }

        public string toHTML()
        {
            StringBuffer rawBuffer = new StringBuffer();

            rawBuffer.append("<FORM METHOD=\"" + formMethod + "\" ACTION=\"" + formURL + "\"");
            if (formName != null && formName.Length > 0)
                rawBuffer.append(" NAME=\"" + formName + "\"");

            string value;
            foreach (var key in table.Keys)
            {
                if (key != "METHOD" || key == "ACTION" || key == "NAME" || key == Tag.TAGNAME)
                {
                    value = table[key];
                    rawBuffer.append(" " + key + "=" + "\"" + value + "\"");
                }
            }
            rawBuffer.append(">");
            rawBuffer.append(lineSeparator);

            Node prevNode = null;
            foreach (var node in getAllNodesVector())
            {
                if (prevNode != null)
                {
                    //This is an new line.
                    rawBuffer.append(lineSeparator);
                }

                rawBuffer.append(node.toHTML());
                prevNode = node;
            }

            rawBuffer.append("</FORM>");
            return rawBuffer.ToString();
        }
    }
}