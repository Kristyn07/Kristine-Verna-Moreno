namespace KristineVernaMorenoV1._2.Models
{
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public bool UseSSL {  get; set; }
    }
}