using BatalhaNaval1;

internal class Program
{
    private static void Main(string[] args)
    {

        Tabuleiro tabuleiro = new Tabuleiro();
        tabuleiro.Inicializacao();
        //tabuleiro.Exibicao();
        
        Submarino submario = new Submarino();
        Console.WriteLine(submario.ToString());
        /*
        int tamanho = 2;
        tabuleiro.setCaracter('A');

        for(int i = 0; i < 3; i++)
        {
            tabuleiro.PlotarPecasNoTabuleiro(tamanho);
            tamanho++;
        }

        tabuleiro.setCaracter('S');
        tamanho = 2;

        for(int i = 0; i < 3; i++)
        {
           tabuleiro.PlotarPecasNoTabuleiro(tamanho);
            tamanho++;
        }

        tabuleiro.Exibicao();*/

    }
}