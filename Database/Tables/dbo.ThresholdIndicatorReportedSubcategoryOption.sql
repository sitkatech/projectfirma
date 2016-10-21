SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption](
	[ThresholdIndicatorReportedSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[ThresholdIndicatorReportedID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[ThresholdIndicatorID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_ThresholdIndicatorReportedSubcategoryOption_ThresholdIndicatorReportedSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[ThresholdIndicatorReportedSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_ThresholdIndicatorID] FOREIGN KEY([IndicatorSubcategoryID], [ThresholdIndicatorID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [ThresholdIndicatorID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_ThresholdIndicatorID]
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_ThresholdIndicator_ThresholdIndicatorID] FOREIGN KEY([ThresholdIndicatorID])
REFERENCES [dbo].[ThresholdIndicator] ([ThresholdIndicatorID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_ThresholdIndicator_ThresholdIndicatorID]
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_ThresholdIndicatorReported_ThresholdIndicatorReportedID] FOREIGN KEY([ThresholdIndicatorReportedID])
REFERENCES [dbo].[ThresholdIndicatorReported] ([ThresholdIndicatorReportedID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_ThresholdIndicatorReported_ThresholdIndicatorReportedID]
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_ThresholdIndicatorReported_ThresholdIndicatorReportedID_ThresholdIndicatorID] FOREIGN KEY([ThresholdIndicatorReportedID], [ThresholdIndicatorID])
REFERENCES [dbo].[ThresholdIndicatorReported] ([ThresholdIndicatorReportedID], [ThresholdIndicatorID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportedSubcategoryOption] CHECK CONSTRAINT [FK_ThresholdIndicatorReportedSubcategoryOption_ThresholdIndicatorReported_ThresholdIndicatorReportedID_ThresholdIndicatorID]