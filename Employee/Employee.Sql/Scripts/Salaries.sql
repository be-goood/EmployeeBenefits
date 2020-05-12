CREATE TABLE [dbo].[Salaries]
(
	[Id]			UNIQUEIDENTIFIER CONSTRAINT [DF_Dependents_Id] NOT NULL,
	[EmployeeId]	UNIQUEIDENTIFIER NOT NULL,
	[YearlyWages]	MONEY NOT NULL,
	[StartDate]		DATETIME NOT NULL, 
	[EndDate]		DATETIME NULL, 
	[CreatedOn]		DATETIME NOT NULL, 
	[CreatedBy]		NVARCHAR (50) NOT NULL,
	[UpdateOn]		DATETIME NOT NULL, 
	[UpdatedBy]		NVARCHAR (50) NOT NULL,

	CONSTRAINT [PK_Salaries] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Salaries_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id])
);
