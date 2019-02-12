using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class TechnicalAssistanceParameterSimple
    {
        public int Year { get; set; }

        public Money? EngineeringHourlyCost { get; set; }

        public Money? OtherAssistanceHourlyCost { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TechnicalAssistanceParameterSimple()
        {

        }

        public TechnicalAssistanceParameterSimple(TechnicalAssistanceParameter technicalAssistanceParameter)
        {
            Year = technicalAssistanceParameter.Year;
            EngineeringHourlyCost = technicalAssistanceParameter.EngineeringHourlyCost;
            OtherAssistanceHourlyCost = technicalAssistanceParameter.OtherAssistanceHourlyCost;
        }

        public TechnicalAssistanceParameterSimple(int year)
        {
            Year = year;
        }

        public TechnicalAssistanceParameter ToTechnicalAssistanceParameter()
        {
            return new TechnicalAssistanceParameter(Year)
            {
                EngineeringHourlyCost = EngineeringHourlyCost,
                OtherAssistanceHourlyCost = OtherAssistanceHourlyCost
            }; 
        }
    }
}