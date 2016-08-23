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
    public class dSqlGrupoUsuarios: IGrupoUsuarios
    {
        private dbConexion _db = new dbConexion();

        public dSqlGrupoUsuarios()
        {
            _db = new dbConexion();
        }

        public Int64 GrupoUserAdd(eUsuarioGrupo sGrupo)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarGrupoPart;

                sqlcmd.Parameters.Add("@CodiUsuGrup", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiGrup", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@UsuCrea", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FechCrea", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@EstUsuGrup", SqlDbType.VarChar);

                sqlcmd.Parameters["@CodiUsuGrup"].Value = sGrupo.CodiUsuGrup.ToInt64();
                sqlcmd.Parameters["@CodiUsu"].Value = sGrupo.Usuario.Codigo.ToInt64();
                sqlcmd.Parameters["@CodiGrup"].Value = sGrupo.Grupo.CodiGrup.ToInt64();
                sqlcmd.Parameters["@UsuCrea"].Value = sGrupo.UsuCrea.ToText();
                sqlcmd.Parameters["@FechCrea"].Value = sGrupo.FechCrea.ToDateTime();
                sqlcmd.Parameters["@EstUsuGrup"].Value = sGrupo.EstUsuGrup.ToText();

                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();
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

            return _TmpInt64;
        }

        public Int64 AnulaGrupoUser(eUsuarioGrupo sGrupo)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPUpdateGrupoPart;

                sqlcmd.Parameters.Add("@CodiGrup", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);

                sqlcmd.Parameters["@CodiGrup"].Value = sGrupo.Grupo.CodiGrup.ToInt64();
                sqlcmd.Parameters["@CodiUsu"].Value = sGrupo.Usuario.Codigo.ToInt64();
                

                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();
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

            return _TmpInt64;
            
        }
    }
}
