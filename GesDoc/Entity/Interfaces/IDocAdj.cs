using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IDocAdj
    {
        Int64 SetDocAdj(eDocAdj _eDocAdj);
        Int64 SetAnulaDocAdj(eDocAdj _eDocAdj);

        IList<eDocAdj> GetDocAdj(eDocAdj _eDocAdj);
    }
}
