using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class FileResourcePhoto
    {
        public int PrimaryKey { get; }
        public int? EntityImageIDAsNullable { get; }

        public FileResourceInfo FileResourceInfo { get; }
        public string DeleteUrl { get; }
        public bool IsKeyPhoto { get; }
        public string CaptionOnFullView { get; }

        public string CaptionOnGallery { get; }
        public string Caption { get; }
        public string PhotoUrl { get; }

        public string PhotoUrlScaledThumbnail { get; }

        public string EditUrl { get; }

        public List<string> AdditionalCssClasses { get; set; }

        public FileResourcePhoto(FirmaHomePageImage firmaHomePage)
        {
            PrimaryKey = firmaHomePage.FirmaHomePageImageID;
            FileResourceInfo = firmaHomePage.FileResourceInfo;
            DeleteUrl = firmaHomePage.GetDeleteUrl();
            IsKeyPhoto = false;
            Caption = firmaHomePage.Caption;
            CaptionOnFullView = firmaHomePage.GetCaptionOnFullView();
            CaptionOnGallery = firmaHomePage.GetCaptionOnGallery();
            PhotoUrl = firmaHomePage.GetPhotoUrl();
            PhotoUrlScaledThumbnail = firmaHomePage.GetPhotoUrlScaledThumbnail();
            EditUrl = firmaHomePage.GetEditUrl();
            AdditionalCssClasses = new List<string>();
        }

        public FileResourcePhoto(ProjectImage projectImage)
        {
            EntityImageIDAsNullable = projectImage.ProjectImageID;
            PrimaryKey = projectImage.ProjectImageID;
            FileResourceInfo = projectImage.FileResourceInfo;
            DeleteUrl = projectImage.GetDeleteUrl();
            IsKeyPhoto = projectImage.IsKeyPhoto;
            Caption = projectImage.Caption;
            CaptionOnFullView = projectImage.GetCaptionOnFullView();
            CaptionOnGallery = projectImage.GetCaptionOnGallery();
            PhotoUrl = projectImage.GetPhotoUrl();
            PhotoUrlScaledThumbnail = projectImage.GetPhotoUrlScaledThumbnail();
            EditUrl = projectImage.GetEditUrl();
            AdditionalCssClasses = new List<string>();
        }
        public FileResourcePhoto(ProjectImageUpdate projectImageUpdate)
        {
            EntityImageIDAsNullable = projectImageUpdate.ProjectImageID;
            PrimaryKey = projectImageUpdate.ProjectImageUpdateID;
            FileResourceInfo = projectImageUpdate.FileResourceInfo;
            DeleteUrl = projectImageUpdate.GetDeleteUrl();
            IsKeyPhoto = projectImageUpdate.IsKeyPhoto;
            Caption = projectImageUpdate.Caption;
            CaptionOnFullView = projectImageUpdate.GetCaptionOnFullView();
            CaptionOnGallery = projectImageUpdate.GetCaptionOnGallery();
            PhotoUrl = projectImageUpdate.GetPhotoUrl();
            PhotoUrlScaledThumbnail = projectImageUpdate.GetPhotoUrlScaledThumbnail();
            EditUrl = projectImageUpdate.GetEditUrl();
            AdditionalCssClasses = new List<string>();
        }

        public FileResourcePhoto(FileResourcePhoto fileResourcePhoto, List<string> additionalCssClasses)
        {
            EntityImageIDAsNullable = fileResourcePhoto.EntityImageIDAsNullable;
            PrimaryKey = fileResourcePhoto.PrimaryKey;
            FileResourceInfo = fileResourcePhoto.FileResourceInfo;
            DeleteUrl = fileResourcePhoto.DeleteUrl;
            IsKeyPhoto = fileResourcePhoto.IsKeyPhoto;
            Caption = fileResourcePhoto.Caption;
            CaptionOnFullView = fileResourcePhoto.CaptionOnFullView;
            CaptionOnGallery = fileResourcePhoto.CaptionOnGallery;
            PhotoUrl = fileResourcePhoto.PhotoUrl;
            PhotoUrlScaledThumbnail = fileResourcePhoto.PhotoUrlScaledThumbnail;
            EditUrl = fileResourcePhoto.EditUrl;
            AdditionalCssClasses = additionalCssClasses;
        }
    }
}