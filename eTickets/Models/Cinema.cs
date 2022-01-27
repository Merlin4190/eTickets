using eTickets.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Cinema : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string Logo { get; set; }

        [Display(Name="Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        [StringLength(50, ErrorMessage = "Cinema name must not be longer than 50 characters")]
        public string Name { get; set; }

        [Display(Name ="Description")]
        [Required(ErrorMessage = "Cinema description is required")]
        public string Description { get; set; }

        // Relationships
        public List<Movie> Movies { get; set; }
    }
}
