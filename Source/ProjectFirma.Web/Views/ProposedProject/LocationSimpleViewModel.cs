using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Views.ProposedProject
{    
    public class LocationSimpleViewModel : EditProjectLocationSimpleViewModel
    {
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public LocationSimpleViewModel()
        {
        }

        public LocationSimpleViewModel(Models.ProposedProject proposedProject) : base(proposedProject.ProjectLocationPoint, proposedProject.ProjectLocationAreaID, proposedProject.ProjectLocationSimpleType.ToEnum, proposedProject.ProjectLocationNotes)
        {
        }
        
        public void UpdateModel(Models.ProposedProject proposedProject)
        {
            base.UpdateModel(proposedProject);
        }
    }    
}