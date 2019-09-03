using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace SimonwdixonTuto2_Workers.ws
{
    class HttpCli2
    {

        public async Task<String> GetAsync(string uri)
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            CancellationToken cancellationToken = cts.Token;

            Console.WriteLine("http");
            var httpClient = new HttpClient();
            string content="";

            var response = await httpClient.GetAsync(uri, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }

             

            return content;
        }


    }
}
