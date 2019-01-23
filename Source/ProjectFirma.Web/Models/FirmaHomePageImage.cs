using System;
using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class FirmaHomePageImage : IFileResourcePhoto, IAuditableEntity
    {
        public DateTime GetCreateDate() => FileResource.CreateDate;

        public string GetDeleteUrl()
        {
            return SitkaRoute<FirmaHomePageImageController>.BuildUrlFromExpression(x =>
                x.DeleteFirmaHomePageImage(FirmaHomePageImageID));
        }

        public bool IsKeyPhoto => false;

        public string GetCaptionOnFullView() => $"{GetCaptionOnGallery()}";

        public string GetCaptionOnGallery() => $"{Caption}\r\n{FileResource.FileResourceDataLengthString}";

        public string GetPhotoUrl() => FileResource.FileResourceUrl;

        public string GetPhotoUrlScaledThumbnail() => FileResource.FileResourceUrlScaledThumbnail(150);

        public string PhotoUrlScaledForPrint => FileResource.FileResourceUrlScaledForPrint;

        public string GetEditUrl()
        {
            return SitkaRoute<FirmaHomePageImageController>.BuildUrlFromExpression(x => x.Edit(FirmaHomePageImageID));
        }

        public void SetAdditionalCssClasses(List<string> value)
        {
            _additionalCssClasses = value;
        }

        public List<string> GetAdditionalCssClasses()
        {
            return _additionalCssClasses;
        }

        private object _orderBy;
        private List<string> _additionalCssClasses = new List<string>();

        public void SetOrderBy(object value) => _orderBy = value;

        public object GetOrderBy() => _orderBy ?? SortOrder;

        public bool IsPersonTheCreator(Person person)
        {
            return FileResource.CreatePerson != null && person != null && person.PersonID == FileResource.CreatePersonID;
        }

        public string GetAuditDescriptionString() => $"Image: {Caption}";

        public int? GetEntityImageIDAsNullable() => FirmaHomePageImageID;
    }
}