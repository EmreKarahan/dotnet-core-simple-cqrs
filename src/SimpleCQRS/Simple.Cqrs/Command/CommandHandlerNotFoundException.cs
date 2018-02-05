using System;
using System.Runtime.Serialization;

namespace Simple.Cqrs.Command
{
    [Serializable]
    internal class CommandHandlerNotFoundException : Exception
    {
        private Type _type;

        public CommandHandlerNotFoundException()
        {
        }

        public CommandHandlerNotFoundException(string message) : base(message)
        {
        }

        public CommandHandlerNotFoundException(Type type)
        {
            _type = type;
        }

        public CommandHandlerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommandHandlerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
