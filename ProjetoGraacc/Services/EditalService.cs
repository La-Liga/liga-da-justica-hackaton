using ProjetoGraacc.Data.Repositorios;
using ProjetoGraacc.Interfaces;
using ProjetoGraacc.Models;
using ProjetoGraacc.Models.Edital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGraacc.Services
{
    public class EditalService : IEditalService
    {
        private readonly IEditalRespositorio _editalRespositorio;

        public EditalService(IEditalRespositorio editalRespositorio)
        {
            _editalRespositorio = editalRespositorio;
        }

        public async Task<IList<EditalListViewModel>> GetAllEditaisAsync()
        {
            var result = await _editalRespositorio.ListAllEditalAsync();
            return result.Select(m =>
            new EditalListViewModel
            {
                Id = m.id.ToString(),
                NrEdital = m.num_edital,
                UF = m.uf,
                Municipio = m.municipio,
                Orgao = m.orgao,
                DtPublicacao = m.data_publicacao.ToShortDateString(),
                Status = m.status.ToString(),
                Favorito = m.favorito
            }).ToList();
        }

        public async Task<bool> AlterarFlagFavoritoAsync(FavoritarViewModel model) =>  await _editalRespositorio.AlterFalgFavoritoAsync(model.Id, model.Favoritar);
    }
}
