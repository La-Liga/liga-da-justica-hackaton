using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGraacc.Data.Models
{
    public class Edital
    {
        public int id { get; set; }
        public string num_edital { get; set; }
        public string titulo { get; set; }
        public string resumo { get; set; }
        public string texto { get; set; }
        public string uf { get; set; }
        public string municipio { get; set; }
        public string orgao { get; set; }
        public DateTime data_publicacao { get; set; }
        public bool favorito { get; set; }
        public string link { get; set; }
        public decimal valor_pleiteado { get; set; }
        public decimal valor_recebido { get; set; }
        public DateTime? data_notificacao { get; set; }
        public string usuario_cadastro { get; set; }
        public int status { get; set; }
    }
}
