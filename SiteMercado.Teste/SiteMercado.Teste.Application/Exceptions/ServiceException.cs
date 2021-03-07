using SiteMercado.Teste.Domain.Exceptions;
using System.Collections.Generic;

namespace SiteMercado.Teste.Application.Exceptions
{
    public class ServiceException : AppException
    {
        private const string _message = "Falha ao processar o serviço";

        public ServiceException(string message) : base(message)
        {
        }

        public ServiceException(IList<string> messageList) : base(messageList)
        {
        }

        public ServiceException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public ServiceException(System.Exception innerException) : base(_message, innerException)
        {
        }

        public ServiceException() : base(_message)
        {
        }
    }
}
