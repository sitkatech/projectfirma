SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndicatorRelationship](
	[IndicatorRelationshipID] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorID] [int] NOT NULL,
	[RelatedIndicatorID] [int] NOT NULL,
	[IndicatorRelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_IndicatorRelationship_IndicatorRelationshipID] PRIMARY KEY CLUSTERED 
(
	[IndicatorRelationshipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[IndicatorRelationship]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorRelationship_Indicator_IndicatorID] FOREIGN KEY([IndicatorID])
REFERENCES [dbo].[Indicator] ([IndicatorID])
GO
ALTER TABLE [dbo].[IndicatorRelationship] CHECK CONSTRAINT [FK_IndicatorRelationship_Indicator_IndicatorID]
GO
ALTER TABLE [dbo].[IndicatorRelationship]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorRelationship_Indicator_RelatedIndicatorID_IndicatorID] FOREIGN KEY([RelatedIndicatorID])
REFERENCES [dbo].[Indicator] ([IndicatorID])
GO
ALTER TABLE [dbo].[IndicatorRelationship] CHECK CONSTRAINT [FK_IndicatorRelationship_Indicator_RelatedIndicatorID_IndicatorID]
GO
ALTER TABLE [dbo].[IndicatorRelationship]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorRelationship_IndicatorRelationshipType_IndicatorRelationshipTypeID] FOREIGN KEY([IndicatorRelationshipTypeID])
REFERENCES [dbo].[IndicatorRelationshipType] ([IndicatorRelationshipTypeID])
GO
ALTER TABLE [dbo].[IndicatorRelationship] CHECK CONSTRAINT [FK_IndicatorRelationship_IndicatorRelationshipType_IndicatorRelationshipTypeID]