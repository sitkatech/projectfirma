delete from dbo.Sector
go

insert into dbo.Sector(SectorID, SectorAbbreviation, SectorName, SectorDisplayName, LegendColor, Pre2007Expenditures, Pre2010Expenditures)
values
(1, 'FED', 'Federal', 'Federal', '#1f77b4', 293000000, 424000000),
(2, 'LOC', 'Local', 'Local', '#aec7e8', 53400000, 59000000),
(3, 'PRI', 'Private', 'Private', '#ff7f0e', 216000000, 249000000),
(4, 'STCA', 'StateCalifornia', 'State California', '#ffbb78', 446000000, 612000000),
(5, 'STNV', 'StateNevada', 'State Nevada', '#2ca02c', 82000000, 87000000)