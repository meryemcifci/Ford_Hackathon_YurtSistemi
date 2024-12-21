using Ford_Hackhathon_YurtSistemi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class YurtSistemiContext : DbContext
{
    public DbSet<DormList> DormLists { get; set; }
    public DbSet<RoomList> RoomLists { get; set; }
    public DbSet<StudentList> StudentLists { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }


    public YurtSistemiContext(DbContextOptions<YurtSistemiContext> options) : base(options)
    {
      
    }
 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-I5DH6I8\\MERYEMCIFCI;Database=DormSystem;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Rol için enum sınırlaması
        modelBuilder.Entity<Role>()
            .Property(y => y.RoleName)
            .HasConversion<string>()
            .HasMaxLength(20);

        // Oda - Yurt ilişkisi
        modelBuilder.Entity<RoomList>()
            .HasOne(o => o.DormList)
            .WithMany(y => y.RoomLists)
            .HasForeignKey(o => o.DormId);

        // Öğrenci - Oda ilişkisi
        modelBuilder.Entity<StudentList>()
            .HasOne(o => o.RoomList)
            .WithMany(od => od.StudentLists)
            .HasForeignKey(o => o.RoomId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
  

   

