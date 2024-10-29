using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.API.Entities
{
    [Table("todos")]
    public class Todo
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("completed")]
        public bool Completed { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("deadline")]
        public DateTime Deadline { get; set; }

        [Column("topic_id")]
        public int TopicId { get; set; }

        public Topic? Topic { get; set; }
    }
}
