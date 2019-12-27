
create table dbo.EvaluationVisibility(
	EvaluationVisibilityID int identity(1,1) not null constraint PK_EvaluationVisibility_EvaluationVisibilityID primary key,
	EvaluationVisibilityName varchar(100) not null,
	EvaluationVisibilityDisplayName varchar(100) not null
)

insert into dbo.EvaluationVisibility(EvaluationVisibilityName, EvaluationVisibilityDisplayName) values ('OnlyMe','Only Me')
insert into dbo.EvaluationVisibility(EvaluationVisibilityName, EvaluationVisibilityDisplayName) values ('AdminsFromMyOrganizationOnly','Admins from my Org only')
insert into dbo.EvaluationVisibility(EvaluationVisibilityName, EvaluationVisibilityDisplayName) values ('AllAdmins','All Admins')


create table dbo.EvaluationStatus(
	EvaluationStatusID int identity(1,1) not null constraint PK_EvaluationStatus_EvaluationStatusID primary key,
	EvaluationStatusName varchar(100) not null,
	EvaluationStatusDisplayName varchar(100) not null
)

insert into dbo.EvaluationStatus(EvaluationStatusName, EvaluationStatusDisplayName) values ('Draft','Draft')
insert into dbo.EvaluationStatus(EvaluationStatusName, EvaluationStatusDisplayName) values ('Planned','Planned')
insert into dbo.EvaluationStatus(EvaluationStatusName, EvaluationStatusDisplayName) values ('InProgress','In Progress')
insert into dbo.EvaluationStatus(EvaluationStatusName, EvaluationStatusDisplayName) values ('Completed','Completed')



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