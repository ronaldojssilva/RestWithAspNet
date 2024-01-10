using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet.Model
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
