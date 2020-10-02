using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.Coluna = coluna;
            this.Linha = linha;
        }
        public Posicao ToPosicao()
        {
            //Cada charactere em c# possui um valor correspondente, EX: a = 97, b = 98. Dessa forma se Coluna == 'a', entao, 'a' - 'a' é a mesma coisa que 97 -97.
            return new Posicao(8 - Linha, Coluna - 'a');
        }
        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
