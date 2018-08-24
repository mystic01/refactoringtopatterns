using System.Collections.Generic;

namespace RefactoringToPatterns_Command.MyWork
{
    public class CatalogApp
    {
        public static string NEW_WORKSHOP = "NEW_WORKSHOP";
        public static string ALL_WORKSHOPS = "ALL_WORKSHOPS";
        public static string ALL_WORKSHOPS_STYLESHEET = "ALL_WORKSHOPS_STYLESHEET";
        private Dictionary<string, Handler> handlers;

        public CatalogApp()
        {
            handlers = new Dictionary<string, Handler>();
            handlers[NEW_WORKSHOP] = new NetworkshopHandler(this);
            handlers[ALL_WORKSHOPS] = new AllWorkshopHandler(this);
        }

        public HandlerResponse executeActionAndGetResponse(string actionName, Dictionary<string, string> parameters)
        {
            Handler handler = lookupHandlerBy(actionName);
            return handler.execute(parameters);
        }

        private Handler lookupHandlerBy(string handlerName)
        {
            return handlers[handlerName];
        }

        public WorkshopManager workshopManager { get; set; }
    }
}