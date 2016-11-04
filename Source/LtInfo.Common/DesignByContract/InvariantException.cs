using System;
using System.Runtime.Serialization;

namespace LtInfo.Common.DesignByContract
{
	[Serializable]
	public class InvariantException : ApplicationException
	{
		public InvariantException() {}
		public InvariantException(string message) : base(message) {}
		public InvariantException(string message, Exception inner) : base(message, inner) {}
		public InvariantException(SerializationInfo info, StreamingContext context): base(info, context) {}
	}
}

