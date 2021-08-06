namespace Modelos.OO.HerancaEInterfaces.Funcionarios
{
    /*
     * O modificador internal em uma classe ou metodo, indica que aquele membro estará visivel apenas dentro daquele projeto.
     * Senão colocarmos nenhum modificador de acesso, o C# assume o modificador de acesso internal por default.
     * Exemplo:
     *    class AutenticacaoHelper
     *    class Program
     */
    internal class AutenticacaoHelper
    {
        public bool CompararSenhar(string senhaVerdadeira, string senhaTentativa)
        {
            return senhaVerdadeira == senhaTentativa;
        }
    }
}