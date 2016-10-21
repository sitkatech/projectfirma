using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Areas.Threshold.Controllers;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ThresholdIndicatorImage : IFileResourcePhoto, IAuditableEntity
    {
        public ThresholdIndicatorImage(ThresholdIndicator thresholdIndicator, bool userHasPermissionToSetKeyPhoto)
            : this(ModelObjectHelpers.NotYetAssignedID, thresholdIndicator.ThresholdIndicatorID, string.Empty, string.Empty, false)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            ThresholdIndicator = thresholdIndicator;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor

            // If we are the only picture for this Project so far, it must be the key image -- so long as we have permission to set key photos.
            if (userHasPermissionToSetKeyPhoto && !thresholdIndicator.ThresholdIndicatorImages.Any())
            {
                IsKeyPhoto = true;
            }

            // If they don't have permission, it's definitely NOT the key photo, no matter what.
            if (!userHasPermissionToSetKeyPhoto)
            {
                IsKeyPhoto = false;
            }
        }

        public DateTime CreateDate
        {
            get { return FileResource.CreateDate; }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<ThresholdIndicatorImageController>.BuildUrlFromExpression(x => x.Delete(ThresholdIndicatorImageID)); }
        }

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
            get { return FileResource.FileResourceUrlScaledThumbnail; }
        }

        public string PhotoUrlScaledForPrint
        {
            get { return FileResource.FileResourceUrlScaledForPrint; }
        }

        public string EditUrl
        {
            get { return SitkaRoute<ThresholdIndicatorImageController>.BuildUrlFromExpression(x => x.Edit(ThresholdIndicatorImageID)); }
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

        public void SetAsKeyPhoto()
        {
            SetAsKeyPhoto(ThresholdIndicator.ThresholdIndicatorImages.Where(x => x.ThresholdIndicatorImageID != ThresholdIndicatorImageID).ToList());
        }

        public void SetAsKeyPhoto(List<ThresholdIndicatorImage> thresholdIndicatorImagesToSetAsNotTheKeyPhoto)
        {
            IsKeyPhoto = true;
            thresholdIndicatorImagesToSetAsNotTheKeyPhoto.ForEach(x => x.IsKeyPhoto = false);
        }

        public bool IsPersonTheCreator(Person person)
        {
            return FileResource.CreatePerson != null && person != null && person.PersonID == FileResource.CreatePersonID;
        }

        public string AuditDescriptionString
        {
            get
            {
                var thresholdIndicator = HttpRequestStorage.DatabaseEntities.ThresholdIndicators.Find(ThresholdIndicatorID);
                var thresholdIndicatorName = thresholdIndicator != null ? thresholdIndicator.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}, Image: {1}", thresholdIndicatorName, Caption);
            }
        }

        public int? EntityImageIDAsNullable
        {
            get { return ThresholdIndicatorImageID; }
        }
    }
}