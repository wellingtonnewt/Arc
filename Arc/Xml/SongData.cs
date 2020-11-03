﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Arc.Xml
{
    public class SongData
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> Tags;
        public List<SongLyric> Lyric;

        public SongData()
        {
            
        }

        public SongData(string title, string author)
        {
            Title = title;
            Author = author;
            Tags = new List<string>();
            Lyric = new List<SongLyric>();
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