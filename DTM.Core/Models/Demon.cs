using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DTM.Core.Models
{
    [Bind()]
    public partial class Demon
    {
        public Demon()
        {
            DemonPerso = new HashSet<DemonPerso>();
            PassifDemon = new HashSet<PassifDemon>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Nom { get; set; }

        public ICollection<DemonPerso> DemonPerso { get; set; }
        public ICollection<PassifDemon> PassifDemon { get; set; }
    }
}
