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
    public class dSqlPlanGestion: IPlanGestion
    {
        private dbConexion _db = new dbConexion();

        public dSqlPlanGestion()
        {
            _db = new dbConexion();
        }
        

        private ePlanGestion AgregarItemInicial(String _Items)
        {
            ePlanGestion _PlanGestion = new ePlanGestion();

            _PlanGestion.CodiObjEstr = -1;
            _PlanGestion.CodiObjOper = -1;
            _PlanGestion.CodiProy = -1;
            _PlanGestion.CodiActi = -1;
            _PlanGestion.MesAvan = -1;

            _PlanGestion.DescObjEstr = _Items;
            _PlanGestion.DescObjOper = _Items;
            _PlanGestion.DescProy = _Items;
            _PlanGestion.DescActi = _Items;
            _PlanGestion.Coment = _Items;

            return _PlanGestion;
        }


#region Class: Objetivo Estrategico

        public Int64 SetObetivoEstrategico(ePlanGestion sPlanGestion)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_ObetivoEstrategico;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@DescObjEstr", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AbreObjEstr", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaObjEstr", SqlDbType.VarChar);

                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@DescObjEstr"].Value = sPlanGestion.DescObjEstr.ToText();
                sqlcmd.Parameters["@AbreObjEstr"].Value = sPlanGestion.AbreObjEstr.ToText();
                sqlcmd.Parameters["@EstaObjEstr"].Value = sPlanGestion.EstaObjEstr.ToText();

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

        public IList<ePlanGestion> GetObetivoEstrategico(ePlanGestion sPlanGestion, String _Items)
        {
            IList<ePlanGestion> _lstTmp = new List<ePlanGestion>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_ConsObetivoEstrategico;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@DescObjEstr", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AbreObjEstr", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaObjEstr", SqlDbType.VarChar);

                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@DescObjEstr"].Value = sPlanGestion.DescObjEstr.ToText();
                sqlcmd.Parameters["@AbreObjEstr"].Value = sPlanGestion.AbreObjEstr.ToText();
                sqlcmd.Parameters["@EstaObjEstr"].Value = sPlanGestion.EstaObjEstr.ToText();

                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MUD_ObetivoEstrategico(idr, _Items);;
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
        private IList<ePlanGestion> MUD_ObetivoEstrategico(IDataReader idr, String _Items)
        {
            IList<ePlanGestion> list = new List<ePlanGestion>();

            if (_Items.Length > 0)
                list.Add(AgregarItemInicial(_Items));

            while (idr.Read())
                list.Add(MDM_ObetivoEstrategico(idr));

            return list;
        }
        private ePlanGestion MDM_ObetivoEstrategico(IDataReader idr)
        {
            ePlanGestion sPlanGestion = new ePlanGestion();

            sPlanGestion.PeriObjEstr = idr["PeriObjEstr"].ToInt32();
            sPlanGestion.CodiObjEstr = idr["CodiObjEstr"].ToInt64();
            sPlanGestion.DescObjEstr = idr["DescObjEstr"].ToText();
            sPlanGestion.AbreObjEstr = idr["AbreObjEstr"].ToText();
            sPlanGestion.EstaObjEstr = idr["EstaObjEstr"].ToText();

            return sPlanGestion;
        }

#endregion

#region Class: Objetivo Operativo

        public Int64 SetObetivoOperativo(ePlanGestion sPlanGestion)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_ObetivoOperativo;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiObjOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@DescObjOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AbreObjOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaObjOper", SqlDbType.VarChar);

                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@CodiObjOper"].Value = sPlanGestion.CodiObjOper.ToInt64();
                sqlcmd.Parameters["@DescObjOper"].Value = sPlanGestion.DescObjOper.ToText();
                sqlcmd.Parameters["@AbreObjOper"].Value = sPlanGestion.AbreObjOper.ToText();
                sqlcmd.Parameters["@EstaObjOper"].Value = sPlanGestion.EstaObjOper.ToText();

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

        public IList<ePlanGestion> GetObetivoOperativo(ePlanGestion sPlanGestion, String _Items)
        {
            IList<ePlanGestion> _lstTmp = new List<ePlanGestion>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_ConsObetivoOperativo;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiObjOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@DescObjOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AbreObjOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaObjOper", SqlDbType.VarChar);

                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@CodiObjOper"].Value = sPlanGestion.CodiObjOper.ToInt64();
                sqlcmd.Parameters["@DescObjOper"].Value = sPlanGestion.DescObjOper.ToText();
                sqlcmd.Parameters["@AbreObjOper"].Value = sPlanGestion.AbreObjOper.ToText();
                sqlcmd.Parameters["@EstaObjOper"].Value = sPlanGestion.EstaObjOper.ToText();

                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MUD_ObetivoOperativo(idr, _Items); ;
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
        private IList<ePlanGestion> MUD_ObetivoOperativo(IDataReader idr, String _Items)
        {
            IList<ePlanGestion> list = new List<ePlanGestion>();

            if (_Items.Length > 0)
                list.Add(AgregarItemInicial(_Items));

            while (idr.Read())
                list.Add(MDM_ObetivoOperativo(idr));

            return list;
        }
        private ePlanGestion MDM_ObetivoOperativo(IDataReader idr)
        {
            ePlanGestion sPlanGestion = new ePlanGestion();

            sPlanGestion.PeriObjEstr = idr["PeriObjEstr"].ToInt32();
            sPlanGestion.CodiObjEstr = idr["CodiObjEstr"].ToInt64();
            sPlanGestion.DescObjEstr = idr["DescObjEstr"].ToText();

            sPlanGestion.CodiObjOper = idr["CodiObjOper"].ToInt64();
            sPlanGestion.DescObjOper = idr["DescObjOper"].ToText();
            sPlanGestion.AbreObjOper = idr["AbreObjOper"].ToText();
            sPlanGestion.EstaObjOper = idr["EstaObjOper"].ToText();

            return sPlanGestion;
        }

#endregion

#region Class: Proyecto

        public Int64 SetProyecto(ePlanGestion sPlanGestion)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_Proyecto;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiObjOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiProy", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@DescProy", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AbreProy", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaProy", SqlDbType.VarChar);

                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@CodiObjOper"].Value = sPlanGestion.CodiObjOper.ToInt64();
                sqlcmd.Parameters["@CodiProy"].Value = sPlanGestion.CodiProy.ToInt64();
                sqlcmd.Parameters["@DescProy"].Value = sPlanGestion.DescProy.ToText();
                sqlcmd.Parameters["@AbreProy"].Value = sPlanGestion.AbreProy.ToText();
                sqlcmd.Parameters["@EstaProy"].Value = sPlanGestion.EstaProy.ToText();

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

        public IList<ePlanGestion> GetProyecto(ePlanGestion sPlanGestion, String _Items)
        {
            IList<ePlanGestion> _lstTmp = new List<ePlanGestion>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_ConsProyecto;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiObjOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiProy", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@DescProy", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AbreProy", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaProy", SqlDbType.VarChar);

                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@CodiObjOper"].Value = sPlanGestion.CodiObjOper.ToInt64();
                sqlcmd.Parameters["@CodiProy"].Value = sPlanGestion.CodiProy.ToInt64();
                sqlcmd.Parameters["@DescProy"].Value = sPlanGestion.DescProy.ToText();
                sqlcmd.Parameters["@AbreProy"].Value = sPlanGestion.AbreProy.ToText();
                sqlcmd.Parameters["@EstaProy"].Value = sPlanGestion.EstaProy.ToText();

                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MUD_Proyecto(idr, _Items); ;
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
        private IList<ePlanGestion> MUD_Proyecto(IDataReader idr, String _Items)
        {
            IList<ePlanGestion> list = new List<ePlanGestion>();

            if (_Items.Length > 0)
                list.Add(AgregarItemInicial(_Items));

            while (idr.Read())
                list.Add(MDM_Proyecto(idr));

            return list;
        }
        private ePlanGestion MDM_Proyecto(IDataReader idr)
        {
            ePlanGestion sPlanGestion = new ePlanGestion();

            sPlanGestion.PeriObjEstr = idr["PeriObjEstr"].ToInt32();
            sPlanGestion.CodiObjEstr = idr["CodiObjEstr"].ToInt64();
            sPlanGestion.DescObjEstr = idr["DescObjEstr"].ToText();

            sPlanGestion.CodiObjOper = idr["CodiObjOper"].ToInt64();
            sPlanGestion.DescObjOper = idr["DescObjOper"].ToText();

            sPlanGestion.CodiProy = idr["CodiProy"].ToInt64();
            sPlanGestion.DescProy = idr["DescProy"].ToText();
            sPlanGestion.AbreProy = idr["AbreProy"].ToText();
            sPlanGestion.EstaProy = idr["EstaProy"].ToText();

            return sPlanGestion;
        }

#endregion

#region Class: Actividad

        public Int64 SetActividad(ePlanGestion sPlanGestion)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_Actividad;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiObjOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiProy", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiActi", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@DescActi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AbreActi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaActi", SqlDbType.VarChar);

                sqlcmd.Parameters.Add("@UnidMedMeta", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@NumeItemMeta", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@PesoPondMeta", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompEne", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompFeb", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompMar", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompAbr", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompMay", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompJun", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompJul", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompAgo", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompSet", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompOct", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompNov", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompDic", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanEne", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanFeb", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanMar", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanAbr", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanMay", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanJun", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanJul", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanAgo", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanSet", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanOct", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanNov", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanDic", DbType.Decimal);
                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);

                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@CodiObjOper"].Value = sPlanGestion.CodiObjOper.ToInt64();
                sqlcmd.Parameters["@CodiProy"].Value = sPlanGestion.CodiProy.ToInt64();
                sqlcmd.Parameters["@CodiActi"].Value = sPlanGestion.CodiActi.ToInt64();
                sqlcmd.Parameters["@DescActi"].Value = sPlanGestion.DescActi.ToText();
                sqlcmd.Parameters["@AbreActi"].Value = sPlanGestion.AbreActi.ToText();
                sqlcmd.Parameters["@EstaActi"].Value = sPlanGestion.EstaActi.ToText();

                sqlcmd.Parameters["@UnidMedMeta"].Value = sPlanGestion.UnidMedMeta.ToText();
                sqlcmd.Parameters["@NumeItemMeta"].Value = sPlanGestion.NumeItemMeta.ToInt64();
                sqlcmd.Parameters["@PesoPondMeta"].Value = sPlanGestion.PesoPondMeta.ToDecimal();
                sqlcmd.Parameters["@CompEne"].Value = sPlanGestion.CompEne.ToDecimal();
                sqlcmd.Parameters["@CompFeb"].Value = sPlanGestion.CompFeb.ToDecimal();
                sqlcmd.Parameters["@CompMar"].Value = sPlanGestion.CompMar.ToDecimal();
                sqlcmd.Parameters["@CompAbr"].Value = sPlanGestion.CompAbr.ToDecimal();
                sqlcmd.Parameters["@CompMay"].Value = sPlanGestion.CompMay.ToDecimal();
                sqlcmd.Parameters["@CompJun"].Value = sPlanGestion.CompJun.ToDecimal();
                sqlcmd.Parameters["@CompJul"].Value = sPlanGestion.CompJul.ToDecimal();
                sqlcmd.Parameters["@CompAgo"].Value = sPlanGestion.CompAgo.ToDecimal();
                sqlcmd.Parameters["@CompSet"].Value = sPlanGestion.CompSet.ToDecimal();
                sqlcmd.Parameters["@CompOct"].Value = sPlanGestion.CompOct.ToDecimal();
                sqlcmd.Parameters["@CompNov"].Value = sPlanGestion.CompNov.ToDecimal();
                sqlcmd.Parameters["@CompDic"].Value = sPlanGestion.CompDic.ToDecimal();
                sqlcmd.Parameters["@AvanEne"].Value = sPlanGestion.AvanEne.ToDecimal();
                sqlcmd.Parameters["@AvanFeb"].Value = sPlanGestion.AvanFeb.ToDecimal();
                sqlcmd.Parameters["@AvanMar"].Value = sPlanGestion.AvanMar.ToDecimal();
                sqlcmd.Parameters["@AvanAbr"].Value = sPlanGestion.AvanAbr.ToDecimal();
                sqlcmd.Parameters["@AvanMay"].Value = sPlanGestion.AvanMay.ToDecimal();
                sqlcmd.Parameters["@AvanJun"].Value = sPlanGestion.AvanJun.ToDecimal();
                sqlcmd.Parameters["@AvanJul"].Value = sPlanGestion.AvanJul.ToDecimal();
                sqlcmd.Parameters["@AvanAgo"].Value = sPlanGestion.AvanAgo.ToDecimal();
                sqlcmd.Parameters["@AvanSet"].Value = sPlanGestion.AvanSet.ToDecimal();
                sqlcmd.Parameters["@AvanOct"].Value = sPlanGestion.AvanOct.ToDecimal();
                sqlcmd.Parameters["@AvanNov"].Value = sPlanGestion.AvanNov.ToDecimal();
                sqlcmd.Parameters["@AvanDic"].Value = sPlanGestion.AvanDic.ToDecimal();
                sqlcmd.Parameters["@CodiUsu"].Value = sPlanGestion.AvanDic.ToInt64();

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

        public IList<ePlanGestion> GetActividad(ePlanGestion sPlanGestion, String _Items)
        {
            IList<ePlanGestion> _lstTmp = new List<ePlanGestion>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_ConsActividad;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiObjOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiProy", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiActi", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@DescActi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@AbreActi", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaActi", SqlDbType.VarChar);

                sqlcmd.Parameters.Add("@UnidMedMeta", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@NumeItemMeta", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@PesoPondMeta", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompEne", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompFeb", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompMar", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompAbr", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompMay", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompJun", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompJul", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompAgo", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompSet", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompOct", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompNov", DbType.Decimal);
                sqlcmd.Parameters.Add("@CompDic", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanEne", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanFeb", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanMar", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanAbr", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanMay", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanJun", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanJul", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanAgo", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanSet", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanOct", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanNov", DbType.Decimal);
                sqlcmd.Parameters.Add("@AvanDic", DbType.Decimal);
                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);

                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@CodiObjOper"].Value = sPlanGestion.CodiObjOper.ToInt64();
                sqlcmd.Parameters["@CodiProy"].Value = sPlanGestion.CodiProy.ToInt64();
                sqlcmd.Parameters["@CodiActi"].Value = sPlanGestion.CodiActi.ToInt64();
                sqlcmd.Parameters["@DescActi"].Value = sPlanGestion.DescActi.ToText();
                sqlcmd.Parameters["@AbreActi"].Value = sPlanGestion.AbreActi.ToText();
                sqlcmd.Parameters["@EstaActi"].Value = sPlanGestion.EstaActi.ToText();

                sqlcmd.Parameters["@UnidMedMeta"].Value = sPlanGestion.UnidMedMeta.ToText();
                sqlcmd.Parameters["@NumeItemMeta"].Value = sPlanGestion.NumeItemMeta.ToInt64();
                sqlcmd.Parameters["@PesoPondMeta"].Value = sPlanGestion.PesoPondMeta.ToDecimal();
                sqlcmd.Parameters["@CompEne"].Value = sPlanGestion.CompEne.ToDecimal();
                sqlcmd.Parameters["@CompFeb"].Value = sPlanGestion.CompFeb.ToDecimal();
                sqlcmd.Parameters["@CompMar"].Value = sPlanGestion.CompMar.ToDecimal();
                sqlcmd.Parameters["@CompAbr"].Value = sPlanGestion.CompAbr.ToDecimal();
                sqlcmd.Parameters["@CompMay"].Value = sPlanGestion.CompMay.ToDecimal();
                sqlcmd.Parameters["@CompJun"].Value = sPlanGestion.CompJun.ToDecimal();
                sqlcmd.Parameters["@CompJul"].Value = sPlanGestion.CompJul.ToDecimal();
                sqlcmd.Parameters["@CompAgo"].Value = sPlanGestion.CompAgo.ToDecimal();
                sqlcmd.Parameters["@CompSet"].Value = sPlanGestion.CompSet.ToDecimal();
                sqlcmd.Parameters["@CompOct"].Value = sPlanGestion.CompOct.ToDecimal();
                sqlcmd.Parameters["@CompNov"].Value = sPlanGestion.CompNov.ToDecimal();
                sqlcmd.Parameters["@CompDic"].Value = sPlanGestion.CompDic.ToDecimal();
                sqlcmd.Parameters["@AvanEne"].Value = sPlanGestion.AvanEne.ToDecimal();
                sqlcmd.Parameters["@AvanFeb"].Value = sPlanGestion.AvanFeb.ToDecimal();
                sqlcmd.Parameters["@AvanMar"].Value = sPlanGestion.AvanMar.ToDecimal();
                sqlcmd.Parameters["@AvanAbr"].Value = sPlanGestion.AvanAbr.ToDecimal();
                sqlcmd.Parameters["@AvanMay"].Value = sPlanGestion.AvanMay.ToDecimal();
                sqlcmd.Parameters["@AvanJun"].Value = sPlanGestion.AvanJun.ToDecimal();
                sqlcmd.Parameters["@AvanJul"].Value = sPlanGestion.AvanJul.ToDecimal();
                sqlcmd.Parameters["@AvanAgo"].Value = sPlanGestion.AvanAgo.ToDecimal();
                sqlcmd.Parameters["@AvanSet"].Value = sPlanGestion.AvanSet.ToDecimal();
                sqlcmd.Parameters["@AvanOct"].Value = sPlanGestion.AvanOct.ToDecimal();
                sqlcmd.Parameters["@AvanNov"].Value = sPlanGestion.AvanNov.ToDecimal();
                sqlcmd.Parameters["@AvanDic"].Value = sPlanGestion.AvanDic.ToDecimal();
                sqlcmd.Parameters["@CodiUsu"].Value = sPlanGestion.AvanDic.ToInt64();


                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MUD_Actividad(idr, _Items); ;
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
        private IList<ePlanGestion> MUD_Actividad(IDataReader idr, String _Items)
        {
            IList<ePlanGestion> list = new List<ePlanGestion>();

            if (_Items.Length > 0)
                list.Add(AgregarItemInicial(_Items));

            while (idr.Read())
                list.Add(MDM_Actividad(idr));

            return list;
        }
        private ePlanGestion MDM_Actividad(IDataReader idr)
        {
            ePlanGestion sPlanGestion = new ePlanGestion();

            sPlanGestion.PeriObjEstr = idr["PeriObjEstr"].ToInt32();
            sPlanGestion.CodiObjEstr = idr["CodiObjEstr"].ToInt64();
            sPlanGestion.DescObjEstr = idr["DescObjEstr"].ToText();

            sPlanGestion.CodiObjOper = idr["CodiObjOper"].ToInt64();
            sPlanGestion.DescObjOper = idr["DescObjOper"].ToText();

            sPlanGestion.CodiProy = idr["CodiProy"].ToInt64();
            sPlanGestion.DescProy = idr["DescProy"].ToText();

            sPlanGestion.CodiActi = idr["CodiActi"].ToInt64();
            sPlanGestion.DescActi = idr["DescActi"].ToText();
            sPlanGestion.AbreActi = idr["AbreActi"].ToText();
            sPlanGestion.EstaActi = idr["EstaActi"].ToText();

            sPlanGestion.UnidMedMeta = idr["UnidMedMeta"].ToText();
            sPlanGestion.NumeItemMeta = idr["NumeItemMeta"].ToInt64();
            sPlanGestion.PesoPondMeta = idr["PesoPondMeta"].ToDecimal();

            sPlanGestion.CompEne = idr["CompEne"].ToDecimal();
            sPlanGestion.CompFeb = idr["CompFeb"].ToDecimal();
            sPlanGestion.CompMar = idr["CompMar"].ToDecimal();
            sPlanGestion.CompAbr = idr["CompAbr"].ToDecimal();
            sPlanGestion.CompMay = idr["CompMay"].ToDecimal();
            sPlanGestion.CompJun = idr["CompJun"].ToDecimal();
            sPlanGestion.CompJul = idr["CompJul"].ToDecimal();
            sPlanGestion.CompAgo = idr["CompAgo"].ToDecimal();
            sPlanGestion.CompSet = idr["CompSet"].ToDecimal();
            sPlanGestion.CompOct = idr["CompOct"].ToDecimal();
            sPlanGestion.CompNov = idr["CompNov"].ToDecimal();
            sPlanGestion.CompDic = idr["CompDic"].ToDecimal();

            sPlanGestion.AvanEne = idr["AvanEne"].ToDecimal();
            sPlanGestion.AvanFeb = idr["AvanFeb"].ToDecimal();
            sPlanGestion.AvanMar = idr["AvanMar"].ToDecimal();
            sPlanGestion.AvanAbr = idr["AvanAbr"].ToDecimal();
            sPlanGestion.AvanMay = idr["AvanMay"].ToDecimal();
            sPlanGestion.AvanJun = idr["AvanJun"].ToDecimal();
            sPlanGestion.AvanJul = idr["AvanJul"].ToDecimal();
            sPlanGestion.AvanAgo = idr["AvanAgo"].ToDecimal();
            sPlanGestion.AvanSet = idr["AvanSet"].ToDecimal();
            sPlanGestion.AvanOct = idr["AvanOct"].ToDecimal();
            sPlanGestion.AvanNov = idr["AvanNov"].ToDecimal();
            sPlanGestion.AvanDic = idr["AvanDic"].ToDecimal();

            return sPlanGestion;
        }

#endregion

#region Class: Comentario de Avance

        public Int64 SetComentarioAvance(ePlanGestion sPlanGestion)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_ComentarioAvance;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiObjOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiProy", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiActi", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@MesAvan", SqlDbType.Int);
                sqlcmd.Parameters.Add("@Coment", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaComent", SqlDbType.VarChar);

                
                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@CodiObjOper"].Value = sPlanGestion.CodiObjOper.ToInt64();
                sqlcmd.Parameters["@CodiProy"].Value = sPlanGestion.CodiProy.ToInt64();
                sqlcmd.Parameters["@CodiActi"].Value = sPlanGestion.CodiActi.ToInt64();
                sqlcmd.Parameters["@MesAvan"].Value = sPlanGestion.MesAvan.ToInt32();
                sqlcmd.Parameters["@Coment"].Value = sPlanGestion.Coment.ToText();
                sqlcmd.Parameters["@EstaComent"].Value = sPlanGestion.EstaComent.ToText();

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

        public IList<ePlanGestion> GetComentarioAvance(ePlanGestion sPlanGestion, String _Items)
        {
            IList<ePlanGestion> _lstTmp = new List<ePlanGestion>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_ConsComentarioAvance;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiObjOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiProy", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiActi", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@MesAvan", SqlDbType.Int);
                sqlcmd.Parameters.Add("@Coment", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaComent", SqlDbType.VarChar);


                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@CodiObjOper"].Value = sPlanGestion.CodiObjOper.ToInt64();
                sqlcmd.Parameters["@CodiProy"].Value = sPlanGestion.CodiProy.ToInt64();
                sqlcmd.Parameters["@CodiActi"].Value = sPlanGestion.CodiActi.ToInt64();
                sqlcmd.Parameters["@MesAvan"].Value = sPlanGestion.MesAvan.ToInt32();
                sqlcmd.Parameters["@Coment"].Value = sPlanGestion.Coment.ToText();
                sqlcmd.Parameters["@EstaComent"].Value = sPlanGestion.EstaComent.ToText();



                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MUD_ComentarioAvance(idr, _Items); ;
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
        private IList<ePlanGestion> MUD_ComentarioAvance(IDataReader idr, String _Items)
        {
            IList<ePlanGestion> list = new List<ePlanGestion>();

            if (_Items.Length > 0)
                list.Add(AgregarItemInicial(_Items));

            while (idr.Read())
                list.Add(MDM_ComentarioAvance(idr));

            return list;
        }
        private ePlanGestion MDM_ComentarioAvance(IDataReader idr)
        {
            ePlanGestion sPlanGestion = new ePlanGestion();

            sPlanGestion.PeriObjEstr = idr["PeriObjEstr"].ToInt32();
            sPlanGestion.CodiObjEstr = idr["CodiObjEstr"].ToInt64();
            sPlanGestion.DescObjEstr = idr["DescObjEstr"].ToText();

            sPlanGestion.CodiObjOper = idr["CodiObjOper"].ToInt64();
            sPlanGestion.DescObjOper = idr["DescObjOper"].ToText();

            sPlanGestion.CodiProy = idr["CodiProy"].ToInt64();
            sPlanGestion.DescProy = idr["DescProy"].ToText();

            sPlanGestion.CodiActi = idr["CodiActi"].ToInt64();
            sPlanGestion.DescActi = idr["DescActi"].ToText();

            sPlanGestion.MesAvan = idr["MesAvan"].ToInt32();
            sPlanGestion.Coment = idr["Coment"].ToText();
            sPlanGestion.EstaComent = idr["EstaComent"].ToText();

            return sPlanGestion;
        }

#endregion

#region Class: Informe

        public IList<ePlanGestion> GetInforme(ePlanGestion sPlanGestion)
        {
            IList<ePlanGestion> _lstTmp = new List<ePlanGestion>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSP_Informe;

                sqlcmd.Parameters.Add("@TypeOperacion", SqlDbType.Int);
                sqlcmd.Parameters.Add("@PeriObjEstr", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiObjEstr", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiObjOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiProy", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiActi", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);


                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@TypeOperacion"].Value = sPlanGestion.TypeOperacion.ToInt32();
                sqlcmd.Parameters["@PeriObjEstr"].Value = sPlanGestion.PeriObjEstr.ToInt32();
                sqlcmd.Parameters["@CodiObjEstr"].Value = sPlanGestion.CodiObjEstr.ToInt64();
                sqlcmd.Parameters["@CodiObjOper"].Value = sPlanGestion.CodiObjOper.ToInt64();
                sqlcmd.Parameters["@CodiProy"].Value = sPlanGestion.CodiProy.ToInt64();
                sqlcmd.Parameters["@CodiActi"].Value = sPlanGestion.CodiActi.ToInt64();
                sqlcmd.Parameters["@CodiUsu"].Value = sPlanGestion.CodiUsu.ToInt64();



                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MUD_Informe(idr); ;
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
        private IList<ePlanGestion> MUD_Informe(IDataReader idr)
        {
            IList<ePlanGestion> list = new List<ePlanGestion>();

            while (idr.Read())
                list.Add(MDM_Informe(idr));

            return list;
        }
        private ePlanGestion MDM_Informe(IDataReader idr)
        {
            ePlanGestion sPlanGestion = new ePlanGestion();

            sPlanGestion.PeriObjEstr = idr["PeriObjEstr"].ToInt32();
            sPlanGestion.CodiObjEstr = idr["CodiObjEstr"].ToInt64();
            sPlanGestion.DescObjEstr = idr["DescObjEstr"].ToText();

            sPlanGestion.CodiObjOper = idr["CodiObjOper"].ToInt64();
            sPlanGestion.DescObjOper = idr["DescObjOper"].ToText();

            sPlanGestion.CodiProy = idr["CodiProy"].ToInt64();
            sPlanGestion.DescProy = idr["DescProy"].ToText();

            sPlanGestion.CodiActi = idr["CodiActi"].ToInt64();
            sPlanGestion.DescActi = idr["DescActi"].ToText();
            sPlanGestion.AbreActi = idr["AbreActi"].ToText();
            sPlanGestion.EstaActi = idr["EstaActi"].ToText();

            sPlanGestion.UnidMedMeta = idr["UnidMedMeta"].ToText();
            sPlanGestion.NumeItemMeta = idr["NumeItemMeta"].ToInt64();
            sPlanGestion.PesoPondMeta = idr["PesoPondMeta"].ToDecimal();

            sPlanGestion.CompEne = idr["CompEne"].ToDecimal();
            sPlanGestion.CompFeb = idr["CompFeb"].ToDecimal();
            sPlanGestion.CompMar = idr["CompMar"].ToDecimal();
            sPlanGestion.CompAbr = idr["CompAbr"].ToDecimal();
            sPlanGestion.CompMay = idr["CompMay"].ToDecimal();
            sPlanGestion.CompJun = idr["CompJun"].ToDecimal();
            sPlanGestion.CompJul = idr["CompJul"].ToDecimal();
            sPlanGestion.CompAgo = idr["CompAgo"].ToDecimal();
            sPlanGestion.CompSet = idr["CompSet"].ToDecimal();
            sPlanGestion.CompOct = idr["CompOct"].ToDecimal();
            sPlanGestion.CompNov = idr["CompNov"].ToDecimal();
            sPlanGestion.CompDic = idr["CompDic"].ToDecimal();

            sPlanGestion.AvanEne = idr["AvanEne"].ToDecimal();
            sPlanGestion.AvanFeb = idr["AvanFeb"].ToDecimal();
            sPlanGestion.AvanMar = idr["AvanMar"].ToDecimal();
            sPlanGestion.AvanAbr = idr["AvanAbr"].ToDecimal();
            sPlanGestion.AvanMay = idr["AvanMay"].ToDecimal();
            sPlanGestion.AvanJun = idr["AvanJun"].ToDecimal();
            sPlanGestion.AvanJul = idr["AvanJul"].ToDecimal();
            sPlanGestion.AvanAgo = idr["AvanAgo"].ToDecimal();
            sPlanGestion.AvanSet = idr["AvanSet"].ToDecimal();
            sPlanGestion.AvanOct = idr["AvanOct"].ToDecimal();
            sPlanGestion.AvanNov = idr["AvanNov"].ToDecimal();
            sPlanGestion.AvanDic = idr["AvanDic"].ToDecimal();

            return sPlanGestion;
        }

#endregion

    }
}
