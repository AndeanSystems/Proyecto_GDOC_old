using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using Entity.Entities;
using Entity.Interfaces;
using Common;
using Data;
using Data.SqlConexion;

namespace Business
{
    public class bPlanGestion: IPlanGestion
    {
        private IPlanGestion _dSqlPlanGestion = new dSqlPlanGestion();
        


#region Class: Objetivo Estrategico

        public Int64 SetObetivoEstrategico(ePlanGestion sPlanGestion)
        {
            return _dSqlPlanGestion.SetObetivoEstrategico(sPlanGestion);
        }

        public IList<ePlanGestion> GetObetivoEstrategico(ePlanGestion sPlanGestion, String _Items)
        {
            return _dSqlPlanGestion.GetObetivoEstrategico(sPlanGestion, _Items);
        }
      

#endregion

#region Class: Objetivo Operativo

        public Int64 SetObetivoOperativo(ePlanGestion sPlanGestion)
        {
            return _dSqlPlanGestion.SetObetivoOperativo(sPlanGestion);
        }

        public IList<ePlanGestion> GetObetivoOperativo(ePlanGestion sPlanGestion, String _Items)
        {
            return _dSqlPlanGestion.GetObetivoOperativo(sPlanGestion, _Items);
        }

#endregion

#region Class: Proyecto

        public Int64 SetProyecto(ePlanGestion sPlanGestion)
        {
            return _dSqlPlanGestion.SetProyecto(sPlanGestion);
        }

        public IList<ePlanGestion> GetProyecto(ePlanGestion sPlanGestion, String _Items)
        {
            return _dSqlPlanGestion.GetProyecto(sPlanGestion, _Items);
        }
     
#endregion

#region Class: Actividad

        public Int64 SetActividad(ePlanGestion sPlanGestion)
        {
            return _dSqlPlanGestion.SetActividad(sPlanGestion);
        }

        public IList<ePlanGestion> GetActividad(ePlanGestion sPlanGestion, String _Items)
        {
            return _dSqlPlanGestion.GetActividad(sPlanGestion,_Items);
        }

#endregion

#region Class: Comentario de Avance

        public Int64 SetComentarioAvance(ePlanGestion sPlanGestion)
        {
            return _dSqlPlanGestion.SetComentarioAvance(sPlanGestion);
        }

        public IList<ePlanGestion> GetComentarioAvance(ePlanGestion sPlanGestion, String _Items)
        {
            return _dSqlPlanGestion.GetComentarioAvance(sPlanGestion,_Items);
        }

#endregion

#region Class: Informe

        public IList<ePlanGestion> GetInforme(ePlanGestion sPlanGestion)
        {
            return _dSqlPlanGestion.GetInforme(sPlanGestion);
        }
#endregion

    }
}
