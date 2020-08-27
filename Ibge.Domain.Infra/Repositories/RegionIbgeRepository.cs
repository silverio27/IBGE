using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ibge.Domain.Entities;
using Ibge.Domain.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ibge.Domain.Commands;
using Ibge.Domain.Mapping;
using System.Linq;

namespace Ibge.Domain.Infra.Repositories
{
    public class RegionIbgeRepository : IRegionIbgeRepository
    {
        HttpClient _httpClient;
        const string url = "https://servicodados.ibge.gov.br/api/v1/localidades/regioes";

        public RegionIbgeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RegionCommand>> Get()
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<RegionCommand>>(content);
            }

            return new List<RegionCommand>();
        }
    }
}