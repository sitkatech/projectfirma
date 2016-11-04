using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using log4net;

namespace LtInfo.Common
{
    public class WebServicesErrorHandler : Attribute, IErrorHandler, IContractBehavior
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(WebServicesErrorHandler));

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.ChannelDispatcher.ErrorHandlers.Add(this);
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            SitkaHttpRequestStorage.WcfStoredError = new SitkaWcfException(OperationContext.Current, error);
        }

        public bool HandleError(Exception error)
        {
            return false;
        }
    }
}