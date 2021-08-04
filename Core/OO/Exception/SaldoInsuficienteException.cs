namespace Core.OO.Exception
{
    public class SaldoInsuficienteException : System.Exception
    {
        public double Saldo { get; }
        public double ValorSaque { get; }
        
        public SaldoInsuficienteException()
        {
        }

        public SaldoInsuficienteException(string mensagem)
            : base(mensagem)
        {
        }
        
        /*
         * Abaixo na linha do this(mensagem), estamos chamando o construtor acima
         * public SaldoInsuficienteException(string mensagem)
         */
        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this("Tentativa de saque de " + valorSaque + " com saldo de " + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
    }
}