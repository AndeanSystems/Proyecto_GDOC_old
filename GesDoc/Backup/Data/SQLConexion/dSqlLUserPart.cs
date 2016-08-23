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
    public class dSqlLUserPart: ILUserPart
    {
        private dbConexion _db = new dbConexion();

        public dSqlLUserPart()
        {
            _db = new dbConexion();
        }

        
        public IList<eParticipante> GetUserPart(eParticipante sParticipante)
        {
            IList<eParticipante> _lstTmp = new List<eParticipante>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsUsuPart;

                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);

                sqlcmd.Parameters["@iCodiOper"].Value = sParticipante.CodiOper.ToInt64();
                sqlcmd.Parameters["@iCodiUsu"].Value = sParticipante.CodiUsu.ToInt64();

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

        public IList<eParticipante> GetUserPartBatch(List<long> listCodiOper, List<long> listCodiUsu)
        {
            IList<eParticipante> _lstTmp = new List<eParticipante>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsUsuPartBatch;

                DataTable tableCodiOper = new DataTable();
                tableCodiOper.Columns.Add("listCodiOper", typeof(long));
                for (int i = 0; i < listCodiOper.Count; i++)
                {
                    tableCodiOper.Rows.Add(listCodiOper[i]);
                }

                DataTable tableCodiUsu = new DataTable();
                tableCodiUsu.Columns.Add("listCodiUsu", typeof(long));
                for (int i = 0; i < listCodiUsu.Count; i++)
                {
                    tableCodiUsu.Rows.Add(listCodiUsu[i]);
                }

                sqlcmd.Parameters.Add("@listCodiOper", SqlDbType.Structured);
                sqlcmd.Parameters.Add("@listCodiUsu", SqlDbType.Structured);

                sqlcmd.Parameters["@listCodiOper"].Value = tableCodiOper;
                sqlcmd.Parameters["@listCodiUsu"].Value = tableCodiUsu;

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

        private IList<eParticipante> MakeUniqueDatos(IDataReader idr)
        {
            IList<eParticipante> list = new List<eParticipante>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eParticipante MakeDatosMapeados(IDataReader idr)
        {
            eParticipante sParticipante = new eParticipante();

            sParticipante.CodiOper = idr["CodiOper"].ToInt64();
            sParticipante.CodiUsuPart = idr["CodiUsuPart"].ToInt64();
            sParticipante.TipoOper = idr["TipoOper"].ToText();
            sParticipante.TipoPart = idr["TipoPart"].ToInt16();
            sParticipante.ApruOper = idr["ApruOper"].ToText();
            sParticipante.EnviNoti = idr["EnviNoti"].ToText();
            sParticipante.CodiUsu = idr["CodiUsu"].ToInt64();
            sParticipante.ConfLect = idr["ConfLect"].ToText();

            return sParticipante;
        }
    }
}
