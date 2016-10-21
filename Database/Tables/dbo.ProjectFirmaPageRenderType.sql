SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFirmaPageRenderType](
	[ProjectFirmaPageRenderTypeID] [int] NOT NULL,
	[ProjectFirmaPageRenderTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectFirmaPageRenderTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ProjectFirmaPageRenderType_ProjectFirmaPageRenderTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectFirmaPageRenderTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFirmaPageRenderType_ProjectFirmaPageRenderTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectFirmaPageRenderTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFirmaPageRenderType_ProjectFirmaPageRenderTypeName] UNIQUE NONCLUSTERED 
(
	[ProjectFirmaPageRenderTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
