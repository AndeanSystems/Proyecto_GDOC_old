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
    public class dSqlTipoOperacion: ITipoOperacion
    {
        private dbConexion _db = new dbConexion();

        public dSqlTipoOperacion()
        {
            _db = new dbConexion();
        }
        
        public IList<eTipoOperacion> GetTipoOperacion(eTipoOperacion sTipoOperacion)
        {
            IList<eTipoOperacion> _lstTmp = new List<eTipoOperacion>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsTipoOperacion;

                sqlcmd.Parameters.Add("@sEstTipoOperacion", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstTipoOperacion"].Value = sTipoOperacion.EstTipoOperacion.ToText();

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

        private IList<eTipoOperacion> MakeUniqueDatos(IDataReader idr)
        {
            IList<eTipoOperacion> list = new List<eTipoOperacion>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }


        private eTipoOperacion MakeDatosMapeados(IDataReader idr)
        {
            eTipoOperacion sTipoOperacion = new eTipoOperacion();

            sTipoOperacion.CodiTipoOper = idr["CodiTipoOper"].ToText();
            sTipoOperacion.DescTipoOper = idr["DescTipoOper"].ToText();

            return sTipoOperacion;
        }
    }
}
