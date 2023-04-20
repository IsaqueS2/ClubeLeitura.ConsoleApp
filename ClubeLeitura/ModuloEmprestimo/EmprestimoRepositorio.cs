using ClubeLeitura.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ModuloEmprestimo
{
    public class EmprestimoRepositorio : Repositorio
    {
        public string StatusAtual = "OK";

        public void FecharStatus(Emprestimo emprestimo)
        {
            emprestimo.Status = "COMPLETO";
        }
    }
}
