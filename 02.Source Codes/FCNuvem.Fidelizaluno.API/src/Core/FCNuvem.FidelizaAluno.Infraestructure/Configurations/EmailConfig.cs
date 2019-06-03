namespace FCNuvem.FidelizaAluno.Infrastructure.Configurations
{
    public class EmailConfig
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string AddresFrom { get; set; }
        public string NameFrom { get; set; }

        public string DebugEmail { get; set; }
    }
}