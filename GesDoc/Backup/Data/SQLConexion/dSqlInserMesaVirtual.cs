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
    public class dSqlInserMesaVirtual : IInserMesaVirtual
    {
        private dbConexion _db = new dbConexion();

        public dSqlInserMesaVirtual()
        {
            _db = new dbConexion();
        }


        public Int64 SetMesaVirtual(eMesaVirtual sMesaVirtual)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarMesaVirtual;

                SqlParameter outputIdParam1 = new SqlParameter("@OutCodiMesaVirt", SqlDbType.BigInt,8)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter outputIdParam2 = new SqlParameter("@OutNumMesaVirt", SqlDbType.VarChar,50)
                {
                    Direction = ParameterDirection.Output
                }; 

                sqlcmd.Parameters.Add(outputIdParam1);
                sqlcmd.Parameters.Add(outputIdParam2);
                sqlcmd.Parameters.Add("@Type", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@CodiMesaVirt", SqlDbType.Int);
                sqlcmd.Parameters.Add("@FechOrga", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@FechCie", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@EstaMesaVirt", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@TituMesaVirt", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@PrioMesaVirt", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@NotiMesaVirt", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@DescMesaVirt", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AcceMesaVirt", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@NumMesaVirt", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@ClasMesaVirt", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.Int);

                sqlcmd.Parameters["@Type"].Value = sMesaVirtual.Type.ToInt16();
                sqlcmd.Parameters["@CodiMesaVirt"].Value = sMesaVirtual.CodiOper.ToInt32();
                sqlcmd.Parameters["@FechOrga"].Value = sMesaVirtual.Fecha.ToDateTime();
                sqlcmd.Parameters["@FechCie"].Value = sMesaVirtual.FechaFin.ToDateTime();
                sqlcmd.Parameters["@EstaMesaVirt"].Value = sMesaVirtual.Estado.ToText();
                sqlcmd.Parameters["@TituMesaVirt"].Value = sMesaVirtual.Titulo.ToText();
                sqlcmd.Parameters["@PrioMesaVirt"].Value = sMesaVirtual.Prioridad.ToText();
                sqlcmd.Parameters["@NotiMesaVirt"].Value = sMesaVirtual.Notifica.ToText();
                sqlcmd.Parameters["@DescMesaVirt"].Value = sMesaVirtual.DesMesaVir.ToText();
                sqlcmd.Parameters["@AcceMesaVirt"].Value = sMesaVirtual.Acceso.ToText();
                sqlcmd.Parameters["@NumMesaVirt"].Value = sMesaVirtual.NumOper.ToText();
                sqlcmd.Parameters["@ClasMesaVirt"].Value = sMesaVirtual.ClaseMV.ToInt16();
                sqlcmd.Parameters["@iCodiUsu"].Value = sMesaVirtual.CodiUsu.ToInt32();

                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();

                sMesaVirtual.CodiOper  = outputIdParam1.Value.ToString().ToInt64(); 
                sMesaVirtual.NumOper = outputIdParam2.Value.ToString();

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
