USE [CodeChallengeMaxi]
GO

/****** Object:  StoredProcedure [dbo].[SeleccionarEmpleado]    Script Date: 14/02/2024 10:50:49 a. m. ******/
DROP PROCEDURE [dbo].[SeleccionarEmpleado]
GO

/****** Object:  StoredProcedure [dbo].[SeleccionarEmpleado]    Script Date: 14/02/2024 10:50:49 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SeleccionarEmpleado] @IdEmpleado INT
AS
BEGIN
    
	select * from [dbo].[Empleados] (nolock) where [IdEmpleado] = @IdEmpleado
        
END;
GO


