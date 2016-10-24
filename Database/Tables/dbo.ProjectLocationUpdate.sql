SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationUpdate](
	[ProjectLocationUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[ProjectLocationUpdateGeometry] [geometry] NOT NULL,
	[Annotation] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ProjectLocationUpdate_ProjectLocationUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectLocationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectLocationUpdate] CHECK CONSTRAINT [FK_ProjectLocationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]