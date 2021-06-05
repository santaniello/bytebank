namespace Core.OO.Heranca
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Salario { get; set; }
        
        /**
         * A palavra chave virtual indica que podemos sobreescrever o método GetBonificacao através de alguma classe filha.
         * Em Java, acontece justamente o contrario ...  Cada método criado é virtual por default, ou seja, pode ser sobreescrito e quando colocamos a palavra final
         * ai sim o compilador não deixa você sobreescrever o método...
         *
         * https://codewithshadman.com/no-virtual-keyword-in-java-and-no-final-keyword-in-csharp-explained/
         */
        public  virtual double GetBonificacao()
        {
            return Salario * 0.10;
        }
    }
}