using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class FileResourceDto
    {
        public FileResourceDto(FileResource fileResource)
        {
            FileResourceData = fileResource.FileResourceData;
            FileResourceGUID = fileResource.FileResourceGUID;
            OriginalBaseFilename = fileResource.OriginalBaseFilename;
            OriginalFileExtension = fileResource.OriginalFileExtension;
            Email = fileResource.CreatePerson.Email;
            CreateDate = fileResource.CreateDate;
            FileResourceMimeTypeName = fileResource.FileResourceMimeType.FileResourceMimeTypeDisplayName;
        }

        public FileResourceDto()
        {
        }

        public string FileResourceMimeTypeName { get; set; }
        public string OriginalBaseFilename { get; set; }
        public string OriginalFileExtension { get; set; }
        public Guid FileResourceGUID { get; set; }
        public byte[] FileResourceData { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
    }
}