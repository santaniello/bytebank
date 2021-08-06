using Modelos.OO.HerancaEInterfaces.Funcionarios;
using Modelos.OO.HerancaEInterfaces.Sistemas;

namespace Modelos.OO.HerancaEInterfaces
{
    public class ParceiroComercial : IAutenticavel
    {
        
        private AutenticacaoHelper _autenticacaoHelper = new AutenticacaoHelper();
        public string Senha { get; set; }
        public bool Autenticar(string senha)
        {
            return _autenticacaoHelper.CompararSenhar(Senha, senha);
        }
    }
}