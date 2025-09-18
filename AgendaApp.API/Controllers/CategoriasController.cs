using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;
using AgendaApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController (CategoriaRepository categoriaRepository) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var categorias = categoriaRepository.ObterTodos();

            return Ok(categorias);
        }
    }
}
