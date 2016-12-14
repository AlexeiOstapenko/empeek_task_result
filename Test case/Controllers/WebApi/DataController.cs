using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Test_case.Infrastructure;
using Test_case.Models;
using System.Web.Script.Serialization;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;


namespace Test_case.Controllers.WebApi
{
    public class DataController : ApiController
    {
        
        
        // GET api/data


        public IEnumerable<string> Get(string value)
        {
            return new string[] { "value1", "value2" };
        }

       //  GET api/data/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/data   
        public HttpResponseMessage Post([FromBody]string value)
        {
           
            DirectoryInfo root = new DirectoryInfo(value);
            SearchFile.WalkDirectoryTree(root);
            List<FilesInfo> files = new List<FilesInfo>();

            foreach (var item in SearchFile.myFiles)
            {
                FilesInfo file = new FilesInfo()
                {
                    fileFullName = item.FullName,
                    fileSize = Convert.ToString(item.Length)
                };
                files.Add(file);
            }

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(files);


            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(serializedResult, Encoding.UTF8, "application/json");
            return response;
        }

        // PUT api/data/5
         public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/data/5
        public void Delete(int id)
        {
        }
    }
}
