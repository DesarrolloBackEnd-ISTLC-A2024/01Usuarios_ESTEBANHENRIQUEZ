USE [PROYECTO_1]
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_USUARIOU]    Script Date: 01/07/2024 02:55:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_GET_USUARIOU]
  @PI_ID_USUARIO INTEGER

AS
	
BEGIN
   SELECT * FROM USUARIOS WHERE ID_USUARIO=@PI_ID_USUARIO;


END