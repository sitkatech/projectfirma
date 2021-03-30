-- This is a partial placeholder for Reclamation work. Talk to SLG & MF if you have a problem or are curious.


-- Is a given Tenant using Keystone, or the new self-auth method?
DROP TABLE IF EXISTS dbo.FirmaSystemAuthenticationType
GO

CREATE TABLE dbo.FirmaSystemAuthenticationType
(
    FirmaSystemAuthenticationTypeID [int] NOT NULL,
    FirmaSystemAuthenticationTypeName [varchar](100) NOT NULL,
    FirmaSystemAuthenticationTypeDisplayName [varchar](100) NOT NULL
)
GO

ALTER TABLE [dbo].FirmaSystemAuthenticationType ADD  CONSTRAINT [PK_FirmaSystemAuthenticationType_FirmaSystemAuthenticationTypeID] PRIMARY KEY CLUSTERED 
(
    FirmaSystemAuthenticationTypeID ASC
) ON [PRIMARY]
GO


ALTER TABLE [dbo].FirmaSystemAuthenticationType ADD  CONSTRAINT [AK_FirmaSystemAuthenticationType_FirmaSystemAuthenticationTypeDisplayName] UNIQUE NONCLUSTERED 
(
    FirmaSystemAuthenticationTypeDisplayName ASC
) ON [PRIMARY]
GO