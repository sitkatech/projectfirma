using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Models
{
    public class FileResourceDto
    {
        public FileResourceDto(FileResourceInfo fileResourceInfo)
        {
            FileResourceData = fileResourceInfo.FileResourceData.Data;
            FileResourceGUID = fileResourceInfo.FileResourceGUID;
            OriginalBaseFilename = fileResourceInfo.OriginalBaseFilename;
            OriginalFileExtension = fileResourceInfo.OriginalFileExtension;
            Email = fileResourceInfo.CreatePerson.Email;
            CreateDate = fileResourceInfo.CreateDate;
            FileResourceMimeTypeName = fileResourceInfo.FileResourceMimeType.FileResourceMimeTypeDisplayName;
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