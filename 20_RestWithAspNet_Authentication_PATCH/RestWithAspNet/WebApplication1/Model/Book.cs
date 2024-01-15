using RestWithAspNet.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet.Model
{
    [Table("books")]
    public class Book: BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime launchDate { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
