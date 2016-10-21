namespace ProjectFirma.Web.Models
{
    public class BootstrapTag
    {
        public string id;
        public string text;
        public string url;
        public int num;

        public BootstrapTag(string id, string text, string url, int num)
        {
            this.id = id;
            this.text = text;
            this.url = url;
            this.num = num;
        }

        public BootstrapTag(Tag tag) : this(tag.TagName, tag.TagName, tag.SummaryUrl, tag.ProjectTags.Count)
        {
        }
    }
}