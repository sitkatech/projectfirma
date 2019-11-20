
ALTER TABLE [dbo].[OrganizationRelationshipType]  WITH CHECK ADD  CONSTRAINT [CK_OrganizationRelationshipType_CanOnlyBeRelatedOnceToAProjectMustBeTrueIfIsPrimaryContact] 

CHECK  ((IsPrimaryContact = 1 and CanOnlyBeRelatedOnceToAProject = 1) or (  IsPrimaryContact = 0 ))
GO

ALTER TABLE [dbo].[OrganizationRelationshipType] CHECK CONSTRAINT [CK_OrganizationRelationshipType_CanOnlyBeRelatedOnceToAProjectMustBeTrueIfIsPrimaryContact]
GO

