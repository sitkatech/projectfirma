SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProjectThresholdCategory](
	[ProposedProjectThresholdCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[ThresholdCategoryID] [int] NOT NULL,
	[ProposedProjectThresholdCategoryNotes] [varchar](600) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ProposedProjectThresholdCategory_ProposedProjectThresholdCategoryID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectThresholdCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProposedProjectThresholdCategory_ProposedProjectID_ThresholdCategoryID] UNIQUE NONCLUSTERED 
(
	[ProposedProjectID] ASC,
	[ThresholdCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProjectThresholdCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectThresholdCategory_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[ProposedProjectThresholdCategory] CHECK CONSTRAINT [FK_ProposedProjectThresholdCategory_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[ProposedProjectThresholdCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectThresholdCategory_ThresholdCategory_ThresholdCategoryID] FOREIGN KEY([ThresholdCategoryID])
REFERENCES [dbo].[ThresholdCategory] ([ThresholdCategoryID])
GO
ALTER TABLE [dbo].[ProposedProjectThresholdCategory] CHECK CONSTRAINT [FK_ProposedProjectThresholdCategory_ThresholdCategory_ThresholdCategoryID]