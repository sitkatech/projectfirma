SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption](
	[SustainabilityIndicatorReportedSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[SustainabilityIndicatorReportedID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[SustainabilityIndicatorID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_SustainabilityIndicatorReportedSubcategoryOption_SustainabilityIndicatorReportedSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[SustainabilityIndicatorReportedSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_SustainabilityIndicatorID] FOREIGN KEY([IndicatorSubcategoryID], [SustainabilityIndicatorID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [SustainabilityIndicatorID])
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_SustainabilityIndicatorID]
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategory] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategory]
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_SustainabilityIndicator_SustainabilityIndicatorID] FOREIGN KEY([SustainabilityIndicatorID])
REFERENCES [dbo].[SustainabilityIndicator] ([SustainabilityIndicatorID])
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_SustainabilityIndicator_SustainabilityIndicatorID]
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_SustainabilityIndicatorReported_SustainabilityIndicatorReportedID] FOREIGN KEY([SustainabilityIndicatorReportedID])
REFERENCES [dbo].[SustainabilityIndicatorReported] ([SustainabilityIndicatorReportedID])
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_SustainabilityIndicatorReported_SustainabilityIndicatorReportedID]
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_SustainabilityIndicatorReported_SustainabilityIndicatorReportedID_Sustainabi] FOREIGN KEY([SustainabilityIndicatorReportedID], [SustainabilityIndicatorID])
REFERENCES [dbo].[SustainabilityIndicatorReported] ([SustainabilityIndicatorReportedID], [SustainabilityIndicatorID])
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_SustainabilityIndicatorReportedSubcategoryOption_SustainabilityIndicatorReported_SustainabilityIndicatorReportedID_Sustainabi]