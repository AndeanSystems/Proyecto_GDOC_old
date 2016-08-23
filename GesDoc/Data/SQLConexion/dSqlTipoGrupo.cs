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
    public class dSqlTipoGrupo: ITipoGrupo
    {
        private dbConexion _db = new dbConexion();

        public dSqlTipoGrupo()
        {
            _db = new dbConexion();
        }
        
        public IList<eGrupo> GetTipoGrupo(eGrupo sGrupo)
        {
            IList<eGrupo> _lstTmp = new List<eGrupo>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsTipoGrupo;

                sqlcmd.Parameters.Add("@sEstGrupo", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstGrupo"].Value = sGrupo.EstGrup.ToText();

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

        private IList<eGrupo> MakeUniqueDatos(IDataReader idr)
        {
            IList<eGrupo> list = new List<eGrupo>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eGrupo MakeDatosMapeados(IDataReader idr)
        {
            eGrupo sTipoGrupo = new eGrupo();

            sTipoGrupo.CodiGrup = idr["CodiGrup"].ToText().ToInt64();
            sTipoGrupo.NombGrup = idr["NombGrup"].ToText().ToText();

            return sTipoGrupo;
        }

    }
}
