﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OHDR.WebServicePuller {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://omanexpo.com/soap/WebService", ConfigurationName="WebServicePuller.WebServicePortType")]
    public interface WebServicePortType {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://omanexpo.com/registration/WebServiceSOAP/server.php?wsdl) of message get_messageRequest does not match the default value (http://omanexpo.com/soap/WebService)
        [System.ServiceModel.OperationContractAttribute(Action="http://omanexpo.com/registration/WebServiceSOAP/server.php/get_message", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        OHDR.WebServicePuller.get_messageResponse get_message(OHDR.WebServicePuller.get_messageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://omanexpo.com/registration/WebServiceSOAP/server.php/get_message", ReplyAction="*")]
        System.Threading.Tasks.Task<OHDR.WebServicePuller.get_messageResponse> get_messageAsync(OHDR.WebServicePuller.get_messageRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://omanexpo.com/registration/WebServiceSOAP/server.php?wsdl) of message update_print_statusRequest does not match the default value (http://omanexpo.com/soap/WebService)
        [System.ServiceModel.OperationContractAttribute(Action="http://omanexpo.com/registration/WebServiceSOAP/server.php/update_print_status", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        OHDR.WebServicePuller.update_print_statusResponse update_print_status(OHDR.WebServicePuller.update_print_statusRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://omanexpo.com/registration/WebServiceSOAP/server.php/update_print_status", ReplyAction="*")]
        System.Threading.Tasks.Task<OHDR.WebServicePuller.update_print_statusResponse> update_print_statusAsync(OHDR.WebServicePuller.update_print_statusRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://omanexpo.com/registration/WebServiceSOAP/server.php?wsdl) of message get_print_statusRequest does not match the default value (http://omanexpo.com/soap/WebService)
        [System.ServiceModel.OperationContractAttribute(Action="http://omanexpo.com/registration/WebServiceSOAP/server.php/get_print_status", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        OHDR.WebServicePuller.get_print_statusResponse get_print_status(OHDR.WebServicePuller.get_print_statusRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://omanexpo.com/registration/WebServiceSOAP/server.php/get_print_status", ReplyAction="*")]
        System.Threading.Tasks.Task<OHDR.WebServicePuller.get_print_statusResponse> get_print_statusAsync(OHDR.WebServicePuller.get_print_statusRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="get_message", WrapperNamespace="http://omanexpo.com/registration/WebServiceSOAP/server.php?wsdl", IsWrapped=true)]
    public partial class get_messageRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string token;
        
        public get_messageRequest() {
        }
        
        public get_messageRequest(string token) {
            this.token = token;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="get_messageResponse", WrapperNamespace="http://omanexpo.com/registration/WebServiceSOAP/server.php?wsdl", IsWrapped=true)]
    public partial class get_messageResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string @return;
        
        public get_messageResponse() {
        }
        
        public get_messageResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="update_print_status", WrapperNamespace="http://omanexpo.com/registration/WebServiceSOAP/server.php?wsdl", IsWrapped=true)]
    public partial class update_print_statusRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string token;
        
        public update_print_statusRequest() {
        }
        
        public update_print_statusRequest(string token) {
            this.token = token;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="update_print_statusResponse", WrapperNamespace="http://omanexpo.com/registration/WebServiceSOAP/server.php?wsdl", IsWrapped=true)]
    public partial class update_print_statusResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string @return;
        
        public update_print_statusResponse() {
        }
        
        public update_print_statusResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="get_print_status", WrapperNamespace="http://omanexpo.com/registration/WebServiceSOAP/server.php?wsdl", IsWrapped=true)]
    public partial class get_print_statusRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string token;
        
        public get_print_statusRequest() {
        }
        
        public get_print_statusRequest(string token) {
            this.token = token;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="get_print_statusResponse", WrapperNamespace="http://omanexpo.com/registration/WebServiceSOAP/server.php?wsdl", IsWrapped=true)]
    public partial class get_print_statusResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string @return;
        
        public get_print_statusResponse() {
        }
        
        public get_print_statusResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServicePortTypeChannel : OHDR.WebServicePuller.WebServicePortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServicePortTypeClient : System.ServiceModel.ClientBase<OHDR.WebServicePuller.WebServicePortType>, OHDR.WebServicePuller.WebServicePortType {
        
        public WebServicePortTypeClient() {
        }
        
        public WebServicePortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServicePortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServicePortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServicePortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OHDR.WebServicePuller.get_messageResponse OHDR.WebServicePuller.WebServicePortType.get_message(OHDR.WebServicePuller.get_messageRequest request) {
            return base.Channel.get_message(request);
        }
        
        public string get_message(string token) {
            OHDR.WebServicePuller.get_messageRequest inValue = new OHDR.WebServicePuller.get_messageRequest();
            inValue.token = token;
            OHDR.WebServicePuller.get_messageResponse retVal = ((OHDR.WebServicePuller.WebServicePortType)(this)).get_message(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OHDR.WebServicePuller.get_messageResponse> OHDR.WebServicePuller.WebServicePortType.get_messageAsync(OHDR.WebServicePuller.get_messageRequest request) {
            return base.Channel.get_messageAsync(request);
        }
        
        public System.Threading.Tasks.Task<OHDR.WebServicePuller.get_messageResponse> get_messageAsync(string token) {
            OHDR.WebServicePuller.get_messageRequest inValue = new OHDR.WebServicePuller.get_messageRequest();
            inValue.token = token;
            return ((OHDR.WebServicePuller.WebServicePortType)(this)).get_messageAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OHDR.WebServicePuller.update_print_statusResponse OHDR.WebServicePuller.WebServicePortType.update_print_status(OHDR.WebServicePuller.update_print_statusRequest request) {
            return base.Channel.update_print_status(request);
        }
        
        public string update_print_status(string token) {
            OHDR.WebServicePuller.update_print_statusRequest inValue = new OHDR.WebServicePuller.update_print_statusRequest();
            inValue.token = token;
            OHDR.WebServicePuller.update_print_statusResponse retVal = ((OHDR.WebServicePuller.WebServicePortType)(this)).update_print_status(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OHDR.WebServicePuller.update_print_statusResponse> OHDR.WebServicePuller.WebServicePortType.update_print_statusAsync(OHDR.WebServicePuller.update_print_statusRequest request) {
            return base.Channel.update_print_statusAsync(request);
        }
        
        public System.Threading.Tasks.Task<OHDR.WebServicePuller.update_print_statusResponse> update_print_statusAsync(string token) {
            OHDR.WebServicePuller.update_print_statusRequest inValue = new OHDR.WebServicePuller.update_print_statusRequest();
            inValue.token = token;
            return ((OHDR.WebServicePuller.WebServicePortType)(this)).update_print_statusAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OHDR.WebServicePuller.get_print_statusResponse OHDR.WebServicePuller.WebServicePortType.get_print_status(OHDR.WebServicePuller.get_print_statusRequest request) {
            return base.Channel.get_print_status(request);
        }
        
        public string get_print_status(string token) {
            OHDR.WebServicePuller.get_print_statusRequest inValue = new OHDR.WebServicePuller.get_print_statusRequest();
            inValue.token = token;
            OHDR.WebServicePuller.get_print_statusResponse retVal = ((OHDR.WebServicePuller.WebServicePortType)(this)).get_print_status(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OHDR.WebServicePuller.get_print_statusResponse> OHDR.WebServicePuller.WebServicePortType.get_print_statusAsync(OHDR.WebServicePuller.get_print_statusRequest request) {
            return base.Channel.get_print_statusAsync(request);
        }
        
        public System.Threading.Tasks.Task<OHDR.WebServicePuller.get_print_statusResponse> get_print_statusAsync(string token) {
            OHDR.WebServicePuller.get_print_statusRequest inValue = new OHDR.WebServicePuller.get_print_statusRequest();
            inValue.token = token;
            return ((OHDR.WebServicePuller.WebServicePortType)(this)).get_print_statusAsync(inValue);
        }
    }
}
