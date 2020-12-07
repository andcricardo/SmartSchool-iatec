using System;

namespace SmartSchool_webAPI.Models
{
    public class Agenda
    {
        public Agenda()
        {

        }
        public Agenda(int id, string decricao, DateTime dataagenda, Usuario usuario, Evento evento)
        {
            this.id = id;
            this.decricao = decricao;
            this.dataagenda = dataagenda;
            this.usuario = usuario;
            this.evento = evento;

        }
        public int id { get; set; }
        public string decricao { get; set; }

        public DateTime dataagenda { get; set; }

        public Usuario usuario { get; set; }

        public Evento evento { get; set; }
    }
}