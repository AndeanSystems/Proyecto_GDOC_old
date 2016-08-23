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
    public class dSqlDocumentoElectronico: IDocumentoElectronico  
    {
        private dbConexion _db = new dbConexion();

        public dSqlDocumentoElectronico()
        {
            _db = new dbConexion();
        }

        public Int64 SetDocumentoElectronicoEnviar(eDocumentoElectronico sDocumentoElectronico)
        {
            //if (dbCommand.Parameters[3].Value.ToText() == "1" && dbCommand.Parameters[11].Value.ToText() == "C") 
            //    dbCommand.Parameters[7].Value = DBNull.Value;
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarDocElec;
                
                SqlParameter outputIdParam1 = new SqlParameter("@outCodiDocuElec", SqlDbType.BigInt,8)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter outputIdParam2 = new SqlParameter("outNumDocuElec", SqlDbType.VarChar,50)
                {
                    Direction = ParameterDirection.Output
                };

                sqlcmd.Parameters.Add(outputIdParam1);
                sqlcmd.Parameters.Add(outputIdParam2);

                sqlcmd.Parameters.Add("@CodiDocuElec", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@Type", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@TipoComu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AsunDocuElec", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FechEmi", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@FechEnvi", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@PrioDocuElec", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@MensDocuElec", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FechVige", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@EstDocuElec", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FechCie", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@AcceDocuElec", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@CodiTipoDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@NumDocuElec", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@Memo", SqlDbType.VarChar);
                
                sqlcmd.Parameters["@CodiDocuElec"].Value = sDocumentoElectronico.CodiDocuElec.ToInt64();
                sqlcmd.Parameters["@Type"].Value = sDocumentoElectronico.Type.ToText();
                sqlcmd.Parameters["@TipoComu"].Value = sDocumentoElectronico.TipoComu.ToText();
                sqlcmd.Parameters["@AsunDocuElec"].Value = sDocumentoElectronico.AsunDocuElec.ToText();
                sqlcmd.Parameters["@FechEmi"].Value = sDocumentoElectronico.FechEmi.ToDateTime();
                sqlcmd.Parameters["@FechEnvi"].Value = sDocumentoElectronico.FechEnvi.ToDateTime();
                sqlcmd.Parameters["@PrioDocuElec"].Value = sDocumentoElectronico.PrioDocuElec.ToText();
                sqlcmd.Parameters["@MensDocuElec"].Value = sDocumentoElectronico.MensDocuElec.ToText();
                sqlcmd.Parameters["@FechVige"].Value = sDocumentoElectronico.FechVige.ToDateTime();
                sqlcmd.Parameters["@EstDocuElec"].Value = sDocumentoElectronico.EstDocuElec.ToText();
                sqlcmd.Parameters["@FechCie"].Value = sDocumentoElectronico.FechCie.ToDateTime();
                sqlcmd.Parameters["@AcceDocuElec"].Value = sDocumentoElectronico.TipoAcc.ToText();
                sqlcmd.Parameters["@CodiTipoDocu"].Value = sDocumentoElectronico.CodiTipoDocu.ToText();
                sqlcmd.Parameters["@NumDocuElec"].Value = sDocumentoElectronico.NumDocuElec.ToText();
                sqlcmd.Parameters["@iCodiUsu"].Value = sDocumentoElectronico.CodUsu.ToInt64();
                sqlcmd.Parameters["@Memo"].Value = sDocumentoElectronico.Memo.ToText();
            
                _TmpInt64 = (Int64)sqlcmd.ExecuteNonQuery();

                sDocumentoElectronico.CodiOper = outputIdParam1.Value.ToInt64();
                sDocumentoElectronico.NumDocuElec = outputIdParam2.Value.ToText();
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