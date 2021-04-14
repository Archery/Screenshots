using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Css;
using AngleSharp.Js;
using AngleSharp.Scripting.JavaScript;

namespace MySiteParser {
    internal class AngleSharpWrapper {
        private readonly IBrowsingContext context_;

        public AngleSharpWrapper() {
            var configuration = Configuration.Default.WithDefaultLoader().WithDefaultCookies();
            this.context_ = BrowsingContext.New(configuration);
        }

        public IDocument GetDocByUrl(string url) {
            var document = Task.Run<IDocument>(async () => await this.context_.OpenAsync(url)).Result;
            return document;
        }

        public IDocument GetDocByHtml(string html) {
            var document = Task.Run<IDocument>(async () => await this.context_.OpenAsync(req => req.Content(html))).Result;
            return document;
        }

        public IDocument GetNewDoc() {
            var document = Task.Run<IDocument>(async () => await this.context_.OpenNewAsync()).Result;
            return document;
        }

        public static string Beautify(string doc) {
            doc = doc.Trim();
            doc = Regex.Replace(doc, @"\s*\r\n", "");
            doc = Regex.Replace(doc, @"\s*(<img|<p|<h1|<h2|<h3|<h4|<table|</table|<ul|</ul|<ol|</ol|<li)", "\r\n$1");
            doc = Regex.Replace(doc, @"\s*(<tr|</tr|<li)", "\t\r\n$1");
            doc = Regex.Replace(doc, @"\s*(<td)", "\t\t\r\n$1");
            return doc;
        }
    }
}