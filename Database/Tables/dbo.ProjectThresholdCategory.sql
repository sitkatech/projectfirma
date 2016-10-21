SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectThresholdCategory](
	[ProjectThresholdCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[ThresholdCategoryID] [int] NOT NULL,
	[ProjectThresholdCategoryNotes] [varchar](600) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ProjectThresholdCategory_ProjectThresholdCategoryID] PRIMARY KEY CLUSTERED 
(
	[ProjectThresholdCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectThresholdCategory_ProjectID_ThresholdCategoryID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[ThresholdCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectThresholdCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProjectThresholdCategory_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectThresholdCategory] CHECK CONSTRAINT [FK_ProjectThresholdCategory_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectThresholdCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProjectThresholdCategory_ThresholdCategory_ThresholdCategoryID] FOREIGN KEY([ThresholdCategoryID])
REFERENCES [dbo].[ThresholdCategory] ([ThresholdCategoryID])
GO
ALTER TABLE [dbo].[ProjectThresholdCategory] CHECK CONSTRAINT [FK_ProjectThresholdCategory_ThresholdCategory_ThresholdCategoryID]