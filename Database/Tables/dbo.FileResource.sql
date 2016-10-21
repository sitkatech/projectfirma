SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileResource](
	[FileResourceID] [int] IDENTITY(1,1) NOT NULL,
	[FileResourceMimeTypeID] [int] NOT NULL,
	[OriginalBaseFilename] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[OriginalFileExtension] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FileResourceGUID] [uniqueidentifier] NOT NULL,
	[FileResourceData] [varbinary](max) NOT NULL,
	[CreatePersonID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_FileResource_FileResourceID] PRIMARY KEY CLUSTERED 
(
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FileResource_FileResourceGUID] UNIQUE NONCLUSTERED 
(
	[FileResourceGUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[FileResource]  WITH CHECK ADD  CONSTRAINT [FK_FileResource_FileResourceMimeType_FileResourceMimeTypeID] FOREIGN KEY([FileResourceMimeTypeID])
REFERENCES [dbo].[FileResourceMimeType] ([FileResourceMimeTypeID])
GO
ALTER TABLE [dbo].[FileResource] CHECK CONSTRAINT [FK_FileResource_FileResourceMimeType_FileResourceMimeTypeID]
GO
ALTER TABLE [dbo].[FileResource]  WITH CHECK ADD  CONSTRAINT [FK_FileResource_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[FileResource] CHECK CONSTRAINT [FK_FileResource_Person_CreatePersonID_PersonID]