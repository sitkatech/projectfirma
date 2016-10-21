delete from dbo.ThresholdSectorType
go

insert into dbo.ThresholdSectorType(ThresholdSectorTypeID, ThresholdSectorTypeName, ThresholdSectorTypeDisplayName) 
values 
(1, 'Federal', 'Federal'),
(2, 'California', 'California'),
(3, 'Nevada', 'Nevada'),
(4, 'TRPA', 'TRPA')