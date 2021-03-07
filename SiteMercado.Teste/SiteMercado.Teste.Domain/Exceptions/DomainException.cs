using System.Collections.Generic;

namespace SiteMercado.Teste.Domain.Exceptions
{
    public class DomainException : AppException
    {
        private const string _message = "Falha ao processar o domínio";

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(IList<string> messageList) : base(messageList)
        {
        }

        public DomainException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public DomainException(System.Exception innerException) : base(_message, innerException)
        {
        }

        public DomainException() : base(_message)
        {
        }
    }
}
