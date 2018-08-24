using System.Text;

namespace RefactoringToPatterns_Command.InitialCode
{
    public class Workshop
    {
        private string _name;
        private string _status;
        private string _duration;

        public Workshop(string name, string status, string duration)
        {
            _name = name;
            _status = status;
            _duration = duration;
        }

        public Workshop(StringBuilder content)
        {
            //<workshop name='BBB' status='EEE' duration='AAA'/>
            var contentStr = content.ToString();
            _name = contentStr.Split(' ')[1].Substring(6).TrimEnd('\'');
            _status = contentStr.Split(' ')[2].Substring(8).TrimEnd('\'');
            _duration = contentStr.Split(' ')[3].Substring(10).TrimEnd('\'', '/', '>');
        }

        public string getName()
        {
            return _name;
        }

        public string getStatus()
        {
            return _status;
        }

        public string getDurationAsString()
        {
            return _duration;
        }
    }
}