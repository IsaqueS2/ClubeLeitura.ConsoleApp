using ClubeLeitura.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ModuloAmigo
{
    public class Amigo : Entidade
    {
        public string nome;
        public string responsavel;
        public string telefone;
        public string endereco;

        public Amigo(int id, string nome, string responsável, string telefone, string endereço)
        {
            Id = id;
            this.nome = nome;
            this.responsavel = responsável;
            this.telefone = telefone;
            this.endereco = endereço;
        }

        public override void Atualizar(Entidade registroAtualizado)
        {
            Amigo amigo = (Amigo)registroAtualizado;

            nome = amigo.nome;
            responsavel = amigo.responsavel;
            telefone = amigo.telefone;
            endereco = amigo.endereco;
        }
    }
}
