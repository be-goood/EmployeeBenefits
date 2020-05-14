CREATE TABLE [dbo].[CostRules]
(
	[Id]					UNIQUEIDENTIFIER CONSTRAINT [DF_CostRules_Id]  NOT NULL,
	[BaseEmployeeCost]		MONEY NOT NULL,
	[BaseDependentCost]		MONEY NOT NULL,
	[DiscountPercentage]	MONEY NOT NULL,
	[BeginDate]				DATETIME NOT NULL, 
	[EndDate]				DATETIME NULL, 
	[CreatedOn]				DATETIME NOT NULL, 
	[CreatedBy]				NVARCHAR (50) NOT NULL,
	[UpdatedOn]				DATETIME NOT NULL, 
	[UpdatedBy]				NVARCHAR (50) NOT NULL,

	CONSTRAINT [PK_CostRules] PRIMARY KEY ([Id])
);
