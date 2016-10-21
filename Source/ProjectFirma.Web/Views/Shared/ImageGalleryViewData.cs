using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class ImageGalleryViewData
    {
        public readonly Person CurrentPerson;
        public readonly string GalleryName;
        public readonly IEnumerable<IFileResourcePhoto> GalleryImages;
        public readonly string SelectKeyImageUrl;
        public readonly string AddNewPhotoUrl;
        public readonly bool UserCanAddPhotos;
        public readonly bool UserCanSelectKeyPhoto;
        public readonly int CurrentKeyPhotoID;
        public readonly bool IsGalleryMode;
        public readonly Func<IFileResourcePhoto, object> SortFunction;
        public readonly string ImageEntityName;

        public ImageGalleryViewData(Person currentPerson, string galleryName, IEnumerable<IFileResourcePhoto> galleryImages, bool canAddPhotos, string addNewPhotoUrl, string selectKeyImageUrl, bool isGalleryMode, Func<IFileResourcePhoto, object> sortFunction, string imageEntityName)
        {
            CurrentPerson = currentPerson;
            GalleryImages = galleryImages.ToList();
            UserCanAddPhotos = canAddPhotos;
            SelectKeyImageUrl = selectKeyImageUrl;
            AddNewPhotoUrl = addNewPhotoUrl;
            GalleryName = galleryName;
            UserCanSelectKeyPhoto = !string.IsNullOrWhiteSpace(selectKeyImageUrl);
            CurrentKeyPhotoID = (UserCanSelectKeyPhoto && GalleryImages.Any(x => x.IsKeyPhoto)) ? GalleryImages.Single(x => x.IsKeyPhoto).PrimaryKey : ModelObjectHelpers.NotYetAssignedID;
            IsGalleryMode = isGalleryMode;
            SortFunction = sortFunction;
            ImageEntityName = imageEntityName;
        }
    }
}