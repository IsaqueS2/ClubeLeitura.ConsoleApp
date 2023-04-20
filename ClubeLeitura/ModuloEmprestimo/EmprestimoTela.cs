using ClubeLeitura.Compartilhado;
using ClubeLeitura.ModuloAmigo;
using ClubeLeitura.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ModuloEmprestimo
{
    public class EmprestimoTela : Tela
    {
        public EmprestimoRepositorio emprestimoRepositorio = null;
        public AmigoRepositorio amigoRepositorio = null;
        public RevistaRepositorio revistaRepositorio = null;

        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Criar Emprestimo");
                Console.WriteLine("2 - Editar Emprestimo");
                Console.WriteLine("3 - Deletar Emprestimo");
                Console.WriteLine("4 - Listar Emprestimos");
                Console.WriteLine("5 - Fechar Emprestimo");
                Console.WriteLine("S - Voltar ao Menu Principal");

                string opcao = Console.ReadLine().ToUpper();

                return opcao;
            }
        }

        public void SelecionarOpcaoEmprestimo(string opcao)
        {
            switch (opcao)
            {
                case "1": InserirNovoEmprestimo(); break;
                case "2": EditarEmprestimo(); break;
                case "3": DeletarEmprestimo(); break;
                case "4": ListarEmprestimo(); break;
                case "5": AlterarStatus(); break;
                case "S": MenuApresentacao.VoltarAoMenu(); break;
            }
        }

        public void InserirNovoEmprestimo()
        {
            ListarEmprestimo();

            Emprestimo novoEmprestimo = ObterEmprestimo();
            emprestimoRepositorio.Criar(novoEmprestimo);

            ApresentarMensagem("Sucesso!", ConsoleColor.Green);
        }

        public void EditarEmprestimo()
        {
            ListarEmprestimo();
            int idSelecionado = ReceberIdEmprestimo();
            Emprestimo emprestimoAtualizado = ObterEmprestimo();

            emprestimoRepositorio.Editar(idSelecionado, emprestimoAtualizado);

            ApresentarMensagem("Sucesso!", ConsoleColor.Green);
        }

        public void ListarEmprestimo()
        {
            ArrayList listaEmprestimo = emprestimoRepositorio.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| ID | AMIGO                   | REVISTA                 | DATA DO EMPRÉSTIMO | DATA DEVOLUÇÃO | STATUS   |");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

            if (listaEmprestimo.Count == 0)
            {
                ApresentarMensagem("Nenhum empréstimo cadastrado!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Emprestimo emprestimo in listaEmprestimo)
            {
                Console.WriteLine("| {0,-4}| {1,-24}| {2,-24}| {3,-19}| {4,-15}| {5,-9}|", emprestimo.Id, emprestimo.AmigoQuePegouARevista.nome, emprestimo.RevistaEmprestada.titulo, emprestimo.DataDoEmprestimo, emprestimo.DataDeDevolucao, emprestimo.Status);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public void DeletarEmprestimo()
        {
            ListarEmprestimo();

            int idSelecionado = ReceberIdEmprestimo();
            emprestimoRepositorio.Deletar(idSelecionado);

            ApresentarMensagem("Sucesso!", ConsoleColor.Green);
        }

        public int ReceberIdEmprestimo()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o ID do empréstimo: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = amigoRepositorio.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ID Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Emprestimo ObterEmprestimo()
        {
            Console.WriteLine("Digite o ID amigo que pegou a revista: ");
            int idAmigo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ID da revista emprestada: ");
            int idRevistaEmprestada = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de empréstimo: ");
            string dataDeEmprestimo = Console.ReadLine();

            Console.WriteLine("Digite a data de devolução: ");
            string dataDeDevolucao = Console.ReadLine();


            Amigo amigo = null;
            Revista revista = null;

            foreach (Amigo a in amigoRepositorio.Cadastros)
            {
                if (idAmigo == a.Id)
                    amigo = a;
            }
            foreach (Revista r in revistaRepositorio.Cadastros)
            {
                if (idRevistaEmprestada == r.Id)
                    revista = r;
            }

            Emprestimo emprestimo = new Emprestimo(emprestimoRepositorio.ContadorId, amigo, revista, dataDeEmprestimo, dataDeDevolucao, emprestimoRepositorio.StatusAtual);

            return emprestimo;
        }

        public void AlterarStatus()
        {
            int idFechar = ReceberIdEmprestimo();

            Emprestimo emprestimo = null;

            foreach (Emprestimo e in emprestimoRepositorio.Cadastros)
            {
                if (idFechar == e.Id)
                {
                    emprestimo = e;
                }
            }
            emprestimoRepositorio.FecharStatus(emprestimo);
            ApresentarMensagem("Sucesso!", ConsoleColor.Green);
        }
    }
}
