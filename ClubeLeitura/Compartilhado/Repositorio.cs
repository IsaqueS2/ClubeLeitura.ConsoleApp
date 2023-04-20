using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.Compartilhado
{
    public class Repositorio
    {
        public ArrayList Cadastros = new ArrayList();
        public int ContadorId = 1;

        public void Cadastrar(Entidade entidade) { Cadastros.Add(entidade); }

        public void Criar(Entidade entidade)
        {
            Cadastrar(entidade);
            IncrementarId();
        }

        public void Editar(int idEditar, Entidade entidadeAtualizada)
        {
            Entidade entidade = SelecionarPorId(idEditar);
            entidade.Atualizar(entidadeAtualizada);
        }

        public void Deletar(int id)
        {
            Entidade entidade = SelecionarPorId(id);
            Cadastros.Remove(entidade);
        }

        public ArrayList SelecionarTodos() { return Cadastros; }

        public Entidade SelecionarPorId(int id)
        {
            Entidade entidade = null;

            foreach (Entidade e in Cadastros)
            {
                if (e.Id == id)
                {
                    entidade = e;
                    break;
                }
            }

            return entidade;
        }
        
        public void IncrementarId() { ContadorId++; }
    }
}
