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
        private char _caracter;

        /*
        private Jogador jogador_1;
        private Jogador jogador_2;  
        */

        private Random posicao = new Random();
        private Random random_linha = new Random();
        private Random random_coluna = new Random();

        private int inicio_linha = 0;
        private int inicio_coluna = 0;
        private int horizontal_vertical = 0;

        public Tabuleiro()
        {
            tabuleiro = new char[Dimensoes.LINHA, Dimensoes.COLUNA];
        }

        public void setCaracter(char _caracter)
        {
            this._caracter = _caracter;
        }
        /*
        public void ConectarJogador1(Jogador jogador)
        {
            this.jogador_1 = jogador;
        }
        public void ConectarJogador2(Jogador jogador)
        {
            this.jogador_2 = jogador;
        }
        */
        public void Exibicao()
        {
            Console.WriteLine("     A  ||  B  ||  C  ||  D  ||  E  ||  F  ||  G  ||  H  ||  I  ||  J  ||  K  ||  L  " +
                "||  M  ||  N  ||  O  ||  P  ||  Q  ||  R  ||  S  ||  T  |");
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                if (i <= 8)
                {
                    Console.WriteLine();
                    Console.Write($" {i + 1}-");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write($"{i + 1}-");
                }
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    Console.Write($"|  {tabuleiro[i, j]}  |");
                }
            }
        }

        public void Inicializacao()
        {
            for (int linha = 0; linha < Dimensoes.LINHA; linha++)
            {
                for (int coluna = 0; coluna < Dimensoes.COLUNA; coluna++)
                {
                    tabuleiro[linha, coluna] = '~';
                }
            }
        }
        /*
        public int VerificaAtaque(int linha, int coluna, Jogador atual, Jogador oponente)
        {
            int situacao = 0;

            if (tabuleiro[linha,coluna] == oponente.GetCaracter())
            {
                situacao = 1;
                tabuleiro[linha, coluna] = 'X';
            }
            else
            {
                if (tabuleiro[linha,coluna] == atual.GetCaracter())
                {
                    situacao = 2;
                    tabuleiro[linha, coluna] = 'X';
                }
                else
                {
                    situacao = 3;
                    tabuleiro[linha, coluna] = '#';
                }

            }


            return situacao;
        }
        */
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
