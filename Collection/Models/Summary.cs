using System;
using System.Text.RegularExpressions;
using System.Xml;
using System.Net;

namespace Collection.Models
{
    public class Summary
    {
        public Summary() {}
        public Summary(XmlNode xml)
        {
            Title = WebUtility.HtmlDecode(xml.SelectSingleNode("title").InnerText);
            Description = WebUtility.HtmlDecode(Regex.Replace(xml.SelectSingleNode("description").InnerText, "<.*?>", String.Empty));
            Category = WebUtility.HtmlDecode(xml.SelectSingleNode("category").InnerText);
            Guid = WebUtility.HtmlDecode(xml.SelectSingleNode("guid").InnerText);
            Link = WebUtility.HtmlDecode(xml.SelectSingleNode("link").InnerText);
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