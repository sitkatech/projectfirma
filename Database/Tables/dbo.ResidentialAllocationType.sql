SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResidentialAllocationType](
	[ResidentialAllocationTypeID] [int] NOT NULL,
	[ResidentialAllocationTypeName] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ResidentialAllocationTypeCode] [varchar](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ResidentialAllocationType_ResidentialAllocationTypeID] PRIMARY KEY CLUSTERED 
(
	[ResidentialAllocationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ResidentialAllocationType_ResidentialAllocationTypeCode] UNIQUE NONCLUSTERED 
(
	[ResidentialAllocationTypeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ResidentialAllocationType_ResidentialAllocationTypeName] UNIQUE NONCLUSTERED 
(
	[ResidentialAllocationTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
