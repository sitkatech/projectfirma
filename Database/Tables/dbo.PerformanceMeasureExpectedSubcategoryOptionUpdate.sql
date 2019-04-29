SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate](
	[PerformanceMeasureExpectedSubcategoryOptionUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PerformanceMeasureExpectedUpdateID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedSubcategoryOptionUpdateID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureExpectedSubcategoryOptionUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID] FOREIGN KEY([PerformanceMeasureExpectedUpdateID])
REFERENCES [dbo].[PerformanceMeasureExpectedUpdate] ([PerformanceMeasureExpectedUpdateID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID_Perform] FOREIGN KEY([PerformanceMeasureExpectedUpdateID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureExpectedUpdate] ([PerformanceMeasureExpectedUpdateID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID_Perform]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID_TenantI] FOREIGN KEY([PerformanceMeasureExpectedUpdateID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureExpectedUpdate] ([PerformanceMeasureExpectedUpdateID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID_TenantI]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_TenantID] FOREIGN KEY([PerformanceMeasureSubcategoryID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID_T] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID_T]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_Tenant_TenantID]