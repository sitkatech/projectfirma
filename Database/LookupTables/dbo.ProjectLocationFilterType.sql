
delete from dbo.ProjectLocationFilterType

insert dbo.ProjectLocationFilterType (ProjectLocationFilterTypeID, ProjectLocationFilterTypeName, ProjectLocationFilterTypeDisplayName, ProjectLocationFilterTypeNameWithIdentifier, SortOrder, DisplayGroup) values 
(1, 'TaxonomyTierThree', 'Focus Area', 'TaxonomyTierThreeID', 10, 1),
(2, 'TaxonomyTierTwo', 'TaxonomyTierTwo', 'TaxonomyTierTwoID', 20, 1),
(3, 'TaxonomyTierOne', 'Action Priority', 'TaxonomyTierOneID', 30, 1),
(4, 'ThresholdCategory', 'Threshold Category', 'ThresholdCategoryID', 40, 3),
(5, 'ProjectStage', 'Project Stage', 'ProjectStageID', 50, 3),
(6, 'ImplementingOrganization', 'Implementing Organization', 'ImplementingOrganizationID', 60, 4),
(7, 'FundingOrganization', 'Funding Organization', 'FundingOrganizationID', 70, 4)
