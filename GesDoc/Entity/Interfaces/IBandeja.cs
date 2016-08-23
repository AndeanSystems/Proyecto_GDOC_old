using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IBandeja
    {
        IList<eOperaciones> GetBandejaDoc(eOperaciones _eOperaciones);
    }
}
