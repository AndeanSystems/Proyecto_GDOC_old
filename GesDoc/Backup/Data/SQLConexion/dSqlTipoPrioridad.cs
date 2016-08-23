using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Data.Common;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Common;
using Entity;
using Entity.Entities;
using Entity.Interfaces;

namespace Data.SqlConexion
{
    public class dSqlTipoPrioridad: ITipoPrioridad
    {
        private dbConexion _db = new dbConexion();

        public dSqlTipoPrioridad()
        {
            _db = new dbConexion();
        }

        public IList<eTipoPrioridad> GetListaTipoPrioridad(eTipoPrioridad sTipoPrioridad)
        {
            IList<eTipoPrioridad> _lstTmp = new List<eTipoPrioridad>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsultarTipoPrioridad;

                sqlcmd.Parameters.Add("@sEstTipoPrioridad", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstTipoPrioridad"].Value = sTipoPrioridad.EstaTipoPrio.ToText();

                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MakeUniqueDatos(idr);
                idr.Close();

            }
            catch (Exception ex)
            { }
            finally
            {
                if (_db == null)
                {
                    if (_db.miconexion.State != ConnectionState.Closed)
                    {
                        _db.miconexion.Close();
                        _db.miconexion.Dispose();
                    }
                }
            }

            return _lstTmp;
        }

        private IList<eTipoPrioridad> MakeUniqueDatos(IDataReader idr)
        {
            IList<eTipoPrioridad> list = new List<eTipoPrioridad>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eTipoPrioridad MakeDatosMapeados(IDataReader idr)
        {
            eTipoPrioridad sTipoPrioridad = new eTipoPrioridad();

            sTipoPrioridad.CodiTipoPrio = idr["CodiTipoPrio"].ToInt64();
            sTipoPrioridad.DescTipoPrio = idr["DescTipoPrio"].ToText();

            return sTipoPrioridad;
        }

    }
}
