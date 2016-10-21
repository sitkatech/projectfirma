SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIPPerformanceMeasureActual](
	[EIPPerformanceMeasureActualID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ActualValue] [float] NOT NULL,
 CONSTRAINT [PK_EIPPerformanceMeasureActual_EIPPerformanceMeasureActualID] PRIMARY KEY CLUSTERED 
(
	[EIPPerformanceMeasureActualID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_EIPPerformanceMeasureActual_EIPPerformanceMeasureActualID_EIPPerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[EIPPerformanceMeasureActualID] ASC,
	[EIPPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActual_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActual] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActual_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActual_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActual] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActual_Project_ProjectID]