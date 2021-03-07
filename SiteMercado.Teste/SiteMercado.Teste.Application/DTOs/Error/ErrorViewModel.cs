namespace SiteMercado.Teste.Application.DTOs.Error
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public string OriginalUrl { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
