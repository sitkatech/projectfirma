/*-----------------------------------------------------------------------
<copyright file="SitkaWcfException.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LtInfo.Common
{
    public class SitkaWcfException : Exception
    {
        public SitkaWcfException(OperationContext wcfOperationContext, Exception exception) : base(_MakeMessage(wcfOperationContext), exception)
        {
        }

        protected SitkaWcfException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private static string _MakeMessage(OperationContext wcfOperationContext)
        {
            var requestMessage = wcfOperationContext.RequestContext.RequestMessage;
            var message = string.Format("An error occurred in a WCF call, wrapping in order to log it.\r\nWCF Incoming Message:\r\n{0}\r\n", requestMessage);
            return message;
        }
    }
}
