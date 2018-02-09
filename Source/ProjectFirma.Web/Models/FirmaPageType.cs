/*-----------------------------------------------------------------------
<copyright file="FirmaPageType.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class FirmaPageType
    {
        public abstract string GetViewUrl();
    }

    public partial class FirmaPageTypeHomePage
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeAbout
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.About());
        }
    }

    public partial class FirmaPageTypeMeetingsandDocuments
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Meetings());
        }
    }

    public partial class FirmaPageTypeDemoScript
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.DemoScript());
        }
    }

    public partial class FirmaPageTypeInternalSetupNotes
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.InternalSetupNotes());
        }
    }

    public partial class FirmaPageTypeHomeAdditionalInfo
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeHomeMapInfo
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeFullProjectList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypePerformanceMeasuresList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeTaxonomyTierOneList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeTaxonomyTierThreeList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeFundingSourcesList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeOrganizationsList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeTaxonomyTierTwoList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeWatershedsList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<WatershedController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeMyProjects
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate());
        }
    }

    public partial class FirmaPageTypeMyOrganizationsProjects
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.MyOrganizationsProjects());
        }
    }

    public partial class FirmaPageTypeProjectResults
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ProjectResults());
        }
    }

    public partial class FirmaPageTypeSpendingByPerformanceMeasureByProject
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByPerformanceMeasureByProject(null));
        }
    }

    public partial class FirmaPageTypeProjectMap
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ProjectMap());
        }
    }

    public partial class FirmaPageTypeResultsByTaxonomyTierTwo
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ResultsByTaxonomyTierTwo(null));
        }
    }

    public partial class FirmaPageTypeTaxonomy
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(x => x.Taxonomy());
        }
    }

    public partial class FirmaPageTypeFeaturedProjectList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.FeaturedList());
        }
    }

    public partial class FirmaPageTypeManageUpdateNotifications
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Manage());
        }
    }

    public partial class FirmaPageTypeProjectUpdateStatus
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ProjectUpdateStatus());
        }
    }

    public partial class FirmaPageTypeCostParameterSet
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<CostParameterSetController>.BuildUrlFromExpression(x => x.Detail());
        }
    }

    public partial class FirmaPageTypeFullProjectListSimple
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.FullProjectListSimple());
        }
    }

    public partial class FirmaPageTypeTagList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<TagController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeProposals
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Proposed());
        }
    }

    public partial class FirmaPageTypePendingProjects
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Pending());
        }
    }

    public partial class FirmaPageTypeClassificationsList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ClassificationController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeMonitoringProgramsList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(x => x.Index());
        }
    }
    public partial class FirmaPageTypeProposeProjectInstructions
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null));
        }
    }
    public partial class FirmaPageTypeEnterHistoricProjectInstructions
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsEnterHistoric(null));
        }
    }

    public partial class FirmaPageTypeProjectStewardOrganizationList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectStewardOrganizationController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class FirmaPageTypeTraining
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Training());
        }
    }
}
