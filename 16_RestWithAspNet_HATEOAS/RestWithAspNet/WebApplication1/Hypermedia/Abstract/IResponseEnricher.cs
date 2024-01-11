using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithAspNet.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutedContext context);
        Task Enrich(ResultExecutedContext context);
    }
}
