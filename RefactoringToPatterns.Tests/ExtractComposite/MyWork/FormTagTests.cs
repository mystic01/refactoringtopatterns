using System;
using System.Collections.Generic;
using ExtractComposite.MyWork;
using NUnit.Framework;

namespace RefactoringToPatterns.Tests.ExtractComposite.MyWork
{
    [TestFixture]
    public class FormTagTests
    {
        [Test]
        public void FormTag_toPlainTextStringTest()
        {
            var targrt = new FormTagStub(new List<Node>
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
        public void FormTag_toHTML()
        {
            var targrt = new FormTagStub(
                "AAA", "/action_page.php", "BBB",
                new List<Node>
                {
                    new Node("A"),
                    new Node("B"),
                    new Node("C")
                },
                new Dictionary<string, string>()
            );

            var actual = targrt.toHTML();

            var expected =
                "<FORM METHOD=\"AAA\" ACTION=\"/action_page.php\" NAME=\"BBB\"><br>" +
                    "<A><br>" +
                    "<B><br>" +
                    "<C>" +
                "</FORM>";
            Assert.AreEqual(expected, actual);
        }
    }

    public class FormTagStub : FormTag
    {
        public FormTagStub(List<Node> nodes) : base(0, 0, string.Empty, String.Empty)
        {
            this._children = nodes;
        }

        public FormTagStub(string formMethod, string formURL, string formName, List<Node> nodes, Dictionary<string, string> parsed) : this(nodes)
        {
            this.formMethod = formMethod;
            this.formURL = formURL;
            this.formName = formName;
            this.parsed = new Dictionary<string, string> { { "METHOD", formMethod }, { "ACTION", formURL }, { "NAME", formName } };
        }
    }
}