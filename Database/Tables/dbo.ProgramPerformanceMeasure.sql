SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramPerformanceMeasure](
	[ProgramPerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IsPrimaryProgram] [bit] NOT NULL,
 CONSTRAINT [PK_ProgramPerformanceMeasure_ProgramPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[ProgramPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProgramPerformanceMeasure_ProgramID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[ProgramID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProgramPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_ProgramPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[ProgramPerformanceMeasure] CHECK CONSTRAINT [FK_ProgramPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[ProgramPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_ProgramPerformanceMeasure_Program_ProgramID] FOREIGN KEY([ProgramID])
REFERENCES [dbo].[Program] ([ProgramID])
GO
ALTER TABLE [dbo].[ProgramPerformanceMeasure] CHECK CONSTRAINT [FK_ProgramPerformanceMeasure_Program_ProgramID]
GO
ALTER TABLE [dbo].[ProgramPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [CK_ProgramPerformanceMeasure_PerformanceMeasure33and34ShouldNotBeSelected] CHECK  ((NOT ([PerformanceMeasureID]=(34) OR [PerformanceMeasureID]=(33))))
GO
ALTER TABLE [dbo].[ProgramPerformanceMeasure] CHECK CONSTRAINT [CK_ProgramPerformanceMeasure_PerformanceMeasure33and34ShouldNotBeSelected]