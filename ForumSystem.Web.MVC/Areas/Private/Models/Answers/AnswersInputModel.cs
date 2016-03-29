﻿namespace ForumSystem.Web.MVC.Areas.Private.Models.Answers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mappings;
    using ForumSystem.Models;
    
    public class AnswersInputModel : IMapFrom<Answer>
    {
        public AnswersInputModel()
        {
        }

        public AnswersInputModel(int postId)
        {
            this.PostId = postId;
        }

        [Required]
        [StringLength(1000), MinLength(1)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public int PostId { get; set; }
    }
}