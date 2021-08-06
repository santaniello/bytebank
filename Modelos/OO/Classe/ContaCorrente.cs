using System;
using System.Collections.Generic;
using Modelos.OO.Exception;


namespace Modelos.OO.Classe
{
    public class ContaCorrente
    {
        /**
         *  Atributo privado com getters e setters criados na mão (Essa maneira não é padrão da linguagem C#) 
         */
        private string titular;
        
        public string GetTitular()
        {
            return titular;
        }

        public void SetTitular(string titular)
        {
            this.titular = titular;
        }
        
        /**
         * Aqui utilizamos o recurso de Propriedades para dar acesso aos nossos atributos da classe.
         * Repare que nesse caso, temos uma regra de validação no setter e por conta disso nós criamos a variavel _saldo (o _ é um padrão para propriedades no C#).
         * a palavra reservada value representa o valor que o setter recebe como parâmetro
         * 
         */
        
        private double _saldo;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if(value < 0)
                   return;

                _saldo = value;
            }
        }
        
        /**
         * Abaixo nós criamos as propriedades Agencia e Numero com letra maiuscula que é um padrão da linguagem. Repare que como não houve customização dos gettes e setters
         * não foi necessário criar as varáveis _agencia e _numero pois as mesmas serão criadas em tempo de compilação 
         *  
         * public int Agencia { get; set; } 
         */

        public int  Agencia { get;  }
        public int Numero { get;  }


        /**
         * Abaixo criamos um membro estático (Constante) usando o mecanismo de propriedades do C#.
         * Repare que no caso do método set, deixamos ele privado (apenas a titulo de demnostração pois poderiamos deixar apenas o get).
         * Repare que inicializamos a propriedade com o valor 1.
         */
        public static int TotalDeContasCriadas { get; private set; } = 1;

        public int ContadorSaquesNaoPermitidos { get; private set; }

        public int ContadorTransferenciasNaoPermitidas { get; private set; }
        
        

        /**
         * Exemplo de construtor sem parâmetros          
         */
        public ContaCorrente(){}
        
        /**
         * Exemplo de construtor paramétrico          
         */
        public ContaCorrente(int agencia, int numero)
        {
            /*
             * nameof converte o nome de um atributo em string forcando o usuário caso troque o nome do parametro a alterar
             * também na exceção.
             * 
             */
            if(agencia <= 0)
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            
            if(numero <= 0)
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
        }

        /**
         * Exemplo de construtor paramétrico          
         */
        public ContaCorrente(string titular, int agencia, int numero)
        {
            this.titular = titular;
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
        }

        public override bool Equals(object? obj)
        {
            /*
             * a palavra reservada as verifica se o Objeto recebido é do tipo ContaCorrente
             * caso seja ele faz o cast e caso contrário ele seta null.
             */
            var contaCorrente = obj as ContaCorrente;

            if (contaCorrente == null)
              return false;

            return (contaCorrente.Agencia == Agencia && contaCorrente.Numero == Numero);
        }
        
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor de saque não pode ser negativo", nameof(valor));
            }
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(_saldo, valor);
            }
            _saldo -= valor;
        }
        
        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }
        
        public void Depositar(double valor)
        {
            _saldo += valor;
        }
    }
}