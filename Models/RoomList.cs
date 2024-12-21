using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ford_Hackhathon_YurtSistemi.Models
{
    public class RoomList
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }
        public int OccupancyRate { get; set; }

        // Odanın bağlı olduğu yurt
        public int DormId { get; set; }
        public DormList DormList { get; set; }

        // Bir odada birden fazla öğrenci olabilir
        public ICollection<StudentList> StudentLists { get; set; }

    }
}
