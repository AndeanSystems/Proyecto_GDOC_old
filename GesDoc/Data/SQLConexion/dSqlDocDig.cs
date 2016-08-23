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
    public class dSqlDocDig: IDocDig
    {
        private dbConexion _db = new dbConexion();

        public dSqlDocDig()
        {
            _db = new dbConexion();
        }

        public Int64 SetDocDigAdd(eDocDig sDocDig)
        {
            //if (dbCommand.Parameters[3].Value.ToText() == "1")
            //    dbCommand.Parameters[16].Value = DBNull.Value;

            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarDocDig;

                SqlParameter outputIdParam1 = new SqlParameter("@outCodiDocuDigi", SqlDbType.BigInt,8)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter outputIdParam2 = new SqlParameter("@outNumDocuDigi", SqlDbType.VarChar,50)
                {
                    Direction = ParameterDirection.Output
                };

                
                sqlcmd.Parameters.Add(outputIdParam1);
                sqlcmd.Parameters.Add(outputIdParam2);
                sqlcmd.Parameters.Add("@CodiDocuDigi", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@Type", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@TituDocuDigi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AsunDocuDigi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@NombOrig", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@RutaFisi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@TamaDocu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@ExteDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@NombFisi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@ClasDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstDocuDigi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FechEmiDocu", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@FechRece", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@FechRegi", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@FechActu", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@AcceDocuDigi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@CodiTipoDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@NumDocuDigi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@Comentario", SqlDbType.VarChar);

                sqlcmd.Parameters["@CodiDocuDigi"].Value = sDocDig.CodiDocuDigi.ToInt64();
                sqlcmd.Parameters["@Type"].Value = sDocDig.Type.ToText();
                sqlcmd.Parameters["@TituDocuDigi"].Value = sDocDig.TituDocuDigi.ToText();
                sqlcmd.Parameters["@AsunDocuDigi"].Value = sDocDig.AsunDocuDigi.ToText();
                sqlcmd.Parameters["@NombOrig"].Value = sDocDig.NombOrig.ToText();
                sqlcmd.Parameters["@RutaFisi"].Value = sDocDig.RutaFisi.ToText();
                sqlcmd.Parameters["@TamaDocu"].Value = sDocDig.TamaDocu.ToInt64();
                sqlcmd.Parameters["@ExteDocu"].Value = sDocDig.ExteDocu.ToText();
                sqlcmd.Parameters["@NombFisi"].Value = sDocDig.NombFisi.ToText();
                sqlcmd.Parameters["@ClasDocu"].Value = sDocDig.ClasDocu.ToText();
                sqlcmd.Parameters["@EstDocuDigi"].Value = sDocDig.EstDocuDigi.ToText();
                sqlcmd.Parameters["@FechEmiDocu"].Value = sDocDig.FechEmiDocu.ToDateTime();
                sqlcmd.Parameters["@FechRece"].Value = sDocDig.FechRece.ToDateTime();
                sqlcmd.Parameters["@FechRegi"].Value = sDocDig.FechRegi.ToDateTime();
                sqlcmd.Parameters["@FechActu"].Value = sDocDig.FechActu.ToDateTime();
                sqlcmd.Parameters["@AcceDocuDigi"].Value = sDocDig.AcceDocuDigi.ToText();
                sqlcmd.Parameters["@CodiTipoDocu"].Value = sDocDig.CodiTipoDocu.ToText();
                sqlcmd.Parameters["@NumDocuDigi"].Value = sDocDig.NumDocuDigi.ToText();
                sqlcmd.Parameters["@iCodiUsu"].Value = sDocDig.CodUsu.ToInt64();
                sqlcmd.Parameters["@Comentario"].Value = sDocDig.Comentario;


                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();

                sDocDig.CodiDocuDigi = outputIdParam1.Value.ToInt64();
                sDocDig.NumDocuDigi = outputIdParam2.Value.ToText();

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
