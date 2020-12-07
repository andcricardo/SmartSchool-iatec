using System;

namespace SmartSchool_webAPI.Models
{
    public class Evento
    {
        public Evento()
        {

        }
        public Evento(int id, string tipo, string nome, string descricao, DateTime dataevento, string local, string participantes)
        {
            this.id = id;
            this.tipo = tipo;
            this.nome = nome;
            this.descricao = descricao;
            this.dataevento = dataevento;
            this.local = local;
            this.participantes = participantes;

        }
        public int id { get; set; }
        public string tipo { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime dataevento { get; set; }
        public string local { get; set; }
        public string participantes { get; set; }
    }
}