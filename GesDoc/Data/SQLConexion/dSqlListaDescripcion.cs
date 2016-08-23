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
    public class dSqlListaDescripcion: IListaDescripcion
    {
        private dbConexion _db = new dbConexion();

        public dSqlListaDescripcion()
        {
            _db = new dbConexion();
        }


        public IList<eVariable> GetListaDescrip(eVariable sVariable)
        {
            IList<eVariable> _lstTmp = new List<eVariable>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulDescrip;

                sqlcmd.Parameters.Add("@Descrip", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@CodUsu", SqlDbType.BigInt);

                sqlcmd.Parameters["@Descrip"].Value = sVariable.Descrip.ToText();
                sqlcmd.Parameters["@CodUsu"].Value = sVariable.CodUsu.ToInt64();

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

        private IList<eVariable> MakeUniqueDatos(IDataReader idr)
        {
            IList<eVariable> list = new List<eVariable>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eVariable MakeDatosMapeados(IDataReader idr)
        {
            eVariable sVariable = new eVariable();

            sVariable.CodUsu = idr["CodiUsu"].ToInt64();
            sVariable.Numdoc = idr["NumDoc"].ToText();
            sVariable.Descrip = idr["Descripciones"].ToText();
            sVariable.Codigo = idr["CodDoc"].ToInt64();
            return sVariable;
        }

    }
}

