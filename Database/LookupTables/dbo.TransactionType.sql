delete from dbo.TransactionType
go

insert into dbo.TransactionType(TransactionTypeID, TransactionTypeName, TransactionTypeDisplayName, TransactionTypeAbbreviation) values (1, 'Allocation', 'Allocation', 'ALLOC')
insert into dbo.TransactionType(TransactionTypeID, TransactionTypeName, TransactionTypeDisplayName, TransactionTypeAbbreviation) values (2, 'Conversion', 'Conversion', 'CONV')
insert into dbo.TransactionType(TransactionTypeID, TransactionTypeName, TransactionTypeDisplayName, TransactionTypeAbbreviation) values (3, 'ECM Retirement', 'ECM Retirement', 'ECM')
insert into dbo.TransactionType(TransactionTypeID, TransactionTypeName, TransactionTypeDisplayName, TransactionTypeAbbreviation) values (4, 'Land Bank Acquisition', 'Land Bank Acquisition', 'LBA')
insert into dbo.TransactionType(TransactionTypeID, TransactionTypeName, TransactionTypeDisplayName, TransactionTypeAbbreviation) values (5, 'Transfer', 'Transfer', 'TRF')
insert into dbo.TransactionType(TransactionTypeID, TransactionTypeName, TransactionTypeDisplayName, TransactionTypeAbbreviation) values (6, 'Transfer With Bonus Unit', 'Transfer + Bonus Units', 'TRFB')
insert into dbo.TransactionType(TransactionTypeID, TransactionTypeName, TransactionTypeDisplayName, TransactionTypeAbbreviation) values (7, 'Allocation Assignment', 'Allocation Assignment', 'ALLOCASSGN')
insert into dbo.TransactionType(TransactionTypeID, TransactionTypeName, TransactionTypeDisplayName, TransactionTypeAbbreviation) values (8, 'Conversion With Transfer', 'Conversion With Transfer', 'CONVTRF')