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
    public class dSqlPersonal: IPersonal
    {
        private dbConexion _db = new dbConexion();

        public dSqlPersonal()
        {
            _db = new dbConexion();
        }

        public Int64 SetAddPersonal(ePersonal sPersonal) 
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSInsertPersonal;

                //sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);

                SqlParameter outputIdParam = new SqlParameter("@OutCodiPers", SqlDbType.BigInt,8)
                {
                    Direction = ParameterDirection.Output
                };

                sqlcmd.Parameters.Add(outputIdParam);
                sqlcmd.Parameters.Add("@CodiPers", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@NombPers", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@ApePers", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@SexoPers", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EmaiPers", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EmaiTrab", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FechNac", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@TelePers", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AnexPers", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@CeluPers", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaPers", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@CodiTipUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiArea", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiCarg", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@ClasPers", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@RucEmpr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@DNI", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@DirePers", SqlDbType.VarChar);


                sqlcmd.Parameters["@CodiPers"].Value = sPersonal.CodigoPersona;
                sqlcmd.Parameters["@NombPers"].Value = sPersonal.NombPers;
                sqlcmd.Parameters["@ApePers"].Value = sPersonal.ApePers;
                sqlcmd.Parameters["@SexoPers"].Value = sPersonal.SexoPers;
                sqlcmd.Parameters["@EmaiPers"].Value = sPersonal.EmaiPers;
                sqlcmd.Parameters["@EmaiTrab"].Value = sPersonal.EmaiTrab;
                sqlcmd.Parameters["@FechNac"].Value = sPersonal.FechNac;
                sqlcmd.Parameters["@TelePers"].Value = sPersonal.TelePers;
                sqlcmd.Parameters["@AnexPers"].Value = sPersonal.AnexPers;
                sqlcmd.Parameters["@CeluPers"].Value = sPersonal.CeluPers;
                sqlcmd.Parameters["@EstaPers"].Value = sPersonal.EstaPers;
                sqlcmd.Parameters["@CodiTipUsu"].Value = sPersonal.CodiTipUsu;
                sqlcmd.Parameters["@CodiArea"].Value = sPersonal.CodiArea;
                sqlcmd.Parameters["@CodiCarg"].Value = sPersonal.CodiCarg;
                sqlcmd.Parameters["@ClasPers"].Value = sPersonal.ClasPers;
                sqlcmd.Parameters["@RucEmpr"].Value = sPersonal.RucEmpr;
                sqlcmd.Parameters["@DNI"].Value = sPersonal.DNI;
                sqlcmd.Parameters["@DirePers"].Value = sPersonal.DirePers;

                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();

                sPersonal.CodigoPersona =  outputIdParam.Value.ToInt64(); 

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
