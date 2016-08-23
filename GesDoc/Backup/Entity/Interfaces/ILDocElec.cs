using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface ILDocElec
    {
        IList<eDocumentoElectronico> GetDocElec(eDocumentoElectronico _eDocumentoElectronico);
    }
}
