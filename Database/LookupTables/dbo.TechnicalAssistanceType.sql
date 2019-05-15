delete from dbo.TechnicalAssistanceType
go
insert into dbo.TechnicalAssistanceType(TechnicalAssistanceTypeID, TechnicalAssistanceTypeName, TechnicalAssistanceTypeDisplayName)
values
(1, 'CapacityBuilding', 'Capacity Building'),
(2, 'EducationOutreach', 'Education/Outreach'),
(3, 'Engineering', 'Engineering'),
(4, 'Operations', 'Operations'),
(5, 'TechnicalAssistance', 'Technical Assistance')
go