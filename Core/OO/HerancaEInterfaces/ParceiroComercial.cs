using Core.OO.HerancaEInterfaces.Sistemas;

namespace Core.OO.HerancaEInterfaces
{
    public class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }
        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
    }
}