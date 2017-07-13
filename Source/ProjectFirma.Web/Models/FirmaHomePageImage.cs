using System;
using System.Collections.Generic;
using LtInfo.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class FirmaHomePageImage : IFileResourcePhoto, IAuditableEntity
    {
        public DateTime CreateDate => FileResource.CreateDate;

        public string DeleteUrl
        {
            get { return SitkaRoute<FirmaHomePageImageController>.BuildUrlFromExpression(x => x.DeleteFirmaHomePageImage(FirmaHomePageImageID)); }
        }

        public bool IsKeyPhoto => false;

        public string CaptionOnFullView => $"{CaptionOnGallery}";

        public string CaptionOnGallery => $"{Caption}\r\n{FileResource.FileResourceDataLengthString}";

        public string PhotoUrl => FileResource.FileResourceUrl;

        public string PhotoUrlScaledThumbnail => FileResource.FileResourceUrlScaledThumbnail;

        public string PhotoUrlScaledForPrint => FileResource.FileResourceUrlScaledForPrint;

        public string EditUrl
        {
            get { return SitkaRoute<FirmaHomePageImageController>.BuildUrlFromExpression(x => x.Edit(FirmaHomePageImageID)); }
        }

        public List<string> AdditionalCssClasses { get; set; } = new List<string>();

        private object _orderBy;
        public object OrderBy
        {
            get => _orderBy ?? SortOrder;
            set => _orderBy = value;
        }

        public bool IsPersonTheCreator(Person person)
        {
            return FileResource.CreatePerson != null && person != null && person.PersonID == FileResource.CreatePersonID;
        }

        public string AuditDescriptionString => $"Image: {Caption}";

        public int? EntityImageIDAsNullable => FirmaHomePageImageID;
    }
}