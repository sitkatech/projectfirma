using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class PhotoViewData : ProposedProjectViewData
    {
        public readonly ImageGalleryViewData ImageGalleryViewData;

        public PhotoViewData(Person currentPerson, string galleryName, IEnumerable<IFileResourcePhoto> galleryImages, string addNewPhotoUrl, Func<IFileResourcePhoto, object> sortFunction, Models.ProposedProject proposedProject, ProposalSectionsStatus proposalSectionsStatus)
            : base(currentPerson, proposedProject, ProposedProjectSectionEnum.Photos, proposalSectionsStatus)
        {
            var selectKeyImageUrl = string.Empty;
            ImageGalleryViewData = new ImageGalleryViewData(currentPerson, galleryName, galleryImages, true, addNewPhotoUrl, selectKeyImageUrl, true, sortFunction, "Photo");                        
        }        
    }
}