using ApiAWSExamenFinal.Data;
using ApiAWSExamenFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAWSExamenFinal.Repositories
{
    public class RepositoryEventos
    {
        private ConciertosContext context;

        public RepositoryEventos(ConciertosContext context)
        {
            this.context = context;
        }

        //Funcion que muestra todos los eventos
        public async Task<List<Evento>> GetEventosAsync()
        {
            return await this.context.Eventos.ToListAsync();

        }

        public async Task<List<CategoriaEvento>> GetCategoriasAsync()
        {
            return await this.context.Categorias.ToListAsync();

        }

        public async Task<Evento> FindEventoAsync(int idcategoria)
        {
            return await this.context.Eventos.FirstOrDefaultAsync(x => x.IdCategoria == idcategoria);
        }

        private int GetMaxIdEvento()
        {
            return this.context.Eventos.Max(x => x.IdEvento) + 1;
        }

        public async Task CreateEventoAsync(string nombre, string artista, int idcategoria, string imagen)
        {
            Evento evento = new Evento();
            evento.IdEvento = this.GetMaxIdEvento();
            evento.Nombre = nombre;
            evento.Artista = artista;
            evento.IdCategoria = idcategoria;
            evento.Imagen = imagen;

            await this.context.Eventos.AddAsync(evento);
            await this.context.SaveChangesAsync();
        }
    }
}
