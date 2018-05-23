using System.ServiceModel;

namespace Keystone.Common.Service
{
    [ServiceContract]
    public interface IRelyingPartyAccountService
    {
        [OperationContract]
        ProvisionResult ProvisionAccount(AccountProvisioningData provisioningData);
    }
}
