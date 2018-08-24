using System.Collections.Generic;
using System.Text;

namespace RefactoringToPatterns_Command.MyWork
{
    public class NetworkshopHandler : Handler
    {
        public NetworkshopHandler(CatalogApp catalogApp)
        {
            _catalogApp = catalogApp;
        }

        public override HandlerResponse execute(Dictionary<string, string> parameters)
        {
            createNetworkshop(parameters);
            return _catalogApp.executeActionAndGetResponse(CatalogApp.ALL_WORKSHOPS, parameters);
        }

        private void createNetworkshop(Dictionary<string, string> parameters)
        {
            string nextWorkshopID = workshopManager().getNextWorkshopID();
            workshopManager().addWorkshop(newWorkshopContents(nextWorkshopID));
            parameters.Add("id", nextWorkshopID);
        }

        private StringBuilder newWorkshopContents(string nextWorkshopID)
        {
            StringBuilder newWorkshopContents = _catalogApp.workshopManager.createNewFileFromTemplate(
                nextWorkshopID, _catalogApp.workshopManager.getWorkshopDir(),
                _catalogApp.workshopManager.getWorkshopTemplate());
            return newWorkshopContents;
        }

        private WorkshopManager workshopManager()
        {
            return _catalogApp.workshopManager;
        }
    }
}