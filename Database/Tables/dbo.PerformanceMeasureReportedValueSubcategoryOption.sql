SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption](
	[PerformanceMeasureReportedValueSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureReportedValueID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValueSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureReportedValueSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValueSubcategoryOptionID_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureReportedValueSubcategoryOptionID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValue_PerformanceMeasureReportedValueID] FOREIGN KEY([PerformanceMeasureReportedValueID])
REFERENCES [dbo].[PerformanceMeasureReportedValue] ([PerformanceMeasureReportedValueID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValue_PerformanceMeasureReportedValueID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValueID_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureReportedValueID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureReportedValue] ([PerformanceMeasureReportedValueID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValueID_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryID_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureSubcategoryID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryID_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryOptionID_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID], [PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID], [PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryOptionID_PerformanceMeasureSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_Tenant_TenantID]