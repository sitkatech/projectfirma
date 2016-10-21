delete from dbo.ThresholdEvaluationConfidenceType
go

insert into dbo.ThresholdEvaluationConfidenceType(ThresholdEvaluationConfidenceTypeID, ThresholdEvaluationConfidenceTypeName, ThresholdEvaluationConfidenceTypeDisplayName) 
values 
(1, 'High', 'High'),
(2, 'Moderate', 'Moderate'),
(3, 'Low', 'Low')