
using Modelos.OO.HerancaEInterfaces.Sistemas;

namespace Modelos.OO.HerancaEInterfaces.Funcionarios
{
    /**
     * No caso de uma classe extender de uma classe e implementar uma interface, primeiro adicionamos a classe (ex: Funcionario) e depois colocamos as interfacer separadas por virgula (ex: IAutenticavel).
     */
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {

        private AutenticacaoHelper _autenticacaoHelper = new AutenticacaoHelper();
        
        public string Senha { get; set; }

        public FuncionarioAutenticavel(double salario, string cpf) : base(salario, cpf) { }

        public bool Autenticar(string senha)
        {
            return _autenticacaoHelper.CompararSenhar(Senha,senha);
        }
    }
}