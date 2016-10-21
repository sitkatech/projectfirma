SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramEIPPerformanceMeasure](
	[ProgramEIPPerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[IsPrimaryProgram] [bit] NOT NULL,
 CONSTRAINT [PK_ProgramEIPPerformanceMeasure_ProgramEIPPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[ProgramEIPPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProgramEIPPerformanceMeasure_ProgramID_EIPPerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[ProgramID] ASC,
	[EIPPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProgramEIPPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_ProgramEIPPerformanceMeasure_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[ProgramEIPPerformanceMeasure] CHECK CONSTRAINT [FK_ProgramEIPPerformanceMeasure_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[ProgramEIPPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_ProgramEIPPerformanceMeasure_Program_ProgramID] FOREIGN KEY([ProgramID])
REFERENCES [dbo].[Program] ([ProgramID])
GO
ALTER TABLE [dbo].[ProgramEIPPerformanceMeasure] CHECK CONSTRAINT [FK_ProgramEIPPerformanceMeasure_Program_ProgramID]
GO
ALTER TABLE [dbo].[ProgramEIPPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [CK_ProgramEIPPerformanceMeasure_EIPPerformanceMeasure33and34ShouldNotBeSelected] CHECK  ((NOT ([EIPPerformanceMeasureID]=(34) OR [EIPPerformanceMeasureID]=(33))))
GO
ALTER TABLE [dbo].[ProgramEIPPerformanceMeasure] CHECK CONSTRAINT [CK_ProgramEIPPerformanceMeasure_EIPPerformanceMeasure33and34ShouldNotBeSelected]