using System.Collections.Generic;
using System.Text;

namespace RefactoringToPatterns_Command.MyWork
{
    public class PrettyPrinter
    {
        public PrettyPrinter()
        {
        }

        public string format(string rowData)
        {
            return rowData.ToString();
        }
    }

    public class AllWorkshopHandler : Handler
    {
        private CatalogApp _catalogApp;
        private readonly PrettyPrinter _prettyPrinter;

        public AllWorkshopHandler(CatalogApp catalogApp)
        {
            _catalogApp = catalogApp;
            _prettyPrinter = new PrettyPrinter();
        }

        public override HandlerResponse execute(Dictionary<string, string> parameters)
        {
            return new HandlerResponse(new StringBuilder(PrettyPrint(allWorkshopsData())), CatalogApp.ALL_WORKSHOPS_STYLESHEET);
        }

        private string PrettyPrint(string buffer)
        {
            return _prettyPrinter.format(buffer);
        }

        private string allWorkshopsData()
        {
            XMLBuilder allWorkshopsXml = new XMLBuilder("workshop");
            WorkshopRepository repository = _catalogApp.workshopManager.getWorkshopRepository();
            foreach (var workshop in repository)
            {
                allWorkshopsXml.addAttribute("name", workshop.getName());
                allWorkshopsXml.addAttribute("status", workshop.getStatus());
                allWorkshopsXml.addAttribute("duration", workshop.getDurationAsString());
            }

            var rowData = allWorkshopsXml.ToString();
            return rowData;
        }
    }
}