using System.ServiceModel;

namespace Keystone.Common.Service
{
    public abstract class RelyingPartyAccountService : IRelyingPartyAccountService
    {
        [OperationContract]
        public virtual ProvisionResult ProvisionAccount(AccountProvisioningData provisioningData)
        {
            return ProvisionResult.Ignored;
        }
    }
}
