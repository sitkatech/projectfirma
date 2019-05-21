SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechnicalAssistanceRequestUpdate](
	[TechnicalAssistanceRequestUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[PersonID] [int] NULL,
	[TechnicalAssistanceTypeID] [int] NOT NULL,
	[HoursRequested] [int] NULL,
	[HoursAllocated] [int] NULL,
	[HoursProvided] [int] NULL,
	[Notes] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TechnicalAssistanceRequestUpdate_TechnicalAssistanceRequestUpdateID] PRIMARY KEY CLUSTERED 
(
	[TechnicalAssistanceRequestUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TechnicalAssistanceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_TechnicalAssistanceRequestUpdate_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequestUpdate] CHECK CONSTRAINT [FK_TechnicalAssistanceRequestUpdate_Person_PersonID]
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_TechnicalAssistanceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequestUpdate] CHECK CONSTRAINT [FK_TechnicalAssistanceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_TechnicalAssistanceRequestUpdate_TechnicalAssistanceType_TechnicalAssistanceTypeID] FOREIGN KEY([TechnicalAssistanceTypeID])
REFERENCES [dbo].[TechnicalAssistanceType] ([TechnicalAssistanceTypeID])
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequestUpdate] CHECK CONSTRAINT [FK_TechnicalAssistanceRequestUpdate_TechnicalAssistanceType_TechnicalAssistanceTypeID]
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequestUpdate]  WITH CHECK ADD  CONSTRAINT [FK_TechnicalAssitanceRequestUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TechnicalAssistanceRequestUpdate] CHECK CONSTRAINT [FK_TechnicalAssitanceRequestUpdate_Tenant_TenantID]