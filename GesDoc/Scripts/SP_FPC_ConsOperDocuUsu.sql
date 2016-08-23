USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_ConsOperDocuUsu')
	DROP PROCEDURE [SP_FPC_ConsOperDocuUsu]
GO

CREATE PROCEDURE [dbo].[SP_FPC_ConsOperDocuUsu]      
(         
 @iType  int,      -- 0=Todas Operaciones   1=Solo Doc_E  2=Solo Doc_D       
 @iCodiUsu   bigint,      
 @dFecha     datetime      
)      
AS                      
      
/**************************************************************      
*Descripcion: Consulta Lista de Operaciones por el Asunto      
*Autor      : Alex Pacaya        
*Cambios Importantes:        
-- exec SP_FPC_ConsOperDocuUsu 3,61,'02/12/2013'    
***************************************************************/      
BEGIN                      
 SET NOCOUNT ON                          
      
 --Tipo=0 Consulta todas las operaciones      
 IF (@iType=0 and @iCodiUsu <> 0 and @dFecha <> '')      
         
   Begin      
  Select DE.CodiDocuElec [CodiOper],  DE.NumDocuElec + ' ' + DE.AsunDocuElec [Asunto],           
      DE.CodiTipoDocu [TipoDocu],       
               DE.AcceDocuElec [AcceOper],  DE.NumDocuElec  [NumOper],    DE.FechEmi      [Fecha],      
      US.IdeUsu      
    From DocumentoElectronico DE      
   INNER JOIN UsuarioParticipante UP  On  (DE.CodiDocuElec = UP.CodiOper)      
   INNER JOIN Usuario             US  On  (UP.CodiUsu      = US.CodiUsu)      
   Where UP.CodiUsu = @iCodiUsu    
     and Convert(varchar,UP.FechNoti,112) = convert(varchar,@dFecha,112)       
        Union      
  Select DD.CodiDocuDigi [CodiOper], DD.NumDocuDigi + ' ' + DD.AsunDocuDigi [Asunto],        
      DD.CodiTipoDocu [TipoDocu],       
      DD.AcceDocuDigi [AcceOper], DD.NumDocuDigi  [NumOper], DD.FechRegi  [Fecha],      
      US.IdeUsu      
    From DocumentoDigital DD      
   INNER JOIN UsuarioParticipante UP  On  (DD.CodiDocuDigi = UP.CodiOper)      
   INNER JOIN Usuario             US  On  (UP.CodiUsu      = US.CodiUsu)      
   Where UP.CodiUsu = @iCodiUsu      
     and Convert(varchar,UP.FechNoti,112) = convert(varchar,@dFecha,112)       
   order by Fecha Desc      
      End      
      
 ELSE      
   --Tipo=1 Consulta Solo Doc_E       
   IF (@iType=1 and @iCodiUsu <> 0 and @dFecha <> '')      
        
  Begin      
  Select DE.CodiDocuElec [CodiOper],  DE.AsunDocuElec [Asunto],     DE.CodiTipoDocu [TipoDocu],       
      DE.AcceDocuElec [AcceOper],  DE.NumDocuElec  [NumOper],    DE.FechEmi      [Fecha],      
      US.IdeUsu,      
      isnull((select SP.CodiUsu from UsuarioParticipante SP       
        where DE.CodiDocuElec=SP.CodiOper  and TipoPart = 3),0)[Autor]      
    From DocumentoElectronico DE      
   INNER JOIN UsuarioParticipante UP  On  (DE.CodiDocuElec = UP.CodiOper)      
   INNER JOIN Usuario             US  On  (UP.CodiUsu      = US.CodiUsu)      
   Where UP.CodiUsu = @iCodiUsu      
     and EstDocuElec = 'E'            
   order by Fecha Desc      
  End      
      
   ELSE      
  --Tipo=2 Consulta Solo Doc_D       
     IF (@iType=2 and @iCodiUsu <> 0 and @dFecha <> '')      
      
    Begin      
   Select DD.CodiDocuDigi [CodiOper], DD.AsunDocuDigi [Asunto],  DD.CodiTipoDocu [TipoDocu],       
       DD.AcceDocuDigi [AcceOper], DD.NumDocuDigi  [NumOper], DD.FechRegi  [Fecha],      
       US.IdeUsu,isnull((select SP.CodiUsu from UsuarioParticipante SP where DD.CodiDocuDigi=SP.CodiOper  and TipoPart = 6),0)[Autor]      
     From DocumentoDigital DD      
    INNER JOIN UsuarioParticipante UP  On  (DD.CodiDocuDigi = UP.CodiOper)      
    INNER JOIN Usuario             US  On  (UP.CodiUsu      = US.CodiUsu)      
    Where UP.CodiUsu = @iCodiUsu      
      and Convert(varchar,UP.FechNoti,112) = convert(varchar,@dFecha,112)       
    order by Fecha Desc      
    End      
        
 IF (@iType=3 and @iCodiUsu <> 0 and @dFecha <> '')     
   Begin      
  Select DE.CodiDocuElec [CodiOper],  DE.NumDocuElec+' '+DE.AsunDocuElec [Asunto],           
      DE.CodiTipoDocu [TipoDocu],       
               DE.AcceDocuElec [AcceOper],  DE.NumDocuElec  [NumOper],    DE.FechEmi      [Fecha],      
      US.IdeUsu,isnull((select top 1 SP.CodiUsu from UsuarioParticipante SP where DE.CodiDocuElec=SP.CodiOper  and TipoPart = 3),0)[Autor]      
    From DocumentoElectronico DE      
   INNER JOIN UsuarioParticipante UP  On  (DE.CodiDocuElec = UP.CodiOper)      
   INNER JOIN Usuario             US  On  (UP.CodiUsu      = US.CodiUsu)      
   Where UP.CodiUsu = @iCodiUsu      
     and Convert(varchar,UP.FechNoti,112) = convert(varchar,@dFecha,112)      
     and UP.TipoPart=2       
     and EstDocuElec = 'E'
     and ((select COUNT(*) from UsuarioParticipante	 where Envio = 'Y' and TipoPart = 3 and CodiOper = DE.CodiDocuElec) = 
		  (select COUNT(*) from UsuarioParticipante where TipoPart = 3  and CodiOper = DE.CodiDocuElec) OR
		  (select COUNT(*) from UsuarioParticipante where TipoPart = 3  and CodiOper = DE.CodiDocuElec) = 1)      
        Union      
  Select DD.CodiDocuDigi [CodiOper], DD.NumDocuDigi+' '+DD.AsunDocuDigi [Asunto],        
      DD.CodiTipoDocu [TipoDocu],       
      DD.AcceDocuDigi [AcceOper], DD.NumDocuDigi  [NumOper], DD.FechRegi  [Fecha],      
      US.IdeUsu,isnull((select SP.CodiUsu from UsuarioParticipante SP where DD.CodiDocuDigi=SP.CodiOper  and TipoPart = 6),0)[Autor]      
    From DocumentoDigital DD      
   INNER JOIN UsuarioParticipante UP  On  (DD.CodiDocuDigi = UP.CodiOper)      
   INNER JOIN Usuario             US  On  (UP.CodiUsu      = US.CodiUsu)      
   Where UP.CodiUsu = @iCodiUsu      
     and Convert(varchar,UP.FechNoti,112) = convert(varchar,@dFecha,112)       
     and EstDocuDigi ='E'      
     and UP.TipoPart=7       
   order by Fecha Desc      
      End      
            
 SET NOCOUNT OFF                      
END 