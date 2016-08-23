using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IBuscarDocumentos
    {
        IList<eBuscarDocumentos> GetBusDocDig(eBuscarDocumentos _eBuscarDocumentos);
        IList<eBuscarDocumentos> GetBusDocElect(eBuscarDocumentos _eBuscarDocumentos);
        IList<eBuscarDocumentos> GetBusMesaVirtual(eBuscarDocumentos _eBuscarDocumentos);
        IList<eBuscarDocumentos> GetBuscarAdjunto(eBuscarDocumentos _eBuscarDocumentos);
    }
}
