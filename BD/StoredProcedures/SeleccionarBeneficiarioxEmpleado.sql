USE [CodeChallengeMaxi]
GO

/****** Object:  StoredProcedure [dbo].[SeleccionarBeneficiarioxEmpleado]    Script Date: 14/02/2024 10:50:30 a. m. ******/
DROP PROCEDURE [dbo].[SeleccionarBeneficiarioxEmpleado]
GO

/****** Object:  StoredProcedure [dbo].[SeleccionarBeneficiarioxEmpleado]    Script Date: 14/02/2024 10:50:30 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[SeleccionarBeneficiarioxEmpleado] @IdEmpleado INT
AS
BEGIN
    
	select * from [dbo].[Beneficiarios] (nolock) where [IdEmpleado] = @IdEmpleado
        
END;
GO


