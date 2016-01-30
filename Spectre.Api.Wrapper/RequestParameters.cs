namespace Spectre.Api.Wrapper
{
    public class RequestParameters
    {
        public string Url { get; set; }
        public string Format { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public PaperSize PaperSize { get; set; }
        public int Quality { get; set; }
        public string Mode { get; set; }
        public int Delay { get; set; }
        public string UserAgent { get; set; }
        public bool EnableJs { get; set; }
        public bool LoadImages { get; set; }
        public object Data { get; set; }
        public string DataType { get; set; }
        public Cookie[] Cookies { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
