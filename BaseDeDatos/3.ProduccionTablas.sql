IF NOT EXISTS (
    SELECT TOP 1 1 FROM [INFORMATION_SCHEMA].[TABLES] WHERE 
    [TABLE_SCHEMA] = 'Produccion' AND [TABLE_NAME] = 'Fallas'
)
BEGIN
    CREATE TABLE [Produccion].[Fallas]
    (
        [Id] BIGINT IDENTITY NOT NULL PRIMARY KEY,
        [IdMaestroTipoFalla] BIGINT FOREIGN KEY REFERENCES [Maestros].[TipoFallas]([Id]) NOT NULL,
        [IdEstadosFalla] BIGINT FOREIGN KEY REFERENCES [Maestros].[EstadosFalla]([Id]) NOT NULL,
        [Observacion] NVARCHAR(100),
        [NombreIngreso] NVARCHAR(100) NOT NULL,
        [FechaIngreso] DATETIME NOT NULL DEFAULT GETDATE()
    )
END


IF NOT EXISTS (
    SELECT TOP 1 1 FROM [INFORMATION_SCHEMA].[TABLES] WHERE 
    [TABLE_SCHEMA] = 'Produccion' AND [TABLE_NAME] = 'SeguimientoFallas'
)
BEGIN
    CREATE TABLE [Produccion].[SeguimientoFallas]
    (
        [Id] BIGINT IDENTITY NOT NULL PRIMARY KEY,
        [IdFalla] BIGINT FOREIGN KEY REFERENCES [Produccion].[Fallas]([Id]) NOT NULL,
        [IdEstadosFalla] BIGINT FOREIGN KEY REFERENCES [Maestros].[EstadosFalla]([Id]) NOT NULL,
        [Observacion] NVARCHAR(100),
        [NombreIngreso] NVARCHAR(100) NOT NULL,
        [FechaIngreso] DATETIME NOT NULL DEFAULT GETDATE()
    )
END