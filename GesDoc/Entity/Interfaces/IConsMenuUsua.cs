using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IConsMenuUsua
    {
        IList<eAccesoSistema> GetMenuUsuario(eAccesoSistema _eAccesoSistema);
    }
}
