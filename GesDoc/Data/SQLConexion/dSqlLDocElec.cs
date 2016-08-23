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
    public class dSqlLDocElec: ILDocElec
    {
        private dbConexion _db = new dbConexion();

        public dSqlLDocElec()
        {
            _db = new dbConexion();
        }


        public IList<eDocumentoElectronico> GetDocElec(eDocumentoElectronico sDocElec)
        {
            IList<eDocumentoElectronico> _lstTmp = new List<eDocumentoElectronico>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulDocElec;

                sqlcmd.Parameters.Add("@sEstDocuElec", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iNumDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);


                sqlcmd.Parameters["@sEstDocuElec"].Value = sDocElec.EstDocuElec.ToText();
                sqlcmd.Parameters["@iCodiOper"].Value = sDocElec.CodiOper.ToInt64();
                sqlcmd.Parameters["@iNumDocu"].Value = sDocElec.NumDocuElec.ToText();
                sqlcmd.Parameters["@iCodiUsu"].Value = sDocElec.User.Codigo.ToInt64();

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

        private IList<eDocumentoElectronico> MakeUniqueDatos(IDataReader idr)
        {
            IList<eDocumentoElectronico> list = new List<eDocumentoElectronico>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eDocumentoElectronico MakeDatosMapeados(IDataReader idr)
        {
            eDocumentoElectronico sDocElec = new eDocumentoElectronico();

            sDocElec.CodiOper = idr["CodiDocuElec"].ToInt64();
            sDocElec.TipoComu = idr["TipoComu"].ToText();
            sDocElec.AsunDocuElec = idr["AsunDocuElec"].ToText();
            sDocElec.MensDocuElec = idr["MensDocuElec"].ToText();
            sDocElec.CodiTipoDocu = idr["CodiTipoDocu"].ToText();
            sDocElec.PrioDocuElec = idr["PrioDocuElec"].ToText();
            sDocElec.FechEmi = idr["FechEmi"].ToDateTime();
            sDocElec.FechEnvi = idr["FechEnvi"].ToDateTime();
            sDocElec.FechVige = idr["FechVige"].ToDateTime();
            sDocElec.FechCie = idr["FechCier"].ToDateTime();
            sDocElec.EstDocuElec = idr["EstDocuElec"].ToText();
            sDocElec.TipoAcc = idr["AcceDocuElec"].ToText();
            sDocElec.NumDocuElec = idr["NumDocuElec"].ToText();
            sDocElec.Memo = idr["Memo"].ToText();            

            sDocElec.User = new eUsuario
            {
                Codigo = idr["CodiUsu"].ToInt64()
            };
            sDocElec.Participante = new eParticipante
            {
                CodiUsu = idr["CodiUsu"].ToInt64(),
                TipoPart = idr["TipoPart"].ToInt(),
                ApruOper = idr["ApruOper"].ToText(),
                Reenvio = idr["Reenvio"].ToText()
            };
            
            return sDocElec;
        }
    }
}
