
CREATE TABLE [dbo].FirmaSession
(
    FirmaSessionID [int] IDENTITY(1,1) NOT NULL,
    TenantID int not null,
    FirmaSessionGuid [uniqueidentifier] NOT NULL,
    -- Session could be anonymous, in which case there's no person
    PersonID [int] NULL,
    -- May not be impersonating
    OriginalPersonID [int]  NULL,
    CreateDate datetime not null,
 CONSTRAINT [PK_FirmaSession_FirmaSessionID] PRIMARY KEY CLUSTERED 
(
    FirmaSessionID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT AK_FirmaSession_FirmaSessionGuid UNIQUE NONCLUSTERED 
(
    FirmaSessionGuid ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

-- FK to Tenant
ALTER TABLE [dbo].FirmaSession  WITH CHECK ADD  CONSTRAINT [FK_FirmaSession_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

-- FK to current Person 
ALTER TABLE [dbo].FirmaSession  WITH CHECK ADD  CONSTRAINT [FK_FirmaSession_Person_PersonID] FOREIGN KEY(PersonID)
REFERENCES [dbo].Person (PersonID)
GO

-- FK to original Person (relevant if impersonating)
ALTER TABLE [dbo].FirmaSession  WITH CHECK ADD  CONSTRAINT FK_FirmaSession_Person_OriginalPersonID_PersonID FOREIGN KEY(OriginalPersonID)
REFERENCES [dbo].Person (PersonID)
GO

alter table dbo.FirmaSession add constraint FK_FirmaSession_Person_PersonID_TenantID foreign key (PersonID, TenantID) references dbo.Person(PersonID, TenantID)
GO

alter table dbo.FirmaSession add constraint FK_FirmaSession_Person_OriginalPersonID_TenantID_PersonID_TenantID foreign key (OriginalPersonID, TenantID) references dbo.Person(PersonID, TenantID)
GO