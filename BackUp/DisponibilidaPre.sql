USE [Polleria]
GO
/****** Object:  StoredProcedure [dbo].[DisponibilidadPre]    Script Date: 27/04/2023 17:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DisponibilidadPre]
AS
BEGIN
SELECT 
IdMesa
FROM
MESAS
WHERE
Estado<>8
END
