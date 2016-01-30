using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Spectre.Api.Wrapper
{
    public class SpectreService : ISpectreService
    {
        private readonly HttpClient _httpClient;
        private readonly string _serviceUrl;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        #region ctors
        public SpectreService(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
            _httpClient = new HttpClient();
            _jsonSerializerSettings = GetJsonSerializerSettings();
        }
        public SpectreService(string serviceUrl, HttpClient httpClient)
        {
            if (httpClient == null)
                throw new ArgumentNullException("httpClient");

            _serviceUrl = serviceUrl;
            _httpClient = httpClient;
            _jsonSerializerSettings = GetJsonSerializerSettings();
        }
        #endregion

        public async Task<ByteResponse> GetByteResponseAsync(RequestParameters requestParameters)
        {
            var result = await ExecuteRequestAsync(requestParameters).ConfigureAwait(false);

            if (result.IsSuccessStatusCode)
            {
                return new ByteResponse
                {
                    Result = await result.Content.ReadAsByteArrayAsync().ConfigureAwait(false)
                };
            }

            return new ByteResponse
            {
                Error = await result.Content.ReadAsStringAsync().ConfigureAwait(false)
            };
        }
        public async Task<StreamResponse> GetStreamResponseAsync(RequestParameters requestParameters)
        {
            var result = await ExecuteRequestAsync(requestParameters).ConfigureAwait(false);

            if (result.IsSuccessStatusCode)
            {
                return new StreamResponse
                {
                    Result = await result.Content.ReadAsStreamAsync().ConfigureAwait(false)
                };
            }

            return new StreamResponse
            {
                Error = await result.Content.ReadAsStringAsync().ConfigureAwait(false)
            };
        }
        private async Task<HttpResponseMessage> ExecuteRequestAsync(RequestParameters requestParameters)
        {
            var stringContent = GetStringContent(requestParameters);
            return await _httpClient.PostAsync(_serviceUrl, stringContent).ConfigureAwait(false);
        }

        #region helpers
        private static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
        private StringContent GetStringContent(RequestParameters requestParameters)
        {
            var jsonRequestParameters = JsonConvert.SerializeObject(requestParameters, Formatting.Indented, _jsonSerializerSettings);
            return new StringContent(jsonRequestParameters, System.Text.Encoding.UTF8, "application/json");
        }
        #endregion
    }
}
