delete from dbo.TransactionState

GO

insert into dbo.TransactionState(TransactionStateID, TransactionStateName, TransactionStateDisplayName, SortOrder) 
values 
(1, 'Draft', 'Draft', 1),
(2, 'Proposed', 'Proposed', 2),
(3, 'Approved', 'Approved', 3),
(4, 'De-Allocated', 'De-Allocated', 4),
(5, 'Withdrawn', 'Withdrawn', 5)

GO