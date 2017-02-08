SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectClassification](
	[ProjectClassificationID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[ClassificationID] [int] NOT NULL,
	[ProjectClassificationNotes] [varchar](600) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ProjectClassification_ProjectClassificationID] PRIMARY KEY CLUSTERED 
(
	[ProjectClassificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectClassification_ProjectID_ClassificationID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[ClassificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectClassification]  WITH CHECK ADD  CONSTRAINT [FK_ProjectClassification_Classification_ClassificationID] FOREIGN KEY([ClassificationID])
REFERENCES [dbo].[Classification] ([ClassificationID])
GO
ALTER TABLE [dbo].[ProjectClassification] CHECK CONSTRAINT [FK_ProjectClassification_Classification_ClassificationID]
GO
ALTER TABLE [dbo].[ProjectClassification]  WITH CHECK ADD  CONSTRAINT [FK_ProjectClassification_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectClassification] CHECK CONSTRAINT [FK_ProjectClassification_Project_ProjectID]