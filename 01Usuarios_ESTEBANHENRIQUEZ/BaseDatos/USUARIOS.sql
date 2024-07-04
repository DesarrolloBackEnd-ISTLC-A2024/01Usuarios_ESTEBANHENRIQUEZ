USE [PROYECTO_1]
GO

/****** Object:  Table [dbo].[USUARIOS]    Script Date: 27/6/2024 21:15:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[USUARIOS](
	[ID_USUARIO] [int] NOT NULL,
	[CODIGO] [varchar](20) NULL,
	[NOMBRES] [varchar](100) NULL,
	[APELLIDOS] [varchar](100) NULL,
	[MAIL] [varchar](100) NULL,
	[FECHA_NACIMIENTO] [datetime] NULL,
	[CONTRASENA] [varchar](100) NULL,
	[ESTADO] [varchar](1) NULL,
	[FECHA_ULTIMA_CONEXION] [datetime] NULL,
	[USUARIO_CREACION] [int] NULL,
	[FECHA_CREACION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

