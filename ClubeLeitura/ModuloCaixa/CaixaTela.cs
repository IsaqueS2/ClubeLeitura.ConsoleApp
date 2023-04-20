using ClubeLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ModuloCaixa
{
    public class CaixaTela :Tela
    {
        public CaixaRepositorio caixaRepositorio = null;

        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Criar Caixa");
                Console.WriteLine("2 - Editar Caixa");
                Console.WriteLine("3 - Deletar Caixa");
                Console.WriteLine("4 - Listar Caixas");
                Console.WriteLine("S - Voltar ao Menu Principal");

                string opcao = Console.ReadLine().ToUpper();

                return opcao;
            }
        }
        
        public void SelecionarOpcaoCaixa(string opcao)
        {
            switch (opcao)
            {
                case "1": InserirNovaCaixa(); break;
                case "2": EditarCaixa(); break;
                case "3": DeletarCaixa(); break;
                case "4": ListarCaixa(); break;
                case "S": MenuApresentacao.VoltarAoMenu(); break;
            }
        }

        public void InserirNovaCaixa()
        {
            ListarCaixa();
            Caixa novaCaixa = ObterCaixa();

            caixaRepositorio.Criar(novaCaixa);

            ApresentarMensagem("Sucesso!", ConsoleColor.Green);
        }
        
        public void EditarCaixa()
        {
            ListarCaixa();
            int idSelecionado = ReceberIdCaixa();
            Caixa caixaAtualizada = ObterCaixa();


            caixaRepositorio.Editar(idSelecionado, caixaAtualizada);

            ApresentarMensagem("Sucesso!", ConsoleColor.Green);
        }
        
        public void ListarCaixa()
        {
            ArrayList listaDeCaixa = caixaRepositorio.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("----------------------------------");
            Console.WriteLine("| ID |  ETIQUETA  | COR           |");
            Console.WriteLine("----------------------------------");

            if (listaDeCaixa.Count == 0)
            {
                ApresentarMensagem("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Caixa caixa in listaDeCaixa)
            {
                Console.WriteLine("| {0,-3}| {1,-11}| {2,-14}|", caixa.Id, caixa.Etiqueta, caixa.Cor);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public void DeletarCaixa()
        {
            ListarCaixa();
            int numeroSelecionado = ReceberIdCaixa();
            caixaRepositorio.Deletar(numeroSelecionado);
            ApresentarMensagem("Sucesso!", ConsoleColor.Green);
        }
        
        public int ReceberIdCaixa()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id da caixa: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = caixaRepositorio.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    ApresentarMensagem("Id Inválido, tente novamente", ConsoleColor.Red);
                }
            } while (idInvalido);

            return id;
        }

        public Caixa ObterCaixa()
        {
            Console.WriteLine("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.WriteLine("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Caixa caixa = new Caixa(caixaRepositorio.ContadorId, cor, etiqueta);

            return caixa;
        }
    }
}
