using System;
using System.Collections.Generic;
using System.ServiceModel;

//using Service.Message.Entity.Response;
//using Service.Message.Entity.Request;

using Service.Message.Resquest_Response;

namespace Service.Service.Interfaces
{
    [ServiceContract]
    public interface IBusquedaService
    {

#region Lista : Busqueda de Documentos Digitales

        [OperationContract]
        BuscarDocumentoResponse GetDocumentoDigital(BuscarDocumentoRequest RqtDocDig);

#endregion


#region Lista : Busqueda de Documentos Electronicos

        [OperationContract]
        BuscarDocumentoResponse GetDocumentoElectronico(BuscarDocumentoRequest RqtDocElect);

#endregion


#region Lista : Busqueda de Mesa Virtual

        [OperationContract]
        BuscarDocumentoResponse GetMesaVirtual(BuscarDocumentoRequest RqtMesaVirtual);

#endregion

#region Lista : Busqueda en Bandeja Mesa Virtual

        [OperationContract]
        MesaVirtualResponse GetBandejaMV(MesaVirtualRequest RqtListMesVir);
        
#endregion


#region Lista : Busqueda en Bandeja Documento Electronico

        [OperationContract]
        OperacionResponse GetBandejaDoc(OperacionRequest RqtListOper);

#endregion       

        [OperationContract]
        MesaVirtualResponse GetTipoMesaVirtual(MesaVirtualRequest RqtMesaVirtual);

        [OperationContract]
        BuscarLogOperResponse GetBuscarLogOper(BuscarLogOperRequest RqtLogOper);


#region Lista : Busqueda de Documentos Adjunto (Control)

        [OperationContract]
        BuscarDocumentoResponse GetDocumentoAdjunto(BuscarDocumentoRequest RqtDocAdj);

#endregion

        [OperationContract]
        UbigeoResponse GetUbigeo(UbigeoRequest RqtUbigeo);
    }
}
