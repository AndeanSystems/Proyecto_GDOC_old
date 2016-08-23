using System;
using System.Collections.Generic;
using System.ServiceModel;

//using Service.Message.Entity.Response;
//using Service.Message.Entity.Request;
using Service.Message.Resquest_Response;

namespace Service.Service.Interfaces
{
    [ServiceContract]
    public interface IDigitalizacionService
    {

#region Class: Documento Digital - Referencias

        [OperationContract]
        DocDigResponse SetDocDigAdd(ref DocDigRequest RqtDocDig);

        [OperationContract]
        LDocDigResponse GetDocDigital(DocDigRequest RqtDocDigi);


    #region Class: Referencias

        [OperationContract]
        DocDigRefResponse SetDocDigRefAdd(DocDigRefRequest RqtDocDigRef);

        [OperationContract]
        LDocDigRefResponse GetDocDigRef(DocDigRefRequest RqtDocDigRef);
        
    #endregion

#endregion


#region Class: Tipo de Documentos

        [OperationContract]
        DocDigDTResponse GetListaTipoDoc(DocDigDTRequest RqtListaTipoDoc);
        
#endregion

    
#region Class: Documento Adjunto

        [OperationContract]
        DocAdjResponse SetDocAdj(DocAdjRequest RqtDocAdj);

        [OperationContract]
        LDocAdjResponse GetDocAdj(DocAdjRequest RqtDocAdj);

        [OperationContract]
        DocAdjResponse SetAnulaDocAdj(DocAdjRequest RqtDocAdj);

#endregion


#region Class: Documento Electronico

        [OperationContract]
        DocumentoElectronicoResponse SetDocumentoElectronicoEnviar(ref DocumentoElectronicoRequest RqtDocumentoElectronico);

        [OperationContract]
        LDocElecResponse GetDocElec(DocumentoElectronicoRequest RqtDocElect);

#endregion


#region Class: Log de Operacion

        [OperationContract]
        LogOperacionResponse SetLogOperacion(LogOperacionRequest RqtLogOperacion);

#endregion


#region Class: Mensajes de Alerta

        [OperationContract]
        MensajeAlertaResponse SetMensajeAlerta(MensajeAlertaRequest RqtMensajeAlerta);

        [OperationContract]
        LMensajeAlertaResponse GetMensajAlerta(MensajeAlertaRequest RqtMensAlert);

#endregion


#region Class: Mesa Virtual

        [OperationContract]
        MesaVirtualResponse GetListMesaVirtual(MesaVirtualRequest RqtListMesVir);

        [OperationContract]
        InsertMesaVResponse SetMesaVirtual(ref MesaVirtualRequest RqtListMesVir);
     
        [OperationContract]
        InsertMesaVResponse SetMesaComent(ref MesaVirtualRequest RqtComentVir);//Comentario Mesa Virtual

        [OperationContract]
        MesaVirtualResponse GetListMesaComent(MesaVirtualRequest RqtListMesCom);//Comentario Mesa Virtual Lista
        
#endregion


    }
}
