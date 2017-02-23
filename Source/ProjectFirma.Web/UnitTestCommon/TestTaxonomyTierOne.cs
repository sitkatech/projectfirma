/*-----------------------------------------------------------------------
<copyright file="TestTaxonomyTierOne.cs" company="Sitka Technology Group">
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
        public static class TestTaxonomyTierOne
        {
            public static TaxonomyTierOne Create()
            {
                var taxonomyTierTwo = TestTaxonomyTierTwo.Create();
                var taxonomyTierOne = TaxonomyTierOne.CreateNewBlank(taxonomyTierTwo);
                return taxonomyTierOne;
            }

            /// <summary>
            /// Create new TaxonomyTierOne and attach it to the given context
            /// </summary>
            public static TaxonomyTierOne Create(DatabaseEntities dbContext)
            {
                var taxonomyTierTwo = TestTaxonomyTierTwo.Create(dbContext);
                var taxonomyTierOne = new TaxonomyTierOne(taxonomyTierTwo, MakeTestName("Test Taxonomy Tier One", TaxonomyTierOne.FieldLengths.TaxonomyTierOneName));
                var newTaxonomyTierOne = taxonomyTierOne;
                dbContext.AllTaxonomyTierOnes.Add(newTaxonomyTierOne);
                return newTaxonomyTierOne;
            }
        }
    }
}
