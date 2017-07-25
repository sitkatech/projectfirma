/*-----------------------------------------------------------------------
<copyright file="SearchResultsViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Project
{
    public class SearchResultsViewData : FirmaViewData
    {
        public readonly List<Models.Project> EntitySearchResults;
        public readonly string SearchCriteria;
        public Func<String, string> UrlGeneratingFunctor;

        public SearchResultsViewData(Person currentPerson, List<Models.Project> entitySearchResults, string searchCriteria) : base(currentPerson)
        {
            EntitySearchResults = entitySearchResults;
            SearchCriteria = searchCriteria;
            PageTitle = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Search";
        }
    }
}
