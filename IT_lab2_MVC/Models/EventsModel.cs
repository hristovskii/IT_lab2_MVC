using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Location must be between 5 and 30 characters.")]
        public string Lokacija { get; set; }
    }
}