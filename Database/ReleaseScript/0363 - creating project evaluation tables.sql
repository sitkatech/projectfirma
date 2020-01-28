
create table dbo.EvaluationVisibility(
	EvaluationVisibilityID int not null constraint PK_EvaluationVisibility_EvaluationVisibilityID primary key,
	EvaluationVisibilityName varchar(100) not null,
	EvaluationVisibilityDisplayName varchar(100) not null
)

insert into dbo.EvaluationVisibility(EvaluationVisibilityID, EvaluationVisibilityName, EvaluationVisibilityDisplayName) values (1, 'OnlyMe','Only Me')
insert into dbo.EvaluationVisibility(EvaluationVisibilityID, EvaluationVisibilityName, EvaluationVisibilityDisplayName) values (2, 'AdminsFromMyOrganizationOnly','Admins from my Org only')
insert into dbo.EvaluationVisibility(EvaluationVisibilityID, EvaluationVisibilityName, EvaluationVisibilityDisplayName) values (3, 'AllAdmins','All Admins')


create table dbo.EvaluationStatus(
	EvaluationStatusID int not null constraint PK_EvaluationStatus_EvaluationStatusID primary key,
	EvaluationStatusName varchar(100) not null,
	EvaluationStatusDisplayName varchar(100) not null
)

insert into dbo.EvaluationStatus(EvaluationStatusID, EvaluationStatusName, EvaluationStatusDisplayName) values (1, 'Draft','Draft')
insert into dbo.EvaluationStatus(EvaluationStatusID, EvaluationStatusName, EvaluationStatusDisplayName) values (2, 'Planned','Planned')
insert into dbo.EvaluationStatus(EvaluationStatusID, EvaluationStatusName, EvaluationStatusDisplayName) values (3, 'InProgress','In Progress')
insert into dbo.EvaluationStatus(EvaluationStatusID, EvaluationStatusName, EvaluationStatusDisplayName) values (4, 'Completed','Completed')



CREATE TABLE [dbo].Evaluation(
	[EvaluationID] [int] IDENTITY(1,1) NOT NULL constraint PK_Evaluation_EvaluationID primary key,
	[TenantID] [int] NOT NULL constraint FK_Evaluation_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	EvaluationVisibilityID int not null constraint FK_Evaluation_EvaluationVisibility_EvaluationVisibilityID foreign key references dbo.EvaluationVisibility(EvaluationVisibilityID),
	EvaluationStatusID int not null constraint FK_Evaluation_EvaluationStatus_EvaluationStatusID foreign key references dbo.EvaluationStatus(EvaluationStatusID),
	CreatePersonID int not null constraint FK_Evaluation_Person_CreatePersonID_PersonID foreign key references dbo.Person(PersonID),
	EvaluationName varchar(120) NOT NULL,
	EvaluationDefinition varchar(1000) NOT NULL,
	EvaluationStartDate datetime NULL,
	EvaluationEndDate datetime NULL,
	CreateDate datetime not null,
 CONSTRAINT [AK_Evaluation_EvaluationID_TenantID] UNIQUE NONCLUSTERED 
(
	[EvaluationID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].Evaluation  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_Person_CreatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([CreatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO


CREATE TABLE [dbo].EvaluationCriterion(
	EvaluationCriterionID [int] IDENTITY(1,1) NOT NULL constraint PK_EvaluationCriterion_EvaluationCriterionID primary key,
	[TenantID] [int] NOT NULL constraint FK_EvaluationCriterion_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	EvaluationID int not null constraint FK_EvaluationCriterion_Evaluation_EvaluationID foreign key references dbo.Evaluation(EvaluationID),
	EvaluationCriterionName varchar(120) NOT NULL,
	EvaluationCriterionDefinition varchar(1000) NOT NULL,

 CONSTRAINT [AK_EvaluationCriterion_EvaluationCriterionID_TenantID] UNIQUE NONCLUSTERED 
(
	[EvaluationCriterionID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].EvaluationCriterion  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriterion_Evaluation_EvaluationID_TenantID] FOREIGN KEY([EvaluationID], [TenantID])
REFERENCES [dbo].Evaluation (EvaluationID, [TenantID])
GO




CREATE TABLE [dbo].EvaluationCriterionValue(
	EvaluationCriterionValueID [int] IDENTITY(1,1) NOT NULL constraint PK_EvaluationCriterionValue_EvaluationCriterionValueID primary key,
	[TenantID] [int] NOT NULL constraint FK_EvaluationCriterionValue_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	EvaluationCriterionID int not null constraint FK_EvaluationCriterionValue_EvaluationCriterion_EvaluationCriterionID foreign key references dbo.EvaluationCriterion(EvaluationCriterionID),
	EvaluationCriterionValueRating varchar(60) NOT NULL,
	EvaluationCriterionValueDescription varchar(500) NOT NULL,
	SortOrder int null,
 CONSTRAINT [AK_EvaluationCriterionValue_EvaluationCriterionValueID_TenantID] UNIQUE NONCLUSTERED 
(
	[EvaluationCriterionValueID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].EvaluationCriterionValue  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriterionValue_EvaluationCriterion_EvaluationCriterionID_TenantID] FOREIGN KEY([EvaluationCriterionID], [TenantID])
REFERENCES [dbo].EvaluationCriterion (EvaluationCriterionID, [TenantID])
GO



CREATE TABLE [dbo].ProjectEvaluation(
	ProjectEvaluationID [int] IDENTITY(1,1) NOT NULL constraint PK_ProjectEvaluation_ProjectEvaluationID primary key,
	[TenantID] [int] NOT NULL constraint FK_ProjectEvaluation_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectID [int] NOT NULL constraint FK_ProjectEvaluation_Project_ProjectID foreign key references dbo.Project(ProjectID),
	EvaluationID [int] NOT NULL constraint FK_ProjectEvaluation_Evaluation_EvaluationID foreign key references dbo.Evaluation(EvaluationID),
	Comments varchar(1000) null,
 CONSTRAINT [AK_ProjectEvaluation_ProjectEvaluationID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectEvaluationID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].ProjectEvaluationSelectedValue(
	ProjectEvaluationSelectedValueID [int] IDENTITY(1,1) NOT NULL constraint PK_ProjectEvaluationSelectedValue_ProjectEvaluationSelectedValueID primary key,
	[TenantID] [int] NOT NULL constraint FK_ProjectEvaluationSelectedValue_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectEvaluationID [int] NOT NULL constraint FK_ProjectEvaluationSelectedValue_ProjectEvaluation_ProjectEvaluationID foreign key references dbo.ProjectEvaluation(ProjectEvaluationID),
	EvaluationCriterionValueID [int] NOT NULL constraint FK_ProjectEvaluationSelectedValue_EvaluationCriterionValue_EvaluationCriterionValueID foreign key references dbo.EvaluationCriterionValue(EvaluationCriterionValueID),
 CONSTRAINT [AK_ProjectEvaluationSelectedValue_ProjectEvaluationSelectedValueID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectEvaluationSelectedValueID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




alter table dbo.ProjectEvaluation add constraint FK_ProjectEvaluation_Evaluation_EvaluationID_TenantID foreign key (EvaluationID, TenantID) references dbo.Evaluation(EvaluationID, TenantID)
alter table dbo.ProjectEvaluation add constraint FK_ProjectEvaluation_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID)
alter table dbo.ProjectEvaluationSelectedValue add constraint FK_ProjectEvaluationSelectedValue_EvaluationCriterionValue_EvaluationCriterionValueID_TenantID foreign key (EvaluationCriterionValueID, TenantID) references dbo.EvaluationCriterionValue(EvaluationCriterionValueID, TenantID)
alter table dbo.ProjectEvaluationSelectedValue add constraint FK_ProjectEvaluationSelectedValue_ProjectEvaluation_ProjectEvaluationID_TenantID foreign key (ProjectEvaluationID, TenantID) references dbo.ProjectEvaluation(ProjectEvaluationID, TenantID)



INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(325, N'Evaluation', 'Evaluation'),
(326, N'EvaluationCriteria', 'Evaluation Criteria'),
(327, N'EvaluationCriterionValue', 'Evaluation Criterion Value'),
(328, N'EvaluationPortfolio', 'Evaluation Portfolio'),
(329, N'ProjectEvaluation', 'Project Evaluation'),
(330, N'EvaluationName', 'Evaluation Name'),
(331, N'EvaluationDefinition', 'Evaluation Definition'),
(332, N'EvaluationStatus', 'Evaluation Status'),
(333, N'EvaluationStartDate', 'Evaluation Start Date'),
(334, N'EvaluationEndDate', 'Evaluation End Date'),
(335, N'EvaluationVisibility', 'Evaluation Visibility'),
(336, N'EvaluationCriterionName', 'Evaluation Criterion Name'),
(337, N'EvaluationCriterionDefinition', 'Evaluation Criterion Definition'),
(338, N'EnableProjectEvaluations', 'Enable Project Evaluations');
go

-- Add a seeded values for PSP to replace the word "Project" with "Near Term Action"
INSERT [dbo].[FieldDefinitionData] ([TenantID], [FieldDefinitionID], [FieldDefinitionLabel]) 
VALUES 
(11, 329, 'Near Term Action Evaluation')
go

INSERT [dbo].[FieldDefinitionData] ([TenantID], [FieldDefinitionID], [FieldDefinitionLabel]) 
VALUES 
(11, 338, 'Enable Near Term Action Evaluations')
go


INSERT INTO [dbo].[FieldDefinitionDefault] ([FieldDefinitionID],[DefaultDefinition])
     VALUES
			(325, N'<p>Evaluation</p>'),
			(326, N'<p>Measures used to evaluate projects assigned to this evaluation.</p>'),
			(327, N'<p>Evaluation Criterion Value</p>'),
			(328, N'<p>Evaluation Portfolio</p>'),
			(329, N'<p>Project Evaluation</p>'),
			(330, N'<p>A succinct, descriptive name that captures the purpose and scope of this evaluation.</p>'),
			(331, N'<p>Pertinent context that communicates additional information such as drivers, goals, themes, etc. of this evaluation.</p>'),
			(332, N'<p>Indicates the current phase of all projects in this evaluation; i.e., planning, implementation, completed.</p>'),
			(333, N'<p>The date on which the evaluation process is expected to begin.</p>'),
			(334, N'<p>The date on which the evaluation process is expected to end.</p>'),
			(335, N'<p>Evaluation Visibility</p>'),
			(336, N'<p>Evaluation Criterion Name</p>'),
			(337, N'<p>Evaluation Criterion Definition</p>'),
            (338, N'<p>Enables the Project Evaluations feature.</p>');
GO





--test content for easier testing
--SET IDENTITY_INSERT [dbo].[Evaluation] ON 
--INSERT INTO [dbo].[Evaluation]
--           (EvaluationID
--		   ,[TenantID]
--           ,[EvaluationVisibilityID]
--           ,[EvaluationStatusID]
--           ,[CreatePersonID]
--           ,[EvaluationName]
--           ,[EvaluationDefinition]
--           ,[EvaluationStartDate]
--           ,[EvaluationEndDate]
--           ,[CreateDate])
--     VALUES
--           (1
--		   ,9
--           ,2
--           ,2
--           ,5301
--           ,'Toms Test'
--           ,'This is a sample Evaluation'
--           ,'2019-12-31 00:00:00.000'
--           ,'2020-02-26 00:00:00.000'
--           ,'2019-12-27 12:05:54.017');

--SET IDENTITY_INSERT [dbo].[Evaluation] OFF

--SET IDENTITY_INSERT [dbo].[EvaluationCriterion] ON 
--GO
--INSERT [dbo].[EvaluationCriterion] ([EvaluationCriterionID], [TenantID], [EvaluationID], [EvaluationCriterionName], [EvaluationCriterionDefinition]) VALUES (1, 9, 1, N'rank', N'rank these projects')
--GO
--INSERT [dbo].[EvaluationCriterion] ([EvaluationCriterionID], [TenantID], [EvaluationID], [EvaluationCriterionName], [EvaluationCriterionDefinition]) VALUES (2, 9, 1, N'cost', N'how expensive is this gonna be?')
--GO
--SET IDENTITY_INSERT [dbo].[EvaluationCriterion] OFF
--GO
--SET IDENTITY_INSERT [dbo].[EvaluationCriterionValue] ON 
--GO
--INSERT [dbo].[EvaluationCriterionValue] ([EvaluationCriterionValueID], [TenantID], [EvaluationCriterionID], [EvaluationCriterionValueRating], [EvaluationCriterionValueDescription], [SortOrder]) VALUES (1, 9, 1, N'very good', N'the best', 5)
--GO
--INSERT [dbo].[EvaluationCriterionValue] ([EvaluationCriterionValueID], [TenantID], [EvaluationCriterionID], [EvaluationCriterionValueRating], [EvaluationCriterionValueDescription], [SortOrder]) VALUES (2, 9, 1, N'good', N'okay', 4)
--GO
--INSERT [dbo].[EvaluationCriterionValue] ([EvaluationCriterionValueID], [TenantID], [EvaluationCriterionID], [EvaluationCriterionValueRating], [EvaluationCriterionValueDescription], [SortOrder]) VALUES (3, 9, 1, N'average', N'C+', 3)
--GO
--INSERT [dbo].[EvaluationCriterionValue] ([EvaluationCriterionValueID], [TenantID], [EvaluationCriterionID], [EvaluationCriterionValueRating], [EvaluationCriterionValueDescription], [SortOrder]) VALUES (4, 9, 1, N'poor', N'eek', 2)
--GO
--INSERT [dbo].[EvaluationCriterionValue] ([EvaluationCriterionValueID], [TenantID], [EvaluationCriterionID], [EvaluationCriterionValueRating], [EvaluationCriterionValueDescription], [SortOrder]) VALUES (5, 9, 1, N'very poor', N'not good', 1)
--GO
--INSERT [dbo].[EvaluationCriterionValue] ([EvaluationCriterionValueID], [TenantID], [EvaluationCriterionID], [EvaluationCriterionValueRating], [EvaluationCriterionValueDescription], [SortOrder]) VALUES (6, 9, 2, N'high', N'this project is fancy', 3)
--GO
--INSERT [dbo].[EvaluationCriterionValue] ([EvaluationCriterionValueID], [TenantID], [EvaluationCriterionID], [EvaluationCriterionValueRating], [EvaluationCriterionValueDescription], [SortOrder]) VALUES (7, 9, 2, N'medium', N'okay, keep an eye on the books, but we should be fine', 2)
--GO
--INSERT [dbo].[EvaluationCriterionValue] ([EvaluationCriterionValueID], [TenantID], [EvaluationCriterionID], [EvaluationCriterionValueRating], [EvaluationCriterionValueDescription], [SortOrder]) VALUES (8, 9, 2, N'low', N'cheap, like free beer', 1)
--GO
--SET IDENTITY_INSERT [dbo].[EvaluationCriterionValue] OFF
--GO
