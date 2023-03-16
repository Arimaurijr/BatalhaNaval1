using BatalhaNaval1;

internal class Program
{
    private static void Main(string[] args)
    {
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

        tabuleiro.Exibicao();


        int cont = 0;

        while(jogador1.Vida > 0 && jogador2.Vida > 0) //verifica quem ganhou
        {
            cont++;
            int ataque;
            int linha = 0, coluna = 0;
            bool entrada = false;

            if(cont % 2 != 0)
            {
                do
                {
                    if(entrada == true)
                    {
                        Console.WriteLine("CONTINUE JOGADOR A");
                    }

                    do
                    {
                        Console.WriteLine("JOGADOR A");
                        Console.WriteLine("DIGITE A LINHA: ");
                        linha = int.Parse(Console.ReadLine());

                    }while(linha < 0 || linha >= Dimensoes.LINHA);

                    do
                    {
                        Console.WriteLine("DIGITE A COLUNA: ");
                        coluna = int.Parse(Console.ReadLine());

                    }while(coluna < 0 || coluna >= Dimensoes.COLUNA);

                    ataque = jogador1.Atacar(linha, coluna);

                    if (ataque == 1 || ataque == 0)
                    {
                        if (ataque == 1)
                        {
                            Console.WriteLine("VOCÊ ATIROU COMPRAR A PRÓPRIA EMBARCAÇÃO !!!");
                        }

                        entrada = false;
                    }
                    if (ataque == 2)
                    {
                        Console.WriteLine("PARABÉNS !!! VOCÊ ACERTOU SEU OPONENTE !!!");
                        entrada = true;
                    }

                } while (entrada == true);
                Console.Clear();
                tabuleiro.Exibicao();
            }
            else
            {
                do
                {
                    if(entrada == true)
                    {
                       Console.WriteLine("CONTINUE JOGADOR B");
                    }
                    do
                    {
                        Console.WriteLine("JOGADOR B");
                        Console.WriteLine("DIGITE A LINHA: ");
                        linha = int.Parse(Console.ReadLine());

                    }while(linha < 0 || linha >= Dimensoes.LINHA);

                    do
                    {
                        Console.WriteLine("DIGITE A COLUNA: ");
                        coluna = int.Parse(Console.ReadLine());

                    }while(coluna < 0 || coluna >= Dimensoes.COLUNA);

                    ataque = jogador2.Atacar(linha, coluna);

                    if (ataque == 2 || ataque == 0)
                    {
                        if(ataque == 2)
                        {
                            Console.WriteLine("VOCÊ ATIROU COMPRAR A PRÓPRIA EMBARCAÇÃO !!!");
                        }

                        entrada = false;
                    }
                    if (ataque == 1)
                    {
                        Console.WriteLine("PARABÉNS !!! VOCÊ ACERTOU SEU OPONENTE !!!");
                        entrada = true;

                    }

                    Console.Clear();
                    tabuleiro.Exibicao();

                }while (entrada == true);

            }
        }

        if(jogador1.Vida == 0)
        {
            Console.WriteLine("Parabéns " + jogador2.Nome + ", VOCÊ GANHOU !!!");
        }
        else
        {
            Console.WriteLine("Parabéns " + jogador1.Nome + ", VOCÊ GANHOU !!!");
        }


    }
}