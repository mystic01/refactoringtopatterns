using System;
using System.Text;

namespace MoveEmbellishmentToDecorator.MyWork
{
    public class StringNode : AbstractNode
    {
        protected StringBuilder textBuilder;
        private bool shouldDecode;

        public StringNode(StringBuilder textBuffer, int textBegin, int textEnd) : base(textBegin, textEnd)
        {
            this.textBuilder = textBuffer;
        }

        public override string toHtml()
        {
            throw new NotImplementedException();
        }

        public override string toPlainTextString()
        {
            return textBuilder.ToString();
        }

        public static Node createStringNode(StringBuilder textBuffer, int textBegin, int textEnd, bool shouldEncode)
        {
            if (shouldEncode)
                return new DecodingNode(new StringNode(textBuffer, textBegin, textEnd));
            return new StringNode(textBuffer, textBegin, textEnd);
        }
    }
}