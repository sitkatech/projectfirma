
delete from dbo.ProjectLocationFilterType

insert dbo.ProjectLocationFilterType (ProjectLocationFilterTypeID, ProjectLocationFilterTypeName, ProjectLocationFilterTypeDisplayName, ProjectLocationFilterTypeNameWithIdentifier, SortOrder, DisplayGroup) values 
(1, 'TaxonomyTrunk', 'Taxonomy Trunk', 'TaxonomyTrunkID', 10, 1),
(2, 'TaxonomyBranch', 'Taxonomy Branch', 'TaxonomyBranchID', 20, 1),
(3, 'TaxonomyLeaf', 'Taxonomy Leaf', 'TaxonomyLeafID', 30, 1),
(4, 'Classification', 'Classification', 'ClassificationID', 40, 3),
(5, 'ProjectStage', 'Project Stage', 'ProjectStageID', 50, 3)
