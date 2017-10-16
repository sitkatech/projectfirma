alter table dbo.MeasurementUnitType add NumberOfSignificantDigits int null;

go
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 1
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 2
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 3
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 4
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 5
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 0 where MeasurementUnitTypeID = 6
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 7
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 8
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 9
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 0 where MeasurementUnitTypeID = 10
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 0 where MeasurementUnitTypeID = 11
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 12
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 3 where MeasurementUnitTypeID = 13
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 3 where MeasurementUnitTypeID = 14
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 15
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 1 where MeasurementUnitTypeID = 16
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 1 where MeasurementUnitTypeID = 17
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 0 where MeasurementUnitTypeID = 18
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 19
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 2 where MeasurementUnitTypeID = 20
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 0 where MeasurementUnitTypeID = 21
update dbo.MeasurementUnitType set NumberOfSignificantDigits = 0 where MeasurementUnitTypeID = 22

go

alter table dbo.MeasurementUnitType alter column NumberOfSignificantDigits int not null;
