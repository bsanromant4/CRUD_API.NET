USE [CodeChallengeMaxi]
GO

/****** Object:  StoredProcedure [dbo].[ActualizarEmpleado]    Script Date: 14/02/2024 10:47:24 a. m. ******/
DROP PROCEDURE [dbo].[ActualizarEmpleado]
GO

/****** Object:  StoredProcedure [dbo].[ActualizarEmpleado]    Script Date: 14/02/2024 10:47:24 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ActualizarEmpleado]
    @Nombre NVARCHAR(50),
    @Apellidos NVARCHAR(150),
    @FechaNacimiento DATE,
    @NEmpleado INT,
    @CURP NVARCHAR(50),
    @SSN NVARCHAR(50),
    @Telefono NVARCHAR(50),
    @Nacionalidad NVARCHAR(50),
	@IdEmpleado INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        UPDATE [dbo].[Empleados]
		   SET [Nombre] = @Nombre
			  ,[Apellidos] = @Apellidos
			  ,[FechaNacimiento] = @FechaNacimiento
			  ,[NEmpleado] = @NEmpleado
			  ,[CURP] = @CURP
			  ,[SSN] = @SSN
			  ,[Telefono] = @Telefono
			  ,[Nacionalidad] = @Nacionalidad
				   where IdEmpleado = @IdEmpleado

        -- Commit de la transacción si todo ha ido bien
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback de la transacción si hay algún error
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO


