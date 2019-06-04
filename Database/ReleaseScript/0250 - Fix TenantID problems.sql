--begin tran

alter table  dbo.ProjectCustomAttributeTypeRole
add TenantID int null
GO

update  pcatr
set TenantID = pcat.TenantID
from dbo.ProjectCustomAttributeTypeRole as pcatr
join dbo.ProjectCustomAttributeType as pcat on pcatr.ProjectCustomAttributeTypeID = pcat.ProjectCustomAttributeTypeID
 
 alter table dbo.ProjectCustomAttributeTypeRole
 alter column TenantID int not null
 GO

alter table dbo.ProjectCustomAttributeTypeRole add constraint FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID foreign key (ProjectCustomAttributeTypeID, TenantID) references dbo.ProjectCustomAttributeType(ProjectCustomAttributeTypeID, TenantID)
alter table dbo.ProjectCustomAttributeTypeRole add constraint FK_ProjectCustomAttributeTypeRole_Tenant_TenantID foreign key (TenantID) references dbo.Tenant(TenantID)



alter table dbo.TechnicalAssistanceRequest add constraint FK_TechnicalAssistanceRequest_Person_PersonID_TenantID foreign key (PersonID, TenantID) references dbo.Person(PersonID, TenantID)
alter table dbo.TechnicalAssistanceRequest add constraint FK_TechnicalAssistanceRequest_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID)
alter table dbo.TechnicalAssistanceRequestUpdate add constraint FK_TechnicalAssistanceRequestUpdate_Person_PersonID_TenantID foreign key (PersonID, TenantID) references dbo.Person(PersonID, TenantID)
alter table dbo.TechnicalAssistanceRequestUpdate add constraint FK_TechnicalAssistanceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID foreign key (ProjectUpdateBatchID, TenantID) references dbo.ProjectUpdateBatch(ProjectUpdateBatchID, TenantID)

--rollback tran