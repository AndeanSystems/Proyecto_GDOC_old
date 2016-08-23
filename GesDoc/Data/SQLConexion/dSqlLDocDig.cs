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
    public class dSqlLDocDig: ILDocDig
    {
        private dbConexion _db = new dbConexion();

        public dSqlLDocDig()
        {
            _db = new dbConexion();
        }

        public IList<eDocDig> GetDocDigital(eDocDig sDocDig)
        {
            IList<eDocDig> _lstTmp = new List<eDocDig>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulDocDig;

                sqlcmd.Parameters.Add("@sEstDocuDigi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iNumDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);

                sqlcmd.Parameters["@sEstDocuDigi"].Value = sDocDig.EstDocuDigi.ToText();
                sqlcmd.Parameters["@iCodiOper"].Value = sDocDig.CodiDocuDigi.ToInt64();
                sqlcmd.Parameters["@iNumDocu"].Value = sDocDig.NumDocuDigi.ToText();
                sqlcmd.Parameters["@iCodiUsu"].Value = sDocDig.User.Codigo.ToInt64();

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

        private IList<eDocDig> MakeUniqueDatos(IDataReader idr)
        {
            IList<eDocDig> list = new List<eDocDig>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eDocDig MakeDatosMapeados(IDataReader idr)
        {
            eDocDig sDocDig = new eDocDig();

            sDocDig.CodiDocuDigi = idr["CodiDocuDigi"].ToInt64();
            sDocDig.TituDocuDigi = idr["TituDocuDigi"].ToText();
            sDocDig.AsunDocuDigi = idr["AsunDocuDigi"].ToText();
            sDocDig.NombOrig = idr["NombOrig"].ToText();
            sDocDig.RutaFisi = idr["RutaFisi"].ToText();
            sDocDig.TamaDocu = idr["TamaDocu"].ToInt64();
            sDocDig.ExteDocu = idr["ExteDocu"].ToText();
            sDocDig.NombFisi = idr["NombFisi"].ToText();
            sDocDig.ClasDocu = idr["ClasDocu"].ToText();
            sDocDig.EstDocuDigi = idr["EstDocuDigi"].ToText();
            sDocDig.FechEmiDocu = idr["FechEmiDocu"].ToDateTime();
            sDocDig.FechRece = idr["FechRece"].ToDateTime();
            sDocDig.FechRegi = idr["FechRegi"].ToDateTime();
            sDocDig.FechActu = idr["FechActu"].ToDateTime();
            sDocDig.AcceDocuDigi = idr["AcceDocuDigi"].ToText();
            sDocDig.CodiTipoDocu = idr["CodiTipoDocu"].ToText();
            sDocDig.NumDocuDigi = idr["NumDocuDigi"].ToText();
            sDocDig.Comentario = idr["Comentario"].ToText();
            return sDocDig;
        }
    }
}
