SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SustainabilityIndicator](
	[SustainabilityIndicatorID] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorID] [int] NOT NULL,
	[SustainabilityAspectID] [int] NOT NULL,
	[UseCustomDateRange] [bit] NOT NULL,
 CONSTRAINT [PK_SustainabilityIndicator_SustainabilityIndicatorID] PRIMARY KEY CLUSTERED 
(
	[SustainabilityIndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SustainabilityIndicator_IndicatorID] UNIQUE NONCLUSTERED 
(
	[IndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SustainabilityIndicator]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicator_Indicator_IndicatorID] FOREIGN KEY([IndicatorID])
REFERENCES [dbo].[Indicator] ([IndicatorID])
GO
ALTER TABLE [dbo].[SustainabilityIndicator] CHECK CONSTRAINT [FK_SustainabilityIndicator_Indicator_IndicatorID]
GO
ALTER TABLE [dbo].[SustainabilityIndicator]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicator_SustainabilityAspect_SustainabilityAspectID] FOREIGN KEY([SustainabilityAspectID])
REFERENCES [dbo].[SustainabilityAspect] ([SustainabilityAspectID])
GO
ALTER TABLE [dbo].[SustainabilityIndicator] CHECK CONSTRAINT [FK_SustainabilityIndicator_SustainabilityAspect_SustainabilityAspectID]