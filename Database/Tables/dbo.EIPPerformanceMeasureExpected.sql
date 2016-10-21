SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIPPerformanceMeasureExpected](
	[EIPPerformanceMeasureExpectedID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[ExpectedValue] [float] NULL,
 CONSTRAINT [PK_EIPPerformanceMeasureExpected_EIPPerformanceMeasureExpectedID] PRIMARY KEY CLUSTERED 
(
	[EIPPerformanceMeasureExpectedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_EIPPerformanceMeasureExpected_EIPPerformanceMeasureExpectedID_EIPPerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[EIPPerformanceMeasureExpectedID] ASC,
	[EIPPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpected_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpected] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpected_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpected_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpected] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpected_Project_ProjectID]