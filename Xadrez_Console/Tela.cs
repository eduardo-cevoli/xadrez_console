using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    class Tela
    {

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            if (partida.Xeque() == true)
            {
                ImprimirTabuleiro(partida.Tabuleiro, partida.Xeque(), partida.XequePosRei , partida.XequeAtacante);
                Console.WriteLine();
                ImprimirPecasCapturadas(partida);
                Console.WriteLine();
                Console.WriteLine("Turno: " + partida.Turno);
                Console.WriteLine("Xeque no jogador: " + partida.JogadorAtual);
            }
            else
            {
                ImprimirTabuleiro(partida.Tabuleiro);
                Console.WriteLine();
                ImprimirPecasCapturadas(partida);
                Console.WriteLine();
                Console.WriteLine("Turno: " + partida.Turno);
                Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
            }
        }
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Pecas capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.WriteLine();
            Console.ForegroundColor = aux;
        }
        public static void ImprimirConjunto(HashSet<Peca> conjuto)
        {
            Console.Write("[");
            foreach (Peca x in conjuto)
            {
                Console.Write(x + "");
            }
            Console.Write("]");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                //Imprimir numeros das linhas
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.Colunas; j++)
                {
                    Tela.ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }

            //Impressao letras  das Colunas
            Console.Write("  ");
            char ch = 'a';
            for (int i = 0; i < tab.Colunas; i++)
            {
                Console.Write((char)(ch + i) + " ");
            }
            Console.WriteLine();
        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                //Imprimir numeros das linhas
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Tela.ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }

            //Impressao letras  das Colunas
            Console.Write("  ");
            char ch = 'a';
            for (int i = 0; i < tab.Colunas; i++)
            {
                Console.Write((char)(ch + i) + " ");
            }
            Console.WriteLine();
        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool xeque, Posicao posicaoReiemXeque, Peca pecaatacante)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                //Imprimir numeros das linhas
                Console.Write(8 - i + " ");
                
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.Peca(i, j) == tab.Peca(posicaoReiemXeque))
                    {
                        Tela.ImprimirPeca(tab.Peca(posicaoReiemXeque), ConsoleColor.Red);
                    }
                    else if (tab.Peca(i, j) == pecaatacante)
                    {
                        Tela.ImprimirPeca(pecaatacante, ConsoleColor.Blue);
                    }
                    else
                    {
                        Tela.ImprimirPeca(tab.Peca(i, j));
                    }
                    
                }
                Console.WriteLine();
            }

            //Impressao letras  das Colunas
            Console.Write("  ");
            char ch = 'a';
            for (int i = 0; i < tab.Colunas; i++)
            {
                Console.Write((char)(ch + i) + " ");
            }
            Console.WriteLine();
        }
        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor bkp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = bkp;
                }
                Console.Write(" ");
            }
        }
        public static void ImprimirPeca(Peca peca, ConsoleColor corFundoPeca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    ConsoleColor bkpFundo = Console.BackgroundColor;
                    Console.BackgroundColor = corFundoPeca;
                    Console.Write(peca);
                    Console.BackgroundColor = bkpFundo;
                }
                else
                {
                    ConsoleColor bkp = Console.ForegroundColor;
                    ConsoleColor bkpFundo = Console.BackgroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = corFundoPeca;
                    Console.Write(peca);
                    Console.ForegroundColor = bkp;
                    Console.BackgroundColor = bkpFundo;
                }
                Console.Write(" ");
            }
        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine().ToLower();
            char coluna = s[0];
            //Forçando a ser uma string
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
