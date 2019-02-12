using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class TechnicalAssistanceParametersViewModel : FormViewModel
    {
        public List<TechnicalAssistanceParameterSimple> TechnicalAssistanceParameters { get; set; }
        
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TechnicalAssistanceParametersViewModel()
        {

        }

        public TechnicalAssistanceParametersViewModel(List<TechnicalAssistanceParameterSimple> technicalAssitanceParameters)
        {
            TechnicalAssistanceParameters = technicalAssitanceParameters.OrderByDescending(x=>x.Year).ToList();
        }

        public void UpdateModel(List<TechnicalAssistanceParameter> currentTechnicalAssistanceParameters,
            ICollection<TechnicalAssistanceParameter> allTechnicalAssistanceParameters)
        {
            var technicalAssistanceParametersUpdated = new List<TechnicalAssistanceParameter>();

            if (TechnicalAssistanceParameters != null)
            {
                technicalAssistanceParametersUpdated =
                    TechnicalAssistanceParameters.Select(x => x.ToTechnicalAssistanceParameter()).ToList();
            }

            currentTechnicalAssistanceParameters.Merge(technicalAssistanceParametersUpdated,
                allTechnicalAssistanceParameters, (x, y) => x.Year == y.Year, (x, y) =>
                {
                    x.EngineeringHourlyCost = y.EngineeringHourlyCost;
                    x.OtherAssistanceHourlyCost = y.OtherAssistanceHourlyCost;
                }, HttpRequestStorage.DatabaseEntities);
        }
    }
}