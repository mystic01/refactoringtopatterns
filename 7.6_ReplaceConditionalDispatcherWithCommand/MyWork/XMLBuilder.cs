using System.Collections.Generic;

namespace RefactoringToPatterns_Command.MyWork
{
    internal class XMLBuilder
    {
        private readonly string _name;
        private Dictionary<string, string> _attributes = new Dictionary<string, string>();

        public XMLBuilder(string name)
        {
            _name = name;
        }

        public void addAttribute(string attribute, string value)
        {
            _attributes[attribute] = value;
        }

        public override string ToString()
        {
            var result = $"<{_name}";
            foreach (var attribute in _attributes)
                result += $" {attribute.Key}='{attribute.Value}'";
            result += "/>";
            return result;
        }
    }
}