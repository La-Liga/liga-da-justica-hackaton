using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using ProjetoGraacc.Data.Repositorios;
using ProjetoGraacc.Models;

namespace ProjetoGraacc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEditalRespositorio _editalRepositorio;

        public HomeController(IEditalRespositorio editalRespositorio)
        {
            _editalRepositorio = editalRespositorio;
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

        public IActionResult Editais()
        {
            return View();
        }

        public IActionResult Sentencas()
        {
            return View();
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
