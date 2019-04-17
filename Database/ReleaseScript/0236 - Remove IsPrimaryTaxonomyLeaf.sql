alter table dbo.TaxonomyLeafPerformanceMeasure drop column IsPrimaryTaxonomyLeaf

delete from dbo.FieldDefinitionData where FieldDefinitionID = 52