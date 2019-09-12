ALTER TABLE dbo.ProjectCustomAttributeType
ADD [IsViewableOnFactSheet] [bit] NULL;

UPDATE dbo.ProjectCustomAttributeType
set IsViewableOnFactSheet = 0 where IsViewableOnFactSheet is null;

ALTER TABLE dbo.ProjectCustomAttributeType
ALTER COLUMN IsViewableOnFactSheet [bit] NOT NULL;
