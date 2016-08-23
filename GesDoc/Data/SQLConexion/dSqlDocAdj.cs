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
    public class dSqlDocAdj: IDocAdj
    {
        private dbConexion _db = new dbConexion();

        public dSqlDocAdj()
        {
            _db = new dbConexion();
        }

        public Int64 SetDocAdj(eDocAdj sDocAdj)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarDocAdj;

                sqlcmd.Parameters.Add("@CodiDocuAdju", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cTipoOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiDocAdju", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cTipoDocAdju", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiComenMesaV", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cEstDocuAdju", SqlDbType.VarChar);
            

                sqlcmd.Parameters["@CodiDocuAdju"].Value = sDocAdj.CodiAdj.ToInt64();
                sqlcmd.Parameters["@iCodiOper"].Value = sDocAdj.CodiOper.ToInt64();
                sqlcmd.Parameters["@cTipoOper"].Value = sDocAdj.TipoOper.ToText();
                sqlcmd.Parameters["@iCodiDocAdju"].Value = sDocAdj.CodiDocAdju.ToInt64();
                sqlcmd.Parameters["@cTipoDocAdju"].Value = sDocAdj.TipoDocAdju.ToText();
                sqlcmd.Parameters["@iCodiComenMesaV"].Value = sDocAdj.CodiComenMesaV.ToInt64();
                sqlcmd.Parameters["@cEstDocuAdju"].Value = sDocAdj.EstDocuAdju.ToText();
                

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

        public Int64 SetAnulaDocAdj(eDocAdj sDocAdj)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPAnulaDocAdj;

                sqlcmd.Parameters.Add("@CodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiComenMesaV", SqlDbType.BigInt);


                sqlcmd.Parameters["@CodiOper"].Value = sDocAdj.CodiOper.ToInt64();
                sqlcmd.Parameters["@CodiComenMesaV"].Value = sDocAdj.CodiComenMesaV.ToInt64();


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

        public IList<eDocAdj> GetDocAdj(eDocAdj DocAdj)
        {
            IList<eDocAdj> _lstTmp = new List<eDocAdj>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsDocAdj;

                sqlcmd.Parameters.Add("@CodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiComenMesaV", SqlDbType.BigInt);

                sqlcmd.Parameters["@CodiOper"].Value = DocAdj.CodiOper.ToInt64();
                sqlcmd.Parameters["@CodiComenMesaV"].Value = DocAdj.CodiComenMesaV.ToInt64();

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
        private IList<eDocAdj> MakeUniqueDatos(IDataReader idr)
        {
            IList<eDocAdj> list = new List<eDocAdj>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }
        private eDocAdj MakeDatosMapeados(IDataReader idr)
        {
            eDocAdj sDocAdj = new eDocAdj();

            sDocAdj.CodiAdj = idr["CodiDocuAdju"].ToInt64();
            sDocAdj.CodiOper = idr["CodiOper"].ToInt64();
            sDocAdj.TipoOper = idr["TipoOper"].ToText();
            sDocAdj.CodiDocAdju = idr["CodiDocAdju"].ToInt64();
            sDocAdj.TipoDocAdju = idr["TipoDocAdju"].ToText();
            sDocAdj.CodiComenMesaV = idr["CodiComenMesaV"].ToInt64();
            sDocAdj.EstDocuAdju = idr["EstDocuAdju"].ToText();

            return sDocAdj;
        }

    }
}
