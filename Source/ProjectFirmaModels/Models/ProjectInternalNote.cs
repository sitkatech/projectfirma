using System;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectInternalNote : IEntityNote, IAuditableEntity
    {
        public DateTime GetLastUpdated()
        {
            return UpdateDate ?? CreateDate;
        }

        public string GetLastUpdatedBy()
        {
            if (UpdatePersonID.HasValue)
            {
                return UpdatePerson.GetFullNameFirstLast();
            }

            if (CreatePersonID.HasValue)
            {
                return CreatePerson.GetFullNameFirstLast();
            }

            return "System";
        }

        public string GetDeleteUrl()
        {
            return ProjectInternalNoteModelExtensions.GetDeleteUrl(this);
        }

        public string GetEditUrl()
        {
            return ProjectInternalNoteModelExtensions.GetEditUrl(this);
        }

        public string GetAuditDescriptionString()
        {
            return $"Project: {ProjectID} Note updated";
        }
    }
}