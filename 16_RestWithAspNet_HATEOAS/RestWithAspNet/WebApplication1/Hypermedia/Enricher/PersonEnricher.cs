using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Data.VO;
using RestWithAspNet.Hypermedia.Constant;
using System.Text;

namespace RestWithAspNet.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/person";
            string link = GetLink(content.Id, urlHelper, path);
            content.links.Add(new HyperMediaLink()
            {
                Action = HtttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.links.Add(new HyperMediaLink()
            {
                Action = HtttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.links.Add(new HyperMediaLink()
            {
                Action = HtttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut
            });
            content.links.Add(new HyperMediaLink()
            {
                Action = HtttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });
            return Task.CompletedTask;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (this)
            {
                //var url = new { controler = path, id };
                var url = new { id };
                var absoluteUrl = urlHelper.Link("DefaultApi", url);
                absoluteUrl = new StringBuilder(absoluteUrl).Replace("%2F", "/").ToString();
                return absoluteUrl;
            }
        }
    }
}
