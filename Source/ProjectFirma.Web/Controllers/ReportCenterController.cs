/*-----------------------------------------------------------------------
<copyright file="ReportCenterController.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using SharpDocx;
using System.Web.Mvc;
using ProjectFirma.Web.Views.ReportCenter;

namespace ProjectFirma.Web.Controllers
{
    public class ReportCenterController : FirmaBaseController
    {

        [CrossAreaRoute]
        [HttpGet]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentFirmaSession);
            return RazorView<Index, IndexViewData>(viewData);
        }


        [CrossAreaRoute]
        [HttpGet]
        public ContentResult TestDocxTemplate()
        {
            /**
             * In reality we are probably going to store the templates in the FileResource table (or a document template table?). For SharpDocx we would likely retrieve that file, save it to the temp folder with a unique name, and use that path
             * as the template path.
             *
             * We would probably compile the reports to a tmp directory as well, and serve it to the user from there.
             *
             */
            var templatePath =
                "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\model-testing.docx";
            var compilePath = "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\model-testing-compiled.docx";


            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList();

            var projectModelList = new List<DocxProjectModel>();

            //projectModelList.Add(new DocxProjectModel(projects.First()));

            for (int i = 0; i < projects.Count(); i++)
            {
                projectModelList.Add(new DocxProjectModel(projects[i]));
            }


            var model = new DocxTemplateModel()
            {
                Title = "Title of report",
                Projects = projectModelList
            };


            var document = DocumentFactory.Create<ProjectFirmaDocxDocument>(templatePath, model);
            document.ImageDirectory =
                "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\images";
            document.Generate(compilePath);


            return Content(String.Empty);
        }

        [CrossAreaRoute]
        [HttpGet]
        public ContentResult MonthlyStatusReport(ProjectPrimaryKey projectPrimaryKey)
        {

            var project = projectPrimaryKey.EntityObject;

            var templatePath =
                "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\monthly-status-report.docx";
            var compilePath = $"C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\monthly-status-report-{project.ProjectID}.docx";

            var projectModel = new DocxProjectModel(project);

            var document = DocumentFactory.Create<ProjectFirmaDocxDocument>(templatePath, projectModel);

            document.Generate(compilePath);

            return Content(String.Empty);
        }

    }
}