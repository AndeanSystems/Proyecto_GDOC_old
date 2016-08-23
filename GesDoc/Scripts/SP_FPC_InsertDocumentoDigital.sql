alter PROCEDURE [dbo].[SP_FPC_InsertDocumentoDigital]        
(        
 @outCodiDocuDigi bigint output,        
 @outNumDocuDigi     varchar(20) output,      
 @Type    char(1),      
 @CodiDocuDigi  bigint,      
 @TituDocuDigi  varchar(100),      
 @AsunDocuDigi  varchar(1000),      
 @NombOrig   char(100),      
 @RutaFisi   varchar(300),      
 @TamaDocu   int,      
 @ExteDocu   varchar(10),      
 @NombFisi   char(256),      
 @ClasDocu   char(2),      
 @EstDocuDigi  char(1),      
 @FechEmiDocu  datetime,      
 @FechRece   datetime,      
 @FechRegi   datetime,      
 @FechActu   datetime,      
 @AcceDocuDigi  char(2),      
 @CodiTipoDocu  char(5),      
 @NumDocuDigi  varchar(20),      
 @iCodiUsu   bigint,    
 @Comentario   varchar(300) = null    
)        
AS        
BEGIN        
      
 IF(@Type = '1')        
      
   Begin       
      
  -- Crea numero de Documento Interno      
  EXEC SP_FPC_CreaFolioDocuElec @iCodiUsu,'DD', @NumDocuDigi output      
      
  --Inserta Nuevo Documento Digital      
  INSERT INTO DocumentoDigital        
   ( TituDocuDigi,   AsunDocuDigi,   NombOrig,        
     RutaFisi,    TamaDocu,    ExteDocu,       
     NombFisi,    ClasDocu,    EstDocuDigi,       
     FechEmiDocu,   FechRece,    FechRegi,       
     FechActu,    AcceDocuDigi,   CodiTipoDocu,       
     NumDocuDigi, Comentario)        
  VALUES        
   ( UPPER(@TituDocuDigi), UPPER(@AsunDocuDigi), @NombOrig,        
     @RutaFisi,   @TamaDocu,    @ExteDocu,       
     @NombFisi,   @ClasDocu,    @EstDocuDigi,      
     @FechEmiDocu,   @FechRece,    @FechRegi,       
     @FechActu,   @AcceDocuDigi,   @CodiTipoDocu,       
     @NumDocuDigi, @Comentario)        
      
  Select @outCodiDocuDigi = scope_identity()      
      
  select @outNumDocuDigi = @NumDocuDigi      
   End      
      
 If( @Type ='2')      
      
   Begin      
      
  UPDATE DocumentoDigital      
   SET TituDocuDigi = UPPER(@TituDocuDigi)      
      ,AsunDocuDigi = UPPER(@AsunDocuDigi)      
      ,NombOrig     = @NombOrig      
--      ,RutaFisi     = @RutaFisi      
--      ,TamaDocu     = @TamaDocu      
--      ,ExteDocu     = @ExteDocu      
      ,NombFisi     = @NombFisi      
      ,ClasDocu     = @ClasDocu      
      ,EstDocuDigi  = @EstDocuDigi      
      --,FechEmiDocu  = @FechEmiDocu      
      --,FechRece     = @FechRece      
      --,FechRegi     = @FechRegi     
      ,Comentario = @Comentario     
      ,FechActu     = @FechActu      
      ,AcceDocuDigi = @AcceDocuDigi      
      ,CodiTipoDocu = @CodiTipoDocu           
  WHERE NumDocuDigi = @NumDocuDigi      
      
  --Retorna el Codigo de Documento Digital      
  Select @outCodiDocuDigi = 0      
      
   End      
END 