using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectStewardshipAreaTypeModelExtensions
    {
        public static List<HtmlString> GetProjectStewardshipAreaHtmlStringList(this ProjectStewardshipAreaType projectStewardshipAreaType, Person person)
        {
            switch (projectStewardshipAreaType.ToEnum)
            {
                case ProjectStewardshipAreaTypeEnum.ProjectStewardingOrganizations:
                    return person.PersonStewardOrganizations.OrderBy(x => x.Organization.GetDisplayName()).ToList().Select(x => x.Organization.GetDisplayNameAsUrl()).ToList();
                case ProjectStewardshipAreaTypeEnum.TaxonomyBranches:
                    return person.PersonStewardTaxonomyBranches.OrderBy(x => x.TaxonomyBranch.TaxonomyBranchSortOrder).ThenBy(x => x.TaxonomyBranch.TaxonomyBranchName).Select(x => x.TaxonomyBranch.GetDisplayNameAsUrl()).ToList();
                case ProjectStewardshipAreaTypeEnum.GeospatialAreas:
                    return person.PersonStewardGeospatialAreas.OrderBy(x => x.GeospatialArea.GeospatialAreaShortName).ToList().Select(x => x.GeospatialArea.GetDisplayNameAsUrl()).ToList();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}