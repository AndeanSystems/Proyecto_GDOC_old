﻿using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface ITipoOperacion
    {
        IList<eTipoOperacion> GetTipoOperacion(eTipoOperacion _eTipoOperacion);
    }
}