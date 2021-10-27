using System;
using Async.Repository;
using Async.Service;
using Async.View;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new ByteBanckView(new ContaClienteRepository(), new ContaClienteService());
            view.BtnProcessar_Click();
        }
    }
}