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
        private string _url;

        public RegionIbgeRepository(IbgeEndPoints url)
        {
            _httpClient = new HttpClient();
            _url = url.Value;
        }

        public async Task<IEnumerable<RegionCommand>> Get()
        {
            var response = await _httpClient.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<RegionCommand>>(content);
            }

            return new List<RegionCommand>();
        }
    }
}