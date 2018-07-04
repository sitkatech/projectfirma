namespace ProjectFirma.Web.Models
{
    public class ProjectCustomAttributeTypeSimple
    {
        public int ProjectCustomAttributeTypeID { get; set; }
        public string ProjectCustomAttributeTypeName { get; set; }
        public string DataTypeDisplayName { get; set; }
        public string MeasurementUnitDisplayName { get; set; }
        public bool IsRequired { get; set; }
        public string Description { get; set; }
        public int? CustomAttributeTypeSortOrder { get; set; }

        public ProjectCustomAttributeTypeSimple(ProjectCustomAttributeType projectCustomAttributeType)
        {
            ProjectCustomAttributeTypeID = projectCustomAttributeType.ProjectCustomAttributeTypeID;
            ProjectCustomAttributeTypeName = $"{projectCustomAttributeType.ProjectCustomAttributeTypeName}";
            DataTypeDisplayName = projectCustomAttributeType.ProjectCustomAttributeDataType.ProjectCustomAttributeDataTypeDisplayName;
            MeasurementUnitDisplayName = projectCustomAttributeType.GetMeasurementUnitDisplayName();
            IsRequired = projectCustomAttributeType.IsRequired;
            Description = projectCustomAttributeType.ProjectCustomAttributeTypeDescription;
        }
    }
}
