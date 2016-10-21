SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIPPerformanceMeasureExpectedProposed](
	[EIPPerformanceMeasureExpectedProposedID] [int] IDENTITY(1,1) NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[ExpectedValue] [float] NULL,
 CONSTRAINT [PK_EIPPerformanceMeasureExpectedProposed_EIPPerformanceMeasureExpectedProposedID] PRIMARY KEY CLUSTERED 
(
	[EIPPerformanceMeasureExpectedProposedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_EIPPerformanceMeasureExpectedProposed_EIPPerformanceMeasureExpectedProposedID_EIPPerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[EIPPerformanceMeasureExpectedProposedID] ASC,
	[EIPPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedProposed]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedProposed_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedProposed] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedProposed_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedProposed]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedProposed_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedProposed] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedProposed_ProposedProject_ProposedProjectID]