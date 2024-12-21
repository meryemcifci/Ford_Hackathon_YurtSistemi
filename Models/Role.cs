namespace Ford_Hackhathon_YurtSistemi.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; } // "admin" veya "kullanici"

        public ICollection<User> Users { get; set; }
        public ICollection<Admin> Admins { get; set; }

    }
}
