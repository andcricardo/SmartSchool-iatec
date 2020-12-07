using System;
using System.Threading.Tasks;
using SmartSchool_webAPI.Models;

namespace SmartSchool_webAPI.Data
{
    public interface IRepository 
    {
 //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //USUARIO
        Task<Usuario[]> GetAllUsuariosAsync();        
        Task<Usuario> GetUsuariosAsyncByNome(string nome);
        Task<Usuario> GetUsuarioAsyncById(int usuarioId);

         //EVENTO
        Task<Evento[]> GetAllEventoAsync();        
        Task<Evento> GetEventosAsyncByNome(string nome);
        Task<Evento> GetEventosAsyncByDescricao(string descricao);
         Task<Evento> GetEventosAsyncByDataEvento(DateTime dataEvento);
        Task<Evento> GetEventosAsyncByDataExclusivo(DateTime dataEvento);         
        Task<Evento> GetEventoAsyncById(int usuarioId);
               
    }
}