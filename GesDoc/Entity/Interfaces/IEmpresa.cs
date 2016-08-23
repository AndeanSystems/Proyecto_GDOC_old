using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IEmpresa
    {
        Int64 SetEmpresaAdd(eEmpresa _eEmpresa);

        IList<eEmpresa> GetEmpresa(eEmpresa _eEmpresa);
    }
}
