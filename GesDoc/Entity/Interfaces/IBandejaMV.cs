using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IBandejaMV
    {
        IList<eMesaVirtual> GetBandejaMV(eMesaVirtual _eMesaVirtual);
    }
}
