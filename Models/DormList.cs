using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ford_Hackhathon_YurtSistemi.Models
{
    public class DormList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }
        public int OccupancyRate { get; set; }
        public string Images { get; set; }

        // Bir yurdun birden fazla odası olabilir
        public ICollection<RoomList> RoomLists { get; set; }
    }
}
