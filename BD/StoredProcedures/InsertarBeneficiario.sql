USE [CodeChallengeMaxi]
GO

/****** Object:  StoredProcedure [dbo].[InsertarBeneficiario]    Script Date: 14/02/2024 10:48:47 a. m. ******/
DROP PROCEDURE [dbo].[InsertarBeneficiario]
GO

/****** Object:  StoredProcedure [dbo].[InsertarBeneficiario]    Script Date: 14/02/2024 10:48:47 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertarBeneficiario]
	@IdEmpleado int,
    @Nombre NVARCHAR(50),
    @Apellidos NVARCHAR(150),
    @FechaNacimiento DATE,
    @CURP NVARCHAR(50),
    @SSN NVARCHAR(50),
    @Telefono NVARCHAR(50),
    @Nacionalidad NVARCHAR(50),
	@PorcentParticipacion INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        INSERT INTO [dbo].[Beneficiarios]
           ([IdEmpleado]
           ,[Nombre]
           ,[Apellidos]
           ,[FechaNacimiento]
           ,[CURP]
           ,[SSN]
           ,[Telefono]
           ,[Nacionalidad]
           ,[PorcentParticipacion])
     VALUES
           (@IdEmpleado
           ,@Nombre
           ,@Apellidos
           ,@FechaNacimiento
           ,@CURP
           ,@SSN
           ,@Telefono
           ,@Nacionalidad
           ,@PorcentParticipacion)

		select @@IDENTITY as 'IdBeneficiario'

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


