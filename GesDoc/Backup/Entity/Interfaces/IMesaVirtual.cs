using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IMesaVirtual
    {
        IList<eMesaVirtual> GetMesaVirtual(eMesaVirtual _eMesaVirtual);

    }

    public interface IInserMesaVirtual
    {
        Int64 SetMesaVirtual(eMesaVirtual _eMesaVirtual);
    }
}
