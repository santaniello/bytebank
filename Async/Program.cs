using System;
using System.Threading.Tasks;
using Async.Repository;
using Async.Service;
using Async.View;

namespace Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var view = new ByteBanckView(new ContaClienteRepository(), new ContaClienteService());
            //view.BtnProcessar_Click_TASKS();
            await view.BtnProcessar_Click_Async_Await_Com_Progress();
        }
    }
}