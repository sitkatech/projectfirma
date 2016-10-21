using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.FieldDefinition
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Definition")]
        public HtmlString FieldDefinitionDataValue { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(FieldDefinitionData fieldDefinitionData)
        {
            FieldDefinitionDataValue = fieldDefinitionData != null ? fieldDefinitionData.FieldDefinitionDataValueHtmlString : null;
        }

        public void UpdateModel(FieldDefinitionData fieldDefinitionData)
        {
            fieldDefinitionData.FieldDefinitionDataValueHtmlString = FieldDefinitionDataValue;
        }
    }
}