using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface ILUserPart
    {
        IList<eParticipante> GetUserPart(eParticipante _eParticipante);
        IList<eParticipante> GetUserPartBatch(List<long> listCodiOper, List<long> listCodiUsu);
    }
}
