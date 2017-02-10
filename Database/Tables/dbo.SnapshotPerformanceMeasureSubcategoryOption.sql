SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption](
	[SnapshotPerformanceMeasureSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[SnapshotPerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_SnapshotPerformanceMeasureSubcategoryOption_SnapshotPerformanceMeasureSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[SnapshotPerformanceMeasureSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_SnapshotPerformanceMeasure_SnapshotPerformanceMeasureID] FOREIGN KEY([SnapshotPerformanceMeasureID])
REFERENCES [dbo].[SnapshotPerformanceMeasure] ([SnapshotPerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_SnapshotPerformanceMeasure_SnapshotPerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_SnapshotPerformanceMeasure_SnapshotPerformanceMeasureID_PerformanceMeasureID] FOREIGN KEY([SnapshotPerformanceMeasureID], [PerformanceMeasureID])
REFERENCES [dbo].[SnapshotPerformanceMeasure] ([SnapshotPerformanceMeasureID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_SnapshotPerformanceMeasure_SnapshotPerformanceMeasureID_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_Tenant_TenantID]