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

        public SongData()
        {
            Title = "";
            Author = "";
            Tags = new List<string>();
            Lyric = new List<SongLyric>();
        }

        public void Save(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(SongData));
                xml.Serialize(stream, this);
            }
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