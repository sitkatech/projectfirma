delete from dbo.ReportTemplateModelType

insert dbo.ReportTemplateModelType (ReportTemplateModelTypeID, ReportTemplateModelTypeName, ReportTemplateModelTypeDisplayName, ReportTemplateModelTypeDescription) values 
(1, 'SingleProject', 'Single Project', 'Reports with the "Single Project" model type will be able to be run on individual projects.'),
(2, 'MultipleProjects', 'Multiple Projects', 'Reports with the "Multiple Projects" model type will have access to all projects.')