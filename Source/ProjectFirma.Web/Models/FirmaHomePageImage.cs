using System;
using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirmaModels.Models
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

        public string GetCaptionOnGallery() => $"{Caption}\r\n{FileResource.GetFileResourceDataLengthString()}";

        public string GetPhotoUrl() => FileResource.GetFileResourceUrl();

        public string GetPhotoUrlScaledThumbnail() => FileResource.FileResourceUrlScaledThumbnail(150);

        public string PhotoUrlScaledForPrint => FileResource.GetFileResourceUrlScaledForPrint();

        public string GetEditUrl()
        {
            return SitkaRoute<FirmaHomePageImageController>.BuildUrlFromExpression(x => x.Edit(FirmaHomePageImageID));
        }

        public List<string> GetAdditionalCssClasses()
        {
            return _additionalCssClasses;
        }

        private object _orderBy;
        private readonly List<string> _additionalCssClasses = new List<string>();

        public void SetOrderBy(object value) => _orderBy = value;

        public object GetOrderBy() => _orderBy ?? SortOrder;

        public string GetAuditDescriptionString() => $"Image: {Caption}";

        public int? GetEntityImageIDAsNullable() => FirmaHomePageImageID;
    }
}