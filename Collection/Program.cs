using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Collection.DbContexts;
using Collection.Models;
using System.Linq;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient http = new HttpClient();
            var httpRes = http.GetAsync("https://svd.se/?service=rss").Result;
            parseHttpResponse(httpRes).Wait();
        }

        static async Task parseHttpResponse(HttpResponseMessage response) {
            response.EnsureSuccessStatusCode();
            XmlDocument xml = getXMLDoc(await response.Content.ReadAsStringAsync());

            await saveItems(xml.SelectNodes("/rss/channel/item"));
        }

        static async Task saveItems(XmlNodeList items) {
            using (var db = new ArticleContext()) {
                foreach (XmlNode item in items) {
                    var summary = new Summary(item);
                    if (!db.Summaries.Any(s => s.Guid == summary.Guid)) {
                        await db.Summaries.AddAsync(summary);
                    }
                }
                await db.SaveChangesAsync();
            }
        }

        static XmlDocument getXMLDoc(string xml) {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc;
        }
    }
}
