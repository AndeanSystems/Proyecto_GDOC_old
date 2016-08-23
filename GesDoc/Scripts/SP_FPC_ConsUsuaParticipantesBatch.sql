USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_ConsUsuaParticipantesBatch')
	DROP PROCEDURE [SP_FPC_ConsUsuaParticipantesBatch]
GO

CREATE PROCEDURE [dbo].[SP_FPC_ConsUsuaParticipantesBatch]   
 @listCodiOper AS dbo.OperacionIDs READONLY,      
 @listCodiUsu AS dbo.UsuPartIDs READONLY
AS                  
    
/***************************************                  
*Descripcion: Consulta Tabla de Usuarios PArticipantes  
*Parametros :   
* @iCodUsu    : Código interno numerico    
* @sIdeUsu    : Id Usuario    
*Autor      : Alex Pacaya    
*Cambios Importantes:    
***************************************/                  
BEGIN                  
 SET NOCOUNT ON                      
     
  
  Select UP.CodiOper, UP.CodiUsuPart, UP.TipoOper,    UP.TipoPart,     UP.ApruOper,  UP.EnviNoti,   UP.CodiUsu, UP.ConfLect    
  From UsuarioParticipante UP 
  INNER JOIN  @listCodiOper AS B ON UP.CodiOper = B.CodiOper  
  
  UNION
   
  Select UP.CodiOper, UP.CodiUsuPart, UP.TipoOper,    UP.TipoPart,     UP.ApruOper,  UP.EnviNoti,   UP.CodiUsu, UP.ConfLect    
  From UsuarioParticipante UP    
  INNER JOIN  @listCodiUsu AS B ON UP.CodiUsuPart = B.CodiUsuPart
 
        
 SET NOCOUNT OFF                  
END     
    