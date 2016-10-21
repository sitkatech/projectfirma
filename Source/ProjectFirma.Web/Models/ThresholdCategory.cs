using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class ThresholdCategory : IAuditableEntity
    {
        public List<Project> AssociatedProjects
        {
            get { return ProjectThresholdCategories.Select(ptc => ptc.Project).Distinct(new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.DisplayName).ToList(); }
        }

        public string KeyImageUrlSmall
        {
            get { return string.Format("/Areas/Threshold/content/img/ThresholdCategory_{0}_sm.jpg", ThresholdCategoryName); }
        }

        public string KeyImageUrlLarge
        {
            get { return string.Format("/Areas/Threshold/content/img/ThresholdCategory_{0}_lg.jpg", ThresholdCategoryName); }
        }

        public string AuditDescriptionString
        {
            get { return ThresholdCategoryName; }
        }

        /* TODO-MB: This whole section should be data driven
         *          Currently this just exists to support the GB mockup */

        public int NumberOfStandards
        {
            get
            {
                switch (DisplayName)
                {
                    case "Air Quality":
                        return 20;
                    case "Fisheries":
                        return 7;
                    case "Noise":
                        return 26;
                    case "Recreation":
                        return 2;
                    case "Scenic Resources":
                        return 860;
                    case "Soil Conservation":
                        return 10;
                    case "Vegetation Preservation":
                        return 26;
                    case "Water Quality":
                        return 44;
                    case "Wildlife":
                        return 11;
                    default:
                        throw new ArgumentException(DisplayName + " is an unknown Threshold Category [AttainmentYes]");
                }
            }
        }

        public double AttainmentYes
        {
            get
            {
                switch (DisplayName)
                {
                    case "Air Quality":
                        return 13 / (double)NumberOfStandards;
                    case "Fisheries":
                        return 4 / (double)NumberOfStandards;
                    case "Noise":
                        return 5 / (double)NumberOfStandards;
                    case "Recreation":
                        return 2 / (double)NumberOfStandards;
                    case "Scenic Resources":
                        return 802 / (double)NumberOfStandards;
                    case "Soil Conservation":
                        return 8 / (double)NumberOfStandards;
                    case "Vegetation Preservation":
                        return 14 / (double)NumberOfStandards;
                    case "Water Quality":
                        return 1 / (double)NumberOfStandards;
                    case "Wildlife":
                        return 5 / (double)NumberOfStandards;
                    default:
                        throw new ArgumentException(DisplayName + " is an unknown Threshold Category [AttainmentYes]");
                }
            }
        }

        public double AttainmentNo
                {
            get
            {
                switch (DisplayName)
                {
                    case "Air Quality":
                        return 2 / (double)NumberOfStandards;
                    case "Fisheries":
                        return 0 / (double)NumberOfStandards;
                    case "Noise":
                        return 13 / (double)NumberOfStandards;
                    case "Recreation":
                        return 0 / (double)NumberOfStandards;
                    case "Scenic Resources":
                        return 58 / (double)NumberOfStandards;
                    case "Soil Conservation":
                        return 2 / (double)NumberOfStandards;
                    case "Vegetation Preservation":
                        return 10 / (double)NumberOfStandards;
                    case "Water Quality":
                        return 5 / (double)NumberOfStandards;
                    case "Wildlife":
                        return 3 / (double)NumberOfStandards;
                    default:
                        throw new ArgumentException(DisplayName + " is an unknown Threshold Category [AttainmentYes]");
                }
            }
        }

        public double AttainmentUnknown
        {
            get
            {
                switch (DisplayName)
                {
                    case "Air Quality":
                        return 5 / (double)NumberOfStandards;
                    case "Fisheries":
                        return 3 / (double)NumberOfStandards;
                    case "Noise":
                        return 8 / (double)NumberOfStandards;
                    case "Recreation":
                        return 0 / (double)NumberOfStandards;
                    case "Scenic Resources":
                        return 0 / (double)NumberOfStandards;
                    case "Soil Conservation":
                        return 0 / (double)NumberOfStandards;
                    case "Vegetation Preservation":
                        return 2 / (double)NumberOfStandards;
                    case "Water Quality":
                        return 38 / (double)NumberOfStandards;
                    case "Wildlife":
                        return 3 / (double)NumberOfStandards;
                    default:
                        throw new ArgumentException(DisplayName + " is an unknown Threshold Category [AttainmentYes]");
                }
            }
        }

        public List<Indicator> GetRelatedIndicatorsByIndicatorType(IndicatorType indicatorType)
        {
            return ThresholdReportingCategories.SelectMany(x => x.GetRelatedIndicatorsByIndicatorType(indicatorType)).Distinct(new HavePrimaryKeyComparer<Indicator>()).ToList();
        }
    }
}