﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5477
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebGdoc.PlanGestionServRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RequestBase", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.PlanGestionServRef.PlanGestionRequest))]
    public partial class RequestBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccessTokenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ActionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClientTagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] LoadOptionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RequestIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VersionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AccessToken {
            get {
                return this.AccessTokenField;
            }
            set {
                if ((object.ReferenceEquals(this.AccessTokenField, value) != true)) {
                    this.AccessTokenField = value;
                    this.RaisePropertyChanged("AccessToken");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Action {
            get {
                return this.ActionField;
            }
            set {
                if ((object.ReferenceEquals(this.ActionField, value) != true)) {
                    this.ActionField = value;
                    this.RaisePropertyChanged("Action");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientTag {
            get {
                return this.ClientTagField;
            }
            set {
                if ((object.ReferenceEquals(this.ClientTagField, value) != true)) {
                    this.ClientTagField = value;
                    this.RaisePropertyChanged("ClientTag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] LoadOptions {
            get {
                return this.LoadOptionsField;
            }
            set {
                if ((object.ReferenceEquals(this.LoadOptionsField, value) != true)) {
                    this.LoadOptionsField = value;
                    this.RaisePropertyChanged("LoadOptions");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RequestId {
            get {
                return this.RequestIdField;
            }
            set {
                if ((object.ReferenceEquals(this.RequestIdField, value) != true)) {
                    this.RequestIdField = value;
                    this.RaisePropertyChanged("RequestId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Version {
            get {
                return this.VersionField;
            }
            set {
                if ((object.ReferenceEquals(this.VersionField, value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlanGestionRequest", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class PlanGestionRequest : WebGdoc.PlanGestionServRef.RequestBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.ePlanGestion CtrPlanGestionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.ePlanGestion CtrPlanGestion {
            get {
                return this.CtrPlanGestionField;
            }
            set {
                if ((object.ReferenceEquals(this.CtrPlanGestionField, value) != true)) {
                    this.CtrPlanGestionField = value;
                    this.RaisePropertyChanged("CtrPlanGestion");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseBase", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.PlanGestionServRef.PlanGestionResponse))]
    public partial class ResponseBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebGdoc.PlanGestionServRef.AcknowledgeType AcknowledgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuildField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CorrelationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ReservationExpiresField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReservationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RowsAffectedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VersionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WebGdoc.PlanGestionServRef.AcknowledgeType Acknowledge {
            get {
                return this.AcknowledgeField;
            }
            set {
                if ((this.AcknowledgeField.Equals(value) != true)) {
                    this.AcknowledgeField = value;
                    this.RaisePropertyChanged("Acknowledge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Build {
            get {
                return this.BuildField;
            }
            set {
                if ((object.ReferenceEquals(this.BuildField, value) != true)) {
                    this.BuildField = value;
                    this.RaisePropertyChanged("Build");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CorrelationId {
            get {
                return this.CorrelationIdField;
            }
            set {
                if ((object.ReferenceEquals(this.CorrelationIdField, value) != true)) {
                    this.CorrelationIdField = value;
                    this.RaisePropertyChanged("CorrelationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ReservationExpires {
            get {
                return this.ReservationExpiresField;
            }
            set {
                if ((this.ReservationExpiresField.Equals(value) != true)) {
                    this.ReservationExpiresField = value;
                    this.RaisePropertyChanged("ReservationExpires");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReservationId {
            get {
                return this.ReservationIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ReservationIdField, value) != true)) {
                    this.ReservationIdField = value;
                    this.RaisePropertyChanged("ReservationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RowsAffected {
            get {
                return this.RowsAffectedField;
            }
            set {
                if ((this.RowsAffectedField.Equals(value) != true)) {
                    this.RowsAffectedField = value;
                    this.RaisePropertyChanged("RowsAffected");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Version {
            get {
                return this.VersionField;
            }
            set {
                if ((object.ReferenceEquals(this.VersionField, value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlanGestionResponse", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class PlanGestionResponse : WebGdoc.PlanGestionServRef.ResponseBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long AddActividadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long AddComentarioAvanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long AddObetivoEstrategicoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long AddObetivoOperativoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long AddProyectoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.ePlanGestion[] ListaActividadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.ePlanGestion[] ListaComentarioAvanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.ePlanGestion[] ListaInformeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.ePlanGestion[] ListaObetivoEstrategicoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.ePlanGestion[] ListaObetivoOperativoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.ePlanGestion[] ListaProyectoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long AddActividad {
            get {
                return this.AddActividadField;
            }
            set {
                if ((this.AddActividadField.Equals(value) != true)) {
                    this.AddActividadField = value;
                    this.RaisePropertyChanged("AddActividad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long AddComentarioAvance {
            get {
                return this.AddComentarioAvanceField;
            }
            set {
                if ((this.AddComentarioAvanceField.Equals(value) != true)) {
                    this.AddComentarioAvanceField = value;
                    this.RaisePropertyChanged("AddComentarioAvance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long AddObetivoEstrategico {
            get {
                return this.AddObetivoEstrategicoField;
            }
            set {
                if ((this.AddObetivoEstrategicoField.Equals(value) != true)) {
                    this.AddObetivoEstrategicoField = value;
                    this.RaisePropertyChanged("AddObetivoEstrategico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long AddObetivoOperativo {
            get {
                return this.AddObetivoOperativoField;
            }
            set {
                if ((this.AddObetivoOperativoField.Equals(value) != true)) {
                    this.AddObetivoOperativoField = value;
                    this.RaisePropertyChanged("AddObetivoOperativo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long AddProyecto {
            get {
                return this.AddProyectoField;
            }
            set {
                if ((this.AddProyectoField.Equals(value) != true)) {
                    this.AddProyectoField = value;
                    this.RaisePropertyChanged("AddProyecto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.ePlanGestion[] ListaActividad {
            get {
                return this.ListaActividadField;
            }
            set {
                if ((object.ReferenceEquals(this.ListaActividadField, value) != true)) {
                    this.ListaActividadField = value;
                    this.RaisePropertyChanged("ListaActividad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.ePlanGestion[] ListaComentarioAvance {
            get {
                return this.ListaComentarioAvanceField;
            }
            set {
                if ((object.ReferenceEquals(this.ListaComentarioAvanceField, value) != true)) {
                    this.ListaComentarioAvanceField = value;
                    this.RaisePropertyChanged("ListaComentarioAvance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.ePlanGestion[] ListaInforme {
            get {
                return this.ListaInformeField;
            }
            set {
                if ((object.ReferenceEquals(this.ListaInformeField, value) != true)) {
                    this.ListaInformeField = value;
                    this.RaisePropertyChanged("ListaInforme");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.ePlanGestion[] ListaObetivoEstrategico {
            get {
                return this.ListaObetivoEstrategicoField;
            }
            set {
                if ((object.ReferenceEquals(this.ListaObetivoEstrategicoField, value) != true)) {
                    this.ListaObetivoEstrategicoField = value;
                    this.RaisePropertyChanged("ListaObetivoEstrategico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.ePlanGestion[] ListaObetivoOperativo {
            get {
                return this.ListaObetivoOperativoField;
            }
            set {
                if ((object.ReferenceEquals(this.ListaObetivoOperativoField, value) != true)) {
                    this.ListaObetivoOperativoField = value;
                    this.RaisePropertyChanged("ListaObetivoOperativo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.ePlanGestion[] ListaProyecto {
            get {
                return this.ListaProyectoField;
            }
            set {
                if ((object.ReferenceEquals(this.ListaProyectoField, value) != true)) {
                    this.ListaProyectoField = value;
                    this.RaisePropertyChanged("ListaProyecto");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AcknowledgeType", Namespace="http://www.yourcompany.com/types/")]
    public enum AcknowledgeType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Failure = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PlanGestionServRef.IPlanGestionService")]
    public interface IPlanGestionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/SetObetivoEstrategico", ReplyAction="http://tempuri.org/IPlanGestionService/SetObetivoEstrategicoResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse SetObetivoEstrategico(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/GetObetivoEstrategico", ReplyAction="http://tempuri.org/IPlanGestionService/GetObetivoEstrategicoResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse GetObetivoEstrategico(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion, string _Items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/SetObetivoOperativo", ReplyAction="http://tempuri.org/IPlanGestionService/SetObetivoOperativoResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse SetObetivoOperativo(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/GetObetivoOperativo", ReplyAction="http://tempuri.org/IPlanGestionService/GetObetivoOperativoResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse GetObetivoOperativo(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion, string _Items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/SetProyecto", ReplyAction="http://tempuri.org/IPlanGestionService/SetProyectoResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse SetProyecto(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/GetProyecto", ReplyAction="http://tempuri.org/IPlanGestionService/GetProyectoResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse GetProyecto(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion, string _Items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/SetActividad", ReplyAction="http://tempuri.org/IPlanGestionService/SetActividadResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse SetActividad(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/GetActividad", ReplyAction="http://tempuri.org/IPlanGestionService/GetActividadResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse GetActividad(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion, string _Items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/SetComentarioAvance", ReplyAction="http://tempuri.org/IPlanGestionService/SetComentarioAvanceResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse SetComentarioAvance(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/GetComentarioAvance", ReplyAction="http://tempuri.org/IPlanGestionService/GetComentarioAvanceResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse GetComentarioAvance(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion, string _Items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanGestionService/GetInforme", ReplyAction="http://tempuri.org/IPlanGestionService/GetInformeResponse")]
        WebGdoc.PlanGestionServRef.PlanGestionResponse GetInforme(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IPlanGestionServiceChannel : WebGdoc.PlanGestionServRef.IPlanGestionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class PlanGestionServiceClient : System.ServiceModel.ClientBase<WebGdoc.PlanGestionServRef.IPlanGestionService>, WebGdoc.PlanGestionServRef.IPlanGestionService {
        
        public PlanGestionServiceClient() {
        }
        
        public PlanGestionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PlanGestionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlanGestionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlanGestionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse SetObetivoEstrategico(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion) {
            return base.Channel.SetObetivoEstrategico(RqtListaPlanGestion);
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse GetObetivoEstrategico(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion, string _Items) {
            return base.Channel.GetObetivoEstrategico(RqtListaPlanGestion, _Items);
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse SetObetivoOperativo(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion) {
            return base.Channel.SetObetivoOperativo(RqtListaPlanGestion);
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse GetObetivoOperativo(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion, string _Items) {
            return base.Channel.GetObetivoOperativo(RqtListaPlanGestion, _Items);
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse SetProyecto(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion) {
            return base.Channel.SetProyecto(RqtListaPlanGestion);
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse GetProyecto(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion, string _Items) {
            return base.Channel.GetProyecto(RqtListaPlanGestion, _Items);
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse SetActividad(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion) {
            return base.Channel.SetActividad(RqtListaPlanGestion);
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse GetActividad(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion, string _Items) {
            return base.Channel.GetActividad(RqtListaPlanGestion, _Items);
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse SetComentarioAvance(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion) {
            return base.Channel.SetComentarioAvance(RqtListaPlanGestion);
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse GetComentarioAvance(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion, string _Items) {
            return base.Channel.GetComentarioAvance(RqtListaPlanGestion, _Items);
        }
        
        public WebGdoc.PlanGestionServRef.PlanGestionResponse GetInforme(WebGdoc.PlanGestionServRef.PlanGestionRequest RqtListaPlanGestion) {
            return base.Channel.GetInforme(RqtListaPlanGestion);
        }
    }
}
