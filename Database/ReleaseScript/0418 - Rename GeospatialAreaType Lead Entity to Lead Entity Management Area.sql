update dbo.GeospatialAreaType set GeospatialAreaTypeName = 'Lead Entity Management Area' where GeospatialAreaTypeID = 18
update dbo.GeospatialAreaType set GeospatialAreaTypeNamePluralized = 'Lead Entity Management Areas' where GeospatialAreaTypeID = 18
update dbo.GeospatialAreaType set GeospatialAreaLayerName = 'PSPActionAgenda:LeadEntityManagementArea' where GeospatialAreaTypeID = 18
update dbo.GeospatialAreaType set GeospatialAreaIntroContent = '<p>This map shows areas of Puget Sound that are managed by Lead Entity Management Areas. Lead Entity Management Areas are local, citizen-based, organizations that coordinate salmon recovery efforts in their local watershed. Lead entities work with local and state agencies, tribes, citizens, and other community groups to adaptively manage their local salmon recovery chapters to recover salmon and ensure that salmon recovery actions are implemented on the ground. For more information, see <a href="https://psp.wa.gov/salmon-recovery-overview.php">Salmon Recovery in Puget Sound</a>.</p>

<p>NTAs can be associated with one or many Lead Entity Management Areas, regardless of their mapped location.</p>
'
where GeospatialAreaTypeID = 18
