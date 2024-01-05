insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(96, 'ProgressDashboardFishAndWildlifeHabitat', 'Progress Dashboard Fish & Wildlife Habitat', 1)

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(13, 96, 'The Salton Sea Management Program''s 10-year plan calls for construction of habitat restoration and dust suppression on 30,000 acres of exposed lakebed and areas that will be exposed by 2028. The Progress Dashboard provides a snapshot of the accomplishments and advancements being made at the project-level towards this goal and towards promoting a healthier and more sustainable future for the Salton Sea region.')

update dbo.FirmaPage set FirmaPageContent = 'The Salton Sea Management Program''s 10-year plan calls for construction of habitat restoration and dust suppression on 30,000 acres of exposed lakebed and areas that will be exposed by 2028. The Progress Dashboard provides a snapshot of the accomplishments and advancements being made at the project-level towards this goal and towards promoting a healthier and more sustainable future for the Salton Sea region.'
where FirmaPageTypeID = 93