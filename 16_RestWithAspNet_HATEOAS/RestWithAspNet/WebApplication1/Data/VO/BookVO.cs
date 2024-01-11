using RestWithAspNet.Hypermedia;
using RestWithAspNet.Hypermedia.Abstract;
using RestWithAspNet.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }

        public string Author { get; set; }

        public DateTime launchDate { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }

        public List<HyperMediaLink> links { get; set; } = new List<HyperMediaLink>();

    }
}
