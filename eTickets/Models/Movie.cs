using eTickets.Data;
using eTickets.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Movie : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Movie Image")]
        public string ImageURL { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        // Relationships
        public List<ActorMovie> ActorMovies { get; set; }

        // Cinema
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        // Producer
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
