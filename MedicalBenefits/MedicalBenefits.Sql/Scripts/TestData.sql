USE [MedicalBenefits]
GO

DELETE [dbo].[CostRules]

GO

DECLARE @mdId1 as uniqueidentifier = NEWID();  

INSERT INTO [dbo].[CostRules] VALUES (@mdId1, 1000.00, 500.00, 0.1, '1/1/2018', null, GETDATE(),N'TestData.sql',GETDATE(),N'TestData.sql')

GO 

SELECT * FROM [dbo].[CostRules]

