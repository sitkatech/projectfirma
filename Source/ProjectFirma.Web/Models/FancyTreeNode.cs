using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Models
{
    public class FancyTreeNode
    {
        [JsonProperty(PropertyName = "title", Order = 1)]
        public string Title;
        [JsonProperty(PropertyName = "key", Order = 1)]
        public string Key;
        [JsonProperty(PropertyName = "expanded", Order = 1)]
        public bool Expanded;
        [JsonProperty(PropertyName = "children", Order = 1)]
        public List<FancyTreeNode> Children;

        // custom attributes
        public int? NumberOfProjects { get { return GetProjectCount(); } }

        // custom attributes
        public string Answer;

        private int? GetProjectCount()
        {
            return Children == null ? 1 : Children.Sum(x => x.GetProjectCount());
        }

        public string ThemeColor;
        public string MapUrl;
        public Dictionary<int, string> StatusTrendConfidenceIcons;

        public FancyTreeNode(string title, string key, bool expanded)
        {
            Title = title;
            Key = key;
            Expanded = expanded;
        }

        public FancyTreeNode(HtmlString title, string key, bool expanded)
        {
            Title = title.ToString();
            Key = key;
            Expanded = expanded;
        }
    }   
}