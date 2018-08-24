using System.Collections.Generic;
using NUnit.Framework;
using RefactoringToPatterns_Command.MyWork;

namespace RefactoringToPatterns.Tests.ReplaceConditionalDispatcherWithCommand.MyWork
{
    [TestFixture]
    public class CatalogAppTests
    {
        [Test]
        public void executeActionAndGetResponseTest_ALL_WORKSHOPS()
        {
            List<Workshop> workshops = new List<Workshop> { new Workshop("HELLO", "OPEN", "2018/08") };
            var repository = new WorkshopRepository() { _workshops = workshops };
            var target = new CatalogApp();
            target.workshopManager = new WorkshopManager() { Repository = repository };
            var expectedString = "<workshop name='HELLO' status='OPEN' duration='2018/08'/>";

            var actual = target.executeActionAndGetResponse(CatalogApp.ALL_WORKSHOPS, null);

            Assert.AreEqual(actual.Builder.ToString(), expectedString);
            Assert.AreEqual(actual.ALlWorkshopsStylesheet, CatalogApp.ALL_WORKSHOPS_STYLESHEET);
        }

        [Test]
        public void executeActionAndGetResponseTest_NEW_WORKSHOP()
        {
            List<Workshop> workshops = new List<Workshop> { new Workshop("HELLO", "OPEN", "2018/08") };
            var repository = new WorkshopRepository() { _workshops = workshops };
            var target = new CatalogApp();
            target.workshopManager = new WorkshopManager() { Repository = repository };
            var expectedString = "<workshop name='HELLO' status='OPEN' duration='2018/08'/>";
            target.workshopManager.FakeString = expectedString;

            var actual = target.executeActionAndGetResponse(CatalogApp.NEW_WORKSHOP, new Dictionary<string, string>());

            Assert.AreEqual(actual.Builder.ToString(), expectedString);
            Assert.AreEqual(actual.ALlWorkshopsStylesheet, CatalogApp.ALL_WORKSHOPS_STYLESHEET);
        }
    }
}