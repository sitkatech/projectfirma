
CREATE TABLE [dbo].FirmaSession
(
    FirmaSessionID [int] IDENTITY(1,1) NOT NULL,
    FirmaSessionGuid [uniqueidentifier] NOT NULL,
    -- These should all agree - you can't impersonate across tenants
    TenantID int not null,
    -- Session could be anonymous, in which case there's no person
    PersonID [int] NULL,
    OriginalPersonID [int]  NULL,
    CreateDate datetime not null,
 CONSTRAINT [PK_FirmaSession_FirmaSessionID] PRIMARY KEY CLUSTERED 
(
	FirmaSessionID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_FirmaSession_FirmaSessionGuid] UNIQUE NONCLUSTERED 
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
ALTER TABLE [dbo].FirmaSession  WITH CHECK ADD  CONSTRAINT [FK_FirmaSession_OrignalPerson_OriginalPersonID] FOREIGN KEY(OriginalPersonID)
REFERENCES [dbo].Person (PersonID)
GO



GO

