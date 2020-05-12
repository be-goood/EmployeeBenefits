USE [Dependents]
GO

DELETE [dbo].[Dependents]

GO

DECLARE @dId1 as uniqueidentifier = NEWID();  
DECLARE @dId2 as uniqueidentifier = NEWID();  
DECLARE @dId3 as uniqueidentifier = NEWID();  
DECLARE @dId4 as uniqueidentifier = NEWID();  

INSERT INTO [dbo].[Dependents] VALUES (@dId1, '48694223-E058-47D4-9886-2374A460AE4B',  N'Daphne',N'Velazquez', '111-11-1111', '1/20/2013', 0, GETDATE(),N'TestData.sql',GETDATE(),N'TestData.sql')
INSERT INTO [dbo].[Dependents] VALUES (@dId2, '48694223-E058-47D4-9886-2374A460AE4B',  N'Heather',N'Velazquez', '000-00-0000', '1/20/1973', 1, GETDATE(),N'TestData.sql',GETDATE(),N'TestData.sql')

INSERT INTO [dbo].[Dependents] VALUES (@dId3, 'D97C9609-5A16-48E0-A346-A7141D638E9D',  N'Danny',N'Doe', '111-11-1111', '1/20/2013', 0, GETDATE(),N'TestData.sql',GETDATE(),N'TestData.sql')
INSERT INTO [dbo].[Dependents] VALUES (@dId4, 'D97C9609-5A16-48E0-A346-A7141D638E9D',  N'Emma',N'Doe', '000-00-0000', '1/20/1973', 1, GETDATE(),N'TestData.sql',GETDATE(),N'TestData.sql')

GO 

SELECT * FROM [dbo].[Dependents]
