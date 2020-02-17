--begin tran

-- New table for ReportTemplateModel

CREATE TABLE dbo.ReportTemplateModel(
	[ReportTemplateModelID] int NOT NULL CONSTRAINT PK_ReportTemplateModel_ReportTemplateModelID PRIMARY KEY,
	[ReportTemplateModelName] varchar(100) NOT NULL CONSTRAINT AK_ReportTemplateModel_ReportTemplateModelName UNIQUE,
	[ReportTemplateModelDisplayName] varchar(100) NOT NULL CONSTRAINT AK_ReportTemplateModel_ReportTemplateModelDisplayName UNIQUE,
	[ReportTemplateModelDescription] varchar(250) not null
)

-- Create the new column on the ReportTemplate table to refer to the model 

ALTER TABLE dbo.ReportTemplate
ADD ReportTemplateModelID int not null;

-- Create the FK reference to the model 
ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_ReportTemplateModel_ReportTemplateModelID] FOREIGN KEY([ReportTemplateModelID])
REFERENCES [dbo].[ReportTemplateModel] ([ReportTemplateModelID])
GO

--rollback tran