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
    public class dSqlRol: IRol
    {
        private dbConexion _db = new dbConexion();

        public dSqlRol()
        {
            _db = new dbConexion();
        }

        public IList<eRol> GetTipoRol(eRol sRol)
        {
            IList<eRol> _lstTmp = new List<eRol>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPListaRol;

                sqlcmd.Parameters.Add("@sEstTipoRol", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstTipoRol"].Value = sRol.EstTipoRol.ToText();

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

        private IList<eRol> MakeUniqueDatos(IDataReader idr)
        {
            IList<eRol> list = new List<eRol>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eRol MakeDatosMapeados(IDataReader idr)
        {
            eRol sTipoRol = new eRol();

            sTipoRol.CodiRol = idr["CodiRol"].ToText();
            sTipoRol.DescRol = idr["DescRol"].ToText();

            return sTipoRol;
        }
    }
}
