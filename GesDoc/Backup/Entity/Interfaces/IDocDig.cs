using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IDocDig
    {
        Int64 SetDocDigAdd(eDocDig _eDocDig);
    }

    public interface IDocDigListTD
    {
        IList<eDocDigListTD> GetListaTipoDoc(eDocDigListTD _eDocDigListTD);
    }
}
