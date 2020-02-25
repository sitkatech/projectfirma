/*-----------------------------------------------------------------------
<copyright file="EditBasicsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Tenant
{
    public class EditBasicsViewData : FirmaViewData
    {
        public IEnumerable<SelectListItem> TenantPeople { get; }
        public IEnumerable<SelectListItem> TaxonomyLevels { get; }
        public EditBasicsViewDataForAngular ViewDataForAngular { get; }
        public bool CanEditEnableProjectCategoriesCheckbox { get; }

        public EditBasicsViewData(FirmaSession currentFirmaSession, IEnumerable<SelectListItem> tenantPeople, IEnumerable<SelectListItem> taxonomyLevels, 
            int budgetTypeID, Dictionary<int, string> budgetTypes, IEnumerable<int> disabledBudgetTypeValues, List<string> costTypes, bool canEditEnableProjectCategoriesCheckbox)
            : base(currentFirmaSession)
        {
            TenantPeople = tenantPeople;
            TaxonomyLevels = taxonomyLevels;
            ViewDataForAngular = new EditBasicsViewDataForAngular(budgetTypeID, budgetTypes, disabledBudgetTypeValues, costTypes);
            CanEditEnableProjectCategoriesCheckbox = canEditEnableProjectCategoriesCheckbox;
        }

        public class EditBasicsViewDataForAngular
        {
            public int BudgetTypeID { get; }
            public int BudgetTypeIDRequiringCostType { get; }
            public Dictionary<int, string> BudgetTypes { get; }
            public IEnumerable<int> DisabledBudgetTypeValues { get; }
            public List<string> CostTypes { get; }

            public EditBasicsViewDataForAngular(int budgetTypeID, Dictionary<int, string> budgetTypes, IEnumerable<int> disabledBudgetTypeValues, List<string> costTypes)
            {
                BudgetTypeID = budgetTypeID;
                BudgetTypeIDRequiringCostType = BudgetType.AnnualBudgetByCostType.BudgetTypeID;
                BudgetTypes = budgetTypes;
                DisabledBudgetTypeValues = disabledBudgetTypeValues;
                CostTypes = costTypes;
            }
        }
    }
}
