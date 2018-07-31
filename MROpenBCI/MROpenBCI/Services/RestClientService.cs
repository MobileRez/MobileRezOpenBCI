using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MROpenBCI.Model.OpenBCI.Wifi;

namespace MROpenBCI.Services
{
    public class RestClientService
    {
        const string AcceptHeaderApplicationJson = "application/json";
        private string restServiceBaseAddress;
        HttpResponseMessage dataResp;

        private HttpClient CreateRestClient(string baseAddress)
        {
            //RestServiceBaseAddress = baseAddress;
            var client = new HttpClient
            {
                //BaseAddress = new Uri(RestServiceBaseAddress),
                BaseAddress = new Uri(baseAddress),
                Timeout = new TimeSpan(0, 0, 0, 10, 0)
            };

            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(AcceptHeaderApplicationJson));
            return client;
        }

        public async Task<Board> GetBoardInfo(string baseAddress)
        {
            var jsonResponse = string.Empty;
            dataResp = new HttpResponseMessage();
            
            string fullAddress = "http://" + baseAddress + "/board";

            using (var client = CreateRestClient(fullAddress))
            {
                //var dataResp = await client.GetAsync("", HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                dataResp = await client.GetAsync("", HttpCompletionOption.ResponseContentRead);

                //If we do not get a successful status code, then return an empty set
                if (!dataResp.IsSuccessStatusCode)
                    throw new Exception("Could not talk to Device");

                //jsonResponse = await dataResp.Content.ReadAsStringAsync().ConfigureAwait(false);
                jsonResponse = await dataResp.Content.ReadAsStringAsync();
            }

            if (string.IsNullOrEmpty(jsonResponse))
                return null;

            //var parsedResponse = JsonConvert.DeserializeObject<Board>(jsonResponse);
            /*var parsedResponse = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Board>(jsonResponse)).ConfigureAwait(false); */
            var parsedResponse = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Board>(jsonResponse));

            return parsedResponse;
        }

        public string RestServiceBaseAddress
        {
            get => restServiceBaseAddress;
            set
            {
                if (restServiceBaseAddress != value)
                {
                    restServiceBaseAddress = value;
                    //OnPropertyChanged(nameof(RestServiceBaseAddress));
                }
            }
        }
    }
}

