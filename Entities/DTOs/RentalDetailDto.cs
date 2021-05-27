using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string UserName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
