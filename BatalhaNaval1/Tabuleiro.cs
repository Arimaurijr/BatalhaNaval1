using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval1
{
    internal class Tabuleiro
    {
        private char[,] tabuleiro;
        private char[,] tabuleiroUser;
        private char _caracter;
        //private char[,] matriz_exibicao[]

        private PortaAviao[] portaAviao = new PortaAviao[2];
        private Submarino[] submarino = new Submarino[2];
        private Destroyer[] destroyer = new Destroyer[2];


        private Random posicao = new Random();
        private Random random_linha = new Random();
        private Random random_coluna = new Random();

        private int inicio_linha = 0;
        private int inicio_coluna = 0;
        private int horizontal_vertical = 0;

        public Tabuleiro()
        {
            tabuleiro = new char[Dimensoes.LINHA, Dimensoes.COLUNA];
            tabuleiroUser = new char[Dimensoes.LINHA, Dimensoes.COLUNA];
        }

        public void setCaracter(char _caracter)
        {
            this._caracter = _caracter;
        }
        public void RecebePortaAviao(PortaAviao portaAviao, int tipo_de_jogador)
        {
            if (tipo_de_jogador == 1)
            {
                this.portaAviao[0] = portaAviao;
            }
            else
            {
                this.portaAviao[1] = portaAviao;
            }
        }
        public void RecebeSubmarino(Submarino submarino, int tipo_de_jogador)
        {
            if (tipo_de_jogador == 1)
            {
                this.submarino[0] = submarino;
            }
            else
            {
                this.submarino[1] = submarino;
            }
        }
        public void RecebeDestroyer(Destroyer destroyer, int tipo_de_jogador)
        {
            if (tipo_de_jogador == 1)
            {
                this.destroyer[0] = destroyer;
            }
            else
            {
                this.destroyer[1] = destroyer;
            }
        }

        public int MarcarNoTabuleiro(int linha, int coluna)
        {
            int verificacao = 0;

            switch (tabuleiro[linha, coluna])
            {
                case 'D':
                    tabuleiro[linha, coluna] = 'X';
                    destroyer[0].DecrementarVida();
                    verificacao = 1;
                    break;

                case 'd':
                    tabuleiro[linha, coluna] = 'x';
                    destroyer[1].DecrementarVida();
                    verificacao = 2;
                    break;

                case 'P':
                    tabuleiro[linha, coluna] = 'X';
                    portaAviao[0].DecrementarVida();
                    verificacao = 1;
                    break;

                case 'p':
                    tabuleiro[linha, coluna] = 'x';
                    portaAviao[1].DecrementarVida();
                    verificacao = 2;
                    break;

                case 'S':
                    tabuleiro[linha, coluna] = 'X';
                    submarino[0].DecrementarVida();
                    verificacao = 1;
                    break;

                case 's':
                    tabuleiro[linha, coluna] = 'x';
                    submarino[1].DecrementarVida();
                    verificacao = 2;
                    break;
                case '#':
                    verificacao = 3;
                    break;
                case 'X':
                    verificacao = 3;
                    break;
                case 'x':
                    verificacao = 3;
                    break;

                default:
                    tabuleiro[linha, coluna] = '#';
                    break;
            }
            tabuleiroUser[linha, coluna] = tabuleiro[linha, coluna];
            return verificacao;
        }
        public void ExibirTeste()
        {
            //Para exibir matriz original descomentar esse codigo
            Console.WriteLine("      A  ||  B  ||  C  ||  D  ||  E  ||  F  ||  G  ||  H  ||  I  ||  J  ||  K  ||  L  " +
   "||  M  ||  N  ||  O  ||  P  ||  Q  ||  R  ||  S  ||  T  |");

            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                // Para exibir matriz original descomentar esse codigo
                 if (i <= 9)
                {
                    Console.WriteLine();
                    Console.Write($" {i}-");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write($"{i}-");
                }
               
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    // Para exibir matriz original descomentar esse codigo
                    Console.Write($"|  {tabuleiro[i, j]}  |");
                    tabuleiroUser[i, j] = tabuleiro[i, j];
                }
            }
        }
        public void Exibicao()
        {
            
            Console.WriteLine("      A  ||  B  ||  C  ||  D  ||  E  ||  F  ||  G  ||  H  ||  I  ||  J  ||  K  ||  L  " +
                "||  M  ||  N  ||  O  ||  P  ||  Q  ||  R  ||  S  ||  T  |");
            for (int i = 0; i < tabuleiroUser.GetLength(0); i++)
            {
                if (i <= 9)
                {
                    Console.WriteLine();
                    Console.Write($" {i}-");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write($"{i}-");
                }

                for (int j = 0; j < tabuleiroUser.GetLength(1); j++)
                {
                    if (tabuleiroUser[i, j] == 'd' || tabuleiroUser[i, j] == 'D' ||
                        tabuleiroUser[i, j] == 'p' || tabuleiroUser[i, j] == 'P' ||
                        tabuleiroUser[i, j] == 's' || tabuleiroUser[i, j] == 'S')
                    {
                        tabuleiroUser[i, j] = '.';
                    }
                    Console.Write($"|  {tabuleiroUser[i, j]}  |");
                }
            } 
        }

        public void Inicializacao()
        {
            for (int linha = 0; linha < Dimensoes.LINHA; linha++)
            {
                for (int coluna = 0; coluna < Dimensoes.COLUNA; coluna++)
                {
                    tabuleiroUser[linha, coluna] = '.';
                    tabuleiro[linha, coluna] = '.';
                }
            }
        }

        public void PlotarPecasNoTabuleiro(int tamanho)
        {
            bool plotar = false;

            while (plotar == false)
            {
                GerarCoordenadasAleatorias();

                if (horizontal_vertical == 0) // horizontal
                {
                    if ((VerificarExeceColuna(inicio_coluna, tamanho))
                        && (ConflitoNavioHorizontal(inicio_linha, inicio_coluna, tamanho)))
                    {
                        InserirNavioHorizontal(inicio_linha, inicio_coluna, tamanho);
                        plotar = true;
                    }
                }
                else
                {
                    if ((VerificarExeceLinha(inicio_linha, tamanho))
                        && (ConflitoNavioVertical(inicio_linha, inicio_coluna, tamanho)))
                    {
                        InserirNavioVertical(inicio_linha, inicio_coluna, tamanho);
                        plotar = true;
                    }
                }
            }
        }

        private void GerarCoordenadasAleatorias()
        {
            horizontal_vertical = posicao.Next(2);
            inicio_linha = random_linha.Next(Dimensoes.LINHA);
            inicio_coluna = random_coluna.Next(Dimensoes.COLUNA);
        }
        private bool ConflitoNavioVertical(int linha, int coluna, int tamanho)
        {
            bool verifica = true;
            int cont = 0;
            int l = linha;

            while ((verifica == true) && (cont < tamanho))
            {
                if (tabuleiro[l, coluna] != '.')
                {
                    verifica = false;
                }

                l++;
                cont++;
            }

            return verifica;
        }
        private bool ConflitoNavioHorizontal(int linha, int coluna, int tamanho)
        {
            bool verifica = true;
            int cont = 0;
            int c = coluna;

            while ((verifica == true) && (cont < tamanho))
            {
                if (tabuleiro[linha, c] != '.')
                {
                    verifica = false;
                }

                c++;
                cont++;
            }


            return verifica;
        }

        private void InserirNavioHorizontal(int linha, int coluna, int tamanho)
        {// incrementar as colunas

            for (int c = coluna, i = 0; i < tamanho; c++, i++)
            {
                tabuleiro[linha, c] = _caracter;
            }

        }

        private void InserirNavioVertical(int linha, int coluna, int tamanho)
        {//incrementar as linhas

            for (int l = linha, i = 0; i < tamanho; l++, i++)
            {
                tabuleiro[l, coluna] = _caracter;
            }
        }

        private bool VerificarExeceLinha(int linha, int tamanho)
        {
            bool verifica = false;

            if ((linha + tamanho - 1) < Dimensoes.LINHA)
            {
                verifica = true;
            }

            return verifica;
        }

        private bool VerificarExeceColuna(int coluna, int tamanho)
        {
            bool verifica = false;

            if ((coluna + tamanho - 1) < Dimensoes.COLUNA)
            {
                verifica = true;
            }

            return verifica;
        }

    }
}
