/*-----------------------------------------------------------------------
<copyright file="BasicsViewModelValidatorTest.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.UnitTestCommon;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    [TestFixture]
    public class BasicsViewModelValidatorTest
    {
        private BasicsViewModelValidator _validator;
        private Models.ProjectUpdate _projectUpdate;

        [SetUp]
        public void Setup()
        {
            _projectUpdate = TestFramework.TestProjectUpdate.Create();
            _projectUpdate.ProjectDescription = "TestProjectUpdateDescription777";
            _projectUpdate.ProjectUpdateID = -999999;
            _validator = new BasicsViewModelValidator();
        }

        [Test]
        public void ShouldHaveErrorWhenProjectDescriptionIsNullOrWhiteSpaceOrInvalidLength()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProjectDescription, string.Empty);
            //            _validator.ShouldHaveValidationErrorFor(x => x.ProjectDescription, TestFramework.MakeTestNameLongerThan("Random Text", Models.ProjectUpdate.FieldLengths.ProjectDescription));
        }

        [Test]
        public void ShouldNotHaveErrorWhenProjectDescriptionIsSpecified()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProjectDescription, TestFramework.MakeTestName("Random Text", Models.ProjectUpdate.FieldLengths.ProjectDescription));
        }
    }
}
