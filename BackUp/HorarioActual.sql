USE [Polleria]
GO
/****** Object:  StoredProcedure [dbo].[HoraHorario]    Script Date: 27/04/2023 17:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[HoraHorario]
AS
BEGIN
DECLARE @Horario varchar(40)
/*DECLARE @Id int*/
SET @Horario=(
Select 
case 
when (select CONVERT(varchar,GETDATE(),108))BETWEEN '09:00' and '10:59:59' then (SELECT DescHorario FROM Horario WHERE Idhorario=1)  
when (select CONVERT(varchar,GETDATE(),108))BETWEEN '11:00' and '12:59:59' then (SELECT DescHorario FROM Horario WHERE Idhorario=2)
when (select CONVERT(varchar,GETDATE(),108))BETWEEN '13:00' and '14:59:59' then (SELECT DescHorario FROM Horario WHERE Idhorario=3) 
when (select CONVERT(varchar,GETDATE(),108))BETWEEN '15:00' and '16:59:59' then (SELECT DescHorario FROM Horario WHERE Idhorario=4) 
when (select CONVERT(varchar,GETDATE(),108))BETWEEN '17:00' and '18:59:59' then (SELECT DescHorario FROM Horario WHERE Idhorario=5) 
when (select CONVERT(varchar,GETDATE(),108))BETWEEN '19:00' and '20:59:59' then (SELECT DescHorario FROM Horario WHERE Idhorario=6) 
when (select CONVERT(varchar,GETDATE(),108))BETWEEN '21:00' and '22:59:59' then (SELECT DescHorario FROM Horario WHERE Idhorario=7)
END
)
/*SET @Id=(
SELECT 
CASE
WHEN @Horario='09:00 - 11:00' THEN 1 
WHEN @Horario='11:00 - 13:00' THEN 2 
WHEN @Horario='13:00 - 15:00' THEN 3 
WHEN @Horario='15:00 - 17:00' THEN 4 
WHEN @Horario='17:00 - 19:00' THEN 5 
WHEN @Horario='19:00 - 21:00' THEN 6
WHEN @Horario='21:00 - 23:00' THEN 7 
END
)*/
select 
/*@Id as 'Id'
,*/@Horario as 'Horario'
END