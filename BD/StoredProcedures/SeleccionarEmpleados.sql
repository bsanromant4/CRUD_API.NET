USE [CodeChallengeMaxi]
GO

/****** Object:  StoredProcedure [dbo].[SeleccionarEmpleados]    Script Date: 14/02/2024 10:51:07 a. m. ******/
DROP PROCEDURE [dbo].[SeleccionarEmpleados]
GO

/****** Object:  StoredProcedure [dbo].[SeleccionarEmpleados]    Script Date: 14/02/2024 10:51:07 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SeleccionarEmpleados]
AS
BEGIN
    
	select * from [dbo].[Empleados] (nolock) 
        
END;
GO


