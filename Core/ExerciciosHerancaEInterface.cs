using System;
using Modelos.OO.HerancaEInterfaces;
using Modelos.OO.HerancaEInterfaces.Funcionarios;
using Modelos.OO.HerancaEInterfaces.Sistemas;

namespace Core
{
    public class ExerciciosHerancaEInterface
    {
        static void TestarUsoDeHeranca()
        {
            GerenciadorBonificacao gerenciadorBonificacao = new GerenciadorBonificacao();

            Funcionario pedro = new Designer("833.222.048-39");
            pedro.Nome = "Pedro";

            Funcionario roberta = new Diretor("159.753.398-04");
            roberta.Nome = "Roberta";

            Funcionario igor = new Auxiliar("981.198.778-53");
            igor.Nome = "Igor";

            Funcionario camila = new GerenteDeConta("326.985.628-89");
            camila.Nome = "Camila";

            Desenvolvedor guilherme = new Desenvolvedor("456.175.468-20"); 
            guilherme.Nome = "Guilherme"; 

            gerenciadorBonificacao.Registrar(guilherme);
            gerenciadorBonificacao.Registrar(pedro);
            gerenciadorBonificacao.Registrar(roberta);
            gerenciadorBonificacao.Registrar(igor);
            gerenciadorBonificacao.Registrar(camila);
            
            // Testando sobreescrita de metodos virtuais com que possuem uma implementação padrão porém podem ser reescritos ...
            pedro.MetodoComImplementacaoPadrao();
            roberta.MetodoComImplementacaoPadrao();

            Console.WriteLine("Total de bonificações do mês " +
                              gerenciadorBonificacao.GetTotalBonificacao());
        }
        
        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();

            Diretor roberta = new Diretor("159.753.398-04");
            roberta.Nome = "Roberta";
            roberta.Senha = "123";

            GerenteDeConta camila = new GerenteDeConta("326.985.628-89");
            camila.Nome = "Camila";
            camila.Senha = "abc";

            ParceiroComercial parceiro = new ParceiroComercial();
            parceiro.Senha = "123456";

            sistemaInterno.Logar(parceiro, "123456");

            sistemaInterno.Logar(roberta, "123"); 
            sistemaInterno.Logar(camila, "abc");
        }
    }
}