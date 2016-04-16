using System;
using System.IO;

namespace DSA.Common.Infrastructure.Helpers
{
    public static class XmlSerializerHelper
    {        

       

        public static void SaveToXml<T>(string dataPath, T t)
        {
            try
            {
                var writer = new System.Xml.Serialization.XmlSerializer(typeof(T));

                var file = new StreamWriter(dataPath);
                writer.Serialize(file, t);


                file.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public static T GetFromXml<T>(string dataPath)
        {
            if (File.Exists(dataPath))
            {
                try
                {
                    var reader = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    var file = new StreamReader(dataPath);
                    return (T)reader.Deserialize(file);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {

            }

            return default(T);
        }
    }
}
