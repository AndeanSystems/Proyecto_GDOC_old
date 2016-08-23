USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_ConsUsuarios')
	DROP PROCEDURE [SP_FPC_ConsUsuarios]
GO

CREATE  PROCEDURE [dbo].[SP_FPC_ConsUsuarios]  
AS                    
      
/***************************************                    
*Descripcion: Consulta Tabla de Usuarios, segun el Codigo o Username      
*Autor      : Alex Pacaya      
*Cambios Importantes:      
***************************************/                    
BEGIN    
                
SET NOCOUNT ON  


Select  US.CodiUsu,     US.IdeUsu,       US.PassUsu,    US.FirmElec,     US.EstaUsu,         
US.FechReg,     US.FechUltiAcc,  US.FechModi,   US.InteErraPass, US.InteErraFirm,       
US.TermUsu,     US.UsuCrea,      US.CodiCnx,    US.CodiPers,     US.CodiRol,           
US.CodiTipUsu,  US.ClasUsu,    
PE.NombPers,    PE.ApePers,      PE.SexoPers,   PE.EmaiPers,      
PE.EmaiTrab, PE.FechNac,      PE.TelePers, PE.AnexPers,     PE.CeluPers,      
PE.EstaPers, PE.CodiTipUsu,   PE.CodiArea, PE.CodiCarg,  PE.DNI,    
PE.DirePers,    
AR.DescArea,      
CG.DescCarg,      
EM.RucEmpr,     EM.RazoSoci,  EM.DireEmpr, EM.CodiUbig      
From   USUARIO US           
Inner  Join PERSONAL PE on ( US.CodiPers = PE.CodiPers)           
Inner  Join AREA     AR on ( PE.CodiArea = AR.CodiArea )           
Inner  Join CARGO    CG on ( PE.CodiCarg = CG.CodiCarg)           
Inner  Join EMPRESA  EM on ( PE.RucEmpr = EM.RucEmpr)             
Where PE.EstaPers = 'A'    
AND US.EstaUsu = 'A'    
Order by  2, 17, 18    
   
END