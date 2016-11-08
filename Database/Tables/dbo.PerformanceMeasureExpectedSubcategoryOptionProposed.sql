SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed](
	[PerformanceMeasureExpectedSubcategoryOptionProposedID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureExpectedProposedID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasureExpectedSubcategoryOptionProposedID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureExpectedSubcategoryOptionProposedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategory_IndicatorSubcategoryID_PerformanceMeasureID] FOREIGN KEY([IndicatorSubcategoryID], [PerformanceMeasureID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategory_IndicatorSubcategoryID_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcateg] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcateg]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasureExpectedProposed_PerformanceMeasureExpectedProposedID] FOREIGN KEY([PerformanceMeasureExpectedProposedID])
REFERENCES [dbo].[PerformanceMeasureExpectedProposed] ([PerformanceMeasureExpectedProposedID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasureExpectedProposed_PerformanceMeasureExpectedProposedID]