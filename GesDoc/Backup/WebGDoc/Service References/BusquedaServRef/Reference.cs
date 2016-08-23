﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5477
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebGdoc.BusquedaServRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RequestBase", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.BusquedaServRef.MesaVirtualRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.BusquedaServRef.OperacionRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.BusquedaServRef.BuscarLogOperRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.BusquedaServRef.UbigeoRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.BusquedaServRef.BuscarDocumentoRequest))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="MesaVirtualRequest", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class MesaVirtualRequest : WebGdoc.BusquedaServRef.RequestBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eMesaVirtual CtrMesaVirField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eMesaVirtual CtrMesaVir {
            get {
                return this.CtrMesaVirField;
            }
            set {
                if ((object.ReferenceEquals(this.CtrMesaVirField, value) != true)) {
                    this.CtrMesaVirField = value;
                    this.RaisePropertyChanged("CtrMesaVir");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OperacionRequest", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class OperacionRequest : WebGdoc.BusquedaServRef.RequestBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eOperaciones CtrOperField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eOperaciones CtrOper {
            get {
                return this.CtrOperField;
            }
            set {
                if ((object.ReferenceEquals(this.CtrOperField, value) != true)) {
                    this.CtrOperField = value;
                    this.RaisePropertyChanged("CtrOper");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BuscarLogOperRequest", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class BuscarLogOperRequest : WebGdoc.BusquedaServRef.RequestBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eBuscarLogOperacion CtrBLogOperField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eBuscarLogOperacion CtrBLogOper {
            get {
                return this.CtrBLogOperField;
            }
            set {
                if ((object.ReferenceEquals(this.CtrBLogOperField, value) != true)) {
                    this.CtrBLogOperField = value;
                    this.RaisePropertyChanged("CtrBLogOper");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UbigeoRequest", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class UbigeoRequest : WebGdoc.BusquedaServRef.RequestBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eUbigeo CtrUbigeoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eUbigeo CtrUbigeo {
            get {
                return this.CtrUbigeoField;
            }
            set {
                if ((object.ReferenceEquals(this.CtrUbigeoField, value) != true)) {
                    this.CtrUbigeoField = value;
                    this.RaisePropertyChanged("CtrUbigeo");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BuscarDocumentoRequest", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class BuscarDocumentoRequest : WebGdoc.BusquedaServRef.RequestBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eBuscarDocumentos CtrDocDigTDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eBuscarDocumentos CtrDocDigTD {
            get {
                return this.CtrDocDigTDField;
            }
            set {
                if ((object.ReferenceEquals(this.CtrDocDigTDField, value) != true)) {
                    this.CtrDocDigTDField = value;
                    this.RaisePropertyChanged("CtrDocDigTD");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseBase", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.BusquedaServRef.MesaVirtualResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.BusquedaServRef.OperacionResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.BusquedaServRef.BuscarLogOperResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.BusquedaServRef.UbigeoResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebGdoc.BusquedaServRef.BuscarDocumentoResponse))]
    public partial class ResponseBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebGdoc.BusquedaServRef.AcknowledgeType AcknowledgeField;
        
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
        public WebGdoc.BusquedaServRef.AcknowledgeType Acknowledge {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="MesaVirtualResponse", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class MesaVirtualResponse : WebGdoc.BusquedaServRef.ResponseBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eMesaVirtual[] ListaMesaVirtualField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eMesaVirtual[] ListaMesaVirtual {
            get {
                return this.ListaMesaVirtualField;
            }
            set {
                if ((object.ReferenceEquals(this.ListaMesaVirtualField, value) != true)) {
                    this.ListaMesaVirtualField = value;
                    this.RaisePropertyChanged("ListaMesaVirtual");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OperacionResponse", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class OperacionResponse : WebGdoc.BusquedaServRef.ResponseBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eOperaciones[] OperacionListaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eOperaciones[] OperacionLista {
            get {
                return this.OperacionListaField;
            }
            set {
                if ((object.ReferenceEquals(this.OperacionListaField, value) != true)) {
                    this.OperacionListaField = value;
                    this.RaisePropertyChanged("OperacionLista");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BuscarLogOperResponse", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class BuscarLogOperResponse : WebGdoc.BusquedaServRef.ResponseBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eBuscarLogOperacion[] BListaLogOperField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eBuscarLogOperacion[] BListaLogOper {
            get {
                return this.BListaLogOperField;
            }
            set {
                if ((object.ReferenceEquals(this.BListaLogOperField, value) != true)) {
                    this.BListaLogOperField = value;
                    this.RaisePropertyChanged("BListaLogOper");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UbigeoResponse", Namespace="http://www.yourcompany.com/types/")]
    [System.SerializableAttribute()]
    public partial class UbigeoResponse : WebGdoc.BusquedaServRef.ResponseBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eUbigeo[] ListaUbigeoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eUbigeo[] ListaUbigeo {
            get {
                return this.ListaUbigeoField;
            }
            set {
                if ((object.ReferenceEquals(this.ListaUbigeoField, value) != true)) {
                    this.ListaUbigeoField = value;
                    this.RaisePropertyChanged("ListaUbigeo");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BuscarDocumentoResponse", Namespace="http://schemas.datacontract.org/2004/07/Service.Message.Resquest_Response")]
    [System.SerializableAttribute()]
    public partial class BuscarDocumentoResponse : WebGdoc.BusquedaServRef.ResponseBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eBuscarDocumentos[] BListaDocDigField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eBuscarDocumentos[] BListaDocElectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eBuscarDocumentos[] BListaDocumentoAdjuntoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Entity.Entities.eBuscarDocumentos[] BListaMesaVirtualField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eBuscarDocumentos[] BListaDocDig {
            get {
                return this.BListaDocDigField;
            }
            set {
                if ((object.ReferenceEquals(this.BListaDocDigField, value) != true)) {
                    this.BListaDocDigField = value;
                    this.RaisePropertyChanged("BListaDocDig");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eBuscarDocumentos[] BListaDocElect {
            get {
                return this.BListaDocElectField;
            }
            set {
                if ((object.ReferenceEquals(this.BListaDocElectField, value) != true)) {
                    this.BListaDocElectField = value;
                    this.RaisePropertyChanged("BListaDocElect");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eBuscarDocumentos[] BListaDocumentoAdjunto {
            get {
                return this.BListaDocumentoAdjuntoField;
            }
            set {
                if ((object.ReferenceEquals(this.BListaDocumentoAdjuntoField, value) != true)) {
                    this.BListaDocumentoAdjuntoField = value;
                    this.RaisePropertyChanged("BListaDocumentoAdjunto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Entity.Entities.eBuscarDocumentos[] BListaMesaVirtual {
            get {
                return this.BListaMesaVirtualField;
            }
            set {
                if ((object.ReferenceEquals(this.BListaMesaVirtualField, value) != true)) {
                    this.BListaMesaVirtualField = value;
                    this.RaisePropertyChanged("BListaMesaVirtual");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BusquedaServRef.IBusquedaService")]
    public interface IBusquedaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusquedaService/GetDocumentoDigital", ReplyAction="http://tempuri.org/IBusquedaService/GetDocumentoDigitalResponse")]
        WebGdoc.BusquedaServRef.BuscarDocumentoResponse GetDocumentoDigital(WebGdoc.BusquedaServRef.BuscarDocumentoRequest RqtDocDig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusquedaService/GetDocumentoElectronico", ReplyAction="http://tempuri.org/IBusquedaService/GetDocumentoElectronicoResponse")]
        WebGdoc.BusquedaServRef.BuscarDocumentoResponse GetDocumentoElectronico(WebGdoc.BusquedaServRef.BuscarDocumentoRequest RqtDocElect);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusquedaService/GetMesaVirtual", ReplyAction="http://tempuri.org/IBusquedaService/GetMesaVirtualResponse")]
        WebGdoc.BusquedaServRef.BuscarDocumentoResponse GetMesaVirtual(WebGdoc.BusquedaServRef.BuscarDocumentoRequest RqtMesaVirtual);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusquedaService/GetBandejaMV", ReplyAction="http://tempuri.org/IBusquedaService/GetBandejaMVResponse")]
        WebGdoc.BusquedaServRef.MesaVirtualResponse GetBandejaMV(WebGdoc.BusquedaServRef.MesaVirtualRequest RqtListMesVir);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusquedaService/GetBandejaDoc", ReplyAction="http://tempuri.org/IBusquedaService/GetBandejaDocResponse")]
        WebGdoc.BusquedaServRef.OperacionResponse GetBandejaDoc(WebGdoc.BusquedaServRef.OperacionRequest RqtListOper);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusquedaService/GetTipoMesaVirtual", ReplyAction="http://tempuri.org/IBusquedaService/GetTipoMesaVirtualResponse")]
        WebGdoc.BusquedaServRef.MesaVirtualResponse GetTipoMesaVirtual(WebGdoc.BusquedaServRef.MesaVirtualRequest RqtMesaVirtual);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusquedaService/GetBuscarLogOper", ReplyAction="http://tempuri.org/IBusquedaService/GetBuscarLogOperResponse")]
        WebGdoc.BusquedaServRef.BuscarLogOperResponse GetBuscarLogOper(WebGdoc.BusquedaServRef.BuscarLogOperRequest RqtLogOper);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusquedaService/GetDocumentoAdjunto", ReplyAction="http://tempuri.org/IBusquedaService/GetDocumentoAdjuntoResponse")]
        WebGdoc.BusquedaServRef.BuscarDocumentoResponse GetDocumentoAdjunto(WebGdoc.BusquedaServRef.BuscarDocumentoRequest RqtDocAdj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusquedaService/GetUbigeo", ReplyAction="http://tempuri.org/IBusquedaService/GetUbigeoResponse")]
        WebGdoc.BusquedaServRef.UbigeoResponse GetUbigeo(WebGdoc.BusquedaServRef.UbigeoRequest RqtUbigeo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IBusquedaServiceChannel : WebGdoc.BusquedaServRef.IBusquedaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class BusquedaServiceClient : System.ServiceModel.ClientBase<WebGdoc.BusquedaServRef.IBusquedaService>, WebGdoc.BusquedaServRef.IBusquedaService {
        
        public BusquedaServiceClient() {
        }
        
        public BusquedaServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BusquedaServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BusquedaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BusquedaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebGdoc.BusquedaServRef.BuscarDocumentoResponse GetDocumentoDigital(WebGdoc.BusquedaServRef.BuscarDocumentoRequest RqtDocDig) {
            return base.Channel.GetDocumentoDigital(RqtDocDig);
        }
        
        public WebGdoc.BusquedaServRef.BuscarDocumentoResponse GetDocumentoElectronico(WebGdoc.BusquedaServRef.BuscarDocumentoRequest RqtDocElect) {
            return base.Channel.GetDocumentoElectronico(RqtDocElect);
        }
        
        public WebGdoc.BusquedaServRef.BuscarDocumentoResponse GetMesaVirtual(WebGdoc.BusquedaServRef.BuscarDocumentoRequest RqtMesaVirtual) {
            return base.Channel.GetMesaVirtual(RqtMesaVirtual);
        }
        
        public WebGdoc.BusquedaServRef.MesaVirtualResponse GetBandejaMV(WebGdoc.BusquedaServRef.MesaVirtualRequest RqtListMesVir) {
            return base.Channel.GetBandejaMV(RqtListMesVir);
        }
        
        public WebGdoc.BusquedaServRef.OperacionResponse GetBandejaDoc(WebGdoc.BusquedaServRef.OperacionRequest RqtListOper) {
            return base.Channel.GetBandejaDoc(RqtListOper);
        }
        
        public WebGdoc.BusquedaServRef.MesaVirtualResponse GetTipoMesaVirtual(WebGdoc.BusquedaServRef.MesaVirtualRequest RqtMesaVirtual) {
            return base.Channel.GetTipoMesaVirtual(RqtMesaVirtual);
        }
        
        public WebGdoc.BusquedaServRef.BuscarLogOperResponse GetBuscarLogOper(WebGdoc.BusquedaServRef.BuscarLogOperRequest RqtLogOper) {
            return base.Channel.GetBuscarLogOper(RqtLogOper);
        }
        
        public WebGdoc.BusquedaServRef.BuscarDocumentoResponse GetDocumentoAdjunto(WebGdoc.BusquedaServRef.BuscarDocumentoRequest RqtDocAdj) {
            return base.Channel.GetDocumentoAdjunto(RqtDocAdj);
        }
        
        public WebGdoc.BusquedaServRef.UbigeoResponse GetUbigeo(WebGdoc.BusquedaServRef.UbigeoRequest RqtUbigeo) {
            return base.Channel.GetUbigeo(RqtUbigeo);
        }
    }
}
