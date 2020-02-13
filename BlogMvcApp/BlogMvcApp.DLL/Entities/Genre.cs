using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogMvcApp.DLL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Mood { get; set; } = false;
        public virtual ICollection<Article> Articles { get; set; }
    }
}
