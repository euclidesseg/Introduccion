IF NOT EXISTS(
    SELECT TOP 1 1
    FROM [sys].[objects]
    WHERE [type] = 'P'
    AND [object_id] = OBJECT_ID('Maestros.SP_TipoFalla_Create')
)
    exec('CREATE PROCEDURE [Maestros].[SP_TipoFalla_Create] AS')
GO
-- procedimiento llenar tipo de fallas
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =========================================
-- Author: Euclides Segundo Perez
-- Date created: 26/12/22
-- Description: Procedimiento para rellenar tipo de fallas
-- Ejemplo: 
-- =========================================
ALTER PROCEDURE [Maestros].[SP_TipoFalla_Create](
	@Nombre nvarchar(30),
	@Descripcion nvarchar(30),
	@NombreIngreso nvarchar(100),
)
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON
-- DECLARACION VARIABLES
DECLARE @strMsg VARCHAR(2000)
DECLARE @IdTipoFalla BIGINT

BEGIN TRY
    BEGIN TRAN
        INSERT INTO [Maestros].[TipoFallas]( [Nombre], [Descripcion], [NombreIngreso])
        VALUES(@Nombre, @Descripcion, @NombreIngreso)

        SET @IdTipoFalla = (SELECT TOP 1 [Id] FROM [Maestros].[TipoFallas] ORDER BY [FechaIngreso] DESC)

    COMMIT TRAN

    SELECT 
        TIPOFALLAS.[Id],
        TIPOFALLAS.[Nombre],
        TIPOFALLAS.[Descripcion],
        TIPOFALLAS.[NombreIngreso],
        TIPOFALLAS.[FechaIngreso],
        TIPOFALLAS.[NombreActualizacion],
        TIPOFALLAS.[FechaActualizacion]
    FROM [Maestros].[TipoFallas] TIPOFALLAS
    WHERE TIPOFALLAS.[Id] = @IdTipoFalla

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRAN

    SET @strMsg = 'Se presento un error en el procedimiento: [Maestros].[SP_TipoFalla_Create] ' + ERROR_MESSAGE()
    RAISERROR(@strMsg, 16,1)
END CATCH
END
GO

-- =======================PROCEDIMIENTO ACTUALIZAR TIPOFALLAS=====================================

IF NOT EXISTS(
    SELECT TOP 1 1
    FROM [sys].[objects]
    WHERE [type] = 'P'
    AND [object_id] = OBJECT_ID('Maestros.SP_TipoFalla_Update')
)
    exec('CREATE PROCEDURE [Maestros].[SP_TipoFalla_Update] AS')
GO
-- procedimiento actualizar tipo de fallas
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =========================================
-- Author: Euclides Segundo Perez
-- Date created: 26/12/22
-- Description: Procedimiento para actualizar tipo de fallas
-- Ejemplo: 
-- =========================================
ALTER PROCEDURE [Maestros].[SP_TipoFalla_Update](
	@Descripcion nvarchar(30),
	@NombreActualizacion nvarchar(100),
    @IdTipoFalla BIGINT
)
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON
-- DECLARACION VARIABLES
DECLARE @strMsg VARCHAR(2000)

BEGIN TRY
    BEGIN TRAN

        UPDATE [Maestros].[TipoFallas]
        SET 
            [Maestros].[TipoFallas].[Descripcion] = @Descripcion,
            [Maestros].[TipoFallas].[NombreActualizacion] = @NombreActualizacion,
            [Maestros].[TipoFallas].[FechaActualizacion] = GETDATE()
        FROM [Maestros].[TipoFallas]
        WHERE [Maestros].[TipoFallas].[Id] = @IdTipoFalla

    COMMIT TRAN

    SELECT 
        TIPOFALLAS.[Id],
        TIPOFALLAS.[Nombre],
        TIPOFALLAS.[Descripcion],
        TIPOFALLAS.[NombreIngreso],
        TIPOFALLAS.[FechaIngreso],
        TIPOFALLAS.[NombreActualizacion],
        TIPOFALLAS.[FechaActualizacion]
    FROM [Maestros].[TipoFallas] TIPOFALLAS
    WHERE TIPOFALLAS.[Id] = @IdTipoFalla

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRAN

    SET @strMsg = 'Se presento un error en el procedimiento: [Maestros].[SP_TipoFalla_Update] ' + ERROR_MESSAGE()
    RAISERROR(@strMsg, 16,1)
END CATCH
END
GO

-- =======================OBTNER TODOS LOS REGISTROS DE TIPOFALLAS=====================================

IF NOT EXISTS(
    SELECT TOP 1 1
    FROM [sys].[objects]
    WHERE [type] = 'P'
    AND [object_id] = OBJECT_ID('Maestros.SP_TipoFallaa_GetAll')
)
    exec('CREATE PROCEDURE [Maestros].[SP_TipoFallaa_GetAll] AS')
GO
-- procedimiento actualizar tipo de fallas
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =========================================
-- Author: Euclides Segundo Perez
-- Date created: 26/12/22
-- Description: Procedimiento para actualizar tipo de fallas
-- Ejemplo: 
-- =========================================
ALTER PROCEDURE [Maestros].[SP_TipoFallaa_GetAll]
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON
-- DECLARACION VARIABLES
DECLARE @strMsg VARCHAR(2000)

BEGIN TRY
    BEGIN TRAN

    COMMIT TRAN

    SELECT 
        TIPOFALLAS.[Id],
        TIPOFALLAS.[Nombre],
        TIPOFALLAS.[Descripcion],
        TIPOFALLAS.[NombreIngreso],
        TIPOFALLAS.[FechaIngreso],
        TIPOFALLAS.[NombreActualizacion],
        TIPOFALLAS.[FechaActualizacion]
    FROM [Maestros].[TipoFallas] TIPOFALLAS

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRAN

    SET @strMsg = 'Se presento un error en el procedimiento: [Maestros].[SP_TipoFallaa_GetAll] ' + ERROR_MESSAGE()
    RAISERROR(@strMsg, 16,1)
END CATCH
END
GO