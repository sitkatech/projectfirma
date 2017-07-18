ALTER TABLE dbo.TenantAttribute ADD RecaptchaPublicKey varchar(100) null, RecaptchaPrivateKey varchar(100) null;
GO

UPDATE dbo.TenantAttribute SET RecaptchaPublicKey = '6LfZQQoUAAAAAIJ_2lD6ct0lBHQB9j5kv8p994SP' WHERE TenantID = 1;
UPDATE dbo.TenantAttribute SET RecaptchaPrivateKey = '6LfZQQoUAAAAAOeNQDcXlTV9JM7PBQE3jCqlDBSB' WHERE TenantID = 1;

UPDATE dbo.TenantAttribute SET RecaptchaPublicKey = '6LfSQQoUAAAAAFHpdE_ueMs4ptzC7zRzvWpdaeZp' WHERE TenantID = 2;
UPDATE dbo.TenantAttribute SET RecaptchaPrivateKey = '6LfSQQoUAAAAAJWSKhiXBLvd3JPbHgcrGOes6t5K' WHERE TenantID = 2;

UPDATE dbo.TenantAttribute SET RecaptchaPublicKey = '6Le8KCkUAAAAAEls-flsHxSH2pT83XOp5yAiSM7M' WHERE TenantID = 3;
UPDATE dbo.TenantAttribute SET RecaptchaPrivateKey = '6Le8KCkUAAAAAB-2mpnVpwQeNXqQuqumNad5tKZ2' WHERE TenantID = 3;
