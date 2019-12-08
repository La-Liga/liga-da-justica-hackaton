using ProjetoGraacc.Data.Models.Include;
using ProjetoGraacc.Data.Repositorios;
using ProjetoGraacc.Interfaces;
using ProjetoGraacc.Models;
using ProjetoGraacc.Models.Edital;
using ProjetoGraacc.Models.Publicacao;
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

        public async Task<IList<EditalListViewModel>> GetAllEditaisAsync(EditalFilterViewModel filter)
        {
            var filterRepositorio = new ProjetoGraacc.Data.Models.Filters.EditalFilterViewModel
            {
                UF = filter.UF,
                Municipio = filter.Municipio,
                Orgao = filter.Orgao,
                Favoritas = filter.Favoritas,
                Pesquisa = filter.Pesquisa
            };
            var result = await _editalRespositorio.ListEditaisAsync(filterRepositorio);
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
                Favorito = m.favorito,
                vlPeiteado = m.valor_pleiteado,
                vlRecebido = m.valor_recebido,
                dtNotificacao = m.data_notificacao.HasValue ? m.data_notificacao.Value.ToShortDateString() : null
            }).ToList();
        }

        public async Task<bool> AlterarFlagFavoritoAsync(FavoritarViewModel model) =>  await _editalRespositorio.AlterFalgFavoritoAsync(model.Id, model.Favoritar);

        public async Task<bool> EditEditalAsync(EditalEditViewModel model) => await _editalRespositorio.EditEditalAsync(model.Id, model.ValorPleiteado, model.ValorRecebido, model.DtNotificacao, model.Status);

        public async Task<bool> IncluiEditalAsync(PublicacaoSelecionarViewModel model)
        {
            var edital = new IncluirEditalModel
            {
                NrProcesso = model.NrProcesso,
                Titulo = model.Titulo,
                Link = model.Link,
                Texto = model.Texto,
                TextoHtml = model.TextoHtml,
                DtPublicacao = model.DtPublicacao,
                TpPublicacao = model.TpPublicacao,
                ValorPleiteado = model.ValorPleiteado,
                DtNotificacao = model.DtNotificacao,
                Status = model.Status
            };

            return await _editalRespositorio.IncluiEditalAsync(edital);
        }
    }
}
