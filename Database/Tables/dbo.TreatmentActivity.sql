SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TreatmentActivity](
	[TreatmentActivityID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[TreatmentActivityTypeID] [int] NOT NULL,
	[TreatmentActivityAcresTreated] [decimal](18, 0) NOT NULL,
	[TreatmentActivityStartDate] [datetime] NOT NULL,
	[TreatmentActivityEndDate] [datetime] NULL,
	[TreatmentActivityNotes] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_TreatmentActivity_TreatmentActivityID] PRIMARY KEY CLUSTERED 
(
	[TreatmentActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TreatmentActivity_TreatmentActivityID_TenantID] UNIQUE NONCLUSTERED 
(
	[TreatmentActivityID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TreatmentActivity]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentActivity_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[TreatmentActivity] CHECK CONSTRAINT [FK_TreatmentActivity_Project_ProjectID]
GO
ALTER TABLE [dbo].[TreatmentActivity]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentActivity_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[TreatmentActivity] CHECK CONSTRAINT [FK_TreatmentActivity_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[TreatmentActivity]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentActivity_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TreatmentActivity] CHECK CONSTRAINT [FK_TreatmentActivity_Tenant_TenantID]
GO
ALTER TABLE [dbo].[TreatmentActivity]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentActivity_TreatmentType_TreatmentActivityTypeID] FOREIGN KEY([TreatmentActivityTypeID])
REFERENCES [dbo].[TreatmentType] ([TreatmentTypeID])
GO
ALTER TABLE [dbo].[TreatmentActivity] CHECK CONSTRAINT [FK_TreatmentActivity_TreatmentType_TreatmentActivityTypeID]