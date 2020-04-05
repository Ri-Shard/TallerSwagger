CREATE DATABASE [Copago];
USE  [Copago]

CREATE TABLE [dbo].[Pacientes](
	[Identificacion] [nvarchar](10) NOT NULL PRIMARY KEY,
	[Nombre] [nvarchar](50) NULL,
	[ValorServ] [numeric] NULL,
	[Salario] [numeric] NULL,
	[Copago] [numeric] NULL,
) 
GO

COMMIT