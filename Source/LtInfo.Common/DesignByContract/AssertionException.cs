using System;
using System.Runtime.Serialization;

namespace LtInfo.Common.DesignByContract
{
	[Serializable]
	public class AssertionException : ApplicationException
	{
		public AssertionException() {}
		public AssertionException(string message) : base(message) {}
		public AssertionException(string message, Exception inner) : base(message, inner) {}
		public AssertionException(SerializationInfo info, StreamingContext context): base(info, context) {}
	}
}
