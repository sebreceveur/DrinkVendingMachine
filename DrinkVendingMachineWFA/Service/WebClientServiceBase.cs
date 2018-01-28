using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DrinkVendingMachineWFA.Service
{
    public class WebClientServiceBase : IWebClientService
    {
        public string BaseUri { get; protected set; }

        public WebClientServiceBase()
        {
            BaseUri = "http://localhost/DrinkVendingMachine/api";
        }

        public virtual object Get()
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(BaseUri);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                if ((webResponse.StatusCode == HttpStatusCode.OK) )
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var arr = JsonConvert.DeserializeObject<JArray>(s);

                    reader.Close();
                    webResponse.Close();
                    
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

        public object Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Post(object postData)
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create(BaseUri);
            // Set the Method property of the request to POST.
            request.Method = "POST";

            // Create POST data and convert it to a byte array.
            //string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(postData));
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        //public virtual void Post(object postData)
        //{
        //    var request = (HttpWebRequest)WebRequest.Create(BaseUri);
        //    var serialized = JsonConvert.SerializeObject(postData);
        //    var data = Encoding.ASCII.GetBytes(serialized);            

        //    request.Method = "POST";
        //    request.ContentType = "application/x-www-form-urlencoded";
        //    request.ContentLength = data.Length;

        //    using (var stream = request.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);

        //        var response = (HttpWebResponse)request.GetResponse();
        //        var reader = new StreamReader(response.GetResponseStream());
        //        var responseString = reader.ReadToEnd();

        //        reader.Close();
        //        response.Close();
        //    }           

            
        //}
    }
}
