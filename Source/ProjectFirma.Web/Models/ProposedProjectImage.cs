using System;
using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProjectImage : IFileResourcePhoto, IAuditableEntity
    {
        public ProposedProjectImage(ProposedProject proposedProject)
            : this(ModelObjectHelpers.NotYetAssignedID, proposedProject.ProposedProjectID, ProjectImageTiming.Unknown.ProjectImageTimingID, string.Empty, string.Empty)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            ProposedProject = proposedProject;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor           
        }

        public DateTime CreateDate
        {
            get { return FileResource.CreateDate; }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<ProposedProjectImageController>.BuildUrlFromExpression(x => x.Delete(ProposedProjectImageID)); }
        }
        public bool IsKeyPhoto { get { return false; } }

        public string CaptionOnFullView
        {
            get
            {
                var creditString = string.IsNullOrWhiteSpace(Credit) ? string.Empty : string.Format("\r\nCredit: {0}", Credit);
                return string.Format("{0}{1}", CaptionOnGallery, creditString);
            }
        }

        public string CaptionOnGallery
        {
            get { return string.Format("{0}\r\n{1}", Caption, FileResource.FileResourceDataLengthString); }
        }

        public string PhotoUrl
        {
            get { return FileResource.FileResourceUrl; }
        }

        public string PhotoUrlScaledThumbnail
        {
            get
            {
                return FileResource.FileResourceUrlScaledThumbnail;
            }
        }

        public string PhotoUrlScaledForPrint
        {
            get
            {
                return FileResource.FileResourceUrlScaledForPrint;
            }
        }

        public string EditUrl
        {
            get { return SitkaRoute<ProposedProjectImageController>.BuildUrlFromExpression(x => x.Edit(ProposedProjectImageID)); }
        }

        private List<string> _additionalCssClasses = new List<string>();
        public List<string> AdditionalCssClasses
        {
            get { return _additionalCssClasses; }
            set { _additionalCssClasses = value; }
        }

        private object _orderBy;
        public object OrderBy
        {
            get { return _orderBy ?? CaptionOnFullView; }
            set { _orderBy = value; }
        }       

        public bool IsPersonTheCreator(Person person)
        {
            return FileResource.CreatePerson != null && person != null && person.PersonID == FileResource.CreatePersonID;
        }

        public string AuditDescriptionString
        {
            get
            {
                var proposedProject = HttpRequestStorage.DatabaseEntities.AllProposedProjects.Find(ProposedProjectID);
                var proposedProjectName = proposedProject != null ? proposedProject.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}, Image: {1}", proposedProjectName, Caption);
            }
        }

        public int? EntityImageIDAsNullable
        {
            get { return ProposedProjectImageID; }
        }
    }
}