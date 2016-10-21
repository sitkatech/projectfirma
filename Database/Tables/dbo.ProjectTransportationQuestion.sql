SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTransportationQuestion](
	[ProjectTransportationQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[TransportationQuestionID] [int] NOT NULL,
	[Answer] [bit] NULL,
 CONSTRAINT [PK_ProjectTransportationQuestion_ProjectTransportationQuestionID] PRIMARY KEY CLUSTERED 
(
	[ProjectTransportationQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectTransportationQuestion_ProjectID_TransportationQuestionID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[TransportationQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectTransportationQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTransportationQuestion_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectTransportationQuestion] CHECK CONSTRAINT [FK_ProjectTransportationQuestion_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectTransportationQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTransportationQuestion_TransportationQuestion_TransportationQuestionID] FOREIGN KEY([TransportationQuestionID])
REFERENCES [dbo].[TransportationQuestion] ([TransportationQuestionID])
GO
ALTER TABLE [dbo].[ProjectTransportationQuestion] CHECK CONSTRAINT [FK_ProjectTransportationQuestion_TransportationQuestion_TransportationQuestionID]