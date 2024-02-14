USE [CodeChallengeMaxi]
GO

/****** Object:  StoredProcedure [dbo].[EliminarBeneficiario]    Script Date: 14/02/2024 10:47:50 a. m. ******/
DROP PROCEDURE [dbo].[EliminarBeneficiario]
GO

/****** Object:  StoredProcedure [dbo].[EliminarBeneficiario]    Script Date: 14/02/2024 10:47:50 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[EliminarBeneficiario] @IdBeneficiario INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY

		IF EXISTS (SELECT 1 FROM [dbo].[Beneficiarios] WHERE [IdBeneficiario] = @IdBeneficiario)
			DELETE FROM [dbo].[Beneficiarios] WHERE [IdBeneficiario] = @IdBeneficiario
		ELSE
			RAISERROR ('El beneficiario indicado no existe', 16, 1);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH

		IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO


