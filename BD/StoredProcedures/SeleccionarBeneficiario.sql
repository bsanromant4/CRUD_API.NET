USE [CodeChallengeMaxi]
GO

/****** Object:  StoredProcedure [dbo].[SeleccionarBeneficiario]    Script Date: 14/02/2024 10:49:57 a. m. ******/
DROP PROCEDURE [dbo].[SeleccionarBeneficiario]
GO

/****** Object:  StoredProcedure [dbo].[SeleccionarBeneficiario]    Script Date: 14/02/2024 10:49:57 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SeleccionarBeneficiario] @IdBeneficiario INT
AS
BEGIN
    
	select * from [dbo].[Beneficiarios] (nolock) where [IdBeneficiario] = @IdBeneficiario
        
END;
GO


