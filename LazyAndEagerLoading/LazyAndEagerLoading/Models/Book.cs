using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyAndEagerLoading.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public double price { get; set; }
        public virtual Author Author { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
    }
}
