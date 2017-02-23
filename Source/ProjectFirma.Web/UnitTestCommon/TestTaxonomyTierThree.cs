/*-----------------------------------------------------------------------
<copyright file="TestTaxonomyTierThree.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTaxonomyTierThree
        {
            public static TaxonomyTierThree Create()
            {
                var taxonomyTierThree = TaxonomyTierThree.CreateNewBlank();
                taxonomyTierThree.ThemeColor = "#FFFFFF";
                return taxonomyTierThree;
            }

            /// <summary>
            /// Create new TaxonomyTierThree and attach it to the given context
            /// </summary>
            public static TaxonomyTierThree Create(DatabaseEntities dbContext)
            {
                var taxonomyTierThree = new TaxonomyTierThree(MakeTestName("Taxonomy Tier Three", TaxonomyTierThree.FieldLengths.TaxonomyTierThreeName));
                dbContext.AllTaxonomyTierThrees.Add(taxonomyTierThree);
                return taxonomyTierThree;
            }
        }
    }
}
