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
    public class dSqlTipoAcceso: ITipoAcceso
    {
        private dbConexion _db = new dbConexion();

        public dSqlTipoAcceso()
        {
            _db = new dbConexion();
        }
        
        public IList<eTipoAcceso> GetListaTipoAcceso(eTipoAcceso sTipoAcceso)
        {
            IList<eTipoAcceso> _lstTmp = new List<eTipoAcceso>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsultarTipoAcceso;

                sqlcmd.Parameters.Add("@sEstTipoAcceso", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstTipoAcceso"].Value = sTipoAcceso.EstAcc.ToText();

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

        private IList<eTipoAcceso> MakeUniqueDatos(IDataReader idr)
        {
            IList<eTipoAcceso> list = new List<eTipoAcceso>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eTipoAcceso MakeDatosMapeados(IDataReader idr)
        {
            eTipoAcceso sTipoAcceso = new eTipoAcceso();

            sTipoAcceso.TipoAcc = idr["TipoAcc"].ToText();
            sTipoAcceso.DescAcc = idr["DescAcc"].ToText();

            return sTipoAcceso;
        }

    }
}
