using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// A helper containing functions which are used throughout the project.
    /// </summary>
    public static class BolApiHelper
    {
        /// <summary>
        /// Converts an object into json serialized httpcontent
        /// </summary>
        /// <param name="contentObject">The object to convert</param>
        /// <returns></returns>
        public static HttpContent BuildContentFromObject(object contentObject)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return new StringContent(JsonConvert.SerializeObject(contentObject, settings), Encoding.UTF8, "application/vnd.retailer.v3+json");
        }

        /// <summary>
        /// Takes the content of a HttpResponseMessage and converts it into an object of type T
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="response">A HttpResponseMessage containing json</param>
        /// <returns></returns>
        public static async Task<T> GetContentFromResponse<T>(HttpResponseMessage response)
        {
            var responseContentString = await response.Content.ReadAsStringAsync();
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.DeserializeObject<T>(responseContentString, settings);
        }
    }
}
