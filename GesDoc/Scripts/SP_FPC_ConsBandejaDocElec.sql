USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_ConsBandejaDocElec')
	DROP PROCEDURE [SP_FPC_ConsBandejaDocElec]
GO

CREATE proc [dbo].[SP_FPC_ConsBandejaDocElec]  
(  
 @iType  int,  
 @iCodiUsu   bigint,  
 @dFecha     datetime,  
 --rsecaira  
 @sTipoPart smallint,  
 @sTipoComu char(10),  
 @CodiTipoDocu char(5),  
 @sAsunto varchar(100),  
 @sPrioDoc char(1),  
 @sPeriodo char(1),  
 @NumDocuElec varchar(20)  
)  
/**************************************************************  
*Descripcion: Consulta Documentos Electronicos Para La Bandeja de E/S  
*Autor      : Ronald Secaira   
*Cambios Importantes:    
***************************************************************/  
AS  
BEGIN  
 if(@iType = 0)  
 BEGIN  
 Select DE.CodiDocuElec [CodiOper],  DE.AsunDocuElec [Asunto],     DE.CodiTipoDocu [TipoDocu],   
      DE.AcceDocuElec [AcceOper],  DE.NumDocuElec  [NumOper],    DE.FechEmi      [Fecha],  
      US.IdeUsu,  
      isnull((select SP.CodiUsu from UsuarioParticipante SP   
        where DE.CodiDocuElec=SP.CodiOper  and TipoPart = 3),0)[Autor]  
     ,DE.PrioDocuElec[Prioridad]  
    From DocumentoElectronico DE  
   INNER JOIN UsuarioParticipante UP  On  (DE.CodiDocuElec = UP.CodiOper)  
   INNER JOIN Usuario             US  On  (UP.CodiUsu      = US.CodiUsu)  
   Where UP.CodiUsu = @iCodiUsu  
     and EstDocuElec = 'E'  
     and UP.TipoPart in (2,3)      
   order by Fecha Desc  
 END  
   
 if(@iType = 1)  
 BEGIN   
 Select distinct DE.CodiDocuElec [CodiOper],  DE.AsunDocuElec [Asunto],     DE.CodiTipoDocu [TipoDocu],   
       DE.AcceDocuElec [AcceOper],  DE.NumDocuElec  [NumOper],    UP.FechNoti     [Fecha],  
       US.IdeUsu,  
       isnull((select TOP 1 SP.CodiUsu from UsuarioParticipante SP   
         where DE.CodiDocuElec=SP.CodiOper  and TipoPart = 3),0)[Autor]  
       ,DE.PrioDocuElec[Prioridad]  
     From DocumentoElectronico DE  
    INNER JOIN UsuarioParticipante UP  On  (DE.CodiDocuElec = UP.CodiOper)  
    INNER JOIN Usuario             US  On  (UP.CodiUsu      = US.CodiUsu)  
    Where UP.CodiUsu = @iCodiUsu  
      AND EstDocuElec = 'E'   
      AND CASE WHEN (@sTipoPart=0)THEN '' ELSE UP.TipoPart END = CASE WHEN(@sTipoPart=0) THEN '' ELSE @sTipoPart END  
      And CASE WHEN (@sTipoComu='')THEN '' ELSE DE.TipoComu END = CASE WHEN(@sTipoComu='') THEN '' ELSE @sTipoComu END  
      AND CASE WHEN (@CodiTipoDocu='')THEN '' ELSE DE.CodiTipoDocu END = CASE WHEN(@CodiTipoDocu='')THEN '' ELSE @CodiTipoDocu END  
               and CASE WHEN (@sAsunto='')THEN '' ELSE DE.AsunDocuElec END like CASE WHEN (@sAsunto='') THEN '' ELSE '%'+ @sAsunto+'%'END  
      and CASE WHEN (@sPrioDoc='')THEN '' ELSE DE.PrioDocuElec END = CASE WHEN (@sPrioDoc ='') THEN '' ELSE @sPrioDoc END  
      and (CASE WHEN (@sPeriodo='M')THEN Convert(varchar(6),UP.FechNoti,112) END = CASE WHEN(@sPeriodo='M') THEN convert(varchar(6),@dFecha,112) END  
     OR CASE WHEN (@sPeriodo='D')THEN Convert(varchar,UP.FechNoti,112) END = CASE WHEN(@sPeriodo='D') THEN convert(varchar,@dFecha,112) END)  
      and CASE WHEN (@NumDocuElec='') THEN '' ELSE DE.NumDocuElec END = CASE WHEN(@NumDocuElec='') THEN '' ELSE @NumDocuElec END  
      order by Fecha Desc  
  
 END  
END  