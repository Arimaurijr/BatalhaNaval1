using System;
using System.Reflection.PortableExecutable;
using BatalhaNaval1;

//// INSTANCIAR TABULEIRO
Tabuleiro tabuleiro = new Tabuleiro();
tabuleiro.Inicializacao();

//// INSTANCIAR JOGADOR
Jogador jogador1 = new Jogador();
Jogador jogador2 = new Jogador();

//PASSANDO TABULEIRO PARA JOGADORES
jogador1.RecebeTabuleiro(tabuleiro);
jogador2.RecebeTabuleiro(tabuleiro);

//PASSANDO JOGADOR 1 PARA SUBMARINO 1 E SUBMARINO 1 PARA TABULEIRO
Submarino submarino1 = new Submarino(1);
submarino1.ReceberJogador(jogador1);
tabuleiro.RecebeSubmarino(submarino1, 1);

//PASSANDO JOGADOR 1 PARA SUBMARINO 1 E SUBMARINO 1 PARA TABULEIRO
Submarino submarino2 = new Submarino(2);
submarino2.ReceberJogador(jogador2);
tabuleiro.RecebeSubmarino(submarino2, 2);

// PASSANDO JOGADOR 1 PARA DESTROYER 1 E DESTROYER 1 PARA TABULEIRO
Destroyer destroyer1 = new Destroyer(1);
destroyer1.ReceberJogador(jogador1);
tabuleiro.RecebeDestroyer(destroyer1, 1);

//PASSANDO JOGADOR 1 PARA DESTROYER 1 E DESTROYER 1 PARA TABULEIRO
Destroyer destroyer2 = new Destroyer(2);
destroyer2.ReceberJogador(jogador2);
tabuleiro.RecebeDestroyer(destroyer2, 2);

// PORTA AVIÃO RECEBE JOGADOR 1 E TABULEIRO RECEBE PORTA-AVIÃO 1
PortaAviao portaAviao1 = new PortaAviao(1);
portaAviao1.ReceberJogador(jogador1);
tabuleiro.RecebePortaAviao(portaAviao1, 1);

// PORTA AVIÃO RECEBE JOGADOR 2 E TABULEIRO RECEBE PORTA-AVIÃO 2
PortaAviao portaAviao2 = new PortaAviao(2);
portaAviao2.ReceberJogador(jogador2);
tabuleiro.RecebePortaAviao(portaAviao2, 2);

// plotagem das peças 
tabuleiro.setCaracter(submarino1.Caracter);
tabuleiro.PlotarPecasNoTabuleiro(submarino1.Tamanho);

tabuleiro.setCaracter(submarino2.Caracter);
tabuleiro.PlotarPecasNoTabuleiro(submarino2.Tamanho);

tabuleiro.setCaracter(destroyer1.Caracter);
tabuleiro.PlotarPecasNoTabuleiro(destroyer1.Tamanho);

tabuleiro.setCaracter(destroyer2.Caracter);
tabuleiro.PlotarPecasNoTabuleiro(destroyer2.Tamanho);

tabuleiro.setCaracter(portaAviao1.Caracter);
tabuleiro.PlotarPecasNoTabuleiro(portaAviao1.Tamanho);

tabuleiro.setCaracter(portaAviao2.Caracter);
tabuleiro.PlotarPecasNoTabuleiro(portaAviao2.Tamanho);

Console.Write("Digite o nome do jogador 1: ");
jogador1.Nome = Console.ReadLine();

Console.Write("Digite o nome do jogador 2: ");
jogador2.Nome = Console.ReadLine();


//tabuleiro.Exibicao();
tabuleiro.ExibirTabuleiroA();
tabuleiro.ExibirTabuleiroB();

int cont = 0;

while (jogador1.Vida > 0 && jogador2.Vida > 0) //verifica quem ganhou
{
    cont++;
    int ataque;
    int linha = 0, coluna = 0;
    string coord = null;
    bool entrada = false;
    Console.WriteLine($"\nVida de {jogador1.Nome}: " + jogador1.Vida);
    Console.WriteLine($"Vida de {jogador2.Nome}: " + jogador2.Vida);

    if (cont % 2 != 0)
    {
        do
        {

            if (entrada == true)
            {
                tabuleiro.Exibicao();
                Console.WriteLine();
                Console.WriteLine("CONTINUE JOGADOR A");
            }

            do
            {
                //Console.Clear();
                tabuleiro.Exibicao();
                Console.WriteLine();
                Console.Write($"JOGADOR {jogador1.Nome} - ");
                Console.Write("DIGITE A LINHA: ");

                linha = jogador1.CheckLine();

            } while (linha < 0 || linha >= Dimensoes.LINHA);

            do
            {
                Console.Write("DIGITE A COLUNA: ");
                coluna = jogador1.CheckColumn(coord = Console.ReadLine());

            } while (coluna < 0 || coluna >= Dimensoes.COLUNA);


            ataque = jogador1.Atacar(linha, coluna);

            if (ataque == 1 || ataque == 0)
            {
                if (ataque == 1)
                {
                    Console.WriteLine("VOCÊ ATIROU NA PRÓPRIA EMBARCAÇÃO !!!");
                }

                entrada = false;
            }
            if (ataque == 2)
            {
                Console.WriteLine();
                Console.Write("PARABÉNS !!! VOCÊ ACERTOU SEU OPONENTE !!! Press enter continue...");
                Console.ReadKey();
                linha = 0;
                entrada = true;
            }
            if (ataque == 3)
            {
                Console.WriteLine($"Essa posição já foi preenchida jogador {jogador1.Nome}.");
                Console.ReadKey();
                entrada = true;
            }

        } while (entrada == true && jogador2.Vida > 0);
        //Console.Clear();
        tabuleiro.Exibicao();

    }
    else
    {
        do
        {
            if (entrada == true)
            {
                Console.WriteLine();
                Console.WriteLine($"CONTINUE JOGADOR {jogador2.Nome}");
            }
            do
            {
                Console.Write($"JOGADOR {jogador2.Nome}");
                Console.Write(" DIGITE A LINHA: ");

                linha = jogador2.CheckLine();

            } while (linha < 0 || linha >= Dimensoes.LINHA);

            do
            {
                Console.Write("DIGITE A COLUNA: ");
                coluna = jogador2.CheckColumn(coord = Console.ReadLine());

            } while (coluna < 0 || coluna >= Dimensoes.COLUNA);

            ataque = jogador2.Atacar(linha, coluna);

            if (ataque == 2 || ataque == 0)
            {
                if (ataque == 2)
                {
                    Console.WriteLine("VOCÊ ATIROU CONTRA A PRÓPRIA EMBARCAÇÃO !!!");
                    Console.ReadKey();
                    //Console.Clear();
                }

                entrada = false;
            }
            if (ataque == 1)
            {
                //Console.Clear();
                Console.WriteLine("PARABÉNS !!! VOCÊ ACERTOU SEU OPONENTE !!!");
                entrada = true;

            }
            if (ataque == 3)
            {
                Console.WriteLine($"Essa posição já foi preenchida jogador {jogador2.Nome}.");
                Console.ReadKey();
                entrada = true;
            }


            tabuleiro.Exibicao();

        } while (entrada == true && jogador1.Vida > 0);

    }
}

if (jogador1.Vida == 0)
{
    Console.WriteLine("\nParabéns " + jogador2.Nome + ", VOCÊ GANHOU !!!");
}
else
{
    Console.WriteLine("\nParabéns " + jogador1.Nome + ", VOCÊ GANHOU !!!");
}
