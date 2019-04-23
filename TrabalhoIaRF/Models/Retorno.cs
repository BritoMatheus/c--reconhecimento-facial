using System.Collections.Generic;

namespace TrabalhoIaRF.Models
{
    public class Retorno
    {
        public Retorno()
        {

        }

        public Retorno(List<Emocao> emocoes)
        {
            Emocoes = emocoes;
            Sucesso = true;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public List<Emocao> Emocoes { get; set; }
    }
}