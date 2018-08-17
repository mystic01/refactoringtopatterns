using System.Collections.Generic;
using NUnit.Framework;
using ReplaceImplicitTreeWithComposite.MyWork;

namespace RefactoringToPatterns.Tests.ReplaceImplicitTreeWithComposite.MyWork
{
    [TestFixture]
    public class OrdersWriterTests
    {
        [Test]
        public void getContentsTest()
        {
            var fireTruck = new Product("f1234", 9, "Fire Truck", 60);
            var firewall = new Product("f1235", 8, "Firewall", 66);
            var order1 = new Order(987, new List<Product> { fireTruck, firewall });
            var order2 = new Order(999, new List<Product> { fireTruck });
            var orders = new Orders(new List<Order> { order1, order2 });
            var target = new OrdersWriter(orders);
            var expected =
                "<orders>" +
                    "<order id='987'>" +
                        "<product id='f1234' color='red' size='9'>" +
                            "<price currency='USD'>60</price>" +
                            "Fire Truck" +
                        "</product>" +
                        "<product id='f1235' color='red' size='8'>" +
                            "<price currency='USD'>66</price>" +
                            "Firewall" +
                        "</product>" +
                    "</order>" +
                    "<order id='999'>" +
                        "<product id='f1234' color='red' size='9'>" +
                            "<price currency='USD'>60</price>" +
                                "Fire Truck" +
                        "</product>" +
                    "</order>" +
                "</orders>";

            var actual = target.getContents();

            Assert.AreEqual(expected, actual, "orders");
        }
    }
}