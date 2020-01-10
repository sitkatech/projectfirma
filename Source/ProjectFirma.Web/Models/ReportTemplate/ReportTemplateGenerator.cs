using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models.ReportTemplate.Models;
using ProjectFirmaModels.Models;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Dynamic;
using System.Reflection;
using System.Reflection.Emit;
using SharpDocx;

namespace ProjectFirma.Web.Models.ReportTemplate
{
    public class ReportTemplateGenerator
    {
        public static readonly EnglishPluralizationService PluralizationService = new EnglishPluralizationService();
        protected ProjectFirmaModels.Models.ReportTemplate ReportTemplate { get; set; }
        protected ReportTemplateModelEnum ReportTemplateModelEnum { get; set; }
        protected ReportTemplateModelTypeEnum ReportTemplateModelTypeEnum { get; set; }
        protected List<int> SelectedModelIDs { get; set; }
        

        public ReportTemplateGenerator(ProjectFirmaModels.Models.ReportTemplate reportTemplate, List<int> selectedModelIDs)
        {
            ReportTemplate = reportTemplate;
            ReportTemplateModelEnum = reportTemplate.ReportTemplateModel.ToEnum;
            ReportTemplateModelTypeEnum = reportTemplate.ReportTemplateModelType.ToEnum;
            SelectedModelIDs = selectedModelIDs;
        }

        public void Generate()
        {



            var models = GetListOfModels();
            var templateViewModel = new ReportTemplateBaseViewModel()
            {
                ReportTitle = ReportTemplate.DisplayName,
                ReportModel = models
            };

            // TODO: Need to abstract out these template and compile paths
            var templatePath =
                "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\Testing-generate.docx";
            var compilePath = "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\Testing-general-compiled.docx";

            var document = DocumentFactory.Create<ProjectFirmaDocxDocument>(templatePath, templateViewModel);
            // TODO: Figure out solution/need for images in the reports
            document.ImageDirectory =
                "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\images";
            document.Generate(compilePath);



        }


        private List<ReportTemplateBaseModel> GetListOfModels()
        {
            var listOfModels = new List<ReportTemplateBaseModel>();

            switch (ReportTemplateModelEnum)
            {
                case ReportTemplateModelEnum.Project:
                    var projectsList = HttpRequestStorage.DatabaseEntities.Projects.Where(x => SelectedModelIDs.Contains(x.ProjectID)).ToList();
                    var orderedProjectList = projectsList.OrderBy(p => SelectedModelIDs.IndexOf(p.ProjectID)).ToList();
                    orderedProjectList.ForEach(x => listOfModels.Add(new ReportTemplateProjectModel(x)));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return listOfModels;
        }


    }
}