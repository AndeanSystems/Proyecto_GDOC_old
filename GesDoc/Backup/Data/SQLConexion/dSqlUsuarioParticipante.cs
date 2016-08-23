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
    public class dSqlUsuarioParticipante: IUsuarioParticipante
    {
        private dbConexion _db = new dbConexion();

        public dSqlUsuarioParticipante()
        {
            _db = new dbConexion();
        }

        public Int64 SetUsuParticipante(eParticipante sParticipante)
        {
            Int64 _return = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarUsuParticip;

                sqlcmd.Parameters.Add("@iCodiUsuPart", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cTipoOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cTipoPart", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@cApruOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cEnviNoti", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@dFechNoti", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@cEstaUsuaPart", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cReenvio", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cEnvio", SqlDbType.VarChar);

                sqlcmd.Parameters["@iCodiUsuPart"].Value = sParticipante.CodiUsuPart.ToInt64();
                sqlcmd.Parameters["@cTipoOper"].Value = sParticipante.TipoOper.ToText();
                sqlcmd.Parameters["@iCodiOper"].Value = sParticipante.CodiOper.ToInt64();
                sqlcmd.Parameters["@cTipoPart"].Value = sParticipante.TipoPart.ToInt16();
                sqlcmd.Parameters["@cApruOper"].Value = sParticipante.ApruOper.ToText();
                sqlcmd.Parameters["@cEnviNoti"].Value = sParticipante.EnviNoti.ToText();
                sqlcmd.Parameters["@dFechNoti"].Value = sParticipante.FechNoti.ToDateTime();
                sqlcmd.Parameters["@cEstaUsuaPart"].Value = sParticipante.EstaUsuaPart.ToText();
                sqlcmd.Parameters["@iCodiUsu"].Value = sParticipante.CodiUsu.ToInt64();
                sqlcmd.Parameters["@cReenvio"].Value = sParticipante.Reenvio.ToText();
                sqlcmd.Parameters["@cEnvio"].Value = sParticipante.Envio.ToText();

                _return = (int)sqlcmd.ExecuteScalar();
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

            return _return;
        }

        public Int64 UpdateUsuParticipante(eParticipante sParticipante)
        {
            Int64 _return = 0;
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPUpdateUsuParticip;

                sqlcmd.Parameters.Add("@iCodiUsuPart", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cTipoOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cTipoPart", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cConfLect", SqlDbType.VarChar);

                sqlcmd.Parameters["@iCodiUsuPart"].Value = sParticipante.CodiUsuPart.ToInt64();
                sqlcmd.Parameters["@cTipoOper"].Value = sParticipante.TipoOper.ToText();
                sqlcmd.Parameters["@iCodiOper"].Value = sParticipante.CodiOper.ToInt64();
                sqlcmd.Parameters["@cTipoPart"].Value = sParticipante.TipoPart.ToInt16();
                sqlcmd.Parameters["@iCodiUsu"].Value = sParticipante.CodiUsu.ToInt64();
                sqlcmd.Parameters["@cConfLect"].Value = sParticipante.ConfLect.ToText();

                sqlcmd.ExecuteScalar();
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

            return _return;
        }

        public Int64 SetAnulaUserPart(eParticipante sParticipante)
        {
             Int64 _return = 0;

             try
             {
                 SqlCommand sqlcmd = new SqlCommand();
                 sqlcmd.Connection = _db.miconexion;
                 sqlcmd.CommandType = CommandType.StoredProcedure;
                 sqlcmd.CommandText = _db.sSPAnulaUsuParticip;

                 sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                 sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);

                 sqlcmd.Parameters["@iCodiOper"].Value = sParticipante.CodiOper.ToInt64();
                 sqlcmd.Parameters["@iCodiUsu"].Value = sParticipante.CodiUsu.ToInt64();

                 _return = (int)sqlcmd.ExecuteScalar();
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

             return _return;
         }
    }
}
