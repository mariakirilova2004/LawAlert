﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Infrastructure.Data.Entities
{
    public class Chapter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LawId { get; set; }

        [ForeignKey(nameof(LawId))]
        public Law? Law { get; set; }

        [Required]
        public virtual List<Article>? Articles { get; set; } = new List<Article>();
    }
}