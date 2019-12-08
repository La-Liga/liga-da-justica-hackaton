using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGraacc.Models.Edital
{
    public class EditalMongoListViewModel
    {
        public string Id { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }

        public string TextoHtml { get; set; }

        public string NumeroProcesso { get; set; }

        public string DataPublicacao { get; set; }

        public string Link { get; set; }
    }
}
