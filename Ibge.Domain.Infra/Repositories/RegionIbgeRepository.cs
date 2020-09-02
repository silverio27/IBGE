using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ibge.Domain.RegionIbgeContext.Repositories;
using System.Text.Json;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Enums;

namespace Ibge.Domain.Infra.Repositories
{
    public class RegionIbgeRepository : IRegionIbgeRepository
    {
        HttpClient _httpClient;
        public RegionIbgeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CreateRegionCommand>> Get(IbgeEndPoints endPoint)
        {
            var url = endPoint.Value;
            var response = new List<CreateRegionCommand>();
            if (string.IsNullOrEmpty(url) || (_httpClient == null))
                return response;

            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<CreateRegionCommand>>(content);
            }

            return response;
        }
    }
}