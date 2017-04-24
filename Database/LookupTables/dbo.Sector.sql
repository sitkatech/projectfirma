delete from dbo.Sector
go

insert into dbo.Sector(SectorID, SectorAbbreviation, SectorName, SectorDisplayName, LegendColor)
values
(1, 'FED', 'Federal', 'Federal', '#1f77b4'),
(2, 'LOC', 'Local', 'Local', '#aec7e8'),
(3, 'PRI', 'Private', 'Private', '#ff7f0e'),
(4, 'ST', 'State', 'State', '#ffbb78'),
(5, 'TRI', 'Tribe', 'Tribe', '#2ca02c')