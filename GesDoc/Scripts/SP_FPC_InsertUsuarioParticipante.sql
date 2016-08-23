USE GesDoc

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_FPC_InsertUsuarioParticipante')
	DROP PROCEDURE [SP_FPC_InsertUsuarioParticipante]
GO

CREATE PROCEDURE [dbo].[SP_FPC_InsertUsuarioParticipante]        
(        
 @iCodiUsuPart bigint,  /* Siempre debe venir vacio */      
 @cTipoOper  char(2),       
 @iCodiOper  bigint,      
 @cTipoPart  char(3),      
 @cApruOper  char(1),      
 @cEnviNoti  char(1),      
 @dFechNoti  datetime,      
 @cEstaUsuaPart  char(1),      
 @iCodiUsu  bigint,    
 @cReenvio  char(1),      
 @cEnvio  char(1)      
)        
AS        
      
BEGIN        
      
   --Set @iCodiUsuPart = 0      
         
   /* Valida que no exista el usuario para la operacion */      
   Set @iCodiUsuPart = ( Select count(CodiUsuPart) From UsuarioParticipante      
           Where CodiOper  = @iCodiOper      
             and CodiUsu   = @iCodiUsu         
          and TipoPart = @cTipoPart)--Rsecaira 07/02/2012      
      
   /* Si no existe registro de usuarios particioante Inserta */      
   if(@dFechNoti ='')      
  Begin      
   set @dFechNoti=Null      
  End       
      
   If ( @iCodiUsuPart = 0 )      
  Begin       
    Insert Into UsuarioParticipante        
      (      
     TipoOper,  CodiOper,   TipoPart,   ApruOper,         
     EnviNoti,  FechNoti,   CodiUsu,      EstaUsuaPart,    
     Reenvio,	Envio      
    )        
    Values      
      (       
     @cTipoOper, @iCodiOper,  @cTipoPart,  @cApruOper,       
     @cEnviNoti, @dFechNoti,  @iCodiUsu,  @cEstaUsuaPart,    
     @cReenvio,  @cEnvio      
    )        
      
   select @iCodiUsuPart = scope_identity()          
      
    if(@cApruOper = 'S')      
   Begin      
     EXEC SP_FPC_InsertUsuarioAutorizador       
     1, @iCodiUsu, @iCodiOper, @cTipoOper, null, @dFechNoti, null, 'A'      
   End      
      
  End      
      
   /* Si Existe registro Actualiza */      
   Else      
  Begin       
      
   UPDATE UsuarioParticipante      
      
      SET TipoOper = @cTipoOper,      
       /*CodiOper = @iCodiOper,*/      
       TipoPart = @cTipoPart,      
       ApruOper = @cApruOper,      
       EnviNoti = @cEnviNoti,      
       FechNoti = @dFechNoti,      
       EstaUsuaPart=@cEstaUsuaPart,     
       Envio = @cEnvio
      
    Where CodiOper = @iCodiOper       
      and CodiUsu = @iCodiUsu      
      and TipoPart = @cTipoPart--Rsecaira 07/02/2012
      and Envio = 'N'
      
  End      
END        
      
select * from usuarioparticipante  