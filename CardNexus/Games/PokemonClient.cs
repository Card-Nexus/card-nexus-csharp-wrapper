using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CardNexus.Games
{
    public class PokemonClient
    {
        private readonly string baseUrl = "http://localhost:3000/v1/pokemon";
        private readonly HttpClient httpClient;

        public PokemonClient()
        {
            httpClient = new HttpClient();
        }

        // Fetches all Pokémon TCG eras
        public async Task<object> GetAllEras()
        {
            try
            {
                var response = await httpClient.GetStringAsync($"{baseUrl}/eras");
                return JsonConvert.DeserializeObject<object>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching all eras", ex);
            }
        }

        // Fetches a specific era by its identifier
        public async Task<object> GetEraByIdentifier(string identifier)
        {
            try
            {
                var response = await httpClient.GetStringAsync($"{baseUrl}/eras/{identifier}");
                return JsonConvert.DeserializeObject<object>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching era by identifier: {identifier}", ex);
            }
        }

        // Fetches all sets with optional filtering by era, name, and sorting
        public async Task<object> GetAllSets(string era = null, string name = null, string sort = null, string order = null)
        {
            var url = $"{baseUrl}/sets";

            // Build query parameters
            var parameters = new List<string>();
            if (!string.IsNullOrEmpty(era)) parameters.Add($"era={era}");
            if (!string.IsNullOrEmpty(name)) parameters.Add($"name={name}");
            if (!string.IsNullOrEmpty(sort)) parameters.Add($"sort={sort}");
            if (!string.IsNullOrEmpty(order)) parameters.Add($"order={order}");

            if (parameters.Count > 0)
                url += "?" + string.Join("&", parameters);

            try
            {
                var response = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<object>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching all sets", ex);
            }
        }

        // Fetches a specific set by its identifier
        public async Task<object> GetSetByIdentifier(string identifier)
        {
            try
            {
                var response = await httpClient.GetStringAsync($"{baseUrl}/sets/{identifier}");
                return JsonConvert.DeserializeObject<object>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching set by identifier: {identifier}", ex);
            }
        }

        // Fetches all cards with pagination and optional filters
        public async Task<object> GetAllCards(int limit = 20, int offset = 0, Dictionary<string, string> filters = null)
        {
            var url = $"{baseUrl}/cards?limit={limit}&offset={offset}";

            if (filters != null && filters.Count > 0)
            {
                foreach (var filter in filters)
                {
                    url += $"&{filter.Key}={filter.Value}";
                }
            }

            try
            {
                var response = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<object>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching cards", ex);
            }
        }

        // Fetches a specific card by its identifier
        public async Task<object> GetCardByIdentifier(string identifier)
        {
            try
            {
                var response = await httpClient.GetStringAsync($"{baseUrl}/cards/{identifier}");
                return JsonConvert.DeserializeObject<object>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching card by identifier: {identifier}", ex);
            }
        }
    }
}