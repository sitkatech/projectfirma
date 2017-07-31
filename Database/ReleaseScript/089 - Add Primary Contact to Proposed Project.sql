alter table dbo.Project alter column LeadImplementerOrganizationID int not null

alter table dbo.ProposedProject add PrimaryContactPersonID int null
alter table dbo.ProposedProject add constraint FK_ProposedProject_Person_PrimaryContactPersonID_PersonID foreign key (PrimaryContactPersonID) references dbo.Person(PersonID)
alter table dbo.ProposedProject add constraint FK_ProposedProject_Person_PrimaryContactPersonID_TenantID_PersonID_TenantID foreign key (PrimaryContactPersonID, TenantID) references dbo.Person(PersonID, TenantID)