using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Arc.Xml
{
    public sealed class XmlController
    {
        private static XmlController _instance;
        private static readonly object Padlock = new object();

        XmlController()
        {
        }

        public static XmlController Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new XmlController();
                    }

                    return _instance;
                }
            }
        }

        public void WriteXmlFile(SongData data, string path)
        {
            XmlSerializer writer = new XmlSerializer(typeof(SongData));
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, data);
            }
        }

        public SongData ReadXmlFile(string path)
        {
            XmlSerializer reader = new XmlSerializer(typeof(SongData));
            using (FileStream xml = File.OpenRead(path))
            {
                return (SongData) reader.Deserialize(xml);
            }
        }
    }
}