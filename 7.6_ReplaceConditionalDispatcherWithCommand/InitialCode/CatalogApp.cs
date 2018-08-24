using System.Collections.Generic;
using System.Text;

namespace RefactoringToPatterns_Command.InitialCode
{
    public class CatalogApp
    {
        public static string NEW_WORKSHOP = "NEW_WORKSHOP";
        public static string ALL_WORKSHOPS = "ALL_WORKSHOPS";
        public static string ALL_WORKSHOPS_STYLESHEET = "ALL_WORKSHOPS_STYLESHEET";

        public HandlerResponse executeActionAndGetResponse(string actionName, Dictionary<string, string> parameters)
        {
            if (actionName.Equals(NEW_WORKSHOP))
            {
                string nextWorkshopID = workshopManager.getNextWorkshopID();
                StringBuilder newWorkshopContents = workshopManager.createNewFileFromTemplate(
                    nextWorkshopID,
                    workshopManager.getWorkshopDir(),
                    workshopManager.getWorkshopTemplate());
                workshopManager.addWorkshop(newWorkshopContents);
                parameters.Add("id", nextWorkshopID);
                return executeActionAndGetResponse(ALL_WORKSHOPS, parameters);
            }
            else if (actionName.Equals(ALL_WORKSHOPS))
            {
                XMLBuilder allWorkshopsXml = new XMLBuilder("workshop");
                WorkshopRepository repository = workshopManager.getWorkshopRepository();
                foreach (var workshop in repository)
                {
                    allWorkshopsXml.addAttribute("name", workshop.getName());
                    allWorkshopsXml.addAttribute("status", workshop.getStatus());
                    allWorkshopsXml.addAttribute("duration", workshop.getDurationAsString());
                }

                string formattedXml = getFormattedData(allWorkshopsXml.ToString());
                return new HandlerResponse(new StringBuilder(formattedXml), ALL_WORKSHOPS_STYLESHEET);
            }
            //more else if()...
            return null;
        }

        private string getFormattedData(string rowData)
        {
            return rowData.ToString();
        }

        public WorkshopManager workshopManager { get; set; }
    }
}