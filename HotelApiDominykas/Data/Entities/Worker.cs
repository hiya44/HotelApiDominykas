using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Data.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Sector { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
