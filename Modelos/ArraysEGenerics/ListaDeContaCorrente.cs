using System;
using System.Runtime.CompilerServices;
using Modelos.OO.Classe;

namespace Modelos.ArraysEGenerics
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
        
        /**
         * 
         * 
         */
        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach(ContaCorrente conta in itens)
            {
                Adicionar(conta);
            }
        }
        

        public int getIndex(ContaCorrente item)
        {
            for (int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public ContaCorrente GetItemNoIndice(int index)
        {
            if (index < 0 || index >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return  _itens[index];
        }
        
        /**
         * Os Indexadores permitem que as instâncias de uma classe ou estrutura sejam indexadas apenas como vetores.         
         * Não existe este tipo de construção na linguagem Java.
         *
         * Sixtax de exemplo usando int:
         *
         * public int this[int index] // declaração
         * {
         *   acessores get e set
         * }
         *
         * Artigo: http://www.macoratti.net/16/08/c_index1.htm
         *
         * -----------------------------------------------------------------------------------------------------------------------
         * params int[] indices // Aqui estamos fazendo uso de params que são um sixtar sugar da linguagem C# e desempenham
         * o mesmo papel do varargs em Java
         *
         * params servem para passarmos uma quantidade infinitas de objetos de um mesmo tipo e o método recebera esses objetos em forma de um array
         */
        public ContaCorrente[] this[params int[] indices]
        {
            get
            {
                ContaCorrente[] resultado = new ContaCorrente[indices.Length];
                for (int i = 0; i < indices.Length; i++)
                {
                    int indiceDaLista = indices[i];
                    resultado[i] = GetItemNoIndice(indiceDaLista);
                }
                return resultado;
            }
        }
        
        

        public void Remover(ContaCorrente item)
        {
            int index = getIndex(item);
            if (index < 0)
            {
                return;
            }

            for (int i = index; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void EscreverNaTela()
        {
            foreach (var conta in _itens)
            {
                Console.WriteLine($"Conta numero {conta.Agencia} {conta.Numero}");
            }
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