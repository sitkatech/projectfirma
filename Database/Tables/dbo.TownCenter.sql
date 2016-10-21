SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TownCenter](
	[TownCenterID] [int] IDENTITY(1,1) NOT NULL,
	[TownCenterName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TownCenterTypeID] [int] NOT NULL,
	[GeometryXml] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TownCenter_TownCenterID] PRIMARY KEY CLUSTERED 
(
	[TownCenterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TownCenter_TownCenterName_TownCenterTypeID] UNIQUE NONCLUSTERED 
(
	[TownCenterName] ASC,
	[TownCenterTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TownCenter]  WITH CHECK ADD  CONSTRAINT [FK_TownCenter_TownCenterType_TownCenterTypeID] FOREIGN KEY([TownCenterTypeID])
REFERENCES [dbo].[TownCenterType] ([TownCenterTypeID])
GO
ALTER TABLE [dbo].[TownCenter] CHECK CONSTRAINT [FK_TownCenter_TownCenterType_TownCenterTypeID]