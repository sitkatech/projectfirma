SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed](
	[EIPPerformanceMeasureExpectedSubcategoryOptionProposedID] [int] IDENTITY(1,1) NOT NULL,
	[EIPPerformanceMeasureExpectedProposedID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_EIPPerformanceMeasureExpectedSubcategoryOptionProposedID] PRIMARY KEY CLUSTERED 
(
	[EIPPerformanceMeasureExpectedSubcategoryOptionProposedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_EIPPerformanceMeasureExpectedProposed_EIPPerformanceMeasureExpectedPro] FOREIGN KEY([EIPPerformanceMeasureExpectedProposedID])
REFERENCES [dbo].[EIPPerformanceMeasureExpectedProposed] ([EIPPerformanceMeasureExpectedProposedID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_EIPPerformanceMeasureExpectedProposed_EIPPerformanceMeasureExpectedPro]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID] FOREIGN KEY([IndicatorSubcategoryID], [EIPPerformanceMeasureID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubca] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOptionProposed_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubca]