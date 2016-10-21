SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectExemptReportingYear](
	[ProjectExemptReportingYearID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
 CONSTRAINT [PK_ProjectExemptReportingYear_ProjectExemptReportingYearID] PRIMARY KEY CLUSTERED 
(
	[ProjectExemptReportingYearID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectExemptReportingYear_ProjectID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectExemptReportingYear]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExemptReportingYear_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectExemptReportingYear] CHECK CONSTRAINT [FK_ProjectExemptReportingYear_Project_ProjectID]