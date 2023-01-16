using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Zer0ne.Data
{
    public class DataSerializer
    {
        public void JsonSerializer(object data, string filePath)
        {
            if (data == null)
            {
                return;
            }

            JsonSerializer js = new JsonSerializer();
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter sw = new StreamWriter(filePath))
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                js.Serialize(jsonWriter, data);
                jsonWriter.Close();
                sw.Close();
            }
        }

        public object JsonDeserializer(Type dataType, string filePath)
        {
            JObject obj = null;
            JsonSerializer js = new JsonSerializer();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                using (JsonReader jsonReader = new JsonTextReader(sr))
                {
                    obj = js.Deserialize(jsonReader) as JObject;
                    jsonReader.Close();
                    sr.Close();
                }

                if (obj != null)
                {
                    return obj.ToObject(dataType);
                }
            }
            return null;
        }
    }
}
