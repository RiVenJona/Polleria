USE [Polleria]
GO
/****** Object:  StoredProcedure [dbo].[BuscaReservaRec]    Script Date: 27/04/2023 17:19:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BuscaReservaRec](
@DNI int
)
AS BEGIN
SELECT
T0.NumOrdenRe
,CONVERT(varchar,T0.FechaProgra,101) as 'FechaProgra'
,T4.DNI
,T4.Nombre
,T4.Apellidos
,T5.DescHorario
,T4.Telefono
,T4.correo
,T0.IdMesa
,T2.Espacios
,T1.DescEstado
from OrdenReserva T0
INNER JOIN Estado T1 ON T0.EstadoOrden=T1.EstadoId
INNER JOIN Mesas T2 ON T0.IdMesa=T2.IdMesa
INNER JOIN Cliente t3 ON T0.IdCliente=T3.IdCliente
INNER JOIN Persona T4 ON T3.PersonaID=T4.PersonaId
INNER JOIN Horario T5 ON T0.IdHorario=T5.IdHorario
WHERE T4.DNI=@DNI AND T0.FechaProgra=CONVERT(CHAR(10),GETDATE(),112)
END