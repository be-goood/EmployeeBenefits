﻿CREATE TABLE [dbo].[Dependents]
(
	[Id]			UNIQUEIDENTIFIER CONSTRAINT [DF_Dependents_Id] NOT NULL,
	[EmployeeId]	UNIQUEIDENTIFIER NOT NULL,
	[FirstName]		NVARCHAR (256) NOT NULL,
	[LastName]		NVARCHAR (256) NOT NULL,
	[Ssn]			NVARCHAR (50) NOT NULL,
	[Dob]			DATETIME NOT NULL, 
	[DependentType] INT NULL, 
	[CreatedOn]		DATETIME NOT NULL, 
	[CreatedBy]		NVARCHAR (50) NOT NULL,
	[UpdatedOn]		DATETIME NOT NULL, 
	[UpdatedBy]		NVARCHAR (50) NOT NULL,

	CONSTRAINT [PK_Dependents] PRIMARY KEY ([Id]),
);

