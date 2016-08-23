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
    public class dSqlBuscarDocumentos: IBuscarDocumentos 
    {
        private dbConexion _db = new dbConexion();

        public dSqlBuscarDocumentos()
        {
            _db = new dbConexion();
        }


        public IList<eBuscarDocumentos> GetBusDocDig(eBuscarDocumentos sDocDig)
        {
            IList<eBuscarDocumentos> _lstTmp = new List<eBuscarDocumentos>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulBDocDig;

                sqlcmd.Parameters.Add("@sAsunto", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@sTipoDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@dFecIni", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@dFecFin", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@iCodiUsuRem", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiUsuDes", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iTipoBusq", SqlDbType.Int);

                sqlcmd.Parameters["@sAsunto"].Value = sDocDig.sDocDig.AsunDocuDigi.ToText();
                sqlcmd.Parameters["@sTipoDocu"].Value = sDocDig.sDocDig.ClasDocu.ToText();
                sqlcmd.Parameters["@dFecIni"].Value = sDocDig.sDocDig.FechRegi;
                sqlcmd.Parameters["@dFecFin"].Value = sDocDig.FecReg2;
                sqlcmd.Parameters["@iCodiUsuRem"].Value = sDocDig.CodiUsuRem.ToInt64();
                sqlcmd.Parameters["@iCodiUsuDes"].Value = sDocDig.CodiUsuDes.ToInt64();
                sqlcmd.Parameters["@iTipoBusq"].Value = sDocDig.TipoBusq.ToInt32();

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
        private IList<eBuscarDocumentos> MakeUniqueDatos(IDataReader idr)
        {
            IList<eBuscarDocumentos> list = new List<eBuscarDocumentos>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }
        private eBuscarDocumentos MakeDatosMapeados(IDataReader idr)
        {
            eBuscarDocumentos DocDig = new eBuscarDocumentos();
            
            DocDig.sDocDig = new eDocDig
            {
                CodiDocuDigi = idr["CodiDocuDigi"].ToInt64(),
                NumDocuDigi = idr["NumDocuDigi"].ToText(),
                TituDocuDigi = idr["TituDocuDigi"].ToText(),
                AsunDocuDigi = idr["AsunDocuDigi"].ToText(),
                NombOrig = idr["NombOrig"].ToText(),
                RutaFisi = idr["RutaFisi"].ToText(),
                FechRegi = idr["FechRegi"].ToDateTime(),                
                EstDocuDigi = idr["EstDocuDigi"].ToText(),                                                                                
                CodiTipoDocu = idr["CodiTipoDocu"].ToText(),
                NomTipoDocu = idr["NombTipoDocu"].ToText()
            };
            return DocDig;
        }


        public IList<eBuscarDocumentos> GetBusDocElect(eBuscarDocumentos sDocElect)
        {
            IList<eBuscarDocumentos> _lstTmp = new List<eBuscarDocumentos>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulBDocElect;

                sqlcmd.Parameters.Add("@sAsunto", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@sTipoDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@dFecIni", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@dFecFin", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@iCodiUsuRem", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiUsuDes", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iTipoBusq", SqlDbType.Int);

                sqlcmd.Parameters["@sAsunto"].Value = sDocElect.sDocElect.AsunDocuElec.ToText();
                sqlcmd.Parameters["@sTipoDocu"].Value = sDocElect.sDocElect.CodiTipoDocu.ToText();
                sqlcmd.Parameters["@dFecIni"].Value = sDocElect.sDocElect.FechEmi;
                sqlcmd.Parameters["@dFecFin"].Value = sDocElect.FecReg2;
                sqlcmd.Parameters["@iCodiUsuRem"].Value = sDocElect.CodiUsuRem.ToInt64();
                sqlcmd.Parameters["@iCodiUsuDes"].Value = sDocElect.CodiUsuDes.ToInt64();
                sqlcmd.Parameters["@iTipoBusq"].Value = sDocElect.TipoBusq.ToInt32();

                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MakeUniqueDatosElect(idr);
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

        private IList<eBuscarDocumentos> MakeUniqueDatosElect(IDataReader idr)
        {
            IList<eBuscarDocumentos> list = new List<eBuscarDocumentos>();

            while (idr.Read())
                list.Add(MakeDatosMapeadosElect(idr));

            return list;
        }
        private eBuscarDocumentos MakeDatosMapeadosElect(IDataReader idr)
        {
            eBuscarDocumentos DocElect = new eBuscarDocumentos();

            DocElect.sDocElect = new eDocumentoElectronico
            {
                CodiDocuElec = idr["CodiDocuElec"].ToInt64(),               
                AsunDocuElec = idr["AsunDocuElec"].ToText(),
                CodiTipoDocu = idr["TipoDocu"].ToText(),                
                PrioDocuElec = idr["PrioDocuElec"].ToText(),
                FechEmi = idr["FechEmi"].ToDateTime(),                                              
                EstDocuElec = idr["EstDocuElec"].ToText(),              
                NumDocuElec = idr["NumDocuElec"].ToText(),
            };
            return DocElect;
        }


        //  Datos para MesaVirtual
        // ===============================

        public IList<eBuscarDocumentos> GetBusMesaVirtual(eBuscarDocumentos sMesaVirtual)
        {
            IList<eBuscarDocumentos> _lstTmp = new List<eBuscarDocumentos>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulBMesaVirtual;

                sqlcmd.Parameters.Add("@sAsunto", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iClasMesa", SqlDbType.Int);
                sqlcmd.Parameters.Add("@dFecIni", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@dFecFin", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@iCodiUsuOrg", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiUsuCol", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iTipoBusq", SqlDbType.Int);

                sqlcmd.Parameters["@sAsunto"].Value = sMesaVirtual.sMesaVirtual.Asunto.ToText();
                sqlcmd.Parameters["@iClasMesa"].Value = sMesaVirtual.sMesaVirtual.ClaseMV.ToInt32();
                sqlcmd.Parameters["@dFecIni"].Value = sMesaVirtual.sMesaVirtual.Fecha;
                sqlcmd.Parameters["@dFecFin"].Value = sMesaVirtual.FecReg2;
                sqlcmd.Parameters["@iCodiUsuOrg"].Value = sMesaVirtual.CodiUsuRem.ToInt64();
                sqlcmd.Parameters["@iCodiUsuCol"].Value = sMesaVirtual.CodiUsuDes.ToInt64();
                sqlcmd.Parameters["@iTipoBusq"].Value = sMesaVirtual.TipoBusq.ToInt32();

                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MakeUniqueDatosMesaVirtual(idr);
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
        private IList<eBuscarDocumentos> MakeUniqueDatosMesaVirtual(IDataReader idr)
        {
            IList<eBuscarDocumentos> list = new List<eBuscarDocumentos>();

            while (idr.Read())
                list.Add(MakeDatosMapeadosMesaVirtual(idr));

            return list;
        }
        private eBuscarDocumentos MakeDatosMapeadosMesaVirtual(IDataReader idr)
        {
            eBuscarDocumentos MesaVirtual = new eBuscarDocumentos();
            MesaVirtual.sMesaVirtual = new eMesaVirtual
            {
                CodiOper = idr["CodiMesaVirt"].ToInt64(),
                DesMesaVir = idr["DescMesaVirt"].ToText(),
                Titulo = idr["TituMesaVirt"].ToText(),
                Acceso = idr["AcceMesaVirt"].ToText(),
                NumOper = idr["NumMesaVirt"].ToText(),
                Fecha = idr["FechOrga"].ToDateTime(),
                FechaFin = idr["FechCie"].ToDateTime(),  
                Estado = idr["EstaMesaVirt"].ToText(),
                ClaseMV = idr["ClasMesaVirt"].ToInt(),
              
            };
            return MesaVirtual;
        }



        public IList<eBuscarDocumentos> GetBuscarAdjunto(eBuscarDocumentos sBuscarAdjunto)
        {
            IList<eBuscarDocumentos> _lstTmp = new List<eBuscarDocumentos>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulBDocAdj;

                sqlcmd.Parameters.Add("@iTipoBusq", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@vCodiDocu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@vNumDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@vCodiTipoDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@vTituDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@vAsunDocu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@vNombOrig", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@vNombFisi", SqlDbType.VarChar);

                sqlcmd.Parameters["@iTipoBusq"].Value = sBuscarAdjunto.TipoBusq.ToInt16();
                sqlcmd.Parameters["@vCodiDocu"].Value = sBuscarAdjunto.sDocDig.CodiDocuDigi.ToInt64();
                sqlcmd.Parameters["@vNumDocu"].Value = sBuscarAdjunto.sDocDig.NumDocuDigi.ToText();
                sqlcmd.Parameters["@vCodiTipoDocu"].Value = sBuscarAdjunto.sDocDig.CodiTipoDocu.ToText();
                sqlcmd.Parameters["@vTituDocu"].Value = sBuscarAdjunto.sDocDig.TituDocuDigi.ToText();
                sqlcmd.Parameters["@vAsunDocu"].Value = sBuscarAdjunto.sDocDig.AsunDocuDigi.ToText();
                sqlcmd.Parameters["@vNombOrig"].Value = sBuscarAdjunto.sDocDig.NombOrig.ToText();
                sqlcmd.Parameters["@vNombFisi"].Value = sBuscarAdjunto.sDocDig.NombFisi.ToText();

                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MakeUniqueDatosAdjunto(idr);
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

        private IList<eBuscarDocumentos> MakeUniqueDatosAdjunto(IDataReader idr)
        {
            IList<eBuscarDocumentos> list = new List<eBuscarDocumentos>();

            while (idr.Read())
                list.Add(MakeDatosMapeadosAdjunto(idr));

            return list;
        }

        private eBuscarDocumentos MakeDatosMapeadosAdjunto(IDataReader idr)
        {
            eBuscarDocumentos DocDig = new eBuscarDocumentos();

            DocDig.sDocDig = new eDocDig
            {
                CodiDocuDigi = idr["CodiDocuDigi"].ToInt64(),
                NumDocuDigi = idr["NumDocuDigi"].ToText(),
                TituDocuDigi = idr["TituDocuDigi"].ToText(),
                AsunDocuDigi = idr["AsunDocuDigi"].ToText(),
                NombOrig = idr["NombOrig"].ToText(),
                RutaFisi = idr["RutaFisi"].ToText(),
                NombFisi = idr["NombFisi"].ToText(),
                ExteDocu = idr["ExteDocu"].ToText(),
                CodiTipoDocu = idr["CodiTipoDocu"].ToText(),
            };  

            DocDig.sTipoDocumento = new eDocDigListTD
            {
                CodiTipoDocu = idr["CodiTipoDocu"].ToText(),
                NombTipoDocu = idr["NombTipoDocu"].ToText()
            };

            return DocDig;
        }

    }

}
