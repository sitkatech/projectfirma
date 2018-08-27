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
(2, 'TechnicalAssistanceValue', 'Value of Assistance Provided to Conservation Districts', 1)

declare @newPMName varchar(200) = 'Value of Assistance Provided to Conservation Districts'

INSERT INTO dbo.PerformanceMeasure ([TenantID], [CriticalDefinitions], [ProjectReporting], [PerformanceMeasureDisplayName], [MeasurementUnitTypeID], [PerformanceMeasureTypeID], [PerformanceMeasureDefinition], [DataSourceText], [ExternalDataSourceUrl], [ChartCaption], [SwapChartAxes], [CanCalculateTotal], [PerformanceMeasureSortOrder], [IsAggregatable])
values
(9, NULL, NULL, @newPMName, 9, 1, 'The dollar value of technical assistance provided to Conservation Districts.', NULL, NULL, NULL, 0, 0, NULL, 1)

declare @newPMID int = SCOPE_IDENTITY()

INSERT INTO dbo.PerformanceMeasureSubcategory([TenantID], [PerformanceMeasureID], [PerformanceMeasureSubcategoryDisplayName], [ChartConfigurationJson], [GoogleChartTypeID])
values
(9, @newPMID, @NewPMName, '{"title":"","titlePosition":null,"legend":{"position":"none"},"hAxis":{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":false,"formatOptions":{"source":"inline"},"format":"0.##"},"vAxes":[{"title":"Technical Assitance Value ($)","titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":false,"formatOptions":{"source":"inline"},"viewWindow":{"min":0},"format":"0.##"},{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":false,"formatOptions":{"source":"inline"},"viewWindow":{"min":0},"format":"0.##"}],"series":null,"backgroundColor":{"fill":"white"},"legendTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":11,"fontWidth":"normal"},"titleTextStyle":{"italic":false,"bold":false,"color":"#000","fontSize":16,"fontWidth":"normal"},"isStacked":false,"focusTarget":"category","tooltip":null,"curveType":null,"lineWidth":0,"seriesType":null,"type":null,"connectSteps":false,"theme":null}', 1)

UPDATE dbo.PerformanceMeasure
SET PerformanceMeasureDataSourceTypeID = 1

UPDATE dbo.PerformanceMeasure
SET PerformanceMeasureDataSourceTypeID = 2
WHERE TenantID = 9 and PerformanceMeasureDisplayName = @newPMName

ALTER TABLE dbo.PerformanceMeasure
ALTER COLUMN PerformanceMeasureDataSourceTypeID INT NOT NULL

ALTER TABLE dbo.Tenant
ADD UsesTechnicalAssistanceParameters BIT NULL
GO

UPDATE dbo.Tenant
SET UsesTechnicalAssistanceParameters = 0

UPDATE dbo.Tenant
SET UsesTechnicalAssistanceParameters = 1
WHERE TenantID = 9

ALTER TABLE dbo.Tenant
ALTER COLUMN UsesTechnicalAssistanceParameters BIT NOT NULL

-- this feature is only available for Idaho
ALTER TABLE dbo.Tenant
ADD CONSTRAINT CK_OnlyIdahoUsesTechnicalAssistanceParameters
CHECK (UsesTechnicalAssistanceParameters = 0 OR TenantID = 9)