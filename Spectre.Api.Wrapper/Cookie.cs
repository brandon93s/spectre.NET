namespace Spectre.Api.Wrapper
{
    public class Cookie
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Path { get; set; }
        public string Domain { get; set; }
        public bool HttpOnly { get; set; }
        public bool Secure { get; set; }
        public string Expires { get; set; }
    }
}
