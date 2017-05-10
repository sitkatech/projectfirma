using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Util;
using Microsoft.IdentityModel.Protocols.WSFederation;

namespace Keystone.Common
{
    /// <summary>
    /// Allow the dangerous looking Windows Indentity Foundation (WIF) request to pass through the code, otherwise one will get an HttpRequestValidationException
    /// Based on code in this article: "Windows Identity Foundation (WIF): A Potentially Dangerous Request.Form Value Was Detected from the Client"
    /// <see cref="http://social.technet.microsoft.com/wiki/contents/articles/1725.windows-identity-foundation-wif-a-potentially-dangerous-request-form-value-was-detected-from-the-client-wresult-t-requestsecurityto.aspx"/>
    /// 7/21/14 RL: Seems like this code is obsolete once upgraded to .NET 4.5 http://bartwullems.blogspot.com/2013/07/windows-identity-foundationwif-request.html
    /// </summary>
    public class WsFederationRequestValidator : RequestValidator
    {
        /// <summary>
        /// This code must use the unvalidated <see cref="HttpRequest.Form"/> or risk a <see cref="StackOverflowException"/> when calling the <see cref="WSFederationMessage.CreateFromNameValueCollection"/>
        /// This is documented in article "Custom WIF Request Validator Infinite Loop" <see cref="http://stackoverflow.com/questions/8746970/custom-wif-request-validator-infinite-loop"/>
        /// </summary>
        protected override bool IsValidRequestString(HttpContext context, string value, RequestValidationSource requestValidationSource, string collectionKey, out int validationFailureIndex)
        {
            validationFailureIndex = 0;
            if (requestValidationSource == RequestValidationSource.Form && !String.IsNullOrEmpty(collectionKey) && collectionKey.Equals(WSFederationConstants.Parameters.Result, StringComparison.Ordinal))
            {
                // Must use UNVALIDATED HttpRequest.Form for the WSFederationMessage.CreateFromNameValueCollection() or WSFederationMessage will attempt to validate again resulting in StackOverflowException due to infinite recurision 
                var unvalidatedFormValuesToAvoidStackOverflow = context.Request.Unvalidated().Form;
                var message = WSFederationMessage.CreateFromNameValueCollection(WSFederationMessage.GetBaseUrl(context.Request.Url), unvalidatedFormValuesToAvoidStackOverflow) as SignInResponseMessage;
                if (message != null)
                {
                    return true;
                }
            }
            var isValidRequestString = base.IsValidRequestString(context, value, requestValidationSource, collectionKey, out validationFailureIndex);
            return isValidRequestString;
        }
    }
}
