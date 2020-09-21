using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace VimeoVHX
{
    class Resources
    {
        private readonly HttpClient _client = new HttpClient();

        public Resources()
        {
            PreencherCabecalho();
        }

        private void PreencherCabecalho()
        {
            string token;

            try
            {
                token = ConfigurationManager.AppSettings.Get("Token");
            }
            catch (Exception)
            {

                throw;
            }

            _client.DefaultRequestHeaders.Add("u", token);
        }
    }
}
