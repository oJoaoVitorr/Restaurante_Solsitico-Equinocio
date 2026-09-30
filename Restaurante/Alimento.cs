using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    public class Alimento
    {
        public string Nome { get; set; }
        public string Estacao { get; set; }
        public string Categoria { get; set; }

        public Alimento(string nome, string estacao, string categoria)
        {
            Nome = nome;
            Estacao = estacao;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
