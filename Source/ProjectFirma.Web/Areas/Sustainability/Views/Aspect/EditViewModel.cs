using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.Sustainability.Views.Aspect
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        public int AspectID { get; set; }
        [Required]
        [StringLength(SustainabilityAspect.FieldLengths.Blurb)]
        public string AspectBlurb { get; set; }
        [Required]
        public HtmlString ActionIntroText { get; set; }
        [Required]
        public HtmlString OutcomeIntroText { get; set; }
        [Required]
        public HtmlString OutroText { get; set; }
        
        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(SustainabilityAspect aspect)
        {
            AspectID = aspect.SustainabilityAspectID;
            AspectBlurb = aspect.Blurb;
            ActionIntroText = aspect.ActionIntroTextHtmlString;
            OutcomeIntroText = aspect.OutcomeIntroTextHtmlString;
            OutroText = aspect.OutroTextHtmlString;
        }

        public void UpdateModel(SustainabilityAspect aspect, Person currentPerson)
        {
            aspect.Blurb = AspectBlurb;
            aspect.ActionIntroTextHtmlString = ActionIntroText;
            aspect.OutcomeIntroTextHtmlString = OutcomeIntroText;
            aspect.OutroTextHtmlString = OutroText;
        }
    }
}