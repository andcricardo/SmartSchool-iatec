using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool_webAPI.Models;                            


namespace SmartSchool_webAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>()
                .HasData(new List<Usuario>(){
                    new Usuario(1, "André", "contato@andrericardo.eti.br", "123", Convert.ToDateTime("28/5/2016"), "Masculino")
                    
                });
        }
    }
}