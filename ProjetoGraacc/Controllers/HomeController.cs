using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using ProjetoGraacc.Data.Constants;
using ProjetoGraacc.Interfaces;
using ProjetoGraacc.Models;
using ProjetoGraacc.Models.Edital;
using ProjetoGraacc.Models.Helper;

namespace ProjetoGraacc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEditalService _editalService;

        public HomeController(IEditalService editalService)
        {
            _editalService = editalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Publicacoes()
        {
            return View();
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
                if (model.Objeto == ObjectsConstant.Edital)
                {
                    result = await _editalService.AlterarFlagFavoritoAsync(model);
                }
                else if (model.Objeto == ObjectsConstant.Sentenca)
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
