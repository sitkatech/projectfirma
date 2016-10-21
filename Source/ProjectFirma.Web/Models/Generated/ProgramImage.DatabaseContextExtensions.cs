//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProgramImage]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProgramImage GetProgramImage(this IQueryable<ProgramImage> programImages, int programImageID)
        {
            var programImage = programImages.SingleOrDefault(x => x.ProgramImageID == programImageID);
            Check.RequireNotNullThrowNotFound(programImage, "ProgramImage", programImageID);
            return programImage;
        }

        public static void DeleteProgramImage(this IQueryable<ProgramImage> programImages, List<int> programImageIDList)
        {
            if(programImageIDList.Any())
            {
                programImages.Where(x => programImageIDList.Contains(x.ProgramImageID)).Delete();
            }
        }

        public static void DeleteProgramImage(this IQueryable<ProgramImage> programImages, ICollection<ProgramImage> programImagesToDelete)
        {
            if(programImagesToDelete.Any())
            {
                var programImageIDList = programImagesToDelete.Select(x => x.ProgramImageID).ToList();
                programImages.Where(x => programImageIDList.Contains(x.ProgramImageID)).Delete();
            }
        }

        public static void DeleteProgramImage(this IQueryable<ProgramImage> programImages, int programImageID)
        {
            DeleteProgramImage(programImages, new List<int> { programImageID });
        }

        public static void DeleteProgramImage(this IQueryable<ProgramImage> programImages, ProgramImage programImageToDelete)
        {
            DeleteProgramImage(programImages, new List<ProgramImage> { programImageToDelete });
        }
    }
}