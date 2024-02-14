USE [CodeChallengeMaxi]
GO

/****** Object:  StoredProcedure [dbo].[ActualizarBeneficiario]    Script Date: 14/02/2024 10:46:53 a. m. ******/
DROP PROCEDURE [dbo].[ActualizarBeneficiario]
GO

/****** Object:  StoredProcedure [dbo].[ActualizarBeneficiario]    Script Date: 14/02/2024 10:46:53 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[ActualizarBeneficiario]
	@IdBeneficiario INT,
	@IdEmpleado INT,
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
        UPDATE [dbo].[Beneficiarios]
		   SET [Nombre] = @Nombre
			  ,[Apellidos] = @Apellidos
			  ,[FechaNacimiento] = @FechaNacimiento
			  ,[CURP] = @CURP
			  ,[SSN] = @SSN
			  ,[Telefono] = @Telefono
			  ,[Nacionalidad] = @Nacionalidad
			  ,[PorcentParticipacion] = @PorcentParticipacion
				   where IdBeneficiario = @IdBeneficiario

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


