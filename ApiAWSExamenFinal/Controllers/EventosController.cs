using ApiAWSExamenFinal.Models;
using ApiAWSExamenFinal.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAWSExamenFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private RepositoryEventos repo;

        public EventosController(RepositoryEventos repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Evento>>> GetEventosList()
        {
            return await this.repo.GetEventosAsync();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<CategoriaEvento>>> GetCategoriasAsync()
        {
            return await this.repo.GetCategoriasAsync();
        }

        [HttpGet("{id}")]
       
        public async Task<ActionResult<Evento>> FindEvento(int id)
        {
            return await this.repo.FindEventoAsync(id);
        }

        [HttpPost]
        
        public async Task<ActionResult> CreateEvento(Evento evento)
        {
            await this.repo.CreateEventoAsync(evento.Nombre, evento.Artista, evento.IdCategoria, evento.Imagen);
            return Ok();
        }
    }
}
