using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogMvcApp.DLL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(100)]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Required]
        [MinLength(2)]
        public string Author { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [Display(Name = "Genre of your article")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        //Добавлю сейчас 2 плохих жанра и миграцию где будет булевый Mood
        //После создам объект в Models, который будет содержать анкету
        //После формы буду получать этот объект и так-же 2 чекбокса и на основе их буду выдавать результаты анкеты
    }
}