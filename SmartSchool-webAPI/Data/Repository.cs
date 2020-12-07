using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool_webAPI.Models;

namespace SmartSchool_webAPI.Data
{
    public class Repository: IRepository
    {
        private const string V = "exclusivo";
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
         public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<Usuario[]> GetAllUsuariosAsync()
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }
        public async Task<Usuario> GetUsuariosAsyncByNome(string nome)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            
            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario.id)
                         .Where(usuario => usuario.nome == nome);

            return await query.FirstOrDefaultAsync();
        }
         
        public async Task<Usuario> GetUsuarioAsyncById(int usuarioId)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            
            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario.id)
                         .Where(usuario => usuario.id == usuarioId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Evento> GetEventosAsyncByNome(string nome)
        {
            IQueryable<Evento> query = _context.Eventos;

            
            query = query.AsNoTracking()
                         .OrderBy(evento => evento.id)
                         .Where(evento => evento.nome == nome);

            return await query.FirstOrDefaultAsync();
        }        
        public async Task<Evento> GetEventosAsyncByDescricao(string descricao)
        {
            IQueryable<Evento> query = _context.Eventos;

            
            query = query.AsNoTracking()
                         .OrderBy(evento => evento.id)
                         .Where(evento => evento.descricao == descricao);

            return await query.FirstOrDefaultAsync();
        }                
         public async Task<Evento[]> GetAllEventoAsync()
        {
            IQueryable<Evento> query = _context.Eventos;

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }       
        public async Task<Evento> GetEventoAsyncById(int eventoId)
        {
            IQueryable<Evento> query = _context.Eventos;

            
            query = query.AsNoTracking()
                         .OrderBy(evento => evento.id)
                         .Where(evento => evento.id == eventoId);

            return await query.FirstOrDefaultAsync();
        }        

        public async Task<Evento> GetEventosAsyncByDataEvento(DateTime dataEvento)
        {
            IQueryable<Evento> query = _context.Eventos;

            
            query = query.AsNoTracking()
                         .OrderBy(evento => evento.id)
                         .Where(evento => evento.dataevento == dataEvento);

            return await query.FirstOrDefaultAsync();
        }        

        public async Task<Evento> GetEventosAsyncByDataExclusivo(DateTime dataEvento)
        {
            IQueryable<Evento> query = _context.Eventos;

            
            query = query.AsNoTracking()
                         .OrderBy(evento => evento.id)
                         .Where(evento => evento.dataevento == dataEvento && evento.tipo == V);

            return await query.FirstOrDefaultAsync();
        }        
    }
}