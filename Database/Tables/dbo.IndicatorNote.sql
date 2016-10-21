SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndicatorNote](
	[IndicatorNoteID] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorID] [int] NOT NULL,
	[Note] [varchar](8000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreatePersonID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatePersonID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_IndicatorNote_IndicatorNoteID] PRIMARY KEY CLUSTERED 
(
	[IndicatorNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_IndicatorNote_IndicatorNoteID_IndicatorID] UNIQUE NONCLUSTERED 
(
	[IndicatorNoteID] ASC,
	[IndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[IndicatorNote]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorNote_Indicator_IndicatorID] FOREIGN KEY([IndicatorID])
REFERENCES [dbo].[Indicator] ([IndicatorID])
GO
ALTER TABLE [dbo].[IndicatorNote] CHECK CONSTRAINT [FK_IndicatorNote_Indicator_IndicatorID]
GO
ALTER TABLE [dbo].[IndicatorNote]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[IndicatorNote] CHECK CONSTRAINT [FK_IndicatorNote_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[IndicatorNote]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[IndicatorNote] CHECK CONSTRAINT [FK_IndicatorNote_Person_UpdatePersonID_PersonID]