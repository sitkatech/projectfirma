SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingVideo](
	[TrainingVideoID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[VideoName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VideoDescription] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VideoUploadDate] [datetime] NOT NULL,
	[VideoURL] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_TrainingVideo_TrainingVideoID] PRIMARY KEY CLUSTERED 
(
	[TrainingVideoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TrainingVideo_TrainingVideoID_TenantID] UNIQUE NONCLUSTERED 
(
	[TrainingVideoID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TrainingVideo]  WITH CHECK ADD  CONSTRAINT [FK_TrainingVideo_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TrainingVideo] CHECK CONSTRAINT [FK_TrainingVideo_Tenant_TenantID]