using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUChairVO;

namespace TUChair.Util
{
    public class ServiceHelp : IDisposable
    {
        HttpClient client = new HttpClient();
        string url = ConfigurationManager.AppSettings["ApiAddess"];

        public string BaseServiceUrl { get; set; }

        public ServiceHelp(string routePrefix)
        {
            BaseServiceUrl = $"{url}/{routePrefix}";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetListAsync<T>(string path, T t)
        {
            path = BaseServiceUrl + path;
            T list = default(T);
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(path))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        list = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    }
                }
                return list;
            }
            catch
            {
                return list;
            }
        }

        public async Task<T> GetAsync<T>(string path, T t)
        {
            T obj = default(T);
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(path))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Message<T> msg = JsonConvert.DeserializeObject<Message<T>>(await response.Content.ReadAsStringAsync());
                        obj = msg.Data;
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }

        public async Task<TUChairVO.Message> GetAsync(string path)
        {
            TUChairVO.Message msg = null;
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(path))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        msg = JsonConvert.DeserializeObject<TUChairVO.Message>(await response.Content.ReadAsStringAsync());
                    }
                }
                return msg;
            }
            catch
            {
                return msg;
            }
        }

        public async Task<Message<T>> PostAsync<T>(string path, T t)
        {
            Message<T> result = null;
            try
            {
                using (HttpResponseMessage response = await client.PostAsJsonAsync(path, t))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<Message<T>>(await response.Content.ReadAsStringAsync());
                    }
                }
                return result;
            }
            catch
            {
                return result;
            }
        }
        public async Task<TUChairVO.Message> PostAsyncNone<T>(string path, T t)
        {
            TUChairVO.Message result = null;
            try
            {
                path = BaseServiceUrl + path;
                using (HttpResponseMessage response = await client.PostAsJsonAsync(path, t))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<TUChairVO.Message>(await response.Content.ReadAsStringAsync());
                    }
                }
                return result;
            }
            catch
            {
                return result;
            }
        }
        public void Dispose()
        {
            client.Dispose();
        }
    }
}
