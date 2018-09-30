using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using ReplaceOneManyDistinctionsWithComposite.InitialCode;

namespace RefactoringToPatterns.Tests.ReplaceOneManyDistinctionsWithComposite.InitialCode
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private ProductRepository repository;

        private Product fireTruck = new Product("f1234", "Fire Truck", Color.Red, 8.95f, ProductSize.MEDIUM);
        private Product barbieClassic = new Product("b7654", "Barbie Classic", Color.Yellow, 15.95f, ProductSize.SMALL);
        private Product frisbee = new Product("f4321", "Frisbee", Color.Pink, 9.99f, ProductSize.LARGE);
        private Product baseball = new Product("b2343", "Baseball", Color.White, 8.95f, ProductSize.NOT_APPLICABLE);
        private Product toyConvertible = new Product("p1112", "Toy Porsche Convertible", Color.Red, 230.00f, ProductSize.NOT_APPLICABLE);

        [SetUp]
        public void SetUp()
        {
            repository = new ProductRepository();
            repository.add(fireTruck);
            repository.add(toyConvertible);
        }

        [Test]
        public void testForFindColor()
        {
            List<Product> foundProducts = repository.selectBy(new ColorSpec(Color.Red));
            Assert.AreEqual(2, foundProducts.Count, "found 2 red products");
            Assert.IsTrue(foundProducts.Contains(fireTruck), "found fireTruck");
            Assert.IsTrue(foundProducts.Contains(toyConvertible), "found Toy Porsche Convertible.");
        }

        [Test]
        public void testFindByColorSizeAndBelowPrice()
        {
            List<Spec> specs = new List<Spec>();
            specs.Add(new ColorSpec(Color.Red));
            specs.Add(new SizeSpec(ProductSize.SMALL));
            specs.Add(new BelowPriceSpec(10.00f));
            List<Product> foundProducts = repository.selectBy(specs);
            Assert.AreEqual(0, foundProducts.Count, "small red products below $10.00");
        }
    }
}