
CREATE TABLE dbo.ClassificationSystem(
	ClassificationSystemID int NOT NULL IDENTITY(1,1) constraint PK_ClassificationSystem_ClassificationSystemID PRIMARY KEY,
	TenantID int NOT NULL constraint FK_ClassificationSystem_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),	
	ClassificationSystemName varchar(200) NOT NULL,
	ClassificationSystemDescription varchar(max) NOT NULL,
)

alter table dbo.ClassificationSystem add constraint AK_ClassificationSystem_ClassificationSystemID_TenantID UNIQUE (ClassificationSystemID, TenantID)
alter table dbo.ClassificationSystem add constraint AK_ClassificationSystem_ClassificationSystemName_TenantID UNIQUE (ClassificationSystemName, TenantID) 

go

insert into dbo.ClassificationSystem(TenantID, ClassificationSystemName, ClassificationSystemDescription)
select t.TenantID, FieldDefinitionLabel, isnull(FieldDefinitionDataValue, '<p>A logical system to group projects according to overarching program themes or goals.</p>')
from dbo.Tenant t
	left join dbo.FieldDefinitionData fdd on t.TenantID = fdd.TenantID
	left join dbo.FieldDefinition fd on fd.FieldDefinitionID = fdd.FieldDefinitionID
	where fd.FieldDefinitionName = 'Classification'

insert into dbo.ClassificationSystem(TenantID, ClassificationSystemName, ClassificationSystemDescription)
values (1, 'Classification', '<p>A logical system to group projects according to overarching program themes or goals.</p>'),
(7, 'Classification', '<p>A logical system to group projects according to overarching program themes or goals.</p>')


alter table dbo.Classification add ClassificationSystemID int null
alter table dbo.Classification add constraint FK_Classification_ClassificationSystem_ClassificationSystemID foreign key (ClassificationSystemID) references dbo.ClassificationSystem(ClassificationSystemID)
alter table dbo.Classification add constraint FK_Classification_ClassificationSystem_ClassificationSystemID_TenantID foreign key (ClassificationSystemID, TenantID) references dbo.ClassificationSystem(ClassificationSystemID, TenantID)


go

UPDATE dbo.Classification 
SET ClassificationSystemID = cft.ClassificationSystemID
FROM
    dbo.Classification  AS cf
    INNER JOIN ClassificationSystem AS cft
        ON cf.TenantID = cft.TenantID

go

alter table dbo.Classification alter column ClassificationSystemID int not null