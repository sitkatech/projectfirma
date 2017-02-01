SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureNote](
	[PerformanceMeasureNoteID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[Note] [varchar](8000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreatePersonID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatePersonID] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureNote_PerformanceMeasureNoteID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureNote_PerformanceMeasureNoteID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureNoteID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureNote]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureNote_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureNote] CHECK CONSTRAINT [FK_PerformanceMeasureNote_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureNote]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PerformanceMeasureNote] CHECK CONSTRAINT [FK_PerformanceMeasureNote_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[PerformanceMeasureNote]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PerformanceMeasureNote] CHECK CONSTRAINT [FK_PerformanceMeasureNote_Person_UpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[PerformanceMeasureNote]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureNote_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureNote] CHECK CONSTRAINT [FK_PerformanceMeasureNote_Tenant_TenantID]