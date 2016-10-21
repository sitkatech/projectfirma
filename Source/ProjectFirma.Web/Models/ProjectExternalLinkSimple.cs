namespace ProjectFirma.Web.Models
{
    public class ProjectExternalLinkSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectExternalLinkSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExternalLinkSimple(int projectExternalLinkID, int projectID, string externalLinkLabel, string externalLinkUrl)
            : this()
        {
            ProjectExternalLinkID = projectExternalLinkID;
            ProjectID = projectID;
            ExternalLinkLabel = externalLinkLabel;
            ExternalLinkUrl = externalLinkUrl;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectExternalLinkSimple(ProjectExternalLink projectExternalLink)
            : this()
        {
            ProjectExternalLinkID = projectExternalLink.ProjectExternalLinkID;
            ProjectID = projectExternalLink.ProjectID;
            ExternalLinkLabel = projectExternalLink.ExternalLinkLabel;
            ExternalLinkUrl = projectExternalLink.ExternalLinkUrl;
        }

        public int ProjectExternalLinkID { get; set; }
        public int ProjectID { get; set; }
        public string ExternalLinkLabel { get; set; }
        public string ExternalLinkUrl { get; set; }
    }
}