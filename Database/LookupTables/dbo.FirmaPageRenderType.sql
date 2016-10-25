delete from dbo.FirmaPageRenderType
go

insert into dbo.FirmaPageRenderType(FirmaPageRenderTypeID, FirmaPageRenderTypeName, FirmaPageRenderTypeDisplayName)
values
(1, 'IntroductoryText', 'Introductory Text'),
(2, 'PageContent', 'Page Content')