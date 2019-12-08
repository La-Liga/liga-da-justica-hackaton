using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGraacc.Data.Models.Include
{
    public class IncluirEditalModel
    {
        public string NrProcesso { get; set; }
        public string Titulo { get; set; }
        public string Link { get; set; }
        public string Texto { get; set; }
        public string TextoHtml { get; set; }
        public string DtPublicacao { get; set; }

        public string TpPublicacao { get; set; }
        public decimal ValorPleiteado { get; set; }
        public DateTime? DtNotificacao { get; set; }
        public string Status { get; set; }
    }
}
