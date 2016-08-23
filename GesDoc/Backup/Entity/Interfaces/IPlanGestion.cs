using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IPlanGestion
    {
        Int64 SetObetivoEstrategico(ePlanGestion _ePlanGestion);
        IList<ePlanGestion> GetObetivoEstrategico(ePlanGestion _ePlanGestion, String _Items);

        Int64 SetObetivoOperativo(ePlanGestion _ePlanGestion);
        IList<ePlanGestion> GetObetivoOperativo(ePlanGestion _ePlanGestion, String _Items);

        Int64 SetProyecto(ePlanGestion _ePlanGestion);
        IList<ePlanGestion> GetProyecto(ePlanGestion _ePlanGestion, String _Items);

        Int64 SetActividad(ePlanGestion _ePlanGestion);
        IList<ePlanGestion> GetActividad(ePlanGestion _ePlanGestion, String _Items);

        Int64 SetComentarioAvance(ePlanGestion _ePlanGestion);
        IList<ePlanGestion> GetComentarioAvance(ePlanGestion _ePlanGestion, String _Items);

        IList<ePlanGestion> GetInforme(ePlanGestion _ePlanGestion);

    }
}
