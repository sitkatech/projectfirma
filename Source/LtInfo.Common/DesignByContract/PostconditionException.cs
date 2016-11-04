using System;
using System.Runtime.Serialization;

namespace LtInfo.Common.DesignByContract
{
	[Serializable]
	public class PostconditionException : ApplicationException
	{
		public PostconditionException() {}
		public PostconditionException(string message) : base(message) {}
		public PostconditionException(string message, Exception inner) : base(message, inner) {}
		public PostconditionException(SerializationInfo info, StreamingContext context): base(info, context) {}
	}
}

