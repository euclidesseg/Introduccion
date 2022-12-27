IF NOT EXISTS (
    SELECT TOP 1 1 FROM [INFORMATION_SCHEMA].[TABLES] WHERE 
    [TABLE_SCHEMA] = 'Maestros' AND [TABLE_NAME] = 'TipoFallas'
)
BEGIN
    CREATE TABLE [Maestros].[TipoFallas]
    (
        [Id] BIGINT IDENTITY NOT NULL PRIMARY KEY,
        [Nombre] NVARCHAR(30) NOT NULL,
        [Descripcion] NVARCHAR(100),
        [NombreIngreso] NVARCHAR(100) NOT NULL,
        [FechaIngreso] DATETIME NOT NULL DEFAULT GETDATE(),
        [NombreActualizacion] NVARCHAR(100),
        [FechaActualizacion] DATETIME
    )
END

IF NOT EXISTS (
    SELECT TOP 1 1 FROM [INFORMATION_SCHEMA].[TABLES] WHERE 
    [TABLE_SCHEMA] = 'Maestros' AND [TABLE_NAME] = 'EstadosFalla'
)
BEGIN
    CREATE TABLE [Maestros].[EstadosFalla]
    (   
        [Id] BIGINT IDENTITY NOT NULL PRIMARY KEY,
        [Estado] NVARCHAR(30) NOT NULL,
        [Descripcion] NVARCHAR(100),
        [ValorNumerico] INT NOT NULL,
        [NombreIngreso] NVARCHAR(100) NOT NULL,
        [FechaIngreso] DATETIME NOT NULL DEFAULT GETDATE(),
        [NombreActualizacion] NVARCHAR(100),
        [FechaActualizacion] DATETIME
    )
END