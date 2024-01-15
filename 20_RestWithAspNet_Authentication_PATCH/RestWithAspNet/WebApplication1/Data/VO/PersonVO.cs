using RestWithAspNet.Hypermedia;
using RestWithAspNet.Hypermedia.Abstract;

namespace RestWithAspNet.Data.VO
{
    public class PersonVO: ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        
        public bool Enabled { get; set; }

        public List<HyperMediaLink> links { get; set ; } = new List<HyperMediaLink>();
    }
}
