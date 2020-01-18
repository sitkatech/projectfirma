--begin tran


CREATE TABLE [dbo].[ProjectType](
	[ProjectTypeID] [int] NOT NULL,
	[ProjectTypeName] [varchar](100) NOT NULL,
	[ProjectTypeDisplayName] [varchar](100) NOT NULL
 
 
 CONSTRAINT [PK_ProjectType_ProjectTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 
 
 CONSTRAINT [AK_ProjectType_ProjectTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 
 
 CONSTRAINT [AK_ProjectType_ProjectTypeName] UNIQUE NONCLUSTERED 
(
	[ProjectTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert dbo.ProjectType (ProjectTypeID, ProjectTypeName, ProjectTypeDisplayName) values 
(1, 'Normal', 'Normal'),
(2, 'Administrative', 'Administrative')
GO


--rollback tran