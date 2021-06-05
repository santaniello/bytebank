namespace Core.OO.Heranca
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Salario { get; set; }
        
        public double GetBonificacao()
        {
            return Salario * 0.10;
        }
    }
}