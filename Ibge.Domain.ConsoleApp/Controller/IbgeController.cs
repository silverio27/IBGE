using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.RegionIbgeContext.Handlers;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.Infra.Contexts;
using Ibge.Domain.Infra.Repositories;

namespace Ibge.Domain.ConsoleApp.Controller
{
    public class IbgeController
    {
        public static async Task RegionIbgeRequestManualTest()
        {

            HttpClient client = new HttpClient();
            RegionIbgeRepository repository = new RegionIbgeRepository(client);
            var response = await repository.Get();
            Console.WriteLine("Retorno da api do IBGE");
            foreach (var item in response)
                Console.WriteLine("{0}, {1}, {2}", item.id, item.nome, item.sigla);


        }

        public static void CreateRegionManualTest()
        {
            var context = new DataContext();
            var repository = new RegionRepository(context);
            var handler = new RegionHandler(repository);
            var region = new RegionCommand(1, "I", "N");

            var res = handler.Handle(region);
            Console.WriteLine("Comando válido: {0}, Mensagem: {1}", res.Success, res.Message);

        }

        public static async Task ExecuteFacadeManualTest()
        {
            var context = new DataContext();
            var repository = new RegionRepository(context);

            HttpClient client = new HttpClient();
            RegionIbgeRepository externalRepository = new RegionIbgeRepository(client);
            var handler = new RegionHandler(repository);

            var handle = new RegionIntegrationHandler(externalRepository, handler);
            var result = await handle.Execute();
            foreach (var item in result)            
                Console.WriteLine("incluído: {0}, Message: {1}, Nome: {2}", item.Success, item.Message, item.Data.nome);
            


        }
    }

}