using System;
using System.Runtime.Serialization;

namespace Simple.Cqrs.Query
{
    [Serializable]
    internal class QueryHandlerNotFoundException : Exception
    {
        private Type _type;

        public QueryHandlerNotFoundException()
        {
        }

        public QueryHandlerNotFoundException(string message) : base(message)
        {
        }

        public QueryHandlerNotFoundException(Type type)
        {
            _type = type;
        }

        public QueryHandlerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QueryHandlerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}