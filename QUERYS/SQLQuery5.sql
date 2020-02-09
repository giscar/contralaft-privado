W+++++++++++++++++++++++Script for SelectTopNRows command from SSMS  ******/GBNNNNNNNNNNNNNNNNNNNNNNNNN
SELECT TOP (1000) [N_ID_ACCION]
      ,[C_NUM_CODIGO]
      ,[C_DES_NOMBRE]
      ,[C_DES_DESCRIPCION]
      ,[N_FL_ACTIVO]
      ,[C_COD_ESTADO]
  FROM [privado].[dbo].[ACCION]