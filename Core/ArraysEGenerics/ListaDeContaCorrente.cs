using System;
using System.Runtime.CompilerServices;
using Core.OO.Classe;

namespace Core.ArraysEGenerics
{
    public class ListaDeContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;

        // public ListaDeContaCorrente()
        // {
        //     _itens = new ContaCorrente[5];
        //     _proximaPosicao = 0;
        // }
        //
        
        /**
         * Abaixo temos um parâmetro opcional chamado capacidadeInicial
         * na chamada desse construtor, podendo passar ou não esse parâmetro
         * Exemplo:
         *    new ListaDeContaCorrente();
         *
         *  ou usar atributos nomeados (principalmente quando tivermos mais de um atributo opcional no método):
         *
         *  new ListaDeContaCorrente(capacidadeInicial: 5);
         *
         * em ambos os casos, o atributo capacidadeInicial será = 5
         * 
         * 
         */
        public ListaDeContaCorrente(int capacidadeInicial = 5)
        {
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine($"Adicionando no índice {_proximaPosicao} conta {item.Agencia}/{item.Numero}");
            VerificaCapacidade(_proximaPosicao+1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        private void VerificaCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            
            int novoTamanho = _itens.Length * 2;
            Console.WriteLine("Aumentando capacidade da lista!");
            
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }
           
            _itens = copiar(novoTamanho);
        }


        private ContaCorrente[] copiar(int novoTamanho)
        {
            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];
            for(int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
            }
            return novoArray;
        }

    }
}