using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public class BaseApi : ControllerBase
    {
        private readonly IHttpClientFactory _http;

        public BaseApi(IHttpClientFactory http)
        {
            _http = http;
        }


        public async Task<IActionResult> PostToApi(string ControllerName, object model)
        {
            var client = _http.CreateClient("useApi");

            var response = await client.PostAsJsonAsync(ControllerName, model);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return Ok(content);
            }

            return BadRequest();
        }

        public async Task<IActionResult> GetApi(string ControllerName)
        {
            var client = _http.CreateClient("useApi");

            var response = await client.GetAsync(ControllerName);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return Ok(content);
            }

            return BadRequest();
        }
    }
}
