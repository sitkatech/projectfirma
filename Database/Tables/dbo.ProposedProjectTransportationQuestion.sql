SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProjectTransportationQuestion](
	[ProposedProjectTransportationQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[TransportationQuestionID] [int] NOT NULL,
	[Answer] [bit] NULL,
 CONSTRAINT [PK_ProposedProjectTransportationQuestion_ProposedProjectTransportationQuestionID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectTransportationQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProposedProjectTransportationQuestion_ProposedProjectID_TransportationQuestionID] UNIQUE NONCLUSTERED 
(
	[ProposedProjectID] ASC,
	[TransportationQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProjectTransportationQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectTransportationQuestion_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[ProposedProjectTransportationQuestion] CHECK CONSTRAINT [FK_ProposedProjectTransportationQuestion_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[ProposedProjectTransportationQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectTransportationQuestion_TransportationQuestion_TransportationQuestionID] FOREIGN KEY([TransportationQuestionID])
REFERENCES [dbo].[TransportationQuestion] ([TransportationQuestionID])
GO
ALTER TABLE [dbo].[ProposedProjectTransportationQuestion] CHECK CONSTRAINT [FK_ProposedProjectTransportationQuestion_TransportationQuestion_TransportationQuestionID]