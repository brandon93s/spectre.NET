namespace Spectre.Api.Wrapper
{
    public class Response
    {
        public string Error { get; set; }

        public bool Success
        {
            get { return string.IsNullOrEmpty(Error); }
        }
    }
}
