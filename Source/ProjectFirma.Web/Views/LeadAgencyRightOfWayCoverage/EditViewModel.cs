using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.LeadAgencyRightOfWayCoverage
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.Commodity)]
        [Required]
        public int? CommodityID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.BaileyRating)]
        public int? BaileyRatingID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.RightOfWayCoverageEffectiveDate)]
        [Required]
        public DateTime? RightOfWayCoverageEffectiveDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.RightOfWayCoverageAmount)]
        [Required]
        public int? RightOfWayCoverageAmount { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.RightOfWayCoverageNotes)]
        [StringLength(Models.LeadAgencyRightOfWayCoverage.FieldLengths.RightOfWayCoverageNotes)]
        public string Notes { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel(){}

        public EditViewModel(Models.LeadAgencyRightOfWayCoverage leadAgencyRightOfWayCoverage)
        {
            CommodityID = leadAgencyRightOfWayCoverage.CommodityID;
            BaileyRatingID = leadAgencyRightOfWayCoverage.BaileyRatingID;
            RightOfWayCoverageEffectiveDate = leadAgencyRightOfWayCoverage.RightOfWayCoverageEffectiveDate;
            RightOfWayCoverageAmount = leadAgencyRightOfWayCoverage.RightOfWayCoverageAmount;
            Notes = leadAgencyRightOfWayCoverage.RightOfWayCoverageNotes;
        }

        public void UpdateModel(Models.LeadAgencyRightOfWayCoverage leadAgencyRightOfWayCoverage, Models.Person currentPerson)
        {
            leadAgencyRightOfWayCoverage.CommodityID = CommodityID.Value;
            leadAgencyRightOfWayCoverage.BaileyRatingID = BaileyRatingID;
            leadAgencyRightOfWayCoverage.RightOfWayCoverageAmount = RightOfWayCoverageAmount.Value;
            leadAgencyRightOfWayCoverage.RightOfWayCoverageEffectiveDate = RightOfWayCoverageEffectiveDate.Value;
            leadAgencyRightOfWayCoverage.RightOfWayCoverageNotes = Notes;
            leadAgencyRightOfWayCoverage.LastUpdatePersonID = currentPerson.PersonID;
            leadAgencyRightOfWayCoverage.LastUpdateDate = DateTime.Now;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            var commoditySelected = Commodity.All.Single(x => x.CommodityID == CommodityID.Value);
            if (commoditySelected.IsCoverage && !BaileyRatingID.HasValue)
            {
                validationResults.Add(new SitkaValidationResult<EditViewModel, int?>("Bailey Rating only required for coverage commodites", x => x.BaileyRatingID));
            }
            return validationResults;
        }
    }
}