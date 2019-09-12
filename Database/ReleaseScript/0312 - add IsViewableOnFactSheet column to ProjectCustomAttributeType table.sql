ALTER TABLE dbo.ProjectCustomAttributeType
ADD [IsViewableOnFactSheet] [bit] NULL;
GO

UPDATE dbo.ProjectCustomAttributeType
set IsViewableOnFactSheet = 0 where IsViewableOnFactSheet is null;
GO

ALTER TABLE dbo.ProjectCustomAttributeType
ALTER COLUMN IsViewableOnFactSheet [bit] NOT NULL;
