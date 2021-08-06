namespace Core.OO.Exception
{
    public class OperacaoFinanceiraException : System.Exception
    {
        public OperacaoFinanceiraException()
        {

        }

        public OperacaoFinanceiraException(string mensagem)
            : base(mensagem)
        {

        }

        public OperacaoFinanceiraException(string mensagem, System.Exception excecaoInterna)
            : base(mensagem, excecaoInterna)
        {

        }
    }
}