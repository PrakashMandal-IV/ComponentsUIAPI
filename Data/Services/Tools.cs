
using System.Data;

using System.Net.Mail;
using System.Net;
using System.Security.Claims;

using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using System;

namespace ComponentsUIAPI.Data.Services
{
    public class Tools
    {
        private readonly string _JWTKey;
        private readonly string SenderId;
        private readonly string Password;
        public Tools(IConfiguration configuration)
        {
            _JWTKey = configuration.GetSection("AppSettings:Token").Value;
            SenderId = configuration.GetSection("Email:EmailID").Value;
            Password = configuration.GetSection("Email:Passowrd").Value;
        }
      
        public string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
        public string DataTableSystemTextJson(DataTable dataTable)
        {
            string jsonData = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
            return jsonData;
        }
        public string DataSetSystemTextJson(DataSet dataSet)
        {
          string jsonData = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            return jsonData;
        }

       
       
    }
}
