using System.Collections.Generic;
using Arc.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class XmlTest
    {
        private SongData data;

        public XmlTest()
        {
            data = new SongData("test","testAuthor");
            data.Lyric = new List<SongLyric>
            {
                new SongLyric
                {
                    Type = SongLyricType.Chorus,
                    Text = "ChorusLalalal"
                },
                new SongLyric
                {
                    Type = SongLyricType.Bridge,
                    Text = "BridgeLalalal"
                },
                new SongLyric
                {
                    Type = SongLyricType.Stanza,
                    Text = "StanzaLalalal"
                }
            };
            data.Tags = new List<string>()
            {
                "Tag1",
                "Tag2"
            };
        }

        [TestMethod]
        public void ReadWriteTest()
        {
            XmlController.Instance.WriteXmlFile(data, "UnityTestTestClass.xml");
            SongData readXmlFile = XmlController.Instance.ReadXmlFile("UnityTestTestClass.xml");

            Assert.AreEqual(data.Title,readXmlFile.Title);
            Assert.AreEqual(data.Author,readXmlFile.Author);
            Assert.AreEqual(data.Lyric.Count,readXmlFile.Lyric.Count);
            Assert.AreEqual(data.Tags.Count,readXmlFile.Tags.Count);
        }
    }
}
