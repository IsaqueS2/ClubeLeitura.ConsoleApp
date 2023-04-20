using ClubeLeitura.Compartilhado;
using ClubeLeitura.ModuloCaixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ModuloRevista
{
    public class RevistaTela : Tela
    {
        public CaixaRepositorio caixaRepositorio = null;
        public RevistaRepositorio revistaRepositorio = null;

        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(1) Criar Revista");
                Console.WriteLine("(2) Editar Revista");
                Console.WriteLine("(3) Deletar Revista");
                Console.WriteLine("(4) Listar Revistas");
                Console.WriteLine("(S) Voltar ao Menu Principal");

                string opcao = Console.ReadLine().ToUpper();

                return opcao;
            }
        }

        public void SelecionarOpcaoRevista(string opcao)
        {
            switch (opcao)
            {
                case "1": InserirNovaRevista(); break;
                case "2": EditarRevista(); break;
                case "3": DeletarRevista(); break;
                case "4": ListarRevista(); break;
                case "S": MenuApresentacao.VoltarAoMenu(); break;
            }
        }

        public void InserirNovaRevista()
        {
            ListarRevista();
            Revista novaRevista = ObterRevista();

            revistaRepositorio.Criar(novaRevista);

            ApresentarMensagem("Revista criada com sucesso!", ConsoleColor.Green);
        }

        public void EditarRevista()
        {
            ListarRevista();
            int idSelecionado = ReceberIdRevista();

            foreach (Revista revista in revistaRepositorio.Cadastros)
            {
                if (revista.Id == idSelecionado)
                {
                    foreach (Caixa caixa in caixaRepositorio.Cadastros)
                    {
                        if (revista.caixaOndeEstaGuardada.Id == caixa.Id)
                        {
                            caixa.RevistasNaCaixa.Remove(revista);
                        }
                    }
                }
            }

            Revista revistaAtualizada = ObterRevista();

            revistaRepositorio.Editar(idSelecionado, revistaAtualizada);

            ApresentarMensagem("Revista editada com sucesso!", ConsoleColor.Green);
        }

        public void ListarRevista()
        {
            ArrayList listaRevistas = revistaRepositorio.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ID   |   COLECAO   |     ANO     |   CAIXA   |");
            Console.WriteLine("----------------------------------------------");

            if (listaRevistas.Count == 0)
            {
                ApresentarMensagem("Nenhuma revista cadastrada!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Revista revista in listaRevistas)
            {
                Console.WriteLine("{0,-5}|{1,-13}|{2,-13}|{3,-11}|", revista.Id, revista.titulo, revista.anoDaRevista, revista.caixaOndeEstaGuardada.Id);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public void DeletarRevista()
        {
            ListarRevista();
            int idSelecionado = ReceberIdRevista();

            foreach (Revista revista in revistaRepositorio.Cadastros)
            {
                if (revista.Id == idSelecionado)
                {
                    foreach (Caixa caixa in caixaRepositorio.Cadastros)
                    {
                        if (revista.caixaOndeEstaGuardada.Id == caixa.Id)
                        {
                            caixa.RevistasNaCaixa.Remove(revista);
                        }
                    }
                }
            }

            revistaRepositorio.Deletar(idSelecionado);
            ApresentarMensagem("Revista excluída com sucesso!", ConsoleColor.Green);
        }

        public int ReceberIdRevista()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id da revista: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = revistaRepositorio.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    ApresentarMensagem("id Inválido, tente novamente", ConsoleColor.Red);
                }
            } while (idInvalido);

            return id;
        }
        
        public Revista ObterRevista()
        {
            Console.WriteLine("Digite a coleção: ");
            string colecao = Console.ReadLine();

            Console.WriteLine("Digite o numero da Edição: ");
            string numeroDaEdicao = Console.ReadLine();

            Console.WriteLine("Digite o ano da revista: ");
            string anoDaRevista = Console.ReadLine();

            Console.WriteLine("Digite o id da caixa que a revista pertence: ");
            int idDaCaixa = int.Parse(Console.ReadLine());

            Caixa caixa = null;

            foreach (Caixa c in caixaRepositorio.Cadastros)
            {
                if (idDaCaixa == c.Id)
                {
                    caixa = c;
                }
            }
            while (caixa == null)
            {
                ApresentarMensagem("Caixa inexistente!", ConsoleColor.Red);
                Console.WriteLine("Digite o id da caixa que a revista pertence: ");
                idDaCaixa = int.Parse(Console.ReadLine());

                foreach (Caixa c in caixaRepositorio.Cadastros)
                {
                    if (idDaCaixa == c.Id)
                    {
                        caixa = c;
                    }
                }
            }

            Revista revista = new Revista(revistaRepositorio.ContadorId, colecao, numeroDaEdicao, anoDaRevista, caixa);

            return revista;
        }
    }
}
