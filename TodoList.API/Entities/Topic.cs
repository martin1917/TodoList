using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.API.Entities
{
    [Table("topics")]
    public class Topic
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        public List<Todo> Todos { get; set; } = new();
    }
}
