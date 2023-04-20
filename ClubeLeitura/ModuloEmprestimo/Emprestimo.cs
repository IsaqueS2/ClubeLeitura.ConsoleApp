using ClubeLeitura.Compartilhado;
using ClubeLeitura.ModuloAmigo;
using ClubeLeitura.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ModuloEmprestimo
{
    public class Emprestimo : Entidade
    {
        public Amigo AmigoQuePegouARevista;
        public Revista RevistaEmprestada;
        public string DataDoEmprestimo;
        public string DataDeDevolucao;
        public string Status;

        public Emprestimo(int id, Amigo amigoQuePegouARevista, Revista revistaEmprestada, string dataDoEmprestimo, string dataDeDevolucao, string status)
        {
            Id = id;
            AmigoQuePegouARevista = amigoQuePegouARevista;
            RevistaEmprestada = revistaEmprestada;
            DataDoEmprestimo = dataDoEmprestimo;
            DataDeDevolucao = dataDeDevolucao;
            Status = status;
        }
        
        public override void Atualizar(Entidade registroAtualizado)
        {
            Emprestimo emprestimo = (Emprestimo)registroAtualizado;

            AmigoQuePegouARevista = emprestimo.AmigoQuePegouARevista;
            RevistaEmprestada = emprestimo.RevistaEmprestada;
            DataDoEmprestimo = emprestimo.DataDoEmprestimo;
            DataDeDevolucao = emprestimo.DataDoEmprestimo;
        }
    }
}
