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
    public class dSqlConsAutorizador: IConsAutorizador
    {
        private dbConexion _db = new dbConexion();

        public dSqlConsAutorizador()
        {
            _db = new dbConexion();
        }

        public IList<eAutorizador> GetUserAutoriza(eAutorizador sAutorizador)
        {
            IList<eAutorizador> _lstTmp = new List<eAutorizador>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsAutoriza;

                sqlcmd.Parameters.Add("@iType", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);

                sqlcmd.Parameters["@iType"].Value = sAutorizador.Type.ToText();
                sqlcmd.Parameters["@iCodiOper"].Value = sAutorizador.CodiOper.ToInt64();
                sqlcmd.Parameters["@iCodiUsu"].Value = sAutorizador.CodiUsuPart.ToInt64();

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

        private IList<eAutorizador> MakeUniqueDatos(IDataReader idr)
        {
            IList<eAutorizador> list = new List<eAutorizador>();

            while (idr.Read())
               list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eAutorizador MakeDatosMapeados(IDataReader idr)
        {
            eAutorizador sUserAut = new eAutorizador();

            sUserAut.CodiUsuPart = idr["CodiUsuPart"].ToInt64();
            sUserAut.CodiOper = idr["CodiOper"].ToInt64();
            sUserAut.RespUsuAuto = idr["RespUsuAuto"].ToText();
            sUserAut.FechUsuAuto = idr["FechUsuAuto"].ToDateTime();
            sUserAut.ComeUsuAuto = idr["ComeUsuAuto"].ToText();
            sUserAut.User = new eUsuario
            {
                IdeUsuario = idr["IdeUsu"].ToText(),
                Pasword = idr["PassUsu"].ToText(),
                FirmaElectronica = idr["FirmElec"].ToText()
            };

           return sUserAut;
       }
    }
}
