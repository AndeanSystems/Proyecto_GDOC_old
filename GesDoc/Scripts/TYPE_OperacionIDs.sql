USE [Gesdoc]
GO

/****** Object:  UserDefinedTableType [dbo].[OperacionIDs]    Script Date: 11/14/2013 22:38:51 ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'OperacionIDs' AND ss.name = N'dbo')
DROP TYPE [dbo].[OperacionIDs]
GO

USE [Gesdoc]
GO

/****** Object:  UserDefinedTableType [dbo].[OperacionIDs]    Script Date: 11/14/2013 22:38:51 ******/
CREATE TYPE [dbo].[OperacionIDs] AS TABLE(
	[CodiOper] [bigint] NULL
)
GO


