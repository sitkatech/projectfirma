--begin tran

-- New table for ReportTemplateModelType

CREATE TABLE dbo.ReportTemplateModelType(
	[ReportTemplateModelTypeID] int NOT NULL CONSTRAINT PK_ReportTemplateModelType_ReportTemplateModelTypeID PRIMARY KEY,
	[ReportTemplateModelTypeName] varchar(100) NOT NULL CONSTRAINT AK_ReportTemplateModelType_ReportTemplateModelTypeName UNIQUE,
	[ReportTemplateModelTypeDisplayName] varchar(100) NOT NULL CONSTRAINT AK_ReportTemplateModelType_ReportTemplateModelTypeDisplayName UNIQUE,
	[ReportTemplateModelTypeDescription] varchar(250) not null
)

-- Create the new column on the ReportTemplate table to refer to the model type

ALTER TABLE dbo.ReportTemplate
ADD ReportTemplateModelTypeID int not null;

-- Create the FK reference to the model type
ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_ReportTemplateModelType_ReportTemplateModelTypeID] FOREIGN KEY([ReportTemplateModelTypeID])
REFERENCES [dbo].[ReportTemplateModelType] ([ReportTemplateModelTypeID])
GO

--rollback tran