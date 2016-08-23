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
    public class dSqlListUsuarioGr: IListUsuarioGr
    {
        private dbConexion _db = new dbConexion();

        public dSqlListUsuarioGr()
        {
            _db = new dbConexion();
        }


        public IList<eGrupo> GetUsuarioGrupo(eGrupo sGrupo)
        {
            IList<eGrupo> _lstTmp = new List<eGrupo>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsUsurGruop;

                sqlcmd.Parameters.Add("@sCodiGrupo", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@sIdeGrupo", SqlDbType.VarChar);

                sqlcmd.Parameters["@sCodiGrupo"].Value = sGrupo.CodiGrup.ToInt64();
                sqlcmd.Parameters["@sIdeGrupo"].Value = sGrupo.UsuarioGrupo.IdeUsuario.ToText();

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
            eGrupo sUsurGroup= new eGrupo();

            sUsurGroup.CodiGrup = idr["CodiGrup"].ToInt64();
            sUsurGroup.UsuarioGrupo.Codigo = idr["CodiUsu"].ToInt64();

            return sUsurGroup;
        }
    }
}
