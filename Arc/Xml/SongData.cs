using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Arc.Xml
{
    [Serializable]
    public class SongData
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> Tags;
        public List<SongLyric> Lyric;

        public SongData(){}
        public SongData(string title, string author)
        {
            Title = title;
            Author = author;
            Tags = new List<string>();
            Lyric = new List<SongLyric>();
        }

        public void Save()
        {
            if (!Directory.Exists("Songs"))
            {
                Directory.CreateDirectory("Songs");
            }

            using (FileStream stream = new FileStream("Songs/" + Title + ".xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(SongData));
                xml.Serialize(stream, this);
            }

        }

        public static SongData Load(string path)
        {
            if (File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(SongData));
                    return (SongData) xml.Deserialize(stream);
                }
            }
            else
            {
                Console.WriteLine($"File {path} was not found");
                return null;
            }
        }

        public void Delete()
        {
            File.Delete("Songs/" + Title + ".xml");
        }
    }

    public class SongLyric
    {
        public SongLyricType Type;
        public string Text;
    }

    public enum SongLyricType
    {
        Stanza,
        Chorus,
        Bridge
    }
}