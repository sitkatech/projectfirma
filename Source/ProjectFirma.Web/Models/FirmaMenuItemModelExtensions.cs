using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FirmaMenuItemModelExtensions
    {
        public static string GetFirmaMenuItemDisplayName(this FirmaMenuItem firmaMenuItem)
        {
            if (firmaMenuItem.FirmaMenuItemID == FirmaMenuItem.Projects.FirmaMenuItemID)
            {
                return FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized();
            }

            return firmaMenuItem.FirmaMenuItemDisplayName;
        }
    }
}