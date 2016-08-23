USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_UpdateUsuarioParticipante')
	DROP PROCEDURE [SP_FPC_UpdateUsuarioParticipante]
GO

CREATE PROCEDURE [dbo].[SP_FPC_UpdateUsuarioParticipante]          
(          
 @iCodiUsuPart bigint,  
 @cTipoOper  char(2),         
 @iCodiOper  bigint,        
 @cTipoPart  char(3),        
 @iCodiUsu bigint,      
 @cConfLect char(1)
)          
AS      
BEGIN          
   /* Si Existe registro Actualiza */ 
  Begin         
        
   UPDATE UsuarioParticipante
      SET  ConfLect = @cConfLect
    Where CodiOper = @iCodiOper         
      and CodiUsu = @iCodiUsu      
    
  End        
END          
        
