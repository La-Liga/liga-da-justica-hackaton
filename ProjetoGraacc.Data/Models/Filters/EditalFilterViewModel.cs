using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGraacc.Data.Models.Filters
{
    public class EditalFilterViewModel
    {
        public string UF { get; set; }
        public string Municipio { get; set; }
        public string Orgao { get; set; }
        public string Favoritas { get; set; }

        public bool Pesquisa { get; set; }
    }
}
