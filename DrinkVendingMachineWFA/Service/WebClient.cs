using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.Service
{
    public class WebClient
    {
        public object GetRESTData(string uri)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                if ((webResponse.StatusCode == HttpStatusCode.OK) )
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var arr = JsonConvert.DeserializeObject<JArray>(s);
                    //dataGridView1.DataSource = arr;
                    return arr;
                }
                else
                {   // TO DO
                    //MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
