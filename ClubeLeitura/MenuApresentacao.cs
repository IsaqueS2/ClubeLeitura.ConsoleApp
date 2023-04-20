using ClubeLeitura.ModuloAmigo;
using ClubeLeitura.ModuloCaixa;
using ClubeLeitura.ModuloEmprestimo;
using ClubeLeitura.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura
{
    public class MenuApresentacao
    {
        public CaixaRepositorio caixaRepositorio = null;
        public AmigoRepositorio amigoRepositorio = null;
        public AmigoTela amigoTela = null;
        public EmprestimoTela emprestimoTela = null;
        public CaixaTela caixaTela = null;
        public RevistaTela revistaTela = null;

        public void ExecutarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" 1 - Gerenciar Emprestimo    ");
                Console.WriteLine(" 2 - Gerenciar Amigos        ");
                Console.WriteLine(" 3 - Gerenciar Caixas        ");
                Console.WriteLine(" 4 - Gerenciar Revistas      ");
                Console.WriteLine(" S - Sair                    ");

                string opcao = Console.ReadLine().ToUpper();

                switch (opcao)
                {
                    case "1": MenuEmprestimo(); break;
                    case "2": MenuAmigos(); break;
                    case "3": MenuCaixas(); break;
                    case "4": MenuRevistas(); break;
                    case "S": Finalizar(); return;
                }
            }
        }

        public void MenuEmprestimo()
        {
            while (true)
            {
                string opcao = emprestimoTela.ApresentarMenu();
                emprestimoTela.SelecionarOpcaoEmprestimo(opcao);
                break;
            }
        }

        public void MenuAmigos()
        {
            while (true)
            {
                string opcao = amigoTela.ApresentarMenu();
                amigoTela.SelecionarOpcao(opcao);
                break;
            }
        }

        public void MenuCaixas()
        {
            while (true)
            {
                string opcao = caixaTela.ApresentarMenu();
                caixaTela.SelecionarOpcaoCaixa(opcao);
                break;
            }
        }

        public void MenuRevistas()
        {
            while (true)
            {
                string opcao = revistaTela.ApresentarMenu();
                revistaTela.SelecionarOpcaoRevista(opcao);
                break;
            }
        }

        public static void VoltarAoMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nVoltando!");
            Console.ResetColor();
        }

        private static void Finalizar()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nEncerrando!");
            Console.ResetColor();
            return;
        }
    }
}
