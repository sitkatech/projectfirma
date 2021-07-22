SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[spatial_ref_sys](
	[srid] [int] NOT NULL,
	[auth_name] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[auth_srid] [int] NULL,
	[srtext] [varchar](2048) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[proj4text] [varchar](2048) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_spatial_ref_sys_srid] PRIMARY KEY CLUSTERED 
(
	[srid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
