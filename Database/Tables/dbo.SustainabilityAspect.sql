SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SustainabilityAspect](
	[SustainabilityAspectID] [int] NOT NULL,
	[SustainabilityPillarID] [int] NOT NULL,
	[SustainabilityAspectName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[KeyImageFileName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Blurb] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[OutroText] [dbo].[html] NULL,
	[ActionIntroText] [dbo].[html] NULL,
	[OutcomeIntroText] [dbo].[html] NULL,
 CONSTRAINT [PK_SustainabilityAspect_SustainabilityAspectID] PRIMARY KEY CLUSTERED 
(
	[SustainabilityAspectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SustainabilityAspect_DisplayOrder] UNIQUE NONCLUSTERED 
(
	[DisplayOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SustainabilityAspect_SustainabilityAspectName] UNIQUE NONCLUSTERED 
(
	[SustainabilityAspectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SustainabilityAspect]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityAspect_SustainabilityPillar_SustainabilityPillarID] FOREIGN KEY([SustainabilityPillarID])
REFERENCES [dbo].[SustainabilityPillar] ([SustainabilityPillarID])
GO
ALTER TABLE [dbo].[SustainabilityAspect] CHECK CONSTRAINT [FK_SustainabilityAspect_SustainabilityPillar_SustainabilityPillarID]