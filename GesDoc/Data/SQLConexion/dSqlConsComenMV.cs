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
    public class dSqlConsComenMV: IConsComenMV
    {
        private dbConexion _db = new dbConexion();

        public dSqlConsComenMV()
        {
            _db = new dbConexion();
        }

        public IList<eMesaVirtual> GetComenMesa(eMesaVirtual sMesaVirtual)
        {
            IList<eMesaVirtual> _lstTmp = new List<eMesaVirtual>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsMesaVirtualComet;

                sqlcmd.Parameters.Add("@CodiMesaV", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);

                sqlcmd.Parameters["@CodiMesaV"].Value = sMesaVirtual.CodiOper;
                sqlcmd.Parameters["@CodiUsu"].Value = sMesaVirtual.CodiUsu;

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
            eMesaVirtual sMesaComent = new eMesaVirtual();

            sMesaComent.CodiMesaComent = idr["CodiComeMesaV"].ToInt64();
            sMesaComent.Asunto = idr["ComeMesaV"].ToText();
            sMesaComent.Fecha = idr["FechPubl"].ToDateTime();
            sMesaComent.Estado = idr["EstCome"].ToText();
            sMesaComent.CodiOper = idr["CodiMesaV"].ToInt64();
            sMesaComent.CodiUsu = idr["CodiUsu"].ToInt64();

            return sMesaComent;
        }
    }
}
