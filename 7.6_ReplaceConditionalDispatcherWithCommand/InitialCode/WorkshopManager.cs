using System.Text;

namespace RefactoringToPatterns_Command.InitialCode
{
    public class WorkshopManager
    {
        public string FakeString;

        public WorkshopManager()
        {
            Repository = new WorkshopRepository();
        }

        public string getNextWorkshopID()
        {
            return "FOO";
        }

        public StringBuilder createNewFileFromTemplate(string id, string directory, string template)
        {
            return new StringBuilder(FakeString);
        }

        public string getWorkshopDir()
        {
            return string.Empty;
        }

        public string getWorkshopTemplate()
        {
            return string.Empty;
        }

        public void addWorkshop(StringBuilder content)
        {
            Repository.AddWrokshop(new Workshop(content));
        }

        public WorkshopRepository getWorkshopRepository()
        {
            return Repository;
        }

        public WorkshopRepository Repository { get; set; }
    }
}