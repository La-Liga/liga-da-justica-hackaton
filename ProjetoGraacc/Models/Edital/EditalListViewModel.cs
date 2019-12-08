using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGraacc.Models.Edital
{
    public class EditalListViewModel
    {
        public string Id { get; set; }
        public string NrEdital { get; set; }
        public string UF { get; set; }
        public string Municipio { get; set; }
        public string Orgao { get; set; }
        public string DtPublicacao { get; set; }
        public string Status { get; set; }
        public bool Favorito { get; set; }

        public decimal vlPeiteado { get; set; }
        public decimal vlRecebido { get; set; }
        public string dtNotificacao { get; set; }
    }
}
