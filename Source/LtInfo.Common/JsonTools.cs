using Newtonsoft.Json;

namespace LtInfo.Common
{
    public class JsonTools
    {
        public static T DeserializeObject<T> (string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace });
        }

        public static string SerializeObject(object objectGraph)
        {
            return JsonConvert.SerializeObject(objectGraph, Formatting.Indented);
        }

        /// <summary>
        /// see Taurus.js Taurus.Methods.decryptObfuscatedUrls- that is the inverse of this function for the javascript side.
        /// </summary>
        /// <param name="stringWithImgSrcUrls"></param>
        /// <returns></returns>
        public static string ObfuscateUrlsForMozillaPrefetching(string stringWithImgSrcUrls)
        {
            return stringWithImgSrcUrls != null ? stringWithImgSrcUrls.Replace("img src=\"/FileResource.mvc/GetImageFile/", "fake_E2E1F9D5-57CD-4A1F-8A1B-36B1AC4EEDB9_mozilla") : null;
        }
    }
}