using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeType
{
    public class EditViewData : FirmaViewData
    {
        public string ProjectCustomAttributeTypeIndexUrl { get; }
        public string SubmitUrl { get; }
        public ViewPageContentViewData ViewInstructionsFirmaPage { get; }
        public IEnumerable<SelectListItem> ProjectCustomAttributeDataTypes { get; }
        public IEnumerable<SelectListItem> ProjectCustomAttributeGroups { get; }
        public IEnumerable<SelectListItem> MeasurementUnitTypes { get; }
        public IEnumerable<SelectListItem> YesNos { get; }
        public EditViewDataForAngular ViewDataForAngular { get; }

        public bool IncludeInNtaGrids { get; }

        public EditViewData(Person currentPerson,
            IEnumerable<MeasurementUnitType> measurementUnitTypes,
            List<ProjectCustomAttributeDataType> projectCustomAttributeDataTypes,
            List<ProjectFirmaModels.Models.Role> roles,
            string submitUrl,
            ProjectFirmaModels.Models.FirmaPage instructionsFirmaPage,
            ProjectFirmaModels.Models.ProjectCustomAttributeType projectCustomAttributeType,
            List<ProjectFirmaModels.Models.ProjectCustomAttributeGroup> allProjectCustomAttributeGroups)
            : base(currentPerson)
        {
            EntityName = "Attribute Type";
            PageTitle =
                $"{(projectCustomAttributeType != null ? "Edit" : "New")} Attribute Type";
            YesNos = BooleanFormats.GetYesNoSelectList();
            ProjectCustomAttributeDataTypes = projectCustomAttributeDataTypes.ToSelectListWithEmptyFirstRow(
                x => x.ProjectCustomAttributeDataTypeID.ToString(), x => x.ProjectCustomAttributeDataTypeDisplayName);
            ProjectCustomAttributeGroups = allProjectCustomAttributeGroups.ToSelectListWithEmptyFirstRow(x => x.ProjectCustomAttributeGroupID.ToString(), x => x.ProjectCustomAttributeGroupName);
            MeasurementUnitTypes = measurementUnitTypes.OrderBy(x => x.MeasurementUnitTypeDisplayName)
                .ToSelectListWithEmptyFirstRow(
                    x => x.MeasurementUnitTypeID.ToString(), x => x.MeasurementUnitTypeDisplayName,
                    ViewUtilities.NoneString);
            ProjectCustomAttributeTypeIndexUrl =
                SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(x => x.Manage());
            SubmitUrl = submitUrl;

            ViewInstructionsFirmaPage = new ViewPageContentViewData(instructionsFirmaPage, currentPerson);

            ViewDataForAngular = new EditViewDataForAngular(projectCustomAttributeDataTypes);
        }

        public class EditViewDataForAngular
        {
            public IEnumerable<ProjectCustomAttributeDataTypeSimple> ProjectCustomAttributeDataTypes { get; }

            public EditViewDataForAngular(IEnumerable<ProjectCustomAttributeDataType> projectCustomAttributeDataTypes)
            {
                ProjectCustomAttributeDataTypes = projectCustomAttributeDataTypes.Select(x => new ProjectCustomAttributeDataTypeSimple(x)).ToList();
            }
        }

        public class ProjectCustomAttributeDataTypeSimple
        {
            public int ID { get; }
            public string DisplayName { get; }
            public bool HasOptions { get; }
            public bool HasMeasurementUnit { get; }

            public ProjectCustomAttributeDataTypeSimple(ProjectCustomAttributeDataType projectCustomAttributeDataType)
            {
                ID = projectCustomAttributeDataType.ProjectCustomAttributeDataTypeID;
                DisplayName = projectCustomAttributeDataType.ProjectCustomAttributeDataTypeDisplayName;
                HasOptions = projectCustomAttributeDataType.HasOptions();
                HasMeasurementUnit = projectCustomAttributeDataType.HasMeasurementUnit();
            }
        }
    }
}
