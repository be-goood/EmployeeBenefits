USE [Employees]
GO

DELETE [dbo].[Employees]
DELETE [dbo].[Salaries]

GO

DECLARE @empId1 as uniqueidentifier = NEWID();  
DECLARE @empId2 as uniqueidentifier = NEWID();  
DECLARE @sId1 as uniqueidentifier = NEWID();  
DECLARE @sId2 as uniqueidentifier = NEWID();  

INSERT INTO [dbo].[Employees] VALUES (@empId1, N'Jorge',N'Velazquez',GETDATE(),N'TestData.sql',GETDATE(),N'TestData.sql')
INSERT INTO [dbo].[Employees] VALUES (@empId2, N'Jon',N'Doe',GETDATE(),N'TestData.sql',GETDATE(),N'TestData.sql')

INSERT INTO [dbo].[Salaries] VALUES (@sId1, @empId1, 125000, '1/1/2019','12/31/2019', GETDATE(),N'TestData.sql',GETDATE(),N'TestData.sql')
INSERT INTO [dbo].[Salaries] VALUES (@sId2, @empId2, 150000, '1/1/2020', null, GETDATE(),N'TestData.sql',GETDATE(),N'TestData.sql')

GO 

SELECT * FROM [dbo].[Employees]
SELECT * FROM [dbo].[Salaries]