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
    public class dSqlMesaVirtual: IMesaVirtual
    {
        private dbConexion _db = new dbConexion();

        public dSqlMesaVirtual()
        {
            _db = new dbConexion();
        }


        public IList<eMesaVirtual> GetMesaVirtual(eMesaVirtual sMesaVirtual)
        {
            IList<eMesaVirtual> _lstTmp = new List<eMesaVirtual>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsMesaVirtualUsu;

                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiMesaVirt", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@NumMesaVirt", SqlDbType.VarChar);

                sqlcmd.Parameters["@iCodiUsu"].Value = sMesaVirtual.CodiUsu.ToInt64();
                sqlcmd.Parameters["@CodiMesaVirt"].Value = sMesaVirtual.CodiOper.ToInt64();
                sqlcmd.Parameters["@NumMesaVirt"].Value = sMesaVirtual.NumOper.ToText();

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
            sMesVir.Prioridad = idr["Prioridad"].ToText();
            sMesVir.Notifica = idr["Notifica"].ToText();
            sMesVir.ClaseMV = idr["Clase"].ToInt16();
            sMesVir.CodiUsu = idr["CodiUsu"].ToInt64();
            sMesVir.Usuario = idr["Usuario"].ToText();
            sMesVir.TipoPart = idr["TipoPart"].ToInt();
            
            return sMesVir;
        }
    }
}
