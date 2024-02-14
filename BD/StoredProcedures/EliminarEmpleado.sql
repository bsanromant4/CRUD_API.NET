USE [CodeChallengeMaxi]
GO

/****** Object:  StoredProcedure [dbo].[EliminarEmpleado]    Script Date: 14/02/2024 10:48:20 a. m. ******/
DROP PROCEDURE [dbo].[EliminarEmpleado]
GO

/****** Object:  StoredProcedure [dbo].[EliminarEmpleado]    Script Date: 14/02/2024 10:48:20 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EliminarEmpleado] @IdEmpleado INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY

		IF EXISTS (SELECT 1 FROM [dbo].[Empleados] WHERE [IdEmpleado] = @IdEmpleado)
			DELETE FROM [dbo].[Empleados] WHERE [IdEmpleado] = @IdEmpleado
		ELSE
			RAISERROR ('El empleado indicado no existe', 16, 1);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH

		IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO


