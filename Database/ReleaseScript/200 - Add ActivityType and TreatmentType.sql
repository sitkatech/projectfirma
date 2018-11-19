CREATE TABLE dbo.ActivityType(
	ActivityTypeID int NOT NULL constraint PK_ActivityType_ActivityTypeID primary key,
	ActivityTypeName varchar(50) NOT NULL constraint AK_ActivityType_ActivityTypeName unique,
	ActivityTypeDisplayName varchar(50) NOT NULL constraint AK_ActivityType_ActivityTypeDisplayName unique
)

CREATE TABLE dbo.TreatmentType(
	TreatmentTypeID int NOT NULL constraint PK_TreatmentType_TreatmentTypeID primary key,
	TreatmentTypeName varchar(50) NOT NULL constraint AK_TreatmentType_TreatmentTypeName unique,
	TreatmentTypeDisplayName varchar(50) NOT NULL constraint AK_TreatmentType_TreatmentTypeDisplayName unique
)

Insert into dbo.ActivityType (ActivityTypeID, ActivityTypeName, ActivityTypeDisplayName)
values
(1, 'Travel', 'Travel'),
(2, 'StaffTime', 'Staff Time'),
(3, 'Treatment', 'Treatment'),
(4, 'ContractorTime', 'Contractor Time'),
(5, 'Supplies', 'Supplies')

--TODO
Insert into dbo.TreatmentType (TreatmentTypeID, TreatmentTypeName, TreatmentTypeDisplayName)
values
(1, 'ToDo', 'To-do')