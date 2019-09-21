using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace Collection.Models
{
    public class Summary
    {
        public Summary() {}
        public Summary(XmlNode xml)
        {
            Title = xml.SelectSingleNode("title").InnerText;
            Description = Regex.Replace(xml.SelectSingleNode("description").InnerText, "<.*?>", String.Empty);
            Category = xml.SelectSingleNode("category").InnerText;
            Guid = xml.SelectSingleNode("guid").InnerText;
            Link = xml.SelectSingleNode("link").InnerText;
            PubTime = DateTime.Parse(xml.SelectSingleNode("pubDate").InnerText);
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Guid { get; set; }
        public DateTime PubTime { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
}