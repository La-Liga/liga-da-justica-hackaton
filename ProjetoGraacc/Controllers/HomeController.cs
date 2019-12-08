using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using ProjetoGraacc.Data.Enum;
using ProjetoGraacc.Interfaces;
using ProjetoGraacc.Models;
using ProjetoGraacc.Models.Edital;
using ProjetoGraacc.Models.Helper;
using ProjetoGraacc.Models.Publicacao;
using ProjetoGraacc.Services;

namespace ProjetoGraacc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEditalService _editalService;
        private readonly EditalMongoService _editalMongoService;

        public HomeController(IEditalService editalService,
            EditalMongoService bookService)
        {
            _editalService = editalService;
            _editalMongoService = bookService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Publicacoes()
        {
            var result = _editalMongoService.Get();
            return View(result.Select(x => new EditalMongoListViewModel
            {
                NumeroProcesso = x.NumeroProcesso,
                Titulo = x.Titulo,
                Link = x.Link,
                Texto = x.Texto,
                TextoHtml = x.TextoHtml,
                DataPublicacao = x.DataPublicacao
            }).ToList());
        }

        [HttpPost, ActionName("SelecionarPublicacao")]
        public async Task<IActionResult> SelecionarPublicacaoAsync(PublicacaoSelecionarViewModel model)
        {
            ReturnViewModel retorno = new ReturnViewModel();

            try
            {
                bool result = false;
                if (model.TpPublicacao == Convert.ToInt32(ObjectsEnum.Edital).ToString())
                {
                    result = await _editalService.IncluiEditalAsync(model);
                }
                else if (model.TpPublicacao == Convert.ToInt32(ObjectsEnum.Sentenca).ToString())
                {

                }

                if (!result)
                    retorno.MensagemErro = "Não foi selecionar esse item!";

                retorno.Sucesso = result;
            }
            catch (Exception)
            {
                retorno.Sucesso = false;
                retorno.MensagemErro = "Erro, tente novamente!";
            }

            return Json(retorno);
        }

        public IActionResult Favoritos()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public async Task<IActionResult> Editais(EditalFilterViewModel filter)
        {
            var model = await _editalService.GetAllEditaisAsync(filter);
            return View(model);
        }

        [HttpPost, ActionName("EditEdital")]
        public async Task<IActionResult> EditEditalAsync(EditalEditViewModel model)
        {
            ReturnViewModel retorno = new ReturnViewModel();

            try
            {
                var result = await _editalService.EditEditalAsync(model);
                retorno.Sucesso = result;
            }
            catch (Exception)
            {
                retorno.Sucesso = false;
                retorno.MensagemErro = "Erro, tente novamente!";
            }

            return Json(retorno);
        }

        public IActionResult Sentencas()
        {
            return View();
        }

        [HttpPost, ActionName("AlterarFlagFavorito")]
        public async Task<IActionResult> AlterarFlagFavoritoAsync(FavoritarViewModel model)
        {
            ReturnViewModel retorno = new ReturnViewModel();

            try
            {
                bool result = false;
                if (model.Objeto == ObjectsEnum.Edital.ToString())
                {
                    result = await _editalService.AlterarFlagFavoritoAsync(model);
                }
                else if (model.Objeto == ObjectsEnum.Sentenca.ToString())
                {
                   
                }

                if (!result)
                    retorno.MensagemErro = "Não foi possível Favoritar/Desfavoritar esse item!";

                retorno.Sucesso = result;
            }
            catch (Exception)
            {
                retorno.Sucesso = false;
                retorno.MensagemErro = "Erro, tente novamente!";
            }

            return Json(retorno);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
