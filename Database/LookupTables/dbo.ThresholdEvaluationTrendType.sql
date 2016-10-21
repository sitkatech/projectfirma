delete from dbo.ThresholdEvaluationTrendType
go

insert into dbo.ThresholdEvaluationTrendType(ThresholdEvaluationTrendTypeID, ThresholdEvaluationTrendTypeName, ThresholdEvaluationTrendTypeDisplayName) 
values 
(1, 'RapidImprovement', 'Rapid Improvement'),
(2, 'ModerateImprovement', 'Moderate Improvement'),
(3, 'LittleOrNoChange', 'Little or No Change'),
(4, 'ModerateDecline', 'Moderate Decline'),
(5, 'RapidDecline', 'Rapid Decline'),
(6, 'InsufficientData', 'Insufficient Data to Determine Trend')