delete from dbo.ProjectCustomGridColumn
go

insert into dbo.ProjectCustomGridColumn(ProjectCustomGridColumnID, ProjectCustomGridColumnName, ProjectCustomGridColumnDisplayName, IsOptional)
values
(1, 'ProjectName', 'Project Name', 0),
(2, 'PrimaryContactOrganization', 'Primary Contact Organization', 0),
(3, 'ProjectStage', 'Project Stage', 0),
(4, 'NumberOfReportedPerformanceMeasures', 'Number of Reported Performance Measures', 1),
(5, 'ProjectsStewardOrganizationRelationshipToProject', 'Projects Steward Organization Relationship To Project', 1),
(6, 'ProjectPrimaryContact', 'Project Primary Contact', 1),
(7, 'ProjectPrimaryContactEmail', 'Project Primary Contact Email', 1),
(8, 'PlanningDesignStartYear', 'Planning Design Start Year', 1),
(9, 'ImplementationStartYear', 'Implementation Start Year', 1),
(10, 'CompletionYear', 'Completion Year', 1),
(11, 'PrimaryTaxonomyLeaf', 'Primary Taxonomy Leaf', 1),
(12, 'SecondaryTaxonomyLeaf', 'Secondary Taxonomy Leaf', 1),
(13, 'NumberOfReportedExpenditures', 'Number of Reported Expenditures', 1),
(14, 'FundingType', 'Funding Type', 1),
(15, 'EstimatedTotalCost', 'Estimated Total Cost', 1),
(16, 'SecuredFunding', 'Secured Funding', 1),
(17, 'TargetedFunding', 'Targeted Funding', 1),
(18, 'NoFundingSourceIdentified', 'No Funding Source Identified', 1),
(19, 'ProjectDescription', 'Project Description', 1),
(20, 'NumberOfPhotos', 'Number of Photos', 1),
(21, 'GeospatialAreaName', 'Geospatial Area Name', 1),
(22, 'CustomAttribute', 'Custom Attribute', 1),
(23, 'ProjectID', 'ProjectID', 1),
(24, 'ProjectLastUpdated', 'Last Updated', 1),
(25, 'ProjectStatus', 'Status', 1),
(26, 'FinalStatusUpdateStatus', 'Final Status Update', 1),
(27, 'ProjectCategory', 'Project Category', 1)