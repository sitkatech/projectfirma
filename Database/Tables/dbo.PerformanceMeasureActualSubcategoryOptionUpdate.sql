SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate](
	[PerformanceMeasureActualSubcategoryOptionUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureActualUpdateID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualSubcategoryOptionUpdateID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureActualSubcategoryOptionUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID] FOREIGN KEY([PerformanceMeasureActualUpdateID])
REFERENCES [dbo].[PerformanceMeasureActualUpdate] ([PerformanceMeasureActualUpdateID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID_PerformanceMe] FOREIGN KEY([PerformanceMeasureActualUpdateID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureActualUpdate] ([PerformanceMeasureActualUpdateID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID_PerformanceMe]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_Tenant_TenantID]