SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechnicalAssistanceRequest](
	[TechnicalAssistanceRequestID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[PersonID] [int] NULL,
	[TechnicalAssistanceTypeID] [int] NOT NULL,
	[HoursRequested] [int] NULL,
	[HoursAllocated] [int] NULL,
	[HoursProvided] [int] NULL,
	[Notes] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TechnicalAssistanceRequest_TechnicalAssistanceRequestID] PRIMARY KEY CLUSTERED 
(
	[TechnicalAssistanceRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TechnicalAssistanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_TechnicalAssistanceRequest_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequest] CHECK CONSTRAINT [FK_TechnicalAssistanceRequest_Person_PersonID]
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_TechnicalAssistanceRequest_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequest] CHECK CONSTRAINT [FK_TechnicalAssistanceRequest_Project_ProjectID]
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_TechnicalAssistanceRequest_TechnicalAssistanceType_TechnicalAssistanceTypeID] FOREIGN KEY([TechnicalAssistanceTypeID])
REFERENCES [dbo].[TechnicalAssistanceType] ([TechnicalAssistanceTypeID])
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequest] CHECK CONSTRAINT [FK_TechnicalAssistanceRequest_TechnicalAssistanceType_TechnicalAssistanceTypeID]
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequest]  WITH CHECK ADD  CONSTRAINT [FK_TechnicalAssitanceRequest_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequest] CHECK CONSTRAINT [FK_TechnicalAssitanceRequest_Tenant_TenantID]