using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IAccesoSistema
    {
        Int64 SetAccesoSistema(eAccesoSistema _eAccesoSistema);
        Int64 SetAnulaAcceso(eAccesoSistema _eAccesoSistema);

        IList<eAccesoSistema> GetAccesoSistema(eAccesoSistema _eAccesoSistema);
    }
}
