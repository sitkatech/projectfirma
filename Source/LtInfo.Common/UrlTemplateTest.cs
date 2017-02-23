/*-----------------------------------------------------------------------
<copyright file="UrlTemplateTest.cs" company="Sitka Technology Group">
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
using System.Linq;
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class UrlTemplateTest
    {
        [Test, Description("The number of parameters for each type is the same")]
        public void HasConsistentNumberOfParameters()
        {
            Assert.That(UrlTemplate.IntParameters.Length, Is.EqualTo(UrlTemplate.StringParameters.Length), "Should be the same number of parameters across each type");
        }

        [Test]
        public void CanReplaceParameter1()
        {
            var urlTemplate = string.Format("/SampleController/SampleAction/{0}", UrlTemplate.Parameter1Int);
            var template = new UrlTemplate<int>(urlTemplate);

            const int realParameter1 = 123;
            var result = template.ParameterReplace(realParameter1);

            Assert.That(result, Is.EqualTo(urlTemplate.Replace(UrlTemplate.Parameter1Int.ToString(), realParameter1.ToString())), "Should be able to replace with 1 parameter");
        }

        [Test]
        public void CanReplaceParameter2()
        {
            var urlTemplate = string.Format("/SampleController/SampleAction/{0}/{1}", UrlTemplate.Parameter1Int, UrlTemplate.Parameter2String);
            var template = new UrlTemplate<int,string>(urlTemplate);

            const int realParameter1 = 123;
            const string realParameter2 = "hi";
            var result = template.ParameterReplace(realParameter1, realParameter2);

            var expected = urlTemplate.Replace(UrlTemplate.Parameter1Int.ToString(), realParameter1.ToString()).Replace(UrlTemplate.Parameter2String, realParameter2);
            Assert.That(result, Is.EqualTo(expected), "Should be able to replace with 2 parameters");
        }

        [Test]
        public void CanReplaceParameter3()
        {
            var urlTemplate = string.Format("/SampleController/SampleAction/{0}/{1}/{2}", UrlTemplate.Parameter1Int, UrlTemplate.Parameter2String, UrlTemplate.Parameter3Int);
            var template = new UrlTemplate<int,string, int>(urlTemplate);

            const int realParameter1 = 123;
            const string realParameter2 = "hi";
            const int realParameter3 = 1234;

            var result = template.ParameterReplace(realParameter1, realParameter2, realParameter3);

            var expected = urlTemplate.Replace(UrlTemplate.Parameter1Int.ToString(), realParameter1.ToString()).Replace(UrlTemplate.Parameter2String, realParameter2).Replace(UrlTemplate.Parameter3Int.ToString(), realParameter3.ToString());
            Assert.That(result, Is.EqualTo(expected), "Should be able to replace with 3 parameters");
        }

        [Test]
        public void CanDetectBadUrlTemplate()
        {
            Assert.That(() => new UrlTemplate<string>(string.Format("/SampleController/SampleAction/{0}", UrlTemplate.Parameter1Int)), Throws.Exception, "Types and parameter order must align");
            Assert.That(() => new UrlTemplate<int>(string.Format("/SampleController/SampleAction/{0}", UrlTemplate.Parameter1String)), Throws.Exception, "Types and parameter order must align");

            Assert.That(() => new UrlTemplate<int>(string.Format("/SampleController/SampleAction/{0}", UrlTemplate.Parameter2Int)), Throws.Exception, "Must do them in order");
            Assert.That(() => new UrlTemplate<int, string>(string.Format("/SampleController/SampleAction/{0}/{1}", UrlTemplate.Parameter1Int, UrlTemplate.Parameter1String)), Throws.Exception, "Should error if there's two of the same ordinals");
        }

        [Test]
        public void JavascriptAndCSharpConstantsAreTheSame()
        {
            var sitkaJsFile = FileUtility.FirstMatchingFileUpDirectoryTree(@"Libraries\SitkaContent\JS\sitka.js");
            var sitkaJsFileContents = FileUtility.FileToString(sitkaJsFile);

            var allParameters = UrlTemplate.StringParameters.Union(UrlTemplate.IntParameters.Select(x => x.ToString())).ToList();
            var missingParameters = allParameters.Where(x => !sitkaJsFileContents.Contains(x)).ToList();

            Assert.That(missingParameters, Is.Empty, string.Format("Could not find some of the parameters from class {0} in file \"{1}\", the .js file should be in sync with the C#", typeof(UrlTemplate).Name, sitkaJsFile.FullName));
        }

    }
}
