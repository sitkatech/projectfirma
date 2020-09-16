using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class SitkaListbox : PartialViewModel, IValidatableObject
    {
        /// <summary>
        /// A uniqueID will prevent any collisions from other listboxes that may be on the page
        /// </summary>
        public string ListboxUniqueID { get; set; }
        public List<SelectListItem> SelectListItems { get; }
        public List<string> SelectedItems { get; set; }

        public SitkaListbox()
        {

        }

        public SitkaListbox(string listboxUniqueID, List<SelectListItem> selectListItems)
        {
            ListboxUniqueID = listboxUniqueID;
            SelectListItems = selectListItems;
            SelectedItems = selectListItems.Where(x => x.Selected).Select(x => x.Value).ToList();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}