using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls
{
    public class ImportGdbFileViewData
    {
        public readonly string SupportedFileExtensionsCommaSeparated;
        public readonly List<string> SupportedFileExtensions;
        public readonly string MapFormID;
        public readonly string NewGisUploadUrl;
        public readonly string ApproveGisUploadUrl;

        public ImportGdbFileViewData(string mapFormID, string newGisUploadUrl, string approveGisUploadUrl)
        {
            MapFormID = mapFormID;
            NewGisUploadUrl = newGisUploadUrl;
            ApproveGisUploadUrl = approveGisUploadUrl;

            SupportedFileExtensions = new List<string> {"zip"};
            SupportedFileExtensionsCommaSeparated = string.Join(", ", SupportedFileExtensions.OrderBy(x => x));
        }
    }
}