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
    public class dSqlEmpresa: IEmpresa
    {
        private dbConexion _db = new dbConexion();

        public dSqlEmpresa()
        {
            _db = new dbConexion();
        }

        public Int64 SetEmpresaAdd(eEmpresa sEmpresa)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarEmpresa;

                sqlcmd.Parameters.Add("@Type", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iRucEmpr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cRazoSoci", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cDireEmpr", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cCodiUbig", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@dFechRegi", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@EstEmpr", SqlDbType.VarChar);


                sqlcmd.Parameters["@Type"].Value = sEmpresa.Type.ToText();
                sqlcmd.Parameters["@iRucEmpr"].Value = sEmpresa.RucEmpr.ToInt64();
                sqlcmd.Parameters["@cRazoSoci"].Value = sEmpresa.RazoSoci.ToText();
                sqlcmd.Parameters["@cDireEmpr"].Value = sEmpresa.DireEmpr.ToText();
                sqlcmd.Parameters["@cCodiUbig"].Value = sEmpresa.CodiUbig.ToText();
                sqlcmd.Parameters["@dFechRegi"].Value = sEmpresa.FechRegi.ToDateTime();
                sqlcmd.Parameters["@iCodiUsu"].Value = sEmpresa.CodiUsu.ToInt64();
                sqlcmd.Parameters["@EstEmpr"].Value = sEmpresa.EstEmpr.ToText();

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

        public IList<eEmpresa> GetEmpresa(eEmpresa sEmpresa)
        {
            IList<eEmpresa> _lstTmp = new List<eEmpresa>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsEmpresa;

                sqlcmd.Parameters.Add("@RucEmpr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@RazoSoci", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstEmpr", SqlDbType.VarChar);

                sqlcmd.Parameters["@RucEmpr"].Value = sEmpresa.RucEmpr.ToInt64();
                sqlcmd.Parameters["@RazoSoci"].Value = sEmpresa.RazoSoci.ToText();
                sqlcmd.Parameters["@EstEmpr"].Value = sEmpresa.EstEmpr.ToText();

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

        private IList<eEmpresa> MakeUniqueDatos(IDataReader idr)
        {
            IList<eEmpresa> list = new List<eEmpresa>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eEmpresa MakeDatosMapeados(IDataReader idr)
        {
            eEmpresa sEmpresa = new eEmpresa();

            sEmpresa.RucEmpr = idr["RucEmpr"].ToInt64();
            sEmpresa.RazoSoci = idr["RazoSoci"].ToText();
            sEmpresa.EmprId = idr["RucEmpr"].ToText() + " - " + idr["RazoSoci"].ToText();
            sEmpresa.DireEmpr = idr["DireEmpr"].ToText();
            sEmpresa.CodiUbig = idr["CodiUbig"].ToText();
            sEmpresa.FechRegi = idr["FechRegi"].ToDateTime();
            sEmpresa.CodiUsu = idr["UsuRegi"].ToInt64();
            sEmpresa.EstEmpr = idr["EstEmpr"].ToText(); 

            return sEmpresa;
        }
    }
}
