CREATE TABLE dbo.PerformanceMeasureDataSourceType(
	PerformanceMeasureDataSourceTypeID int NOT NULL,
	PerformanceMeasureDataSourceTypeName varchar(100) NOT NULL,
	PerformanceMeasureDataSourceTypeDisplayName varchar(100) NOT NULL,
	IsCustomCalculation bit NOT NULL,
 CONSTRAINT PK_PerformanceMeasureDataSourceType_PerformanceMeasureDataSourceTypeID PRIMARY KEY 
(
	PerformanceMeasureDataSourceTypeID 
),
 CONSTRAINT AK_PerformanceMeasureDataSourceType_PerformanceMeasureDataSourceTypeName UNIQUE 
(
	PerformanceMeasureDataSourceTypeName
)
)
GO

ALTER TABLE dbo.PerformanceMeasure
ADD PerformanceMeasureDataSourceTypeID INT NULL
GO

ALTER TABLE dbo.PerformanceMeasure  WITH CHECK ADD  CONSTRAINT FK_PerformanceMeasure_PerformanceMeasureDataSourceType_PerformanceMeasureDataSourceTypeID FOREIGN KEY(PerformanceMeasureDataSourceTypeID)
REFERENCES dbo.PerformanceMeasureDataSourceType (PerformanceMeasureDataSourceTypeID)
GO

INSERT INTO dbo.PerformanceMeasureDataSourceType(PerformanceMeasureDataSourceTypeID, PerformanceMeasureDataSourceTypeName, PerformanceMeasureDataSourceTypeDisplayName, IsCustomCalculation) values 
(1, 'Project', 'Project', 0),
(2, 'TechnicalAssistanceValue', 'Technical Assistance Value', 1)

declare @newPMName varchar(50) = 'Technical Assistance Value'

INSERT INTO dbo.PerformanceMeasure ([TenantID], [CriticalDefinitions], [ProjectReporting], [PerformanceMeasureDisplayName], [MeasurementUnitTypeID], [PerformanceMeasureTypeID], [PerformanceMeasureDefinition], [DataSourceText], [ExternalDataSourceUrl], [ChartCaption], [SwapChartAxes], [CanCalculateTotal], [PerformanceMeasureSortOrder], [IsAggregatable])
values
(9, NULL, NULL, @newPMName, 9, 1, 'The dollar value of technical assistance provided to Conservation Districts.', NULL, NULL, NULL, 0, 0, NULL, 1)

UPDATE dbo.PerformanceMeasure
SET PerformanceMeasureDataSourceTypeID = 1

UPDATE dbo.PerformanceMeasure
SET PerformanceMeasureDataSourceTypeID = 2
WHERE TenantID = 9 and PerformanceMeasureDisplayName = @newPMName

ALTER TABLE dbo.PerformanceMeasure
ALTER COLUMN PerformanceMeasureDataSourceTypeID INT NOT NULL