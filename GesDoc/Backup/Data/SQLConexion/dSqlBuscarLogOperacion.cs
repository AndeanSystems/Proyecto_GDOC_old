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
    public class dSqlBuscarLogOperacion: IBuscarLogOperacion
    {
        private dbConexion _db = new dbConexion();

        public dSqlBuscarLogOperacion()
        {
            _db = new dbConexion();
        }

        public IList<eBuscarLogOperacion> GetBusLogOper(eBuscarLogOperacion sBLogOper)
        {
            IList<eBuscarLogOperacion> _lstTmp = new List<eBuscarLogOperacion>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulBLogOper;

                sqlcmd.Parameters.Add("@iTipoBusq", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@NumDocu", SqlDbType.VarChar);

                sqlcmd.Parameters["@iTipoBusq"].Value = sBLogOper.TipoBusq.ToInt16();
                sqlcmd.Parameters["@NumDocu"].Value = sBLogOper.NumDocu.ToText();

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

        private IList<eBuscarLogOperacion> MakeUniqueDatos(IDataReader idr)
        {
            IList<eBuscarLogOperacion> list = new List<eBuscarLogOperacion>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eBuscarLogOperacion MakeDatosMapeados(IDataReader idr)
        {
            eBuscarLogOperacion BLogOper = new eBuscarLogOperacion();            
            
            BLogOper.CodiDocu= idr["CodiDocu"].ToInt64();
            BLogOper.NumDocu = idr["NumDocu"].ToText();
            BLogOper.FechEven = idr["FechEven"].ToDateTime();
            BLogOper.CodiUsu = idr["CodiUsu"].ToInt16();
            BLogOper.IdeUsu = idr["IdeUsu"].ToText();
            BLogOper.CodiDocAdju= idr["CodiDocAdju"].ToInt64();
            BLogOper.CodiUsu = idr["CodiUsu"].ToInt16();
            BLogOper.CodiEven = idr["CodiEven"].ToText();
            BLogOper.DescEven = idr["DescEven"].ToText();
            BLogOper.AbreEven = idr["AbreEven"].ToText();
            BLogOper.EstEven = idr["EstEven"].ToText();
          
            return BLogOper;
        }

    }
}
