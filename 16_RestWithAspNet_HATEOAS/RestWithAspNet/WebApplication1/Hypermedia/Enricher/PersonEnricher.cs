using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Data.VO;
using RestWithAspNet.Hypermedia.Constant;
using System.Text;

namespace RestWithAspNet.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/person/v1";
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
            return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controler = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }
    }
}
