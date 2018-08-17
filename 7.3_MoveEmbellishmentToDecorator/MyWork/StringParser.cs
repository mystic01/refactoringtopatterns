﻿using System.Text;

namespace MoveEmbellishmentToDecorator.MyWork
{
    public class StringParser
    {
        private StringBuilder textBuffer;
        private int textBegin;
        private int textEnd;

        public Node find(NodeReader reader, string input, string position, bool balance_quotes)
        {
            return StringNode.createStringNode(textBuffer, textBegin, textEnd, reader.getParser().shouldDecodeNodes());
        }
    }
}