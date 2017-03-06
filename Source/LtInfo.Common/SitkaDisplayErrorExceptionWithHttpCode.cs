/*-----------------------------------------------------------------------
<copyright file="SitkaDisplayErrorExceptionWithHttpCode.cs" company="Sitka Technology Group">
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
using System.Net;
using System.Runtime.Serialization;

namespace LtInfo.Common
{
    public class SitkaDisplayErrorExceptionWithHttpCode : SitkaDisplayErrorException
    {
        public HttpStatusCode HttpStatusCode;

        public SitkaDisplayErrorExceptionWithHttpCode(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
        //public SitkaDisplayErrorExceptionWithHttpCode() { }
        public SitkaDisplayErrorExceptionWithHttpCode(HttpStatusCode httpStatusCode, string message, Exception innerException) : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
        }
        protected SitkaDisplayErrorExceptionWithHttpCode(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
