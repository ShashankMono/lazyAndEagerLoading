using System.ComponentModel.DataAnnotations;

namespace LazyAndEagerLoading.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
