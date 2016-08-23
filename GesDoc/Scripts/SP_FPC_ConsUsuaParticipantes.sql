USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_ConsUsuaParticipantes')
	DROP PROCEDURE [SP_FPC_ConsUsuaParticipantes]
GO

CREATE PROCEDURE [dbo].[SP_FPC_ConsUsuaParticipantes]  
 @iCodiOper bigint,       
 @ICodiUsu  bigint    
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
     
 IF (@iCodiOper <> 0)   
   BEGIN    
  Select UP.CodiOper, UP.CodiUsuPart, UP.TipoOper,    UP.TipoPart,     UP.ApruOper,  UP.EnviNoti,   UP.CodiUsu, UP.ConfLect  
  From UsuarioParticipante UP  
  Where UP.CodiOper = @iCodiOper  
   END  
 IF (@ICodiUsu <> 0)   
 BEGIN    
  Select UP.CodiOper, UP.CodiUsuPart, UP.TipoOper,    UP.TipoPart,     UP.ApruOper,  UP.EnviNoti,   UP.CodiUsu, UP.ConfLect  
  From UsuarioParticipante UP  
  Where UP.CodiUsuPart = @iCodiOper  
   END  
        
 SET NOCOUNT OFF                  
END     
    
