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
    public class dSqlTipoEvento: ITipoEvento
    {
        private dbConexion _db = new dbConexion();

        public dSqlTipoEvento()
        {
            _db = new dbConexion();
        }
        
        public IList<eTipoEvento> GetTipoEvento(eTipoEvento sTipoEvento)
        {
            IList<eTipoEvento> _lstTmp = new List<eTipoEvento>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsTipoEvento;

                sqlcmd.Parameters.Add("@sEstTipoEvento", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstTipoEvento"].Value = sTipoEvento.EstTipoEvento.ToText();

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

        private IList<eTipoEvento> MakeUniqueDatos(IDataReader idr)
        {
            IList<eTipoEvento> list = new List<eTipoEvento>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }


        private eTipoEvento MakeDatosMapeados(IDataReader idr)
        {
            eTipoEvento sTipoEvento = new eTipoEvento();

            sTipoEvento.CodiEven = idr["CodiEven"].ToText();
            sTipoEvento.DescEven = idr["DescEven"].ToText();

            return sTipoEvento;
        }
    }
}
