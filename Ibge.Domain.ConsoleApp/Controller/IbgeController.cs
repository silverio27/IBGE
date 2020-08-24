using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ibge.Domain.Entities;
using Ibge.Domain.Facades;
using Ibge.Domain.Handlers.Contract;
using Ibge.Domain.Infra.Contexts;
using Ibge.Domain.Infra.Repositories;

namespace Ibge.Domain.ConsoleApp.Controller
{
    public class IbgeController
    {
        public static async Task RegionIbgeRequestManualTest()
        {
            try
            {
                HttpClient client = new HttpClient();
                RegionIbgeRepository repository = new RegionIbgeRepository(client);
                var response = await repository.Get();
                Console.WriteLine("Retorno da api do IBGE");
                foreach (var item in response)
                    Console.WriteLine("{0}, {1}, {2}", item.Id, item.Name, item.Initials);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static void CreateRegionManualTest()
        {
            var context = new DataContext();
            var repository = new RegionRepository(context);
            var region = new Region(1, "I", "N");

            repository.Create(region);
            Console.WriteLine("Região criada");

        }

        public static async Task ExecuteFacadeManualTest()
        {
            var context = new DataContext();
            var repository = new RegionRepository(context);

            HttpClient client = new HttpClient();
            RegionIbgeRepository externalRepository = new RegionIbgeRepository(client);

            var facade = new RegionIntegrationFacade(externalRepository, repository);
            var result = await facade.Execute();
            Console.WriteLine("{0}, {1}", result.Success, result.Message);
            foreach (var item in ((SuccessResult<IEnumerable<Region>>)result).Data)
            {
                Console.WriteLine(item.Name);
            };

        }
    }

}