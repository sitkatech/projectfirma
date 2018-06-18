SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomAttributeTypePurpose](
	[ProjectCustomAttributeTypePurposeID] [int] NOT NULL,
	[ProjectCustomAttributeTypePurposeName] [varchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectCustomAttributeTypePurposeDisplayName] [varchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ProjectCustomAttributeTypePurpose_ProjectCustomAttributeTypePurposeID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomAttributeTypePurposeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttributeTypePurpose_ProjectCustomAttributeTypePurposeDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectCustomAttributeTypePurposeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttributeTypePurpose_ProjectCustomAttributeTypePurposeName] UNIQUE NONCLUSTERED 
(
	[ProjectCustomAttributeTypePurposeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
