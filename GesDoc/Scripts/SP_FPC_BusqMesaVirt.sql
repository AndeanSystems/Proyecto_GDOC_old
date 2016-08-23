USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_BusqMesaVirt')
	DROP PROCEDURE [SP_FPC_BusqMesaVirt]
GO

CREATE PROCEDURE [dbo].[SP_FPC_BusqMesaVirt]    
(    
 @sAsunto  varchar(max),    
 @iClasMesa  smallint,    
 @dFecIni  datetime = '',    
 @dFecFin  datetime = '',    
 @iCodiUsuOrg Bigint,    
 @iCodiUsuCol Bigint,    
 @iTipoBusq  smallint     
)    
AS       
                  
/*****************************************************************    
*Descripcion        : Busqueda de Mesa Virtual    
*Autor              : Alex Pacaya    
*Cambios Importantes:    
  
*Comentario en el caso de @iClasMesa  
******************************************************************/    
BEGIN                  
 SET NOCOUNT ON                      
  
 IF (@iTipoBusq = 0)    
 Begin    
  Select distinct   
   MV.CodiMesaVirt,   
   MV.DescMesaVirt,   
   MV.TituMesaVirt [TituMesaVirt],   
   MV.AcceMesaVirt,   
   MV.NumMesaVirt,   
   FechOrga,
   FechCie,   
   MV.EstaMesaVirt,   
   MV.ClasMesaVirt  
  From MesaVirtual MV    
  Where CASE WHEN ( @sAsunto = '' )  THEN '' ELSE MV.TituMesaVirt END  LIKE '%' + ltrim(rtrim(@sAsunto)) + '%' AND   
     --Excluye Tipo de Documentos AA=Todos  
     --CASE WHEN ( @iClasMesa = 'AA' ) THEN '' ELSE MV.ClasMesaVirt END  =  CASE WHEN (@iClasMesa = 'AA') THEN '' ELSE @iClasMesa END AND    
     -- Rango de Fecha "@dFecIni" a "@dFecFin"  
  ( CASE WHEN ( @dFecIni = '' )  THEN '' ELSE convert(varchar, MV.FechOrga, 112)  END >= CASE WHEN (@dFecIni = '') THEN '' ELSE convert(varchar,@dFecIni,112) END AND    
    CASE WHEN ( @dFecFin = '' )  THEN '' ELSE convert(varchar, MV.FechOrga, 112)  END <= CASE WHEN (@dFecFin = '') THEN '' ELSE convert(varchar,@dFecFin,112) END ) AND    
  -- Usuario  
  ( ( CASE WHEN ( @iCodiUsuOrg = 0 ) THEN 0 ELSE MV.CodiMesaVirt END = CASE WHEN ( @iCodiUsuOrg = 0 ) THEN 0 ELSE ( select TOP 1 UPR.CodiOper from UsuarioParticipante UPR WHERE MV.CodiMesaVirt = UPR.CodiOper and UPR.CodiUsu = @iCodiUsuOrg and UPR.TipoPart
 = 4) END ) AND  
    ( CASE WHEN ( @iCodiUsuCol = 0 ) THEN 0 ELSE MV.CodiMesaVirt END = CASE WHEN ( @iCodiUsuCol = 0 ) THEN 0 ELSE ( select TOP 1 UPD.CodiOper from UsuarioParticipante UPD WHERE MV.CodiMesaVirt = UPD.CodiOper and UPD.CodiUsu = @iCodiUsuCol and UPD.TipoPart
 = 1) END ) )  
	ORDER BY MV.CodiMesaVirt DESC
 End    
  
 ELSE IF (@iTipoBusq = 1)    
 Begin    
  Select distinct MV.CodiMesaVirt , MV.DescMesaVirt , MV.TituMesaVirt,     
  MV.AcceMesaVirt , MV.NumMesaVirt  , MV.FechOrga,       
  MV.FechCie,   MV.EstaMesaVirt ,   MV.ClasMesaVirt, 
  MV.FechCie    
  From  MesaVirtual MV    
  INNER  JOIN UsuarioParticipante UP  On  (MV.CodiMesaVirt = UP.CodiOper)    
  Where      
  CASE WHEN (@sAsunto = '')  THEN '' ELSE MV.TituMesaVirt END like  CASE WHEN (@sAsunto = '') THEN '' ELSE '%'+ltrim(rtrim(@sAsunto))+'%' END OR    
  --CASE WHEN (@iClasMesa = 0) THEN 0  ELSE MV.ClasMesaVirt END = CASE WHEN (@iClasMesa = 0) THEN 0 ELSE @iClasMesa END  OR    
  CASE WHEN convert(varchar,@dFecIni,112) = ''  THEN '' ELSE convert(varchar,MV.FechOrga,112)   END >= CASE WHEN (@dFecIni = '') THEN '' ELSE convert(varchar,@dFecIni,112) END OR    
  CASE WHEN convert(varchar,@dFecFin,112) = ''  THEN '' ELSE convert(varchar,MV.FechOrga,112)   END <= CASE WHEN (@dFecFin = '') THEN '' ELSE convert(varchar,@dFecFin,112) END OR    
  (CASE WHEN (@iCodiUsuOrg = 0) THEN 0 ELSE UP.CodiUsu END = CASE WHEN (@iCodiUsuOrg = 0) THEN 0 ELSE @iCodiUsuOrg END AND UP.TipoPart = 4) OR    
  (CASE WHEN (@iCodiUsuCol = 0) THEN 0 ELSE UP.CodiUsu END = CASE WHEN (@iCodiUsuCol = 0) THEN 0 ELSE @iCodiUsuCol END AND UP.TipoPart = 1)    
  ORDER BY MV.CodiMesaVirt DESC
 End    
        
 SET NOCOUNT OFF                  
END  