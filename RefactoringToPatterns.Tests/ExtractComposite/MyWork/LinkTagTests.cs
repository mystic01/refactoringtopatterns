using System.Collections.Generic;
using ExtractComposite.MyWork;
using NUnit.Framework;

namespace RefactoringToPatterns.Tests.ExtractComposite.MyWork
{
    [TestFixture]
    public class LinkTagTests
    {
        [Test]
        public void LinkTag_toPlainTextStringTest()
        {
            var targrt = new LinkTagStub(new List<Node>
                {
                    new Node("A"),
                    new Node("B"),
                    new Node("C")
                }
              );

            var actual = targrt.toPlainTextString();

            Assert.AreEqual("ABC", actual);
        }

        [Test]
        public void LinkTag_toHTML()
        {
            var targrt = new LinkTagStub(
                new Dictionary<string, string>()
                {
                    {"href", "url"}
                },
                new List<Node>
                {
                    new Node("A"),
                    new Node("B"),
                    new Node("C")
                }
              );

            var actual = targrt.toHTML();

            var expected = "<A href=\"url\"><A><B><C></A>";
            Assert.AreEqual(expected, actual);
        }
    }

    public class LinkTagStub : LinkTag
    {
        public LinkTagStub(List<Node> nodes) : base(0, 0, string.Empty, string.Empty)
        {
            _children = nodes;
        }

        public LinkTagStub(Dictionary<string, string> parsed, List<Node> nodes) : this(nodes)
        {
            this.parsed = parsed;
        }
    }
}