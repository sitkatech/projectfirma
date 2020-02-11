--begin tran

-- New table for ReportTemplate

CREATE TABLE [dbo].[ReportTemplate](
	[ReportTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
    [DisplayName] [varchar] (50) NOT NULL,
	[Description] [varchar](250) NULL,
 CONSTRAINT [PK_ReportTemplate_ReportTemplateID] PRIMARY KEY CLUSTERED 
(
	[ReportTemplateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ReportTemplate_ReportTemplateID_TenantID] UNIQUE NONCLUSTERED 
(
	[ReportTemplateID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO

ALTER TABLE [dbo].[ReportTemplate] CHECK CONSTRAINT [FK_ReportTemplate_FileResource_FileResourceID]
GO

ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_FileResource_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO

ALTER TABLE [dbo].[ReportTemplate] CHECK CONSTRAINT [FK_ReportTemplate_FileResource_FileResourceID_TenantID]
GO


ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[ReportTemplate] CHECK CONSTRAINT [FK_ReportTemplate_Tenant_TenantID]
GO

USE [ProjectFirma]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [AK_Person_Email_TenantID]    Script Date: 1/7/2020 12:41:44 PM ******/
ALTER TABLE [dbo].[ReportTemplate] ADD  CONSTRAINT [AK_ReportTemplate_DisplayName_TenantID] UNIQUE NONCLUSTERED 
(
	[DisplayName] ASC,
	[TenantID] ASC
)
GO




/**
ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_FileResource_FileResourceID_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO

ALTER TABLE [dbo].[ReportTemplate] CHECK CONSTRAINT [FK_ReportTemplate_FileResource_FileResourceID_FileResourceID]
GO

ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_FileResource_FileResourceID_TenantID_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO

ALTER TABLE [dbo].[ReportTemplate] CHECK CONSTRAINT [FK_ReportTemplate_FileResource_FileResourceID_TenantID_FileResourceID_TenantID]
GO
**/
--rollback tran