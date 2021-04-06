namespace ImagineSoftwareWebsite.Models
{
    public class StatusCodeErrorViewModel
    {
        public int ErrorCode { get; }
        public string ErrorDescription { get; }

        public StatusCodeErrorViewModel(int errorCode)
        {
            ErrorCode = errorCode;

            ErrorDescription = errorCode switch
            {
                404 => "Non trovo la pagina che stai cercando.",
                _ => "Si è verificato un errore inaspettato, riprova più tardi!",
            };
        }
    }
}
