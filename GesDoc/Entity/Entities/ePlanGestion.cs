using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class ePlanGestion
    {
        [DataMember] 
        public Int16 TypeOperacion { get; set; }

#region Class: Objetivo Estrategico

        [DataMember] 
        public Int32 PeriObjEstr { get; set; }

        [DataMember] 
        public Int64 CodiObjEstr { get; set; }

        [DataMember] 
        public String DescObjEstr { get; set; }

        [DataMember] 
        public String AbreObjEstr { get; set; }

        [DataMember] 
        public String EstaObjEstr { get; set; }

#endregion

#region Class: Objetivo Operativo

        [DataMember] 
        public Int64 CodiObjOper { get; set; }
        
        [DataMember] 
        public String DescObjOper { get; set; }

        [DataMember] 
        public String AbreObjOper { get; set; }

        [DataMember] 
        public String EstaObjOper { get; set; }

#endregion

#region Class: Proyecto

        [DataMember] 
        public Int64 CodiProy { get; set; }
        
        [DataMember] 
        public String DescProy { get; set; }

        [DataMember] 
        public String AbreProy { get; set; }

        [DataMember] 
        public String EstaProy { get; set; }

#endregion

#region Class: Actividad

        [DataMember] 
        public Int64 CodiActi { get; set; }

        [DataMember] 
        public String DescActi { get; set; }

        [DataMember] 
        public String AbreActi { get; set; }

        [DataMember] 
        public String EstaActi { get; set; }

        [DataMember] 
        public String UnidMedMeta { get; set; }

        [DataMember] 
        public Int64 NumeItemMeta { get; set; }

        [DataMember] 
        public Decimal PesoPondMeta { get; set; }

        [DataMember] 
        public Int64 CodiUsu { get; set; }

        [DataMember] 
        public Decimal CompEne { get; set; }

        [DataMember] 
        public Decimal CompFeb { get; set; }

        [DataMember] 
        public Decimal CompMar { get; set; }

        [DataMember] 
        public Decimal CompAbr { get; set; }

        [DataMember] 
        public Decimal CompMay { get; set; }

        [DataMember] 
        public Decimal CompJun { get; set; }

        [DataMember] 
        public Decimal CompJul { get; set; }

        [DataMember] 
        public Decimal CompAgo { get; set; }

        [DataMember] 
        public Decimal CompSet { get; set; }

        [DataMember] 
        public Decimal CompOct { get; set; }

        [DataMember] 
        public Decimal CompNov { get; set; }

        [DataMember] 
        public Decimal CompDic { get; set; }

        [DataMember] 
        public Decimal AvanEne { get; set; }

        [DataMember] 
        public Decimal AvanFeb { get; set; }

        [DataMember] 
        public Decimal AvanMar { get; set; }

        [DataMember] 
        public Decimal AvanAbr { get; set; }

        [DataMember] 
        public Decimal AvanMay { get; set; }

        [DataMember] 
        public Decimal AvanJun { get; set; }

        [DataMember] 
        public Decimal AvanJul { get; set; }

        [DataMember] 
        public Decimal AvanAgo { get; set; }

        [DataMember] 
        public Decimal AvanSet { get; set; }

        [DataMember] 
        public Decimal AvanOct { get; set; }

        [DataMember] 
        public Decimal AvanNov { get; set; }

        [DataMember] 
        public Decimal AvanDic { get; set; }

#endregion

#region Class: Comentario de Avance

        [DataMember] 
        public Int32 MesAvan { get; set; }

        [DataMember] 
        public String Coment { get; set; }

        [DataMember] 
        public String EstaComent { get; set; }

#endregion

#region Class: Periodo de Bloqueo

        [DataMember] 
        public Int64 PeriPlanGes { get; set; }

        [DataMember] 
        public Int32 MesPlanGes { get; set; }

        [DataMember] 
        public String EstaPeriMes { get; set; }

#endregion

    }
}
