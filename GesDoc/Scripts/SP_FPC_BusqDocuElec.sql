USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_BusqDocuElec')
	DROP PROCEDURE [SP_FPC_BusqDocuElec]
GO

/**************************************************************************************/  
CREATE PROCEDURE [dbo].[SP_FPC_BusqDocuElec]    
(    
 @sAsunto  varchar(max),    
 @sTipoDocu  char(2),    
 @dFecIni  datetime = '',    
 @dFecFin  datetime = '',    
 @iCodiUsuRem Bigint,    
 @iCodiUsuDes Bigint,    
 @iTipoBusq  smallint     
)    
AS                  
/*****************************************************************    
*Descripcion        : Busqueda de Documentos Electronicos    
*Autor              : Alex Pacaya    
*Cambios Importantes:    
******************************************************************/    
BEGIN                  
 SET NOCOUNT ON                      
  
 --Busqueda por todos los criterios en forma complementaria    
 IF (@iTipoBusq = 0)    
 BEGIN    
  select distinct DE.CodiDocuElec,   
      DE.NumDocuElec,   
      AsunDocuElec [AsunDocuElec],   
      DE.CodiTipoDocu,   
      TD.NombTipoDocu as TipoDocu,  
      FechEmi,   
      PrioDocuElec,   
      estdocuElec  
  From  DocumentoElectronico DE    
  INNER JOIN TIPODOCUMENTO  TD   ON (DE.CODITIPODOCU=TD.CODITIPODOCU)    
  Where    
  CASE WHEN ( @sAsunto = '' )  THEN '' ELSE DE.AsunDocuElec END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' AND    
  --Excluye Tipo de Documentos AA=Todos    
  CASE WHEN ( @sTipoDocu = 'AA' ) THEN '' ELSE DE.CodiTipoDocu END  =  CASE WHEN (@sTipoDocu = 'AA') THEN '' ELSE @sTipoDocu END AND    
  -- Rango de Fecha "@dFecIni" a "@dFecFin"  
  ( CASE WHEN ( @dFecIni = '' )  THEN '' ELSE convert(varchar,DE.FechEmi,112)  END >= CASE WHEN (@dFecIni = '') THEN '' ELSE convert(varchar,@dFecIni,112) END AND    
    CASE WHEN ( @dFecFin = '' )  THEN '' ELSE convert(varchar,DE.FechEmi,112)  END <= CASE WHEN (@dFecFin = '') THEN '' ELSE convert(varchar,@dFecFin,112) END ) AND    
  -- Usuario  
  ( ( CASE WHEN ( @iCodiUsuRem = 0 ) THEN 0 ELSE DE.CodiDocuElec END = CASE WHEN ( @iCodiUsuRem = 0 ) THEN 0 ELSE ( select TOP 1 UPR.CodiOper from UsuarioParticipante UPR WHERE DE.CodiDocuElec = UPR.CodiOper and UPR.CodiUsu = @iCodiUsuRem and UPR.TipoPart
 = 3) END ) AND  
    ( CASE WHEN ( @iCodiUsuDes = 0 ) THEN 0 ELSE DE.CodiDocuElec END = CASE WHEN ( @iCodiUsuDes = 0 ) THEN 0 ELSE ( select TOP 1 UPD.CodiOper from UsuarioParticipante UPD WHERE DE.CodiDocuElec = UPD.CodiOper and UPD.CodiUsu = @iCodiUsuDes and UPD.TipoPart
 = 2) END ) )
  ORDER BY DE.CodiDocuElec DESC  
 END    
   
  --Busqueda por todos los criterios en forma complementaria    
 ELSE IF (@iTipoBusq = 1)    
 BEGIN  
  select distinct DE.CodiDocuElec,   
      DE.NumDocuElec,   
      AsunDocuElec [AsunDocuElec],   
      DE.CodiTipoDocu,   
      TD.NombTipoDocu as TipoDocu,  
       FechEmi,   
      PrioDocuElec,   
      estdocuElec  
  From  DocumentoElectronico DE    
  --INNER JOIN UsuarioParticipante UP ON ( DE.CodiDocuElec = UP.CodiOper )    
  --INNER JOIN Usuario    US ON ( UP.CodiUsu = US.CodiUsu )    
  INNER JOIN TIPODOCUMENTO  TD   ON (DE.CODITIPODOCU=TD.CODITIPODOCU)    
  Where    
  CASE WHEN ( @sAsunto = '' )  THEN '' ELSE DE.AsunDocuElec END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' OR   
  --Excluye Tipo de Documentos AA=Todos    
  CASE WHEN ( @sTipoDocu = 'AA' ) THEN '' ELSE DE.CodiTipoDocu END  =  CASE WHEN (@sTipoDocu = 'AA') THEN '' ELSE @sTipoDocu END OR    
  -- Rango de Fecha "@dFecIni" a "@dFecFin"  
  ( CASE WHEN ( @dFecIni = '' )  THEN '' ELSE convert(varchar,DE.FechEmi,112)  END >= CASE WHEN (@dFecIni = '') THEN '' ELSE convert(varchar,@dFecIni,112) END AND    
    CASE WHEN ( @dFecFin = '' )  THEN '' ELSE convert(varchar,DE.FechEmi,112)  END <= CASE WHEN (@dFecFin = '') THEN '' ELSE convert(varchar,@dFecFin,112) END ) OR    
  ( ( CASE WHEN ( @iCodiUsuRem = 0 ) THEN 0 ELSE DE.CodiDocuElec END = CASE WHEN ( @iCodiUsuRem = 0 ) THEN 0 ELSE ( select TOP 1 UPR.CodiOper from UsuarioParticipante UPR WHERE DE.CodiDocuElec = UPR.CodiOper and UPR.CodiUsu = @iCodiUsuRem and UPR.TipoPart
 = 3) END ) AND  
    ( CASE WHEN ( @iCodiUsuDes = 0 ) THEN 0 ELSE DE.CodiDocuElec END = CASE WHEN ( @iCodiUsuDes = 0 ) THEN 0 ELSE ( select TOP 1 UPD.CodiOper from UsuarioParticipante UPD WHERE DE.CodiDocuElec = UPD.CodiOper and UPD.CodiUsu = @iCodiUsuDes and UPD.TipoPart
 = 2) END ) )  
  ORDER BY DE.CodiDocuElec DESC  
 END   
        
 SET NOCOUNT OFF                  
END  