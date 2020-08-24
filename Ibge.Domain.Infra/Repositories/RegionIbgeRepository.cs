using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ibge.Domain.Entities;
using Ibge.Domain.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ibge.Domain.Dto;
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

        public async Task<IEnumerable<Region>> Get()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var contentDeserialize = JsonSerializer.Deserialize<IEnumerable<RegionDto>>(content);                
                return AutoMapperConfiguration.Mapper.Map<IEnumerable<Region>>(contentDeserialize);
            }

            return null;
        }
    }
}