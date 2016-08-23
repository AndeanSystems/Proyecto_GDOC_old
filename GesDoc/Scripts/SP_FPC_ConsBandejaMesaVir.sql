USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_ConsBandejaMesaVir')
	DROP PROCEDURE [SP_FPC_ConsBandejaMesaVir]
GO

CREATE PROC [dbo].[SP_FPC_ConsBandejaMesaVir]  
(  
 @iType int,  
 @iCodiUsu bigint,  
 @iTipoPart smallint,  
 @sEstado char(1),  
 @sClase smallint,  
 @sAsunto varchar(max),  
 @sPeriodo char(1),  
 @dFecha datetime,  
 @Prioridad varchar(20)  
)  
AS   
Begin  
  if(@iType=0)  
  Begin  
  Select MV.CodiMesaVirt [CodiOper],  MV.DescMesaVirt [Asunto], TituMesaVirt[Titulo],   
      MV.AcceMesaVirt [Acceso],MV.NumMesaVirt  [NumOper],   MV.FechOrga[Fecha],     
      MV.FechCie[FechaFin],MV.EstaMesaVirt [Estado],  
      UP.CodiUsu      [CodiUsu],  
      isnull((select SP.CodiUsu from UsuarioParticipante SP where MV.CodiMesaVirt = SP.CodiOper  and TipoPart = 4),0)[Autor],  
      US.IdeUsu       [Usuario],  
      UP.TipoPart     [TipoPart], TP.AbreTipoPart [AbreTipoPart],MV.PrioMesaVirt[Prioridad], UP.ConfLect  
    From MesaVirtual MV  
   INNER JOIN UsuarioParticipante UP  On  (MV.CodiMesaVirt = UP.CodiOper)  
   INNER JOIN Usuario             US  On  (UP.CodiUsu      = US.CodiUsu)  
   INNER JOIN TipoParticipante    TP  On  (UP.TipoPart     = TP.CodiTipoPart)   
   Where UP.CodiUsu  =  @iCodiUsu  
     --and convert(varchar,MV.FechOrga,112) = convert(varchar,@sFecha,112)  
     and MV.EstaMesaVirt in ('C','V')  
     and UP.EstaUsuaPart =  'A'  
  order by MV.FechOrga Desc  
  End  
  if(@iType=1)  
  Begin  
  Select MV.CodiMesaVirt [CodiOper],  MV.DescMesaVirt [Asunto], TituMesaVirt[Titulo],   
      MV.AcceMesaVirt [Acceso],MV.NumMesaVirt  [NumOper],   MV.FechOrga[Fecha],     
      MV.FechCie[FechaFin],MV.EstaMesaVirt [Estado],  
      UP.CodiUsu      [CodiUsu],  
               isnull((select SP.CodiUsu from UsuarioParticipante SP where MV.CodiMesaVirt = SP.CodiOper  and TipoPart = 4),0)[Autor],  
      US.IdeUsu       [Usuario],  
      UP.TipoPart     [TipoPart], TP.AbreTipoPart [AbreTipoPart],MV.PrioMesaVirt[Prioridad] , UP.ConfLect 
    From MesaVirtual MV  
   INNER JOIN UsuarioParticipante UP  On  (MV.CodiMesaVirt = UP.CodiOper)  
   INNER JOIN Usuario             US  On  (UP.CodiUsu      = US.CodiUsu)  
   INNER JOIN TipoParticipante    TP  On  (UP.TipoPart     = TP.CodiTipoPart)   
   Where UP.CodiUsu  =  @iCodiUsu  
     and UP.EstaUsuaPart = 'A'  
     and CASE WHEN(@iTipoPart <> 0)THEN UP.TipoPart else '' END = CASE WHEN(@iTipoPart <> 0)THEN  @iTipoPart else '' END  
     and CASE WHEN (@sEstado='')THEN '' ELSE MV.EstaMesaVirt END =  CASE WHEN(@sEstado='')THEN '' ELSE @sEstado END  
     and CASE WHEN(@sClase=0)THEN '' ELSE MV.ClasMesaVirt END = CASE WHEN(@sClase=0)THEN '' ELSE @sClase END  
     and CASE WHEN(@sAsunto='')THEN '' ELSE MV.DescMesaVirt END like CASE WHEN (@sAsunto='')THEN '' ELSE'%'+ @sAsunto +'%' END  
     and (CASE WHEN (@sPeriodo='M')THEN Convert(varchar(6),month(MV.FechOrga),112) END = CASE WHEN(@dFecha='') THEN Convert(varchar(6),month(@dFecha),112)END  
    OR CASE WHEN (@sPeriodo='D')THEN  Convert(varchar,MV.FechOrga,112) END = CASE WHEN(@dFecha='') THEN convert(varchar,@dFecha,112) END)  
     and CASE WHEN(@Prioridad='')THEN '' ELSE MV.PrioMesaVirt END = CASE WHEN(@Prioridad='') THEN '' ELSE @Prioridad END  
  order by MV.FechOrga Desc  
  print @iTipoPart  
  
  End  
   
End  