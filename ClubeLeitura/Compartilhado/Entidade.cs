using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.Compartilhado
{
    public class Entidade
    {
        public int Id;

        public virtual void Atualizar(Entidade registroAtualizado) { Id = registroAtualizado.Id;}
    }
}
