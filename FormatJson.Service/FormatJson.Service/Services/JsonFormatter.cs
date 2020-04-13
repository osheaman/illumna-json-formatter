using FormatJson.Service.Data.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FormatJson.Service.Services
{
    public interface IJsonFormatter
    {
        Task<List<FormattedData>> FormatInput(string filePath);
    }
    public class JsonFormatter : IJsonFormatter
    {
        public async Task<List<FormattedData>> FormatInput(string filePath)
        {
            List<FormattedData> formattedJsonList = new List<FormattedData>();
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                using (FileStream s = File.Open(filePath, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    while (reader.Read())
                    {
                        // deserialize only when there's "{" character in the stream
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            JObject obj = JObject.Load(reader);
                            if(obj != null)
                            {
                                //var input1 = serializer.Deserialize<List<InputData>>(obj);
                                foreach (var item in obj["data"])
                                {
                                    var input = item.ToObject<InputData>();
                                    if (ValidateUrl(input.Url))
                                    {
                                        var formattedJson = new UrlSize()
                                        {
                                            Url = input.Url,
                                            Size = input.Size
                                        };
                                        formattedJsonList.Add(new FormattedData
                                        {
                                            PathValue = input.Path,
                                            UrlSize = formattedJson
                                        });
                                    }
                                }
                            }


                        }
                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                return null;
            }
            return formattedJsonList;
        }

        private bool ValidateUrl(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute); ;
        }
    }
}
