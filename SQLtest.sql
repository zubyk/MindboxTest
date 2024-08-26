/*
	Для простоты не описываем FK и PK в ProductCategory, 
	не описываем прочие ограничения (на уникальность и IDENTITY в остальных таблицах).
*/

CREATE TABLE dbo.Products
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL
);

CREATE TABLE dbo.Category
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL
);

CREATE TABLE dbo.ProductCategory
(
	[ProductId] INT NOT NULL, 
    [CategoryId] INT NOT NULL
);

SELECT p.Name, c.Name
FROM dbo.Products p 
	LEFT JOIN dbo.ProductCategory pc ON p.Id = pc.ProductId
	LEFT JOIN dbo.Category c ON pc.CategoryId = c.Id;
	