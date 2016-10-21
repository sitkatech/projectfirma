SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdIndicatorImage](
	[ThresholdIndicatorImageID] [int] IDENTITY(1,1) NOT NULL,
	[FileResourceID] [int] NOT NULL,
	[ThresholdIndicatorID] [int] NOT NULL,
	[Caption] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Credit] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsKeyPhoto] [bit] NOT NULL,
 CONSTRAINT [PK_ThresholdIndicatorImage_ThresholdIndicatorImageID] PRIMARY KEY CLUSTERED 
(
	[ThresholdIndicatorImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdIndicatorImage_FileResourceID_ThresholdIndicatorID] UNIQUE NONCLUSTERED 
(
	[FileResourceID] ASC,
	[ThresholdIndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ThresholdIndicatorImage]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorImage] CHECK CONSTRAINT [FK_ThresholdIndicatorImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[ThresholdIndicatorImage]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorImage_ThresholdIndicator_ThresholdIndicatorID] FOREIGN KEY([ThresholdIndicatorID])
REFERENCES [dbo].[ThresholdIndicator] ([ThresholdIndicatorID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorImage] CHECK CONSTRAINT [FK_ThresholdIndicatorImage_ThresholdIndicator_ThresholdIndicatorID]