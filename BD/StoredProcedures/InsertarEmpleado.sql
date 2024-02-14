USE [CodeChallengeMaxi]
GO

/****** Object:  StoredProcedure [dbo].[InsertarEmpleado]    Script Date: 14/02/2024 10:49:10 a. m. ******/
DROP PROCEDURE [dbo].[InsertarEmpleado]
GO

/****** Object:  StoredProcedure [dbo].[InsertarEmpleado]    Script Date: 14/02/2024 10:49:10 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertarEmpleado]
    @Nombre NVARCHAR(50),
    @Apellidos NVARCHAR(150),
    @FechaNacimiento DATE,
    @NEmpleado INT,
    @CURP NVARCHAR(50),
    @SSN NVARCHAR(50),
    @Telefono NVARCHAR(50),
    @Nacionalidad NVARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        INSERT INTO [dbo].[Empleados]
           ([Nombre]
           ,[Apellidos]
           ,[FechaNacimiento]
           ,[NEmpleado]
           ,[CURP]
           ,[SSN]
           ,[Telefono]
           ,[Nacionalidad])
     VALUES
           (@Nombre, @Apellidos, @FechaNacimiento, @NEmpleado, @CURP, @SSN, @Telefono, @Nacionalidad);

		select @@IDENTITY as 'IdEmpleado'

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


