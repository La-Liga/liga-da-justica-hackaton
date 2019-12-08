using ProjetoGraacc.Models;
using ProjetoGraacc.Models.Edital;
using ProjetoGraacc.Models.Publicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGraacc.Interfaces
{
    public interface IEditalService
    {
        Task<IList<EditalListViewModel>> GetAllEditaisAsync(EditalFilterViewModel filter);
        Task<bool> AlterarFlagFavoritoAsync(FavoritarViewModel model);
        Task<bool> EditEditalAsync(EditalEditViewModel model);
        Task<bool> IncluiEditalAsync(PublicacaoSelecionarViewModel model);
    }
}
