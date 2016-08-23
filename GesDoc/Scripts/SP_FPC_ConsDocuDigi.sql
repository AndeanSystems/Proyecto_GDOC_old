USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_ConsDocuDigi')
	DROP PROCEDURE [SP_FPC_ConsDocuDigi]
GO

CREATE PROCEDURE [dbo].[SP_FPC_ConsDocuDigi]        
(    
@sEstDocuDigi      Char(1),    
@iCodiOper         Bigint,        
@iNumDocu          Char(20),    
@iCodiUsu          Bigint     
)    
AS                  
                  
/***************************************                  
*Descripcion        : Consulta Tabla de Documento Digital    
*Autor              : Alex Pacaya    
*Cambios Importantes:    
***************************************/                  
BEGIN                  
 SET NOCOUNT ON                      
     
 IF (@iNumDocu <> '')    
   BEGIN    
    
  Select  DD.CodiDocuDigi,  DD.TituDocuDigi,  DD.AsunDocuDigi,      
    DD.NombOrig,   DD.RutaFisi,   DD.TamaDocu,       
    DD.ExteDocu,   DD.NombFisi,   DD.ClasDocu,       
    DD.EstDocuDigi,   DD.FechEmiDocu,   DD.FechRece,       
    DD.FechRegi,   DD.FechActu,   DD.AcceDocuDigi,      
    DD.CodiTipoDocu,  DD.NumDocuDigi,    
    UP.TipoOper,   UP.TipoPart,   UP.ApruOper,    
    UP.EnviNoti,   UP.FechNoti,   UP.CodiUsu, 
    DD.Comentario   
    
    From  DocumentoDigital DD    
   INNER  JOIN UsuarioParticipante UP ON ( DD.CodiDocuDigi = UP.CodiOper )    
    
   Where  NumDocuDigi = @iNumDocu    
   and DD.EstDocuDigi in ('C','E')    
   and UP.EstaUsuaPart='A'    
   --  Solo retorna usuarios Tipo Participacion = Destinatario    
   --and UP.TipoPart = 7    
    
   END    
 ELSE IF (@iCodiOper <> 0 )    
    
   BEGIN    
  Select  DD.CodiDocuDigi,  DD.TituDocuDigi,  DD.AsunDocuDigi,      
    DD.NombOrig,   DD.RutaFisi,   DD.TamaDocu,       
    DD.ExteDocu,   DD.NombFisi,   DD.ClasDocu,       
    DD.EstDocuDigi,   DD.FechEmiDocu,   DD.FechRece,       
    DD.FechRegi,   DD.FechActu,   DD.AcceDocuDigi,      
    DD.CodiTipoDocu,  DD.NumDocuDigi,    
    UP.TipoOper,   UP.TipoPart,   UP.ApruOper,    
    UP.EnviNoti,   UP.FechNoti,   UP.CodiUsu,
    DD.Comentario
    From  DocumentoDigital DD    
   INNER  JOIN UsuarioParticipante UP ON ( DD.CodiDocuDigi = UP.CodiOper )    
    
   Where  CodiDocuDigi = @iCodiOper    
   and DD.EstDocuDigi in ('C','E')    
   and UP.EstaUsuaPart='A'    
   --  Solo retorna usuarios Tipo Participacion = Destinatario    
   --and UP.TipoPart = 7    
    
      END    
        
 SET NOCOUNT OFF                  
END  