using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestFileResource
        {
            public static FileResource Create()
            {
                var fileResource = new FileResource(FileResourceMimeType.JPEG.FileResourceMimeTypeID,
                    MakeTestImagefileBaseName(),
                    ".jpg",
                    Guid.NewGuid(),
                    new byte[2000],
                    LoginConstants.PersonID,
                    DateTime.Now);
                return fileResource;
            }

            public static FileResource Create(DatabaseEntities dbContext)
            {
                var fileResource = new FileResource(FileResourceMimeType.JPEG.FileResourceMimeTypeID,
                    MakeTestImagefileBaseName(),
                    ".jpg",
                    Guid.NewGuid(),
                    new byte[2000],
                    LoginConstants.PersonID,
                    DateTime.Now);
                dbContext.AllFileResources.Add(fileResource);
                return fileResource;
            }

            private static string MakeTestImagefileBaseName()
            {
                return TestFramework.MakeTestName("SomeTestImageFile", FileResource.FieldLengths.OriginalBaseFilename);
            }
        }
    }
}