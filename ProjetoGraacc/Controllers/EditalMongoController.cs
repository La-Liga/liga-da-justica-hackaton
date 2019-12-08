using Microsoft.AspNetCore.Mvc;
using ProjetoGraacc.Models;
using ProjetoGraacc.Services;
using System.Collections.Generic;

namespace ProjetoGraacc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly EditalMongoService _editalMongoService;

        public BooksController(EditalMongoService bookService)
        {
            _editalMongoService = bookService;
        }

        [HttpGet]
        public ActionResult<List<EditalMongo>> Get() =>
            _editalMongoService.Get();
    }
}