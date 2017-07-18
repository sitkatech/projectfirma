
delete from dbo.ProjectLocationFilterType

insert dbo.ProjectLocationFilterType (ProjectLocationFilterTypeID, ProjectLocationFilterTypeName, ProjectLocationFilterTypeDisplayName, ProjectLocationFilterTypeNameWithIdentifier, SortOrder, DisplayGroup) values 
(1, 'TaxonomyTierThree', 'Taxonomy Tier Three', 'TaxonomyTierThreeID', 10, 1),
(2, 'TaxonomyTierTwo', 'Taxonomy Tier Two', 'TaxonomyTierTwoID', 20, 1),
(3, 'TaxonomyTierOne', 'Taxonomy Tier One', 'TaxonomyTierOneID', 30, 1),
(4, 'Classification', 'Classification', 'ClassificationID', 40, 3),
(5, 'ProjectStage', 'Project Stage', 'ProjectStageID', 50, 3)
