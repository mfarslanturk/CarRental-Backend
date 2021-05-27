using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public bool MainImage { get; set; } 

        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
