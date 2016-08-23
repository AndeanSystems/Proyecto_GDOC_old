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
    public class dSqlGrupo: IGrupo
    {
        private dbConexion _db = new dbConexion();

        public dSqlGrupo()
        {
            _db = new dbConexion();
        }

        public Int64 GrupoAdd(eGrupo sGrupo)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarGrupo;

                SqlParameter outputIdParam1 = new SqlParameter("@OutCodiGrup", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };

                sqlcmd.Parameters.Add(outputIdParam1);
                sqlcmd.Parameters.Add("@CodiGrup", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@NombGrup", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FechCrea", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@UsuCrea", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@ComeGrup", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstGrup", SqlDbType.VarChar);


                sqlcmd.Parameters["@CodiGrup"].Value = sGrupo.CodiGrup.ToInt64();
                sqlcmd.Parameters["@NombGrup"].Value = sGrupo.NombGrup.ToText();
                sqlcmd.Parameters["@FechCrea"].Value = sGrupo.FechCrea.ToDateTime();
                sqlcmd.Parameters["@UsuCrea"].Value = sGrupo.UsuCrea.ToText();
                sqlcmd.Parameters["@ComeGrup"].Value = sGrupo.ComeGrup.ToText();
                sqlcmd.Parameters["@EstGrup"].Value = sGrupo.EstGrup.ToText();

                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();

                sGrupo.CodiGrup = outputIdParam1.Value.ToInt64();

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
