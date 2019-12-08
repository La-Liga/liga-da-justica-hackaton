using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGraacc.Models.Edital
{
    public class EditalEditViewModel
    {
        public int Id { get; set; }
        public decimal ValorPleiteado { get; set; }
        public decimal ValorRecebido { get; set; }
        public DateTime? DtNotificacao { get; set; }
        public string Status { get; set; }
    }
}
