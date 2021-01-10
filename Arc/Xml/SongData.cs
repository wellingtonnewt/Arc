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

        public SongData() { }

        public SongData(string title, string author)
        {
            Title = title;
            Author = author;
            Tags = new List<string>();
            Lyric = new List<SongLyric>();
        }
        public SongData Clone()
        {
            SongData clone = new SongData();
            clone.Title = Title;
            clone.Author = Author;
            clone.Tags = new List<string>(Tags);
            clone.Lyric = new List<SongLyric>(Lyric);
            clone.Lyric.Clear();
            foreach (SongLyric lyric in Lyric)
            {
                clone.Lyric.Add(lyric.Clone());
            }
            return clone;
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
        public SongLyricType Type { get; set; }
        public string Text { get; set; }

        public SongLyric Clone()
        {
            SongLyric clone = new SongLyric();
            clone.Text = Text;
            clone.Type = Type;
            return clone;
        }
    }

    public enum SongLyricType
    {
        Stanza,
        Chorus,
        Bridge
    }
}