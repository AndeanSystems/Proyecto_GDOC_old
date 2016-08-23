using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IConsModuPag
    {
        IList<eModuloPagina> GetModuloPagina(eModuloPagina _eModuloPagina);
    }
}
