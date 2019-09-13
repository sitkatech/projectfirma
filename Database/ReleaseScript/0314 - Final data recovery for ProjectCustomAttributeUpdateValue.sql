IF NOT EXISTS
    (
    select * from ProjectCustomAttributeUpdateValue
    where ProjectCustomAttributeUpdateID in (4845, 5516)
    )
 BEGIN

    -- We accidentally deleted more than we should for this multiple-choice entry. Ooops.
    INSERT INTO ProjectCustomAttributeUpdateValue (TenantID, ProjectCustomAttributeUpdateID, AttributeValue)
    VALUES 
    ( 11, 4845, '1367075'),
    ( 12, 5516, 'Water Leases'),
    ( 12, 5516, 'Cultural Survey'),
    ( 12, 5516,'Easements'),
    ( 12, 5516,'Utility'),
    ( 12, 5516,'Highway Right of Way')

end