using System.Text;

namespace RefactoringToPatterns_Command.MyWork
{
    public class HandlerResponse
    {
        private StringBuilder stringBuilder;
        private string aLL_WORKSHOPS_STYLESHEET;

        public HandlerResponse(StringBuilder stringBuilder, string aLL_WORKSHOPS_STYLESHEET)
        {
            this.stringBuilder = stringBuilder;
            this.aLL_WORKSHOPS_STYLESHEET = aLL_WORKSHOPS_STYLESHEET;
        }

        public StringBuilder Builder
        {
            get { return stringBuilder; }
        }

        public string ALlWorkshopsStylesheet
        {
            get { return aLL_WORKSHOPS_STYLESHEET; }
        }
    }
}