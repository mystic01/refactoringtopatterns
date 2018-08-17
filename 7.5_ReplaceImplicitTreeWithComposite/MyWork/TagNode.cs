using System.Collections.Generic;

namespace ReplaceImplicitTreeWithComposite.MyWork
{
    internal class TagNode
    {
        private readonly string _name;
        private Dictionary<string, string> _attributes = new Dictionary<string, string>();
        private string _value;
        private List<TagNode> _childTags = new List<TagNode>();

        public TagNode(string name)
        {
            _name = name;
        }

        public void addAttribute(string attribute, string value)
        {
            _attributes[attribute] = value;
        }

        public void addValue(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            var result = $"<{_name}";
            foreach (var attribute in _attributes)
                result += $" {attribute.Key}='{attribute.Value}'";
            result += ">";
            foreach (var childTag in _childTags)
                result += childTag.ToString();
            result += $"{_value}</{_name}>";
            return result;
        }

        public void add(TagNode childTag)
        {
            _childTags.Add(childTag);
        }
    }
}