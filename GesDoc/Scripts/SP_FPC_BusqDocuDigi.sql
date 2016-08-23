USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_BusqDocuDigi')
	DROP PROCEDURE [SP_FPC_BusqDocuDigi]
GO

CREATE PROCEDURE [dbo].[SP_FPC_BusqDocuDigi]  
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
*Descripcion        : Busqueda de Documentos Digitales  
*Autor              : Alex Pacaya  
*Modify              : Kenneth Urbina  
*Cambios Importantes: Comentario de la ultima linea por @iTipoBusq = 0 en el store procedure  
******************************************************************/  
BEGIN                
 SET NOCOUNT ON       
   
 IF (@iTipoBusq = 0)  
 BEGIN  
  Select distinct DD.CodiDocuDigi,  
      DD.NumDocuDigi,  
      TituDocuDigi,  
      NombOrig,  
      AsunDocuDigi [AsunDocuDigi],  
      RutaFisi + rtrim(TD.NombTipoDocu) + '/' + rtrim(NombFisi) + ExteDocu as RutaFisi,  
      DD.CodiTipoDocu,  
      TD.NombTipoDocu,  
      FechRegi,  
      estdocudigi                   
  From  DocumentoDigital DD  
  INNER  JOIN UsuarioParticipante UP ON ( DD.CodiDocuDigi = UP.CodiOper )  
  LEFT JOIN IndexacionDocumento ID ON ( DD.CodiDocuDigi = ID.CodiOper )  
        INNER JOIN TIPODOCUMENTO  TD   ON (DD.CODITIPODOCU=TD.CODITIPODOCU)     
  Where   
     ( ( ( CASE WHEN ( @sAsunto = '' )  THEN '' ELSE DD.AsunDocuDigi END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' OR   
           CASE WHEN ( @sAsunto = '' )  THEN '' ELSE DD.NumDocuDigi END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' ) OR  
        CASE WHEN ( @sAsunto = '' )  THEN '' ELSE DD.TituDocuDigi END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' ) OR   
        CASE WHEN ( @sAsunto = '' )  THEN '' ELSE ID.DescInde END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' ) AND   
     --Excluye Tipo de Documentos AA=Todos  
     CASE WHEN ( @sTipoDocu = 'AA' ) THEN '' ELSE DD.CodiTipoDocu END  =  CASE WHEN (@sTipoDocu = 'AA') THEN '' ELSE @sTipoDocu END AND    
     -- Rango de Fecha "@dFecIni" a "@dFecFin"  
  ( CASE WHEN ( @dFecIni = '' )  THEN '' ELSE convert(varchar, DD.FechRegi, 112)  END >= CASE WHEN (@dFecIni = '') THEN '' ELSE convert(varchar,@dFecIni,112) END AND    
    CASE WHEN ( @dFecFin = '' )  THEN '' ELSE convert(varchar, DD.FechRegi, 112)  END <= CASE WHEN (@dFecFin = '') THEN '' ELSE convert(varchar,@dFecFin,112) END ) AND    
  -- Usuario  
  ( ( CASE WHEN ( @iCodiUsuRem = 0 ) THEN 0 ELSE DD.CodiDocuDigi END = CASE WHEN ( @iCodiUsuRem = 0 ) THEN 0 ELSE ( select TOP 1 UPR.CodiOper from UsuarioParticipante UPR WHERE DD.CodiDocuDigi = UPR.CodiOper and UPR.CodiUsu = @iCodiUsuRem and UPR.TipoPart
 = 6) END ) AND  
    ( CASE WHEN ( @iCodiUsuDes = 0 ) THEN 0 ELSE DD.CodiDocuDigi END = CASE WHEN ( @iCodiUsuDes = 0 ) THEN 0 ELSE ( select TOP 1 UPD.CodiOper from UsuarioParticipante UPD WHERE DD.CodiDocuDigi = UPD.CodiOper and UPD.CodiUsu = @iCodiUsuDes and UPD.TipoPart
 = 7) END ) )  
 END  
 ELSE IF (@iTipoBusq = 1)  
 BEGIN  
  Select distinct DD.CodiDocuDigi,  
      DD.NumDocuDigi,  
      TituDocuDigi,  
      NombOrig,  
      AsunDocuDigi [AsunDocuDigi],  
      RutaFisi + rtrim(TD.NombTipoDocu) + '/' + rtrim(NombFisi) + ExteDocu as RutaFisi,  
      DD.CodiTipoDocu,  
      TD.NombTipoDocu,  
      FechRegi,  
      estdocudigi                   
  From  DocumentoDigital DD  
  INNER  JOIN UsuarioParticipante UP ON ( DD.CodiDocuDigi = UP.CodiOper )  
  INNER JOIN IndexacionDocumento ID ON ( DD.CodiDocuDigi = ID.CodiOper )  
        INNER JOIN TIPODOCUMENTO  TD   ON (DD.CODITIPODOCU=TD.CODITIPODOCU)   
  Where ( ( ( CASE WHEN ( @sAsunto = '' )  THEN '' ELSE DD.AsunDocuDigi END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' OR   
           CASE WHEN ( @sAsunto = '' )  THEN '' ELSE DD.NumDocuDigi END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' ) OR  
        CASE WHEN ( @sAsunto = '' )  THEN '' ELSE DD.TituDocuDigi END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' ) OR   
        CASE WHEN ( @sAsunto = '' )  THEN '' ELSE ID.DescInde END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' )  OR   
     --Excluye Tipo de Documentos AA=Todos  
     CASE WHEN ( @sTipoDocu = 'AA' ) THEN '' ELSE DD.CodiTipoDocu END  =  CASE WHEN (@sTipoDocu = 'AA') THEN '' ELSE @sTipoDocu END OR   
     -- Rango de Fecha "@dFecIni" a "@dFecFin"  
  ( CASE WHEN ( @dFecIni = '' )  THEN '' ELSE convert(varchar, DD.FechRegi, 112)  END >= CASE WHEN (@dFecIni = '') THEN '' ELSE convert(varchar,@dFecIni,112) END AND    
    CASE WHEN ( @dFecFin = '' )  THEN '' ELSE convert(varchar, DD.FechRegi, 112)  END <= CASE WHEN (@dFecFin = '') THEN '' ELSE convert(varchar,@dFecFin,112) END ) OR    
  -- Usuario  
  ( ( CASE WHEN ( @iCodiUsuRem = 0 ) THEN 0 ELSE DD.CodiDocuDigi END = CASE WHEN ( @iCodiUsuRem = 0 ) THEN 0 ELSE ( select TOP 1 UPR.CodiOper from UsuarioParticipante UPR WHERE DD.CodiDocuDigi = UPR.CodiOper and UPR.CodiUsu = @iCodiUsuRem and UPR.TipoPart 
  = 6) END ) AND  
    ( CASE WHEN ( @iCodiUsuDes = 0 ) THEN 0 ELSE DD.CodiDocuDigi END = CASE WHEN ( @iCodiUsuDes = 0 ) THEN 0 ELSE ( select TOP 1 UPD.CodiOper from UsuarioParticipante UPD WHERE DD.CodiDocuDigi = UPD.CodiOper and UPD.CodiUsu = @iCodiUsuDes and UPD.TipoPart
 = 7) END ) )  
     --CASE WHEN (@sAsunto = '')    THEN '' ELSE ID.DescInde END like  CASE WHEN (@sAsunto = '') THEN '' ELSE '%'+ltrim(rtrim(@sAsunto))+'%' END  
   END  
  
 SET NOCOUNT OFF                
END  