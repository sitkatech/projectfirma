CREATE TABLE [dbo].[FirmaMenuItem](
	[FirmaMenuItemID] [int] NOT NULL,
	[FirmaMenuItemName] [varchar](100) NOT NULL,
	[FirmaMenuItemDisplayName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_FirmaMenuItem_FirmaMenuItemID] PRIMARY KEY CLUSTERED 
(
	[FirmaMenuItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FirmaMenuItem_FirmaMenuItemDisplayName] UNIQUE NONCLUSTERED 
(
	[FirmaMenuItemDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FirmaMenuItem_FirmaMenuItemName] UNIQUE NONCLUSTERED 
(
	[FirmaMenuItemName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into dbo.FirmaMenuItem(FirmaMenuItemID, FirmaMenuItemName, FirmaMenuItemDisplayName)
values
(1, 'About', 'About'),
(2, 'Projects', 'Projects'),
(3, 'ProgramInfo', 'Program Info'),
(4, 'Results', 'Results'),
(5, 'Reports', 'Reports'),
(6, 'Manage', 'Manage'),
(7, 'Configure', 'Configure')

alter table dbo.CustomPage add  FirmaMenuItemID int null
alter table dbo.CustomPage add constraint FK_CustomPage_FirmaMenuItem_FirmaMenuItemID foreign key(FirmaMenuItemID) references dbo.FirmaMenuItem(FirmaMenuItemID)
go

update dbo.CustomPage set FirmaMenuItemID = 1 -- About menu

alter table dbo.CustomPage alter column FirmaMenuItemID int not null