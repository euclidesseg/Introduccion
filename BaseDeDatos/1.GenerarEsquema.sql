--Creacion esquema de Maestros
IF NOT EXISTS(SELECT * FROM sys.schemas WHERE name = N'Maestros')
BEGIN
    EXEC sys.sp_executesql N'CREATE SCHEMA [Maestros]'
END
GO

--Creacion esquema de produccion
IF NOT EXISTS(SELECT * FROM sys.schemas WHERE name = N'Produccion')
BEGIN
    EXEC sys.sp_executesql N'CREATE SCHEMA [Produccion]'
END
GO