using RestWithAspNet.Hypermedia.Abstract;

namespace RestWithAspNet.Hypermedia.Filter
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
