delete from dbo.ThresholdStandardType
go

insert into dbo.ThresholdStandardType(ThresholdStandardTypeID, ThresholdStandardTypeName, ThresholdStandardTypeDisplayName) 
values 
(1, 'Numeric', 'Numeric'),
(2, 'Management', 'Management'),
(3, 'PolicyStatement', 'Policy Statement'),
(4, 'ManagementWithNumeric', 'Management with Numeric'),
(5, 'NonDegradation', 'Non-Degradation')