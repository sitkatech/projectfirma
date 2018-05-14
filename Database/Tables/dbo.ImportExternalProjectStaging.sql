SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportExternalProjectStaging](
	[ImportExternalProjectStagingID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[CreatePersonID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ProjectName] [varchar](140) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PlanningDesignStartYear] [smallint] NULL,
	[ImplementationStartYear] [smallint] NULL,
	[EndYear] [smallint] NULL,
	[EstimatedCost] [float] NULL,
 CONSTRAINT [PK_ImportExternalProjectStaging_ImportExternalProjectStagingID] PRIMARY KEY CLUSTERED 
(
	[ImportExternalProjectStagingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ImportExternalProjectStaging]  WITH CHECK ADD  CONSTRAINT [FK_ImportExternalProjectStaging_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ImportExternalProjectStaging] CHECK CONSTRAINT [FK_ImportExternalProjectStaging_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[ImportExternalProjectStaging]  WITH CHECK ADD  CONSTRAINT [FK_ImportExternalProjectStaging_Person_PersonID_TenantID] FOREIGN KEY([CreatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[ImportExternalProjectStaging] CHECK CONSTRAINT [FK_ImportExternalProjectStaging_Person_PersonID_TenantID]
GO
ALTER TABLE [dbo].[ImportExternalProjectStaging]  WITH CHECK ADD  CONSTRAINT [FK_ImportExternalProjectStaging_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ImportExternalProjectStaging] CHECK CONSTRAINT [FK_ImportExternalProjectStaging_Tenant_TenantID]