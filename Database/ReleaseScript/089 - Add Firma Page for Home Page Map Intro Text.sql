insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(24, 'HomeMapInfo', 'Home Page Map Info', 2)

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(1, 24, '<p style="margin-bottom: 5px"> This map shows approximate Project Locations. For more detail, <a href="/Results/ProjectMap">view the comprehensive map page</a>. </p>'),
(2, 24, '<p style="margin-bottom: 5px"> This map shows approximate Project Locations. For more detail, <a href="/Results/ProjectMap">view the comprehensive map page</a>. </p>'),
(3, 24, '<p style="margin-bottom: 5px"> This map shows approximate Project Locations. For more detail, <a href="/Results/ProjectMap">view the comprehensive map page</a>. </p>')