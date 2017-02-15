SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption](
	[PerformanceMeasureExpectedSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureExpectedID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpectedSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureExpectedSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID] FOREIGN KEY([PerformanceMeasureExpectedID])
REFERENCES [dbo].[PerformanceMeasureExpected] ([PerformanceMeasureExpectedID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureExpectedID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureExpected] ([PerformanceMeasureExpectedID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID_TenantID] FOREIGN KEY([PerformanceMeasureExpectedID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureExpected] ([PerformanceMeasureExpectedID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_Tenant_TenantID]