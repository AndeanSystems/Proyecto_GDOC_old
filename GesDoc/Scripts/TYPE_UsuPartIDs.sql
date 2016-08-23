USE [Gesdoc]
GO

/****** Object:  UserDefinedTableType [dbo].[UsuPartIDs]    Script Date: 11/14/2013 22:39:54 ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'UsuPartIDs' AND ss.name = N'dbo')
DROP TYPE [dbo].[UsuPartIDs]
GO

USE [Gesdoc]
GO

/****** Object:  UserDefinedTableType [dbo].[UsuPartIDs]    Script Date: 11/14/2013 22:39:54 ******/
CREATE TYPE [dbo].[UsuPartIDs] AS TABLE(
	[CodiUsuPart] [bigint] NULL
)
GO


