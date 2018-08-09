Alter Table dbo.PerformanceMeasureSubcategoryOption
Add ShowOnFactSheet bit null
Go

Update dbo.PerformanceMeasureSubcategoryOption
set ShowOnFactSheet = 0

Alter Table dbo.PerformanceMeasureSubcategoryOption
Alter Column ShowOnFactSheet bit not null
