using System;

namespace MoveEmbellishmentToDecorator.MyWork
{
    public class DecodingNode : Node
    {
        private Node delegateNode;

        public DecodingNode(StringNode stringNode)
        {
            delegateNode = stringNode;
        }

        public string toPlainTextString()
        {
            return Translate.decode(delegateNode.toPlainTextString());
        }

        public string toHtml()
        {
            return delegateNode.toHtml();
        }

        public string toString()
        {
            return delegateNode.toString();
        }

        public void collectInfo(NodeList nodes, string filter)
        {
            delegateNode.collectInfo(nodes, filter);
        }

        public void collectInfo(NodeList nodes, Type nodeType)
        {
            delegateNode.collectInfo(nodes, nodeType);
        }

        public int elementBegin()
        {
            return delegateNode.elementBegin();
        }

        public int elementEnd()
        {
            return delegateNode.elementEnd();
        }

        public void setParent(CompositeTag tag)
        {
            delegateNode.setParent(tag);
        }

        public CompositeTag getParent()
        {
            return delegateNode.getParent();
        }
    }
}