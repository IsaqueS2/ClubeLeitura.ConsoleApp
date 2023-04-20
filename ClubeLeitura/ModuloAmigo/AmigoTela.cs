using ClubeLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ModuloAmigo
{
    public class AmigoTela : Tela
    {
        public AmigoRepositorio amigoRepositorio = null;

        public string ApresentarMenu()
        {
            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Criar Amigo");
                Console.WriteLine("2 - Editar Amigo");
                Console.WriteLine("3 - Deletar Amigo");
                Console.WriteLine("4 - Listar Amigos");
                Console.WriteLine("S - Voltar ao Menu Principal");

                string opcao = Console.ReadLine().ToUpper();

                return opcao;
            }
        }

        public void SelecionarOpcao(string opcao)
        {
            switch (opcao)
            {
                case "1": Inserir(); break;
                case "2": Editar(); break;
                case "3": Deletar(); break;
                case "4": Listar(); break;
                case "S": MenuApresentacao.VoltarAoMenu(); break;
            }
        }

        public void Inserir()
        {
            Listar();

            Amigo novoAmigo = ObterAmigo();

            amigoRepositorio.Criar(novoAmigo);

            ApresentarMensagem("Amigo criado com sucesso!", ConsoleColor.Green);
        }
        
        public void Editar()
        {
            Listar();

            int idSelecionado = ReceberIdAmigo();
            Amigo amigoAtualizado = ObterAmigo();

            amigoRepositorio.Editar(idSelecionado, amigoAtualizado);

           ApresentarMensagem("Amigo editado com sucesso!", ConsoleColor.Green);
        }

        public void Listar()
        {
            ArrayList listaAmigos = amigoRepositorio.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("| ID | AMIGO                   | RESPONSÁVEL             |  ENDEREÇO               | TELEFONE |");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            if (listaAmigos.Count == 0)
            {
                ApresentarMensagem("Que pena, você não tem nenhum amigo ainda.", ConsoleColor.Red);
                return;
            }

            foreach (Amigo amigo in listaAmigos)
            {
                Console.WriteLine("| {0,-3}| {1,-24}| {2,-24}| {3,-24}| {4,-9}|", amigo.Id, amigo.nome, amigo.responsavel, amigo.endereco, amigo.telefone);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public void Deletar()
        {
            Listar();
            int idSelecionado = ReceberIdAmigo();
            amigoRepositorio.Deletar(idSelecionado);
            ApresentarMensagem("Amigo excluído com sucesso!", ConsoleColor.Green);
        }

        public int ReceberIdAmigo()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do amigo: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = amigoRepositorio.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Amigo ObterAmigo()
        {
            Console.WriteLine("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.WriteLine("Digite o número do telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o endereço do amigo: ");
            string endereço = Console.ReadLine();


            Amigo amigo = new Amigo(amigoRepositorio.ContadorId, nome, nomeResponsavel, telefone, endereço);

            return amigo;
        }
    }
}
