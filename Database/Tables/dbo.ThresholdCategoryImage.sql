SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdCategoryImage](
	[ThresholdCategoryImageID] [int] IDENTITY(1,1) NOT NULL,
	[ThresholdCategoryID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_ThresholdCategoryImage_ThresholdCategoryImageID] PRIMARY KEY CLUSTERED 
(
	[ThresholdCategoryImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdCategoryImage_ThresholdCategoryImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[ThresholdCategoryImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ThresholdCategoryImage]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdCategoryImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ThresholdCategoryImage] CHECK CONSTRAINT [FK_ThresholdCategoryImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[ThresholdCategoryImage]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdCategoryImage_ThresholdCategory_ThresholdCategoryID] FOREIGN KEY([ThresholdCategoryID])
REFERENCES [dbo].[ThresholdCategory] ([ThresholdCategoryID])
GO
ALTER TABLE [dbo].[ThresholdCategoryImage] CHECK CONSTRAINT [FK_ThresholdCategoryImage_ThresholdCategory_ThresholdCategoryID]