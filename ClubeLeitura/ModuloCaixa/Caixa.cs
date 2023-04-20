using ClubeLeitura.Compartilhado;
using ClubeLeitura.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ModuloCaixa
{
    public class Caixa : Entidade
    {
        public string Etiqueta;
        public string Cor;
        public List<Revista> RevistasNaCaixa = new List<Revista>();

        public Caixa(int id, string cor, string etiqueta)
        {
            Id = id;
            Cor = cor;
            Etiqueta = etiqueta;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Caixa caixa = (Caixa)registroAtualizado;

            Cor = caixa.Cor;
            Etiqueta = caixa.Etiqueta;
        }
    }
}
