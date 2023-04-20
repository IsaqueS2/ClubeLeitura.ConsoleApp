using ClubeLeitura.Compartilhado;
using ClubeLeitura.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ModuloRevista
{
    public class Revista : Entidade
    {
        public string titulo;
        public string numeroDaEdicao;
        public string anoDaRevista;
        public Caixa caixaOndeEstaGuardada;

        public Revista(int id, string titulo, string numeroDaEdicao, string anoDaRevista, Caixa caixaOndeEstaGuardada)
        {
            Id = id;
            this.titulo = titulo;
            this.numeroDaEdicao = numeroDaEdicao;
            this.anoDaRevista = anoDaRevista;
            this.caixaOndeEstaGuardada = caixaOndeEstaGuardada;
        }
        public override void Atualizar(Entidade registroAtualizado)
        {
            Revista revista = (Revista)registroAtualizado;

            titulo = revista.titulo;
            numeroDaEdicao = revista.numeroDaEdicao;
            anoDaRevista = revista.anoDaRevista;
            caixaOndeEstaGuardada = revista.caixaOndeEstaGuardada;
        }
    }
}
