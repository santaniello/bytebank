using Modelos.OO.HerancaEInterfaces.Funcionarios;

namespace Modelos.OO.HerancaEInterfaces
{
    public class GerenciadorBonificacao
    {
        private double _totalBonificacao;

        public void Registrar(Funcionario funcionario)
        {
            _totalBonificacao += funcionario.GetBonificacao();
        }
        
        public double GetTotalBonificacao()
        {
            return _totalBonificacao;
        }
    }
}