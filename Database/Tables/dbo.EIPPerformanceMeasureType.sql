SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIPPerformanceMeasureType](
	[EIPPerformanceMeasureTypeID] [int] NOT NULL,
	[EIPPerformanceMeasureTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EIPPerformanceMeasureTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_EIPPerformanceMeasureType_EIPPerformanceMeasureTypeID] PRIMARY KEY CLUSTERED 
(
	[EIPPerformanceMeasureTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_EIPPerformanceMeasureType_EIPPerformanceMeasureTypeName] UNIQUE NONCLUSTERED 
(
	[EIPPerformanceMeasureTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
