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
    public class dSqlBandejaMV: IBandejaMV
    {
        private dbConexion _db = new dbConexion();

        public dSqlBandejaMV()
        {
            _db = new dbConexion();
        }

        public IList<eMesaVirtual> GetBandejaMV(eMesaVirtual sMesaVirtual)
        {
            IList<eMesaVirtual> _lstTmp = new List<eMesaVirtual>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulBandejaMV;

                sqlcmd.Parameters.Add("@iType", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iTipoPart", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@sEstado", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@sClase", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@sAsunto", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@sPeriodo", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@dFecha", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@Prioridad", SqlDbType.VarChar);

                sqlcmd.Parameters["@iType"].Value = sMesaVirtual.Type.ToInt16();
                sqlcmd.Parameters["@iCodiUsu"].Value = sMesaVirtual.CodiUsu.ToInt64();
                sqlcmd.Parameters["@iTipoPart"].Value = sMesaVirtual.TipoPart.ToInt16();
                sqlcmd.Parameters["@sEstado"].Value = sMesaVirtual.Estado.ToText();
                sqlcmd.Parameters["@sClase"].Value = sMesaVirtual.ClaseMV.ToInt16();
                sqlcmd.Parameters["@sAsunto"].Value = sMesaVirtual.Asunto.ToText();
                sqlcmd.Parameters["@sPeriodo"].Value = sMesaVirtual.Periodo.ToText();
                sqlcmd.Parameters["@dFecha"].Value = sMesaVirtual.Fecha.ToDateTime();
                sqlcmd.Parameters["@Prioridad"].Value = sMesaVirtual.Prioridad.ToText();
                

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

        private IList<eMesaVirtual> MakeUniqueDatos(IDataReader idr)
        {
            IList<eMesaVirtual> list = new List<eMesaVirtual>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eMesaVirtual MakeDatosMapeados(IDataReader idr)
        {
            eMesaVirtual sMesVir = new eMesaVirtual();

            sMesVir.CodiOper = idr["CodiOper"].ToInt64();
            sMesVir.Asunto = idr["Asunto"].ToText();
            sMesVir.Titulo = idr["Titulo"].ToText();
            sMesVir.Acceso = idr["Acceso"].ToText();
            sMesVir.NumOper = idr["NumOper"].ToText();
            sMesVir.Fecha = idr["Fecha"].ToDateTime();
            sMesVir.FechaFin = idr["FechaFin"].ToDateTime();
            sMesVir.Estado = idr["Estado"].ToText();
            sMesVir.CodiUsu = idr["Autor"].ToInt64();
            sMesVir.Usuario = idr["Usuario"].ToText();
            sMesVir.TipoPart = idr["TipoPart"].ToInt();
            sMesVir.Prioridad = idr["Prioridad"].ToText();
            sMesVir.ConfLect = idr["ConfLect"].ToText();

            return sMesVir;
        }
    }
}
