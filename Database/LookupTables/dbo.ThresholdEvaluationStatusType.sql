delete from dbo.ThresholdEvaluationStatusType
go

insert into dbo.ThresholdEvaluationStatusType(ThresholdEvaluationStatusTypeID, ThresholdEvaluationStatusTypeName, ThresholdEvaluationStatusTypeDisplayName) 
values 
(1, 'ConsiderablyBetter', 'Considerably Better Than Target'),
(2, 'AtOrSomewhatBetter', 'At or Somewhat Better Than Target'),
(3, 'SomewhatWorse', 'Somewhat Worse Than Target'),
(4, 'ConsiderablyWorse', 'Considerably Worse Than Target'),
(5, 'InsufficientData', 'Insufficient Data to Determine Status or No Target Established')