namespace ProjectFirmaModels.Models
{
    public class ProjectSectionSimple
    {
        public ProjectSectionSimple(string sectionDisplayName, int sortOrder, bool hasCompletionStatus, ProjectWorkflowSectionGrouping projectWorkflowSectionGrouping, string sectionUrl, bool isComplete, bool sectionIsUpdated)
        {
            SectionDisplayName = sectionDisplayName;
            SortOrder = sortOrder;
            HasCompletionStatus = hasCompletionStatus;
            ProjectWorkflowSectionGrouping = projectWorkflowSectionGrouping;
            SectionUrl = sectionUrl;
            IsComplete = isComplete;
            SectionIsUpdated = sectionIsUpdated;
        }

        public ProjectSectionSimple(ProjectUpdateSection projectUpdateSection, string sectionUrl, bool isComplete, bool sectionIsUpdated)
        {
            SectionUrl = sectionUrl;
            IsComplete = isComplete;
            SectionIsUpdated = sectionIsUpdated;
            SectionDisplayName = projectUpdateSection.ProjectUpdateSectionDisplayName;
            SortOrder = projectUpdateSection.SortOrder;
            HasCompletionStatus = projectUpdateSection.HasCompletionStatus;
            ProjectWorkflowSectionGrouping = projectUpdateSection.ProjectWorkflowSectionGrouping;
        }

        public ProjectSectionSimple(ProjectCreateSection projectCreateSection, string sectionUrl, bool isComplete, bool sectionIsUpdated, bool hasCompletionStatus)
        {
            SectionUrl = sectionUrl;
            IsComplete = isComplete;
            SectionIsUpdated = sectionIsUpdated;
            SectionDisplayName = projectCreateSection.ProjectCreateSectionDisplayName;
            SortOrder = projectCreateSection.SortOrder;
            HasCompletionStatus = hasCompletionStatus;
            ProjectWorkflowSectionGrouping = projectCreateSection.ProjectWorkflowSectionGrouping;
        }

        public string SectionDisplayName { get; }
        public int SortOrder { get; }
        public bool HasCompletionStatus { get; }
        public ProjectWorkflowSectionGrouping ProjectWorkflowSectionGrouping { get; }
        public string SectionUrl { get; }
        public bool IsComplete { get; }
        public bool SectionIsUpdated { get; }
    }
}