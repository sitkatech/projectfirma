
create table dbo.ProjectUpdateBatchClassificationSystem
(
	ProjectUpdateBatchClassificationSystemID int identity(1,1) not null constraint PK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatchClassificationSystemID primary key,
	TenantID int not null constraint FK_ProjectUpdateBatchClassificationSystem_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectUpdateBatchID int not null constraint FK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatch_ProjectUpdateBatchID foreign key references dbo.ProjectUpdateBatch(ProjectUpdateBatchID),
	ClassificationSystemID int not null constraint FK_ProjectUpdateBatchClassificationSystem_ClassificationSystem_ClassificationSystemID foreign key references dbo.ClassificationSystem(ClassificationSystemID),
	ProjectClassificationsDiffLog [dbo].[html] null,
    ProjectClassificationsComment [varchar](1000) NULL,
	constraint AK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatchClassificationSystemID_TenantID unique (ProjectUpdateBatchClassificationSystemID, TenantID),
	constraint FK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID  foreign key (ProjectUpdateBatchID, TenantID) references dbo.ProjectUpdateBatch(ProjectUpdateBatchID, TenantID),
	constraint FK_ProjectUpdateBatchClassificationSystem_ClassificationSystem_ClassificationSystemID_TenantID  foreign key (ClassificationSystemID, TenantID) references dbo.ClassificationSystem(ClassificationSystemID, TenantID)
)
go

-- copy data from ProjectUpdateBatch where the ProjectClassificationsDiffLog is not null (note that there was a bug with the review comments and nothing was being written to the ProjectClassificationsComment
insert into dbo.ProjectUpdateBatchClassificationSystem(TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog)
select pub.TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog 
from dbo.ProjectUpdateBatch pub join dbo.ClassificationSystem cs on cs.TenantID = pub.TenantID
where ProjectClassificationsDiffLog is not null and cs.TenantID = 2

insert into dbo.ProjectUpdateBatchClassificationSystem(TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog)
select pub.TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog 
from dbo.ProjectUpdateBatch pub join dbo.ClassificationSystem cs on cs.TenantID = pub.TenantID
where ProjectClassificationsDiffLog is not null and cs.TenantID = 3

insert into dbo.ProjectUpdateBatchClassificationSystem(TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog)
select pub.TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog 
from dbo.ProjectUpdateBatch pub join dbo.ClassificationSystem cs on cs.TenantID = pub.TenantID
where ProjectClassificationsDiffLog is not null and cs.TenantID = 4

insert into dbo.ProjectUpdateBatchClassificationSystem(TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog)
select pub.TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog 
from dbo.ProjectUpdateBatch pub join dbo.ClassificationSystem cs on cs.TenantID = pub.TenantID
where ProjectClassificationsDiffLog is not null and cs.TenantID = 7

insert into dbo.ProjectUpdateBatchClassificationSystem(TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog)
select pub.TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog 
from dbo.ProjectUpdateBatch pub join dbo.ClassificationSystem cs on cs.TenantID = pub.TenantID
where ProjectClassificationsDiffLog is not null and cs.TenantID = 9

insert into dbo.ProjectUpdateBatchClassificationSystem(TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog)
select pub.TenantID, ProjectUpdateBatchID, ClassificationSystemID, ProjectClassificationsDiffLog 
from dbo.ProjectUpdateBatch pub join dbo.ClassificationSystem cs on cs.TenantID = pub.TenantID
where ProjectClassificationsDiffLog is not null and cs.TenantID = 11

alter table dbo.ProjectUpdateBatch drop column ProjectClassificationsDiffLog
alter table dbo.ProjectUpdateBatch drop column ProjectClassificationsComment