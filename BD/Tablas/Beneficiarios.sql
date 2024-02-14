USE [CodeChallengeMaxi]
GO

/****** Object:  Table [dbo].[Beneficiarios]    Script Date: 14/02/2024 10:41:23 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Beneficiarios]') AND type in (N'U'))
DROP TABLE [dbo].[Beneficiarios]
GO

/****** Object:  Table [dbo].[Beneficiarios]    Script Date: 14/02/2024 10:41:23 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Beneficiarios](
	[IdBeneficiario] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellidos] [nvarchar](150) NULL,
	[FechaNacimiento] [date] NULL,
	[CURP] [nvarchar](50) NULL,
	[SSN] [nvarchar](50) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Nacionalidad] [nvarchar](50) NULL,
	[PorcentParticipacion] [int] NULL,
 CONSTRAINT [IdBeneficiario] PRIMARY KEY CLUSTERED 
(
	[IdBeneficiario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


