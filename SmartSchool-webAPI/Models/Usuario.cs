using System;

namespace SmartSchool_webAPI.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(int id, string nome, string email, string senha, DateTime datanascimento, string sexo)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.datanascimento = datanascimento;
            this.sexo = sexo;

        }
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime datanascimento { get; set; }
        public string sexo { get; set; }

    }
}