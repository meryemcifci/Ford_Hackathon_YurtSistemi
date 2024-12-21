namespace Ford_Hackhathon_YurtSistemi.Models
{
    public class StudentList
    {
        public int Id { get; set; }
        public string TcNo {  get; set; }
        public string Name { get; set; }
        public string Surname {  get; set; }
        public string Telephone { get; set; }
        public string Images { get; set; }

        // Öğrencinin kaldığı oda
        public int? RoomId { get; set; }
        public RoomList RoomList{ get; set; }
    }
}
