using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGraacc.Models.Helper
{
    public class ReturnViewModel
    {
        public int Id { get; set; }
        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }
        public object Data { get; set; }
    }
}
