using System.Collections.Generic;
using System.Web;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Shared
{
    public class FirmaIncludesViewData : FirmaUserControlViewData
    {
        public bool IsIntendedForWkthmlToPDF { get; set; }

        public FirmaIncludesViewData()
        {
            // Nearly all pages will not need to interact with this. It is being used specifically for WkhtmlToPDF functionality on fact sheets. 
            // It is ultimately for now being used to EXCLUDE google chart .js files in the FirmaIncludes.cshtml file - 6/2/2020 SMG [#2167]
            IsIntendedForWkthmlToPDF = false;
        }
    }
}