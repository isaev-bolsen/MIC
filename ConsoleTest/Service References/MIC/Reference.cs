﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18052
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleTest.MIC {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MIC.IMIC")]
    public interface IMIC {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMIC/GetData", ReplyAction="http://tempuri.org/IMIC/GetDataResponse")]
        System.IO.Stream GetData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMIC/GetData", ReplyAction="http://tempuri.org/IMIC/GetDataResponse")]
        System.Threading.Tasks.Task<System.IO.Stream> GetDataAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMICChannel : ConsoleTest.MIC.IMIC, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MICClient : System.ServiceModel.ClientBase<ConsoleTest.MIC.IMIC>, ConsoleTest.MIC.IMIC {
        
        public MICClient() {
        }
        
        public MICClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MICClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MICClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MICClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.IO.Stream GetData() {
            return base.Channel.GetData();
        }
        
        public System.Threading.Tasks.Task<System.IO.Stream> GetDataAsync() {
            return base.Channel.GetDataAsync();
        }
    }
}
