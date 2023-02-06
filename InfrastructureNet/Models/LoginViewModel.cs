using Microsoft.AspNetCore.Mvc;

namespace InfrastructureNet.Models
{
    public class LoginViewModel : PadraoViewModel
    {
        public string usuario { get; set; }
        public string senha { get; set; }
        public bool isADM { get; set; }
        public bool isMaster { get; set; }
    }
}
