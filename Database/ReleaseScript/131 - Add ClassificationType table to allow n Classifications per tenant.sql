
CREATE TABLE dbo.ClassificationType(
	ClassificationTypeID int NOT NULL IDENTITY(1,1) constraint PK_ClassificationType_ClassificationTypeID PRIMARY KEY,
	TenantID int NOT NULL constraint FK_ClassificationType_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),	
	ClassificationTypeName varchar(200) NOT NULL,
	ClassificationTypeDescription varchar(max) NOT NULL,
)

alter table dbo.ClassificationType add constraint AK_ClassificationType_ClassificationTypeID_TenantID UNIQUE (ClassificationTypeID, TenantID)
alter table dbo.ClassificationType add constraint AK_ClassificationType_ClassificationTypeName_TenantID UNIQUE (ClassificationTypeName, TenantID) 

go

insert into dbo.ClassificationType(TenantID, ClassificationTypeName, ClassificationTypeDescription)
select t.TenantID, FieldDefinitionLabel, isnull(FieldDefinitionDataValue, '<p>A logical system to group projects according to overarching program themes or goals.</p>')
from dbo.Tenant t
	left join dbo.FieldDefinitionData fdd on t.TenantID = fdd.TenantID
	left join dbo.FieldDefinition fd on fd.FieldDefinitionID = fdd.FieldDefinitionID
	where fd.FieldDefinitionName = 'Classification'

insert into dbo.ClassificationType(TenantID, ClassificationTypeName, ClassificationTypeDescription)
values (1, 'Classification', '<p>A logical system to group projects according to overarching program themes or goals.</p>'),
(7, 'Classification', '<p>A logical system to group projects according to overarching program themes or goals.</p>')


alter table dbo.Classification add ClassificationTypeID int null
alter table dbo.Classification add constraint FK_Classification_ClassificationType_ClassificationTypeID foreign key (ClassificationTypeID) references dbo.ClassificationType(ClassificationTypeID)
alter table dbo.Classification add constraint FK_Classification_ClassificationType_ClassificationTypeID_TenantID foreign key (ClassificationTypeID, TenantID) references dbo.ClassificationType(ClassificationTypeID, TenantID)


go

UPDATE dbo.Classification 
SET ClassificationTypeID = cft.ClassificationTypeID
FROM
    dbo.Classification  AS cf
    INNER JOIN ClassificationType AS cft
        ON cf.TenantID = cft.TenantID

go

alter table dbo.Classification alter column ClassificationTypeID int not null