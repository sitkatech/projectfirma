using System;
using System.Runtime.Serialization;

namespace LtInfo.Common.DesignByContract
{
	[Serializable]
	public class PreconditionException : ApplicationException
	{
		public PreconditionException() {}
		public PreconditionException(string message) : base(message) {}
		public PreconditionException(string message, Exception inner) : base(message, inner) {}
		public PreconditionException(SerializationInfo info, StreamingContext context): base(info, context) {}
	}
}
