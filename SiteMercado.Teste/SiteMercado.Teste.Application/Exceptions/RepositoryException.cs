using SiteMercado.Teste.Domain.Exceptions;
using System.Collections.Generic;

namespace SiteMercado.Teste.Application.Exceptions
{
    public class RepositoryException : AppException
    {
        private const string _message = "Falha ao processar a base de dados";

        public RepositoryException() : this(_message) { }

        public RepositoryException(string message) : base(message) { }

        public RepositoryException(string message, System.Exception innerException) : base(message, innerException) { }

        public RepositoryException(System.Exception innerException) : base(_message, innerException) { }

        public RepositoryException(IList<string> exceptions) : base(exceptions) { }
    }
}
