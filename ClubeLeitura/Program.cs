using ClubeLeitura.ModuloAmigo;
using ClubeLeitura.ModuloCaixa;
using ClubeLeitura.ModuloEmprestimo;
using ClubeLeitura.ModuloRevista;

namespace ClubeLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmprestimoRepositorio emprestimoRepositorio = new EmprestimoRepositorio();
            RevistaRepositorio revistaRepositorio = new RevistaRepositorio();
            CaixaRepositorio caixaRepositorio = new CaixaRepositorio();
            AmigoRepositorio amigoRepositorio = new AmigoRepositorio();

            EmprestimoTela emprestimoTela = new EmprestimoTela();
            emprestimoTela.emprestimoRepositorio = emprestimoRepositorio;
            emprestimoTela.amigoRepositorio = amigoRepositorio;
            emprestimoTela.revistaRepositorio = revistaRepositorio;

            AmigoTela amigoTela = new AmigoTela();
            amigoTela.amigoRepositorio = amigoRepositorio;

            CaixaTela caixaTela = new CaixaTela();
            caixaTela.caixaRepositorio = caixaRepositorio;

            RevistaTela revistaTela = new RevistaTela();
            revistaTela.revistaRepositorio = revistaRepositorio;
            revistaTela.caixaRepositorio = caixaRepositorio;

            MenuApresentacao menu = new MenuApresentacao();
            menu.caixaRepositorio = caixaRepositorio;
            menu.amigoRepositorio = amigoRepositorio;
            menu.amigoTela = amigoTela;
            menu.emprestimoTela = emprestimoTela;
            menu.caixaTela = caixaTela;
            menu.revistaTela = revistaTela;


            Caixa caixa0 = new Caixa(0, "Branco", "Ficção");
            caixaRepositorio.Cadastros.Add(caixa0);

            Amigo amigo0 = new Amigo(0, "Robertinho Gameplays", "Robertao", "B amarelo, R verde, 2", "49 999886969");
            amigoRepositorio.Cadastros.Add(amigo0);

            Revista revista0 = new Revista(0, "Naruto", "435", "2005", caixa0);
            revistaRepositorio.Cadastros.Add(revista0);

            emprestimoRepositorio.Cadastros.Add(new Emprestimo(0, amigo0, revista0, "01/08", "15/08", "OK"));

            menu.ExecutarMenuPrincipal();
        }
    }
}
