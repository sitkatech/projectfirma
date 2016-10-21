SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccelaCAPRecord](
	[AccelaCAPRecordID] [int] IDENTITY(1,1) NOT NULL,
	[AccelaID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[KeyOne] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[KeyTwo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[KeyThree] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ShortNotes] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DetailedDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccelaCAPRecordStatusID] [int] NULL,
	[AccelaCAPTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FileDate] [datetime] NULL,
 CONSTRAINT [PK_AccelaCAPRecord_AccelaCAPRecordID] PRIMARY KEY CLUSTERED 
(
	[AccelaCAPRecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AccelaCAPRecord_AccelaID] UNIQUE NONCLUSTERED 
(
	[AccelaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AccelaCAPRecord]  WITH CHECK ADD  CONSTRAINT [FK_AccelaCAPRecord_AccelaCAPRecordStatus_AccelaCAPRecordStatusID] FOREIGN KEY([AccelaCAPRecordStatusID])
REFERENCES [dbo].[AccelaCAPRecordStatus] ([AccelaCAPRecordStatusID])
GO
ALTER TABLE [dbo].[AccelaCAPRecord] CHECK CONSTRAINT [FK_AccelaCAPRecord_AccelaCAPRecordStatus_AccelaCAPRecordStatusID]