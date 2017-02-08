SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupportRequestLog](
	[SupportRequestLogID] [int] IDENTITY(1,1) NOT NULL,
	[RequestDate] [datetime] NOT NULL,
	[RequestPersonName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RequestPersonEmail] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RequestPersonID] [int] NULL,
	[SupportRequestTypeID] [int] NOT NULL,
	[RequestDescription] [varchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RequestPersonOrganization] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RequestPersonPhone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_SupportRequestLog_SupportRequestLogID] PRIMARY KEY CLUSTERED 
(
	[SupportRequestLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SupportRequestLog]  WITH CHECK ADD  CONSTRAINT [FK_SupportRequestLog_Person_RequestPersonID_PersonID] FOREIGN KEY([RequestPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[SupportRequestLog] CHECK CONSTRAINT [FK_SupportRequestLog_Person_RequestPersonID_PersonID]
GO
ALTER TABLE [dbo].[SupportRequestLog]  WITH CHECK ADD  CONSTRAINT [FK_SupportRequestLog_SupportRequestType_SupportRequestTypeID] FOREIGN KEY([SupportRequestTypeID])
REFERENCES [dbo].[SupportRequestType] ([SupportRequestTypeID])
GO
ALTER TABLE [dbo].[SupportRequestLog] CHECK CONSTRAINT [FK_SupportRequestLog_SupportRequestType_SupportRequestTypeID]