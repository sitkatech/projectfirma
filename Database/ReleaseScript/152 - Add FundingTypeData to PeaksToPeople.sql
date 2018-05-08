
INSERT INTO dbo.FundingTypeData
           (TenantID, FundingTypeID, FundingTypeDisplayName, FundingTypeShortName, SortOrder)
     VALUES
           (6,1,'One-time', 'One-time', 10),
		   (6,2,'Multi-year', 'Multi-year', 20)
           
GO


select * from dbo.FundingTypeData

